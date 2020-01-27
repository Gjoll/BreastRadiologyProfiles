﻿using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Newtonsoft.Json.Linq;
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
            return this.ConfigureSliceByUrlDiscriminator(extDef, overrideExistingSliceDiscriminator);
        }

        public ElementTreeNode ConfigureSliceByUrlDiscriminator(ElementTreeNode extDef, bool overrideExistingSliceDiscriminator)
        {
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

        public ElementTreeSlice ApplyExtension(String name,
            StructureDefinition sd,
            bool showChildren = true)
        {
            return ApplyExtension(name, sd.Url, showChildren);
        }

        public ElementTreeSlice ApplyExtension(ElementTreeNode extDef,
            String name,
            StructureDefinition sd)
        {
            return ApplyExtension(extDef, name, sd.Url);
        }

        public ElementTreeSlice ApplyExtension(String name,
        String extensionUrl,
        bool showChildren = true)
        {
            return this.ApplyExtension(this.Get("extension"), name, extensionUrl);
        }

        public ElementTreeSlice ApplyExtension(ElementTreeNode extDef,
            String name,
            String extensionUrl)
        {
            String sliceName = name.UncapFirstLetter();
            this.ConfigureSliceByUrlDiscriminator(extDef, true);


            ElementTreeSlice slice = extDef.CreateSlice(sliceName);
            slice.ElementDefinition.Min = 0;
            slice.ElementDefinition.Max = "*";

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
            return slice;
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
            if (sd.IsFragment() == false)
                throw new Exception("Expected a fragment");

            String fragRef = sd.Url;
            if (String.IsNullOrWhiteSpace(fragRef))
                throw new Exception($"Fragment Url must not be empty");
            this.SDef.Extension.Add(new Extension
            {
                Url = PreFhirGenerator.FragmentUrl,
                Value = new FhirUrl(fragRef)
            });

            dynamic packet = new JObject();
            packet.LinkType = "fragment";
            packet.ShowChildren = false;
            packet.LinkTarget = sd.Url;
            this.SDef.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));
            return this;
        }

        /// <summary>
        /// Keeps cardinality of element.
        /// Note: We keep a reference to the element, so if the cardinality is changed after
        /// this item is instantiated, we will get a current cardinality.
        /// </summary>
        public class Cardinality
        {
            ElementDefinition element;

            public Cardinality(ElementDefinition e)
            {
                this.element = e;
            }

            public override string ToString() => $"{element.Min}..{element.Max}";
        }

        public SDefEditor AddExtensionLink(String url,
            Cardinality cardinality,
            String localName,
            String componentRef,
            bool showChildren = true)
        {
            dynamic packet = new JObject();
            packet.LinkType = "extension";
            packet.ShowChildren = showChildren;
            packet.Cardinality = cardinality.ToString();
            packet.ComponentHRef = componentRef;
            packet.LocalName = localName;
            packet.LinkTarget = url;
            this.SDef.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));

            return this;
        }

        public SDefEditor AddComponentLinkTarget(String url,
            Cardinality cardinality,
            String componentRef,
            String types,
            String[] targets = null,
            bool showChildren = true)
        {
            dynamic packet = new JObject();
            packet.LinkType = "component";
            packet.ShowChildren = showChildren;
            packet.Cardinality = cardinality.ToString();
            packet.LinkTarget = url;
            packet.ComponentHRef = componentRef;
            packet.Types = types;
            if (targets != null)
                packet.References = new JArray(targets);
            packet.ReferenceType = "target";
            this.SDef.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));

            return this;
        }


        public SDefEditor AddComponentLinkVS(String url,
            Cardinality cardinality,
            String componentRef,
            String types,
            String vs = null,
            bool showChildren = true)
        {
            dynamic packet = new JObject();
            packet.LinkType = "component";
            packet.ShowChildren = showChildren;
            packet.Cardinality = cardinality.ToString();
            packet.LinkTarget = url;
            packet.ComponentHRef = componentRef;
            packet.Types = types;
            if (vs != null)
                packet.References = new JArray(new String[] { vs });
            packet.ReferenceType = "valueSet";
            this.SDef.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));

            return this;
        }

        public SDefEditor AddTargetLink(String url, Cardinality cardinality, bool showChildren = true)
        {

            dynamic packet = new JObject();
            packet.LinkType = "target";
            packet.ShowChildren = showChildren;
            packet.Cardinality = cardinality.ToString();
            packet.LinkTarget = url;
            this.SDef.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));
            return this;
        }

        public SDefEditor AddValueSetLink(ValueSet vs, bool showChildren = true)
        {
            dynamic packet = new JObject();
            packet.LinkType = "valueSet";
            packet.ShowChildren = showChildren;
            packet.LinkTarget = vs.Url;
            this.SDef.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));

            return this;
        }

        ElementTreeSlice AppendSlice(String elementName,
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

        public ElementDefinition SliceSelfByPattern(String path,
            String sliceName,
            Element pattern)
        {
            sliceName = sliceName.UncapFirstLetter();
            ElementDefinition.SlicingComponent slicing = new ElementDefinition.SlicingComponent
            {
                Rules = ElementDefinition.SlicingRules.Open
            };

            slicing.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
            {
                Type = ElementDefinition.DiscriminatorType.Pattern,
                Path = "$this"
            });
            ElementTreeNode elementDef = this.Get(path);
            elementDef.ApplySlicing(slicing, false);

            ElementTreeSlice codingSlice = elementDef.CreateSlice(sliceName);

            codingSlice.ElementDefinition.Pattern = pattern;
            return codingSlice.ElementDefinition;
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
                    .Binding(valueSet, bindingStrength)
                    .Type("CodeableConcept")
                    .SetDefinition(new Markdown()
                        .Paragraph("Value is a codeable concept.")
                     )
                ;
                slice.CreateNode(valueX);
            }

            String componentRef = Global.ElementAnchor(slice.ElementDefinition);
            this.AddComponentLinkVS(componentName,
                new SDefEditor.Cardinality(slice.ElementDefinition),
                componentRef,
                "CodeableConcept",
                valueSet.Url);
        }

        public void SliceComponentCode(ElementTreeSlice slice,
            String sliceName,
            CodeableConcept sliceCode)
        {
            ElementDefinition componentCode = new ElementDefinition
            {
                Path = $"{slice.ElementDefinition.Path}.code",
                ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.code",
                Min = 1,
                Max = "1"
            };
            componentCode.Pattern(sliceCode);
            slice.CreateNode(componentCode);
        }

        public ElementTreeNode SliceValueXByType(ElementTreeSlice slice,
            String sliceName,
            String[] types)
        {
            ElementDefinition valueX = new ElementDefinition
            {
                Path = $"{slice.ElementDefinition.Path}.value[x]",
                ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]",
                Min = 1,
                Max = "1"
            };
            valueX
                .Types(types)
                ;

            ElementDefinition.SlicingComponent slicingComponent = new ElementDefinition.SlicingComponent
            {
                Rules = ElementDefinition.SlicingRules.Closed
            };

            slicingComponent.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
            {
                Type = ElementDefinition.DiscriminatorType.Type,
                Path = "$this"
            });

            valueX.ApplySlicing(slicingComponent, false);

            return slice.CreateNode(valueX);
        }


        public ElementTreeSlice SliceTargetReference(ElementTreeNode sliceElementDef,
            StructureDefinition profile,
            Int32 min = 0,
            String max = "*")
        {
            String baseName = sliceElementDef.ElementDefinition.Path.LastPathPart();
            ElementTreeSlice retVal = this.SliceByUrlTarget(sliceElementDef, profile.Url, min, max);
            retVal.ElementDefinition
                .SetShort($"'{profile.Title}' reference")
                .SetDefinition(
                    new Markdown($"This slice references the target '{profile.Title}'")
                    )
            ;
            this.AddTargetLink(profile.Url.Trim(),
                new SDefEditor.Cardinality(retVal.ElementDefinition),
                false);

            return retVal;
        }

        public void SliceTargetReference(ElementTreeNode sliceElementDef,
            StructureDefinition profile,
            Modalities modalities,
            Int32 min = 0,
            String max = "*")
        {
            String baseName = sliceElementDef.ElementDefinition.Path.LastPathPart();
            ElementDefinition sliceDef = this.SliceByUrlTarget(sliceElementDef, profile.Url, min, max).ElementDefinition
                .SetShort($"'{profile.Title}' reference")
                .SetDefinition(
                    new Markdown($"This slice references the target '{profile.Title}'")
                    .ValidModalities(Modalities.MG)
                    )
            ;
            this.AddTargetLink(profile.Url,
                new SDefEditor.Cardinality(sliceDef),
                false);
        }

        public void SliceComponentSize(String sliceName,
            CodeableConcept componentCode,
            ValueSet units,
            out ElementTreeSlice slice)
        {
            this.StartComponentSliceing();

            slice = this.AppendSlice("component", sliceName, 0, "1");

            // Fix component code
            this.SliceComponentCode(slice, sliceName, componentCode);
            ElementTreeNode valueXNode = this.SliceValueXByType(slice,
                sliceName,
                new string[] { "Quantity", "Range" });
            {
                Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                {
                    System = units.Url
                };

                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:valueQuantity",
                    SliceName = $"valueQuantity",
                    Min = 0,
                    Max = "1"
                }
                .Pattern(q)
                .Type("Quantity")
                ;
                valueXNode.CreateSlice($"valueQuantity", valueX);
            }

            {
                Hl7.Fhir.Model.Range r = new Hl7.Fhir.Model.Range
                {
                    Low = new SimpleQuantity
                    {
                        System = units.Url,
                    },
                    High = new SimpleQuantity
                    {
                        System = units.Url,
                    }
                };
                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:valueRange",
                    SliceName = $"valueRange",
                    Min = 0,
                    Max = "1"
                }
                .Pattern(r)
                .Type("Range")
                ;
                valueXNode.CreateSlice($"{sliceName}/range", valueX);
            }
        }






        public void SliceComponentCount(String sliceName,
            CodeableConcept componentCode,
            out ElementTreeSlice slice)
        {
            this.StartComponentSliceing();

            slice = this.AppendSlice("component", sliceName, 0, "1");

            // Fix component code
            this.SliceComponentCode(slice, sliceName, componentCode);
            ElementTreeNode valueXNode = this.SliceValueXByType(slice,
                sliceName,
                new string[] { "Quantity", "Range" });

            {
                Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                {
                    System = "http://unitsofmeasure.org",
                    Code = "tot"
                };

                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:valueQuantity",
                    SliceName = $"valueQuantity",
                    Min = 0,
                    Max = "1"
                }
                .Pattern(q)
                .Type("Quantity")
                ;
                valueXNode.CreateSlice($"valueQuantity", valueX);
            }

            {
                Hl7.Fhir.Model.Range r = new Hl7.Fhir.Model.Range
                {
                    Low = new SimpleQuantity
                    {
                        System = "http://unitsofmeasure.org",
                        Code = "tot"
                    },
                    High = new SimpleQuantity
                    {
                        System = "http://unitsofmeasure.org",
                        Code = "tot"
                    }
                };
                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:valueRange",
                    SliceName = $"valueRange",
                    Min = 0,
                    Max = "1"
                }
                .Pattern(r)
                .Type("Range")
                ;
                valueXNode.CreateSlice($"{sliceName}/range", valueX);
            }
        }
    }
}
