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
        static Type sDefType = typeof(SDefEditor);

        public IntroDoc IntroDoc {get; }

        public StructureDefinition SDef => this.sDef;
        StructureDefinition baseSDef;
        StructureDefinition sDef;
        String basePath;
        String fragmentDir;
        String pageDir;

        Dictionary<String, ElementDefGroup> baseElements = new Dictionary<string, ElementDefGroup>();
        Dictionary<String, ElementDefGroup> elements = new Dictionary<string, ElementDefGroup>();
        List<ElementDefGroup> elementOrder = new List<ElementDefGroup>();

        /// <summary>
        /// Create structure definition editor
        /// </summary>
        public SDefEditor(String name,
            String url,
            String baseDefinition,
            String mapName,
            String fragmentDir,
            String pageDir)
        {
            this.fragmentDir = fragmentDir;
            this.pageDir = pageDir;
            this.baseSDef = FhirStructureDefinitions.Self.GetResource(baseDefinition);
            if (this.baseSDef == null)
                throw new Exception($"'Base definition resource {baseDefinition}' not found");

            this.basePath = baseDefinition.LastUriPart();

            for (Int32 i = 0; i < this.baseSDef.Snapshot.Element.Count; i++)
            {
                ElementDefinition elementDefinition = this.baseSDef.Snapshot.Element[i];
                ElementDefGroup e = new ElementDefGroup(i, elementDefinition, null);
                this.baseElements.Add(elementDefinition.ElementId.SkipFirstPathPart(), e);
            }

            this.sDef = new StructureDefinition
            {
                Name = name,
                Url = url,
                BaseDefinition = baseDefinition,
                Differential = new StructureDefinition.DifferentialComponent()
            };
            this.sDef.Differential.Element.Add(new ElementDefinition
            {
                Path = basePath,
                ElementId = basePath,
                Min = 0,
                Max = "*"
            });

            this.SDef.AddExtension(Global.ResourceMapNameUrl, new FhirString(mapName));

            this.IntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"StructureDefinition-{name}-intro.xml"));
            this.IntroDoc.AddSvgImage(this);
        }

        /// <summary>
        /// Inserts after the element with the indicated name, and any children of that element.
        /// </summary>
        public ElementDefGroup InsertAfter(ElementDefGroup at,
            ElementDefinition e)
        {
            return this.AddElementDefinition(at.Index, e, null);
        }

        /// <summary>
        /// Inserts after the element with the indicated name, and any children of that element.
        /// </summary>
        public ElementDefGroup InsertAfterAllChildren(String path,
            ElementDefinition insertItem)
        {
            if (this.baseElements.TryGetValue(path, out ElementDefGroup baseDefinition) == false)
                throw new Exception($"{path} not found");

            path = path + ".";
            Int32 i = this.elementOrder.Count;

            while ((i > 0) && (this.elementOrder[i - 1].Index > baseDefinition.Index))
                i -= 1;

            while (i < this.elementOrder.Count)
            {
                if (this.elementOrder[i].ElementDefinition.ElementId.SkipFirstPathPart().StartsWith(path) == false)
                    break;
                i += 1;
            }
            ElementDefGroup newE = new ElementDefGroup(baseDefinition.Index, 
                insertItem, 
                baseDefinition.ElementDefinition);
            this.elements.Add(insertItem.ElementId.SkipFirstPathPart(), newE);
            this.elementOrder.Insert(i, newE);
            return newE;
        }

        /// <summary>
        /// Select a element definition from the base sdef by its path name and 
        /// copy it to the differential of the output sdef.
        /// Note: Path is fhir path without the first element.
        /// ie. 'Observation.value[x]' is just 'value[x]'
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ElementDefGroup GetOrCreate(String path)
        {
            {
                if (this.elements.TryGetValue(path, out ElementDefGroup e) == true)
                    return e;
            }
            {
                if (this.baseElements.TryGetValue(path, out ElementDefGroup e) == true)
                {
                    ElementDefinition eBase = e.ElementDefinition;
                    ElementDefinition ed = new ElementDefinition
                    {
                        Path = eBase.Path,
                        ElementId = eBase.ElementId,
                        Min = eBase.Min,
                        Max = eBase.Max
                    };
                    return this.AddElementDefinition(e.Index, ed, e.ElementDefinition);
                }
            }
            throw new Exception($"'{path}' not found");
        }

        /// <summary>
        /// Insert element ordered by the index. If other items are already
        /// inserted witht his index, the new element will be inserted after them.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="elementDefinition"></param>
        /// <param name="baseDefinition"></param>
        ElementDefGroup AddElementDefinition(Int32 index,
            ElementDefinition elementDefinition,
            ElementDefinition baseDefinition)
        {
            ElementDefGroup newE = new ElementDefGroup(index, elementDefinition, baseDefinition);
            this.elements.Add(elementDefinition.ElementId.SkipFirstPathPart(), newE);
            Int32 i = this.elementOrder.Count;
            while ((i > 0) && (this.elementOrder[i - 1].Index > index))
                i -= 1;
            this.elementOrder.Insert(i, newE);
            return newE;
        }

        /// <summary>
        /// Select a element definition from the base sdef by its path name and 
        /// copy it to the differential of the output sdef.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ElementDefinition Select(String path)
        {
            return this.GetOrCreate(path).ElementDefinition;
        }

        public ElementDefinition Clone(String path)
        {
            if (this.baseElements.TryGetValue(path, out ElementDefGroup e) == false)
                throw new Exception($"{path} not found");
            ElementDefinition eBase = e.ElementDefinition;
            ElementDefinition ed = new ElementDefinition
            {
                Path = eBase.Path,
                ElementId = eBase.ElementId,
            };
            return ed;
        }

        public bool WriteFragment(out String fragmentName)
        {
            foreach (ElementDefGroup item in this.elementOrder)
                this.sDef.Differential.Element.Add(item.ElementDefinition);

            // Patch Path and Id's with correct basePath.
            foreach (ElementDefinition e in this.sDef.Differential.Element)
            {
                e.Path = e.Path.ReplacePathBase(this.basePath);
                e.ElementId = e.ElementId.ReplacePathBase(this.basePath);
            }

            fragmentName = Path.Combine(this.fragmentDir, $"StructureDefinition-{this.sDef.Name}.json");
            this.sDef.SaveJson(fragmentName);
            return true;
        }

        /// <summary>
        /// Configure the extension element to have the corret slicing discriminator. This does not
        /// add the slice, just the discriminator.
        /// </summary>
        void ConfigureExtensionSlice()
        {
            ElementDefinition extDef = this.Select("extension");
            // I assume that if slicing exists, it was added by the code below.
            // If someone else adds slicing differently than below there will be a problem....
            if (extDef.Slicing == null)
                extDef.ConfigureSliceByUrlDiscriminator();
        }

        public ElementDefinition ApplyExtension(String name, String extensionUrl, bool showChildren = true, bool addLink = true)
        {
            this.AddLink("target", extensionUrl, showChildren);
            this.ConfigureExtensionSlice();
            return this.SliceByUrl("extension", extensionUrl, name);
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
                description.Value += $"{descriptionHeader}\n\n";
                description.Value += value.Value;
                this.sDef.Description(description);
            }
            this.sDef.Differential.Element[0].Short = descriptionHeader;
            this.sDef.Differential.Element[0].Definition = value;
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

        public SDefEditor AddValueSetLink(ValueSet vs, bool showChildren = true)
        {
            this.AddLink("valueSet", vs.Url, showChildren);
            return this;
        }


        public SDefEditor AddProfileTargets(params ProfileTargetSlice[] targets)
        {
            foreach (ProfileTargetSlice target in targets)
                this.AddLink("target", target.Profile, false);
            return this;
        }

        public SDefEditor AddLink(String linkType,
            String url,
            bool showChildren)
        {
            if (url.StartsWith("http://hl7.org/fhir/StructureDefinition/") == true)
                return this;
            this.SDef.AddExtension(Global.ResourceMapLinkUrl,
                new FhirString($"{linkType}|{showChildren}|{url}"));
            return this;
        }

        public ElementDefinition AppendSlice(String elementName,
            String sliceName,
            Int32 min = 0,
            String max = "*")
        {
            ElementDefGroup elementDef = this.GetOrCreate(elementName);
            ElementDefinition retVal = new ElementDefinition
            {
                Path = elementDef.ElementDefinition.Path,
                ElementId = $"{elementDef.ElementDefinition.Path}:{sliceName}",
                SliceName = sliceName,
                Min = min,
                Max = max
            };
            if (elementDef.BaseElementDefinition != null)
            {
                retVal.Base = new ElementDefinition.BaseComponent
                {
                    Path = elementDef.BaseElementDefinition.Path,
                    Min = elementDef.BaseElementDefinition.Min,
                    Max = elementDef.BaseElementDefinition.Max
                };
            }
            this.InsertAfterAllChildren(elementName, retVal);
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
            ElementDefGroup elementDef = this.GetOrCreate(path);
            sliceName = sliceName.UncapFirstLetter();
            elementDef.ElementDefinition.Slicing = new ElementDefinition.SlicingComponent
            {
                Rules = ElementDefinition.SlicingRules.Open
            };

            elementDef.ElementDefinition.Slicing.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
            {
                Type = ElementDefinition.DiscriminatorType.Value,
                Path = "coding"
            });

            ElementDefinition coding = new ElementDefinition
            {
                ElementId = $"{elementDef.ElementDefinition.Path}.coding",
                Path = $"{elementDef.ElementDefinition.Path}.coding",
            };
            this.InsertAfterAllChildren(path, coding);

            ElementDefinition slice = new ElementDefinition
            {
                ElementId = $"{elementDef.ElementDefinition.Path}.coding:{sliceName}",
                Path = $"{elementDef.ElementDefinition.Path}.coding",
                SliceName = sliceName,
                Min = 1,
                Max = "1",
                Pattern = new Coding(system, code),
                Base = new ElementDefinition.BaseComponent
                {
                    Path = $"{elementDef.BaseElementDefinition.Path}",
                    Min = elementDef.BaseElementDefinition.Min,
                    Max = elementDef.BaseElementDefinition.Max
                }
            };
            this.InsertAfterAllChildren(path, slice);
            return slice;
        }


        /// <summary>
        /// Add the indicated slice by url.
        /// </summary>
        public ElementDefinition SliceByUrl(String elementName,
            String sliceUrl,
            String sliceName)
        {
            sliceName = sliceName.UncapFirstLetter();

            ElementDefinition extSlice = this.AppendSlice(elementName, sliceName);
            extSlice.IsModifier = false;
            extSlice.Type.Add(new ElementDefinition.TypeRefComponent
            {
                Code = "Extension",
                Profile = new String[] { sliceUrl }
            });
            return extSlice;
        }

        public void SliceByPatterns(String elementName,
            String typeCode,
            IEnumerable<PatternSlice> patternSlices)
        {
            ElementDefGroup elementDef = this.GetOrCreate(elementName);
            elementDef.ElementDefinition
                .ConfigureSliceByPatternDiscriminator("$this")
                .Type(typeCode)
                ;
            foreach (PatternSlice patternSlice in patternSlices)
            {
                ElementDefinition sliceElement = this.AppendSlice(elementName,
                        patternSlice.SliceName, 
                        patternSlice.Min, 
                        patternSlice.Max)
                    .Type("CodeableConcept")
                    .Pattern(patternSlice.Pattern)
                    .Short(patternSlice.Short)
                    .Definition(patternSlice.Definition)
                    .Type(typeCode);
                ;
                sliceElement.Mapping.Clear();
            }
        }

        public void SliceByUrl(String elementName,
            IEnumerable<ProfileTargetSlice> targets)
        {
            ElementDefGroup elementDef = this.GetOrCreate(elementName);
            elementDef.ElementDefinition.ConfigureSliceByUrlDiscriminator();
            foreach (ProfileTargetSlice target in targets)
            {
                String sliceName = target.Profile.LastUriPart().UncapFirstLetter();
                ElementDefinition sliceElement = this.AppendSlice(elementName, sliceName, target.Min, target.Max);
                sliceElement.Type.Clear();
                sliceElement.Type.Add(new ElementDefinition.TypeRefComponent
                {
                    Code = "Reference",
                    TargetProfile = new String[] { target.Profile }
                });
            }
        }

        public void AddIncompatibleFragment(String url)
        {
            this.SDef.AddExtension(Global.IncompatibleFragmentUrl, new FhirUrl(url));
        }

        public ElementDefGroup StartComponentSliceing()
        {
            ElementDefGroup component = this.GetOrCreate("component");

            component.ElementDefinition.Slicing = new ElementDefinition.SlicingComponent
            {
                Rules = ElementDefinition.SlicingRules.Open
            };

            component.ElementDefinition.Slicing.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
            {
                Type = ElementDefinition.DiscriminatorType.Pattern,
                Path = "code"
            });

            return component;
        }

        public void ComponentSliceQuantity(String sliceName,
            CodeableConcept pattern,
            Int32 minCardinality,
            String maxCardinality)
        {
            ElementDefinition slice = this.AppendSlice("component", sliceName, minCardinality, maxCardinality);
            {
                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.Path}.value[x]",
                    ElementId = $"{slice.Path}:{sliceName}.value[x]",
                    Min = 1,
                    Max = "1"
                };
                valueX
                    .Type("Quantity");
                ;
                this.InsertAfterAllChildren("component", valueX);
            }
            {
                ElementDefinition eDef = new ElementDefinition
                {
                    Path = $"{slice.Path}.interpretation",
                    ElementId = $"{slice.Path}:{sliceName}.interpretation",
                    Min = 0,
                    Max = "0"
                };
                this.InsertAfterAllChildren("component", eDef);
            }
            {
                ElementDefinition eDef = new ElementDefinition
                {
                    Path = $"{slice.Path}.referenceRange",
                    ElementId = $"{slice.Path}:{sliceName}.referenceRange",
                    Min = 0,
                    Max = "0"
                };
                this.InsertAfterAllChildren("component", eDef);
            }
        }

        public void ComponentSliceCodeableConcept(String sliceName,
            CodeableConcept pattern,
            String valueSetUrl,
            BindingStrength bindingStrength,
            Int32 minCardinality,
            String maxCardinality)
        {
            ElementDefinition slice = this.AppendSlice("component", sliceName, minCardinality, maxCardinality);
            {
                ElementDefinition componentCode = new ElementDefinition
                {
                    Path = $"{slice.Path}.code",
                    ElementId = $"{slice.Path}:{sliceName}.code",
                    Min = 1,
                    Max = "1"
                };
                componentCode
                    .Pattern(pattern)
                    ;
                this.InsertAfterAllChildren("component", componentCode);
            }
            {
                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.Path}.value[x]",
                    ElementId = $"{slice.Path}:{sliceName}.value[x]",
                    Min = 1,
                    Max = "1"
                };
                valueX
                    .Binding(valueSetUrl, bindingStrength)
                    .Type("CodeableConcept");
                ;
                this.InsertAfterAllChildren("component", valueX);
            }
            {
                ElementDefinition eDef = new ElementDefinition
                {
                    Path = $"{slice.Path}.interpretation",
                    ElementId = $"{slice.Path}:{sliceName}.interpretation",
                    Min = 0,
                    Max = "0"
                };
                this.InsertAfterAllChildren("component", eDef);
            }
            {
                ElementDefinition eDef = new ElementDefinition
                {
                    Path = $"{slice.Path}.referenceRange",
                    ElementId = $"{slice.Path}:{sliceName}.referenceRange",
                    Min = 0,
                    Max = "0"
                };
                this.InsertAfterAllChildren("component", eDef);
            }
        }
    }
}
