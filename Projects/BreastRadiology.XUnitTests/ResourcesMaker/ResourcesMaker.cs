using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        class Definition
        {
            StringBuilder sb = new StringBuilder();
            //bool citeFlag = false;

            public Definition CiteStart()
            {
                return this;
            }

            public Definition CiteEnd(String citationSource)
            {
                this.sb.AppendLine($"    -- {citationSource}");
                return this;
            }

            public Definition Line(String line)
            {
                this.sb.AppendLine(line);
                return this;
            }

            public Definition ValidModalities(Modalities modalities)
            {
                void Add(Modalities flag)
                {
                    if ((modalities & flag) == flag)
                        this.sb.Append($" {flag.ToString()}");
                }

                this.sb.Append("Valid for the following modalities:");
                Add(Modalities.MG);
                Add(Modalities.US);
                Add(Modalities.MRI);
                Add(Modalities.NM);
                this.sb.AppendLine(".");
                return this;
            }

            public String ToText()
            {
                return this.sb.ToString();
            }
        }

        class ConceptDef
        {
            public String Code;
            public String Display;
            public String Definition;

            public ConceptDef(String code, String display, String definition)
            {
                if (String.IsNullOrWhiteSpace(code) == true)
                    throw new Exception("Empty code");
                if (String.IsNullOrWhiteSpace(display) == true)
                    throw new Exception("Empty Display");
                if (String.IsNullOrWhiteSpace(definition) == true)
                    throw new Exception("Empty definition");
                this.Code = code;
                this.Display = display;
                this.Definition = definition;
            }

            public ConceptDef(Coding code, String definition)
            {
                this.Code = code.Code;
                this.Display = code.Display;
                this.Definition = definition;
            }

            public ConceptDef(String code, String display, Definition definition) : this(code, display, definition.ToText())
            {
            }
        }

        public static ResourcesMaker Self { get; set; }

        public const String Group_BaseResources = "BaseResources";
        public const String Group_CommonResources = "CommonResources";
        public const String Group_CommonCodesCS = "CommonCodesCS";
        public const String Group_CommonCodesVS = "CommonCodesVS";

        public const String Group_Fragments = "Fragments";

        public const String Group_AimResources = "AimResources";
        public const String Group_AimCodesCS = "AimCodesCS";
        public const String Group_AimCodesVS = "AimCodesVS";

        public const String Group_MGResources = "MGResources";
        public const String Group_MGCodesVS = "MGCodesVS";
        public const String Group_MGCodesCS = "MGCodesCS";

        public const String Group_MRIResources = "MRIResources";
        public const String Group_MRICodesVS = "MRICodesVS";
        public const String Group_MRICodesCS = "MRICodesCS";

        public const String Group_NMResources = "NMResources";
        public const String Group_NMCodesVS = "NMCodesVS";
        public const String Group_NMCodesCS = "NMCodesCS";

        public const String Group_USResources = "USResources";
        public const String Group_USCodesVS = "USCodesVS";
        public const String Group_USCodesCS = "USCodesCS";

        public const String Group_ExtensionResources = "ExtensionResources";

        public static String BiRadCitation = "Bi-Rads� Atlas � Mammography Fifth Ed. 2013";
        //#const FHIRVersion FVersion = FHIRVersion.N4_0_0;

        const String ProfileVersion = "0.0.2";
        const PublicationStatus ProfileStatus = PublicationStatus.Draft;

        const String Loinc = "http://loinc.org";
        const String Snomed = "http://snomed.info/sct";

        public const String ClinicalImpressionUrl = "http://hl7.org/fhir/StructureDefinition/ClinicalImpression";
        public const String DiagnosticReportUrl = "http://hl7.org/fhir/StructureDefinition/DiagnosticReport";
        public const String DomainResourceUrl = "http://hl7.org/fhir/StructureDefinition/DomainResource";
        public const String ExtensionUrl = "http://hl7.org/fhir/StructureDefinition/Extension";
        public const String ImagingStudyUrl = "http://hl7.org/fhir/StructureDefinition/ImagingStudy";
        public const String MedicationRequestUrl = "http://hl7.org/fhir/StructureDefinition/MedicationRequest";
        public const String ObservationUrl = "http://hl7.org/fhir/StructureDefinition/Observation";
        public const String ResourceUrl = "http://hl7.org/fhir/StructureDefinition/Resource";
        public const String RiskAssessmentUrl = "http://hl7.org/fhir/StructureDefinition/RiskAssessment";
        public const String ServiceRequestUrl = "http://hl7.org/fhir/StructureDefinition/ServiceRequest";

        public const String contactUrl = "http://www.hl7.org/Special/committees/cic";

        Dictionary<String, Resource> resources = new Dictionary<string, Resource>();

        FileCleaner fc;
        String resourceDir;
        String pageDir;
        FhirDateTime date = new FhirDateTime(2019, 11, 1);
        public Dictionary<String, SDefEditor> Editors = new Dictionary<String, SDefEditor>();

        public static String CreateUrl(String name)
        {
            return $"http://hl7.org/fhir/us/breast-radiology/StructureDefinition/{name}";
        }

        public ResourcesMaker(FileCleaner fc,
            String resourceDir,
            String pageDir,
            String cacheDir)
        {
            const String fcn = "ResourcesMaker";

            Self = this;
            this.fc = fc;
            this.resourceDir = resourceDir;
            this.pageDir = pageDir;

            if (Directory.Exists(this.resourceDir) == false)
                Directory.CreateDirectory(this.resourceDir);

            if (Directory.Exists(this.pageDir) == false)
                Directory.CreateDirectory(this.pageDir);

            if (FhirStructureDefinitions.Self == null)
            {
                this.ConversionInfo(this.GetType().Name, fcn, $"Init'g 'FhirStructureDefinitions'");
                FhirStructureDefinitions.Create(cacheDir);
            }
        }

        SDefEditor CreateEditor(String name,
            String title,
            String mapName,
            String baseDefinition,
            String groupPath)
        {
            if (name.Contains(" ", new StringComparison()))
                throw new Exception("Structure Def name can not contains spaces");

            title = title.Trim();
            SDefEditor retVal = new SDefEditor(this, name, CreateUrl(name), baseDefinition, mapName, this.resourceDir, this.pageDir)
                .Title(title)
                .Derivation(StructureDefinition.TypeDerivationRule.Constraint)
                .Abstract(false)
                .Type(baseDefinition.LastUriPart())
                .Kind(StructureDefinition.StructureDefinitionKind.Resource)
                .Status(PublicationStatus.Draft)
                ;

            retVal.SDef.FhirVersion = FHIRVersion.N4_0_0;

            this.Editors.Add(retVal.SDef.Url, retVal);

            // store groupPath as an extension. This is an unregistered extension that will be removed before
            // processing is complete.
            retVal.SDef.Extension.Add(new Extension
            {
                Url = Global.GroupExtensionUrl,
                Value = new FhirString(groupPath)
            });

            return retVal;
        }

        String Article(String title)
        {
            switch (Char.ToLower(title[0]))
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    return "an";

                default:
                    return "a";
            }
        }

        SDefEditor CreateEditor(String name,
            String title,
            String mapName,
            String baseDefinition,
            String groupPath,
            String docTemplateName)
        {
            title = title.Trim();
            SDefEditor retVal = CreateEditor(name, title, mapName, baseDefinition, groupPath);

            retVal.IntroDoc = new IntroDoc();
            retVal.IntroDoc.TryAddUserMacro("FocusPath", FocusMapMaker.FocusMapName(retVal.SDef.Url.LastUriPart()));
            retVal.IntroDoc.TryAddUserMacro("TitleArticle", Article(title));
            retVal.IntroDoc.TryAddUserMacro("Title", title);
            retVal.IntroDoc.Load(docTemplateName, Path.Combine(this.pageDir, $"StructureDefinition-{name}-intro.xml"));

            return retVal;
        }

        SDefEditor CreateFragment(String name,
            String title,
            String mapName,
            String baseDefinition)
        {
            SDefEditor retVal = this.CreateEditor(name,
                title,
                mapName,
                baseDefinition,
                $"Fragment/{name}");
            retVal.SetIsFrag();
            retVal.SDef.Abstract = true;

            retVal.IntroDoc = new IntroDoc();
            retVal.IntroDoc.TryAddUserMacro("FragPath", FragmentMapMaker.FragmentMapName(retVal.SDef.Url.LastUriPart()));
            retVal.IntroDoc.TryAddUserMacro("TitleArticle", Article(title));
            retVal.IntroDoc.TryAddUserMacro("Title", title);
            retVal.IntroDoc.Load("Fragment",
                Path.Combine(pageDir, $"StructureDefinition-{name}-intro.xml"));

            retVal.SDef.Version = "Fragment";       // this will get stripped out when unfrag'd.

            return retVal;
        }

        String CodeSystemUrl(String name) => $"http://hl7.org/fhir/us/breast-radiology/CodeSystem/{name}";

        CodeSystem CreateCodeSystem(String name,
            String title,
            String mapName,
            String description,
            String groupPath,
            IEnumerable<ConceptDef> codes)
        {
            CodeSystem cs = new CodeSystem
            {
                Id = name,
                Url = CodeSystemUrl(name),
                Name = name,
                Title = title,
                Description = new Markdown(description),
                CaseSensitive = true,
                Content = CodeSystem.CodeSystemContentMode.Complete,
                Count = codes.Count(),
            };
            cs.AddFragRef(this.HeaderFragment.Value());

            // store groupPath as an extension. This is an unregistered extension that will be removed before
            // processing is complete.
            cs.Extension.Add(new Extension
            {
                Url = Global.GroupExtensionUrl,
                Value = new FhirString(groupPath)
            });

            foreach (ConceptDef code in codes)
            {
                cs.Concept.Add(new CodeSystem.ConceptDefinitionComponent
                {
                    Code = code.Code,
                    Display = code.Display,
                    Definition = code.Definition
                });
            }

            this.resources.Add(Path.Combine(this.resourceDir, $"CodeSystem-{name}.json"), cs);
            return cs;
        }

        /// <summary>
        /// Create a value set of all the codes in the passed code system.
        /// </summary>
        ValueSet CreateValueSet(String name,
            String title,
            String mapName,
            String description,
            String groupPath,
            CodeSystem cs)
        {
            ValueSet vs = new ValueSet
            {
                Id = name,
                Url = $"http://hl7.org/fhir/us/breast-radiology/ValueSet/{name}",
                Name = name,
                Title = title,
                Description = new Markdown(description)
            };
            vs.AddFragRef(this.HeaderFragment.Value());

            // store groupPath as an extension. This is an unregistered extension that will be removed before
            // processing is complete.
            vs.Extension.Add(new Extension
            {
                Url = Global.GroupExtensionUrl,
                Value = new FhirString(groupPath)
            });


            ValueSet.ConceptSetComponent vsComp = new ValueSet.ConceptSetComponent
            {
                System = cs.Url
            };

            vs.Compose = new ValueSet.ComposeComponent();
            vs.Compose.Include.Add(vsComp);

            foreach (var code in cs.Concept)
            {
                vsComp.Concept.Add(new ValueSet.ConceptReferenceComponent
                {
                    Code = code.Code,
                    Display = code.Display
                });
            }

            this.resources.Add(Path.Combine(this.resourceDir, $"ValueSet-{name}.json"), vs);
            vs.AddExtension(Global.ResourceMapNameUrl, new FhirString(mapName));
            return vs;
        }

        public void CreateResources()
        {
            if (Directory.Exists(this.resourceDir) == false)
                Directory.CreateDirectory(this.resourceDir);
            if (Directory.Exists(this.pageDir) == false)
                Directory.CreateDirectory(this.pageDir);

            // we have to manually force the creation of the following to get
            // all the necessary objects to be created.
            this.ComponentSliceCodesCS.Value();
            this.BreastRadiologyReport.Value();

            this.SaveAll();
        }

        public void SaveAll()
        {
            foreach (KeyValuePair<string, Resource> resourceItem in this.resources)
            {
                resourceItem.Value.SaveJson(resourceItem.Key);
                this.fc?.Mark(resourceItem.Key);
            }

            foreach (SDefEditor sDefEditor in this.Editors.Values)
            {
                if (sDefEditor.WriteFragment(out String fragmentName))
                    this.fc?.Mark(fragmentName);
                if (sDefEditor.IntroDoc != null)
                {
                    String path = sDefEditor.IntroDoc.Save();
                    this.fc?.Mark(path);
                }
            }
        }

        void ComponentSliceBiRads(SDefEditor e)
        {
            e.ComponentSliceCodeableConcept("biRadsAssessmentCategory",
                Self.CodeBiRads.ToCodeableConcept(),
                Self.BiRadsAssessmentCategoriesVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "BiRads Assessment Category",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that defines the BiRAD risk code.",
                                    $"The value of this component is a codeable concept chosen from the {Self.BiRadsAssessmentCategoriesVS.Value().Name} valueset.")
                );
        }

        void FixComponentCode(ElementTreeSlice slice,
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

        ElementTreeNode FixComponentValueX(ElementTreeSlice slice,
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

        void ComponentSliceObservedSize(SDefEditor e)
        {
            const String sliceName = "observedSize";

            ElementTreeSlice slice = e.AppendSlice("component", sliceName, 0, "1");
            slice.ElementDefinition
                .SetShort($"observedSize component")
                .SetDefinition(new Markdown($"This component slice contains the observedSize quantity"))
                .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                ;

            // Fix component code
            FixComponentCode(slice, sliceName, Self.CodeObservedSize.ToCodeableConcept());
            ElementTreeNode valueXNode = FixComponentValueX(slice, sliceName, new string[] { "Quantity", "Range" });

            {
                Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                {
                    System = "http://unitsofmeasure.org",
                    Code = "cm"
                };

                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:{sliceName}/quantity",
                    SliceName = $"{sliceName}/quantity",
                    Min = 0,
                    Max = "1"
                }
                .Pattern(q)
                .Type("Quantity")
                ;
                valueXNode.CreateSlice($"{sliceName}/quantity", valueX);
            }

            {
                Hl7.Fhir.Model.Range r = new Hl7.Fhir.Model.Range
                {
                    Low = new SimpleQuantity
                    {
                        System = "http://unitsofmeasure.org",
                        Code = "cm"
                    },
                    High = new SimpleQuantity
                    {
                        System = "http://unitsofmeasure.org",
                        Code = "cm"
                    }
                };
                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:{sliceName}/range",
                    SliceName = $"{sliceName}/range",
                    Min = 0,
                    Max = "1"
                }
                .Pattern(r)
                .Type("Range")
                ;
                valueXNode.CreateSlice($"{sliceName}/range", valueX);
            }

            e.AddComponentLink($"Observed Size^Quantity");
            e.AddComponentLink($"Observed Size^Range");
        }

        void ComponentSliceObservedCountRange(SDefEditor e)
        {
            const String sliceName = "observedCount";

            ElementTreeSlice slice = e.AppendSlice("component", sliceName, 0, "1");
            slice.ElementDefinition
                .SetShort($"observedCount component")
                .SetDefinition(new Markdown($"This component slice contains the observedCount quantity"))
                .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                ;

            // Fix component code
            FixComponentCode(slice, sliceName, Self.CodeObservedCount.ToCodeableConcept());
            ElementTreeNode valueXNode = FixComponentValueX(slice, sliceName, new string[] { "Quantity", "Range" });

            {
                Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                {
                    System = "http://unitsofmeasure.org",
                    Code = "tot"
                };

                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:{sliceName}/quantity",
                    SliceName = $"{sliceName}/quantity",
                    Min = 0,
                    Max = "1"
                }
                .Pattern(q)
                .Type("Quantity")
                ;
                valueXNode.CreateSlice($"{sliceName}/quantity", valueX);
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
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:{sliceName}/range",
                    SliceName = $"{sliceName}/range",
                    Min = 0,
                    Max = "1"
                }
                .Pattern(r)
                .Type("Range")
                ;
                valueXNode.CreateSlice($"{sliceName}/range", valueX);
            }

            e.AddComponentLink($"Observed Size^Quantity");
            e.AddComponentLink($"Observed Size^Range");
        }

        IntroDoc CreateIntroDocVS(ValueSet binding)
        {
            IntroDoc doc = new IntroDoc();
            doc.TryAddUserMacro("TitleArticle", Article(binding.Title));
            doc.TryAddUserMacro("Title", binding.Title);
            doc.TryAddUserMacro("FocusPath", FocusMapMaker.FocusMapName(binding.Name));
            doc.Load("ValueSet",
                Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
            return doc;
        }

        ElementTreeSlice SliceTargetReference(SDefEditor e,
            ElementTreeNode sliceElementDef,
            StructureDefinition profile,
            Int32 min = 0,
            String max = "*")
        {
            String baseName = sliceElementDef.ElementDefinition.Path.LastPathPart();
            ElementTreeSlice retVal = e.SliceByUrlTarget(sliceElementDef, profile.Url, min, max);
            retVal.ElementDefinition
                .SetShort($"'{profile.Title}' reference")
                .SetDefinition(
                    new Markdown($"This slice references the target '{profile.Title}'")
                    )
            ;
            e.AddTargetLink(profile.Url, false);

            return retVal;
        }

        void SliceTargetReference(SDefEditor e,
            ElementTreeNode sliceElementDef,
            StructureDefinition profile,
            Modalities modalities,
            Int32 min = 0,
            String max = "*")
        {
            String baseName = sliceElementDef.ElementDefinition.Path.LastPathPart();
            e.SliceByUrlTarget(sliceElementDef, profile.Url, min, max).ElementDefinition
                .SetShort($"'{profile.Title}' reference")
                .SetDefinition(
                    new Markdown($"This slice references the target '{profile.Title}'")
                    .ValidModalities(Modalities.MG)
                    )
            ;
            e.AddTargetLink(profile.Url, false);
        }

        void SliceTargetReference(SDefEditor e,
            ElementTreeNode sliceElementDef,
            String profile,
            String title,
            Int32 min = 0,
            String max = "*")
        {
            String baseName = sliceElementDef.ElementDefinition.Path.LastPathPart();
            e.SliceByUrlTarget(sliceElementDef, profile, min, max).ElementDefinition
                .SetShort($"'{title}' reference")
                .SetDefinition(new Markdown($"This slice references the target '{title}'"))
            ;
            e.AddTargetLink(profile, false);
        }

    }
}
