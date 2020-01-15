using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    class SDefEditor
    {
        public StructureDefinition SDef => this.sDef;
        StructureDefinition baseSDef;
        StructureDefinition sDef;
        String basePath;
        String fragmentDir;
        String pageDir;
        ElementTreeNode snapNode;
        ElementTreeNode snapNodeOriginal;
        IConversionInfo info;
        public IntroDoc IntroDoc { get; set; }

        /// <summary>
        /// Create structure definition editor
        /// </summary>
        public SDefEditor(IConversionInfo info,
            String name,
            String url,
            String baseDefinition,
            String mapName,
            String fragmentDir,
            String pageDir)
        {
            this.info = info;
            this.fragmentDir = fragmentDir;
            this.pageDir = pageDir;
            this.baseSDef = FhirStructureDefinitions.Self.GetResource(baseDefinition);
            if (this.baseSDef == null)
                throw new Exception($"'Base definition resource {baseDefinition}' not found");

            this.basePath = baseDefinition.LastUriPart();

            {
                ElementTreeLoader l = new ElementTreeLoader();
                this.snapNode = l.Create(this.baseSDef.Snapshot.Element);
                this.snapNodeOriginal = this.snapNode.Clone();
            }

            this.sDef = new StructureDefinition
            {
                Name = name,
                Url = url,
                BaseDefinition = baseDefinition,
                Differential = new StructureDefinition.DifferentialComponent()
            };

            this.SDef.AddExtension(Global.ResourceMapNameUrl, new FhirString(mapName));
        }

        /// <summary>
        /// Inserts after the element with the indicated name, and any children of that element.
        /// </summary>
        //public ElementDefGroup InsertAfter(ElementDefGroup at,
        //    ElementDefinition e)
        //{
        //    return this.AddElementDefinition(at.Index, e, null);
        //}

        /// <summary>
        /// Inserts after the element with the indicated name, and any children of that element.
        /// </summary>
        //public ElementDefGroup InsertAfterAllChildren(String path,
        //    ElementDefinition insertItem)
        //{
        //    if (this.baseElements.TryGetValue(path, out ElementDefGroup baseDefinition) == false)
        //        throw new Exception($"{path} not found");

        //    path = path + ".";
        //    Int32 i = this.elementOrder.Count;

        //    while ((i > 0) && (this.elementOrder[i - 1].Index > baseDefinition.Index))
        //        i -= 1;

        //    while (i < this.elementOrder.Count)
        //    {
        //        if (this.elementOrder[i].ElementDefinition.ElementId.SkipFirstPathPart().StartsWith(path) == false)
        //            break;
        //        i += 1;
        //    }
        //    ElementDefGroup newE = new ElementDefGroup(baseDefinition.Index,
        //        insertItem,
        //        baseDefinition.ElementDefinition);
        //    this.elements.Add(insertItem.ElementId.SkipFirstPathPart(), newE);
        //    this.elementOrder.Insert(i, newE);
        //    return newE;
        //}

        /// <summary>
        /// Select a element definition from the base sdef by its path name and 
        /// copy it to the differential of the output sdef.
        /// Note: Path is fhir path without the first element.
        /// ie. 'Observation.value[x]' is just 'value[x]'
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ElementTreeNode Get(String path)
        {
            // Note: First part is ignored, but has to be present.
            String tPath = $"Observation.{path}";
            if (this.snapNode.TryGetElementNode(tPath, out ElementTreeNode retVal) == true)
                return retVal;
            throw new Exception($"'{path}' not found");
        }

        /// <summary>
        /// Select a element definition from the base sdef by its path name and 
        /// copy it to the differential of the output sdef.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ElementDefinition Select(String path)
        {
            return this.Get(path).ElementDefinition;
        }

        public ElementDefinition Clone(String path)
        {
            ElementTreeNode node = this.Get(path);
            return (ElementDefinition)node.ElementDefinition.DeepCopy();
        }

        public bool WriteFragment(out String fragmentName)
        {
            fragmentName = null;

            this.sDef.Snapshot = null;

            // Create differential by comparing current snapshot with original.
            ElementTreeNode differentialNode = this.snapNode.Clone();
            {
                ElementTreeDiffer differ = new ElementTreeDiffer(this.info);
                if (differ.Process(this.snapNodeOriginal, differentialNode) == false)
                    return false;
            }
            {
                ElementTreeSetBase setBase = new ElementTreeSetBase(this.info);
                if (setBase.Process(this.snapNodeOriginal, differentialNode) == false)
                    return false;
            }

            // Patch Path and Id's with correct basePath.
            differentialNode.ReplaceBasePath(this.basePath);

            {
                List<ElementDefinition> elementDefinitions = new List<ElementDefinition>();
                differentialNode.CopyTo(elementDefinitions);
                sDef.Differential.Element = elementDefinitions;
            }

            fragmentName = Path.Combine(this.fragmentDir, $"StructureDefinition-{this.sDef.Name}.json");
            this.sDef.SaveJson(fragmentName);
            return true;
        }

        public ElementTreeNode ConfigureSliceByUrlDiscriminator(String path, bool overrideExistingSliceDiscriminator)
        {
            ElementTreeNode extDef = this.Get(path);

            ElementDefinition.SlicingComponent slicingComponent = new ElementDefinition.SlicingComponent
            {
                Ordered = true,
                Rules = ElementDefinition.SlicingRules.OpenAtEnd
            };

            slicingComponent.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
            {
                Type = ElementDefinition.DiscriminatorType.Value,
                Path = "url"
            });

            extDef.ApplySlicing(slicingComponent, overrideExistingSliceDiscriminator);
            return extDef;
        }

        public ElementDefinition ApplyExtension(String name,
            StructureDefinition sd,
            bool showChildren = true)
        {
            return ApplyExtension(name, sd.Url, showChildren);
        }

        public ElementDefinition ApplyExtension(String name,
        String extensionUrl,
        bool showChildren = true)
        {
            this.AddExtensionLink(extensionUrl, showChildren);
            this.ConfigureSliceByUrlDiscriminator("extension", true);

            String sliceName = name.UncapFirstLetter();

            ElementTreeSlice slice = this.AppendSlice("extension", sliceName);
            slice.ElementDefinition
                .SetShort($"{name} extension")
                .SetDefinition(new Markdown($"This extension slice contains the {name} extension"))
                .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                ;

            slice.ElementDefinition.IsModifier = false;
            slice.ElementDefinition.Type.Add(new ElementDefinition.TypeRefComponent
            {
                Code = "Extension",
                Profile = new String[] { extensionUrl }
            });
            return slice.ElementDefinition;
        }

        /// <summary>
        /// Sets the .Description field, and also sets the ElementDefinition.Short and .Description fields
        /// of the first element definition.
        /// </summary>
        /// <param name="descriptionHeader"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public SDefEditor Description(String descriptionHeader, Markdown value)
        {
            {
                Markdown description = new Markdown();
                description.Value += $"<b>{descriptionHeader}</b>\n\n";
                description.Value += value.Value;
                this.sDef.Description(description);
            }

            this.snapNode.ElementDefinition.Short = descriptionHeader;
            this.snapNode.ElementDefinition.Definition = value;
            return this;
        }

        public SDefEditor ContactUrl(String value) { this.sDef.ContactUrl(value); return this; }
        public SDefEditor Publisher(String value) { this.sDef.Publisher(value); return this; }
        public SDefEditor Title(String value) { this.sDef.Title(value); return this; }
        public SDefEditor Status(PublicationStatus? value) { this.sDef.Status(value); return this; }
        public SDefEditor Date(FhirDateTime value) { this.sDef.Date(value); return this; }
        public SDefEditor Derivation(StructureDefinition.TypeDerivationRule? value) { this.sDef.Derivation(value); return this; }
        public SDefEditor Abstract(bool? value) { this.sDef.Abstract(value); return this; }
        public SDefEditor Kind(StructureDefinition.StructureDefinitionKind? value) { this.sDef.Kind(value); return this; }
        public SDefEditor Version(String value) { this.sDef.Version(value); return this; }
        public SDefEditor Type(String value) { this.sDef.Type(value); return this; }
        public SDefEditor Context(StructureDefinition.ExtensionContextType type = StructureDefinition.ExtensionContextType.Element,
            String expression = "*")
        {
            this.sDef.Context(type, expression);
            return this;
        }

        public SDefEditor SetIsFrag()
        {
            this.SDef.Extension.Add(new Extension
            {
                Url = PreFhirGenerator.IsFragmentUrl,
                Value = new FhirBoolean(true)
            });
            return this;
        }

        public SDefEditor AddFragRef(StructureDefinition sd)
        {
            return AddFragRef(sd.Url);
        }

        public SDefEditor AddFragRef(String fragRef)
        {
            if (String.IsNullOrWhiteSpace(fragRef))
                throw new Exception($"Fragment Url must not be empty");
            this.SDef.Extension.Add(new Extension
            {
                Url = PreFhirGenerator.FragmentUrl,
                Value = new FhirUrl(fragRef)
            });
            this.AddFragmentLink(fragRef);
            return this;
        }


        public SDefEditor AddFragmentLink(String url, bool showChildren = true)
        {
            this.AddLink("fragment", url, showChildren);
            return this;
        }

        public SDefEditor AddExtensionLink(String url, bool showChildren = true)
        {
            this.AddLink("extension", url, showChildren);
            return this;
        }

        public SDefEditor AddComponentLink(String url, bool showChildren = true)
        {
            this.AddLink("component", url, showChildren);
            return this;
        }

        public SDefEditor AddTargetLink(String url, bool showChildren = true)
        {
            this.AddLink("target", url, showChildren);
            return this;
        }

        public SDefEditor AddValueSetLink(ValueSet vs, bool showChildren = true)
        {
            this.AddLink("valueSet", vs.Url, showChildren);
            return this;
        }

        public SDefEditor AddLink(String linkType,
            String url,
            bool showChildren)
        {
            this.SDef.AddExtension(Global.ResourceMapLinkUrl,
                new FhirString($"{linkType}|{showChildren}|{url}"));
            return this;
        }

        public ElementTreeSlice AppendSlice(String elementName,
            String sliceName,
            Int32 min = 0,
            String max = "*")
        {
            ElementTreeNode elementDef = this.Get(elementName);
            ElementTreeSlice retVal = elementDef.CreateSlice(sliceName);
            retVal.ElementDefinition.Min = min;
            retVal.ElementDefinition.Max = max;
            return retVal;
        }

        /// <summary>
        /// Add the indicated slice by url.
        /// </summary>
        public ElementDefinition FixedCodeSlice(String path,
            String sliceName,
            String system,
            String code)
        {
            sliceName = sliceName.UncapFirstLetter();
            ElementDefinition.SlicingComponent slicing = new ElementDefinition.SlicingComponent
            {
                Rules = ElementDefinition.SlicingRules.Open
            };

            slicing.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
            {
                Type = ElementDefinition.DiscriminatorType.Value,
                Path = "coding"
            });
            ElementTreeNode elementDef = this.Get(path);
            elementDef.ApplySlicing(slicing, false);

            ElementDefinition coding = new ElementDefinition
            {
                ElementId = $"{elementDef.ElementDefinition.Path}.coding",
                Path = $"{elementDef.ElementDefinition.Path}.coding",
            };

            ElementTreeNode codingNode = elementDef.DefaultSlice.CreateNode(coding);
            ElementTreeSlice codingSlice = codingNode.CreateSlice(sliceName);

            codingSlice.ElementDefinition
                .SetCardinality(1, "1")
                ;

            codingSlice.ElementDefinition.Pattern = new Coding(system, code);
            return codingSlice.ElementDefinition;
        }

        public void SliceByPatterns(String elementName,
            String typeCode,
            IEnumerable<PatternSlice> patternSlices)
        {
            ElementTreeNode elementDef = this.ConfigureSliceByUrlDiscriminator(elementName, false);
            elementDef.ElementDefinition
                .Type(typeCode)
                ;
            foreach (PatternSlice patternSlice in patternSlices)
            {
                ElementTreeSlice slice = elementDef.CreateSlice(patternSlice.SliceName);
                slice.ElementDefinition
                    .SetCardinality(patternSlice.Min, patternSlice.Max)
                    .Type("CodeableConcept")
                    .Pattern(patternSlice.Pattern)
                    .Short(patternSlice.ShortDefinition)
                    .Definition(patternSlice.Definition)
                    .Type(typeCode);
                ;
                slice.ElementDefinition.Mapping.Clear();
            }
        }

        public ElementTreeSlice SliceByUrlTarget(ElementTreeNode sliceElementDef,
            String profileUrl,
            Int32 min,
            String max)
        {
            String sliceName = profileUrl.LastUriPart().UncapFirstLetter();
            ElementTreeSlice slice = sliceElementDef.CreateSlice(sliceName);
            slice.ElementDefinition.SetCardinality(min, max);
            slice.ElementDefinition.Type.Clear();
            slice.ElementDefinition.Type.Add(new ElementDefinition.TypeRefComponent
            {
                Code = "Reference",
                TargetProfile = new String[] { profileUrl }
            });
            return slice;
        }

        public void AddIncompatibleFragment(String url)
        {
            this.SDef.AddExtension(Global.IncompatibleFragmentUrl, new FhirUrl(url));
        }

        public void StartComponentSliceing()
        {
            ElementTreeNode componentNode = this.Get("component");

            ElementDefinition.SlicingComponent slicingComponent = new ElementDefinition.SlicingComponent
            {
                Rules = ElementDefinition.SlicingRules.Open
            };

            slicingComponent.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
            {
                Type = ElementDefinition.DiscriminatorType.Pattern,
                Path = "code"
            });

            componentNode.ApplySlicing(slicingComponent, false);
        }

        public void StartComponentTypeSlicing(ElementTreeSlice parentSlice,
            String type)
        {
            ElementDefinition.SlicingComponent slicingComponent = new ElementDefinition.SlicingComponent
            {
                Rules = ElementDefinition.SlicingRules.Closed
            };

            slicingComponent.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
            {
                Type = ElementDefinition.DiscriminatorType.Type,
                Path = "value[x]"
            });

            parentSlice.ElementDefinition.ApplySlicing(slicingComponent, false);
        }


        public void ComponentSliceQuantity(String sliceName,
            CodeableConcept pattern,
            Int32 minCardinality,
            String maxCardinality,
            String componentName)
        {
            {
                ElementTreeSlice slice = this.AppendSlice("component", sliceName, minCardinality, maxCardinality);
                slice.ElementDefinition
                    .SetShort($"{componentName} component")
                    .SetDefinition(new Markdown($"This component slice contains the {componentName} quantity"))
                    .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                    ;

                {
                    ElementDefinition componentCode = new ElementDefinition
                    {
                        Path = $"{slice.ElementDefinition.Path}.code",
                        ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.code",
                        Min = 1,
                        Max = "1"
                    };
                    componentCode
                        .Pattern(pattern)
                        ;
                    slice.CreateNode(componentCode);
                }
                {
                    ElementDefinition valueX = new ElementDefinition
                    {
                        Path = $"{slice.ElementDefinition.Path}.value[x]",
                        ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]",
                        Min = 1,
                        Max = "1"
                    };
                    valueX
                        .Type("Quantity");
                    ;
                    slice.CreateNode(valueX);
                }
            }
            this.AddComponentLink($"{componentName}^Quantity");
        }

        [Obsolete]
        public void ComponentSliceCodeableConcept(String sliceName,
            CodeableConcept pattern,
            ValueSet valueSet,
            BindingStrength bindingStrength,
            Int32 minCardinality,
            String maxCardinality,
            String componentName,
            Modalities modalities = Modalities.All)
        {
            String compStr = maxCardinality == "1" ? compStr = "component" : "components";
            String valueStr = maxCardinality == "1" ? compStr = "value" : "values";

            ComponentSliceCodeableConcept(sliceName, 
                pattern, 
                valueSet, 
                bindingStrength, 
                minCardinality, 
                maxCardinality, 
                componentName,
                new Markdown($"This component slice contains the {componentName} {valueStr}"),
                modalities);
        }

        public void ComponentSliceCodeableConcept(String sliceName,
                CodeableConcept pattern,
                ValueSet valueSet,
                BindingStrength bindingStrength,
                Int32 minCardinality,
                String maxCardinality,
                String componentName,
                Markdown sliceDefinition,
                Modalities modalities = Modalities.All)
        {
            String compStr = maxCardinality == "1" ? compStr = "component" : "components";

            ElementTreeSlice slice = this.AppendSlice("component", sliceName, minCardinality, maxCardinality);
            slice.ElementDefinition
                .SetShort($"{componentName} component")
                .SetDefinition(sliceDefinition)
                .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                ;

            if (modalities != Modalities.All)
            {
                slice.ElementDefinition.Definition
                    .ValidModalities(modalities);
            }

            {
                ElementDefinition componentCode = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.code",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.code",
                    Min = 1,
                    Max = "1",
                    Short = $"{componentName} component code",
                    Definition = new Markdown($"This code identifies the {componentName} {compStr}")
                };
                componentCode
                    .Pattern(pattern)
                    ;
                slice.CreateNode(componentCode);
            }
            {
                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]",
                    Min = 1,
                    Max = "1",
                    Short = $"{componentName} component value",
                };
                valueX
                    .Binding(valueSet.Url, bindingStrength)
                    .Type("CodeableConcept")
                    .SetDefinition(new Markdown()
                        .Paragraph("Value si a codeable concept.")
                     )
                ;
                slice.CreateNode(valueX);
            }

            this.AddComponentLink($"{componentName}^CodeableConcept^{valueSet.Url}");
        }
    }
}
