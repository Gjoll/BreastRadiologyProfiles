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
    /*
     $ todo. Add negation items (mass, calc, etc).
     $ todo. Add condition that if item is not present, then body site is empty.
     $ todo. Add condition that if body site is empty, then breast body site extension is
             also empty and vice versa.
     */

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

            public Definition ValidModalities(params Modalities[] modalities)
            {
                this.sb.Append("Valid for the following modalities:");
                foreach (Modalities m in modalities)
                    this.sb.Append($" {m.ToString()}");
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

        public static String BiRadCitation = "Bi-Rads® Atlas — Mammography Fifth Ed. 2013";
        const FHIRVersion FVersion = FHIRVersion.N4_0_0;

        const String ProfileVersion = "0.0.2";
        const PublicationStatus ProfileStatus = PublicationStatus.Draft;

        const String Loinc = "http://loinc.org";

        public const String ClinicalImpressionUrl = "http://hl7.org/fhir/StructureDefinition/ClinicalImpression";
        public const String DiagnosticReportUrl = "http://hl7.org/fhir/StructureDefinition/DiagnosticReport";
        public const String ExtensionUrl = "http://hl7.org/fhir/StructureDefinition/Extension";
        public const String ImagingStudyUrl = "http://hl7.org/fhir/StructureDefinition/ImagingStudy";
        public const String MedicationRequestUrl = "http://hl7.org/fhir/StructureDefinition/MedicationRequest";
        public const String ObservationUrl = "http://hl7.org/fhir/StructureDefinition/Observation";
        public const String ResourceUrl = "http://hl7.org/fhir/StructureDefinition/Resource";
        public const String RiskAssessmentUrl = "http://hl7.org/fhir/StructureDefinition/RiskAssessment";
        public const String ServiceRequestUrl = "http://hl7.org/fhir/StructureDefinition/ServiceRequest";

        public const String contactUrl = "http://www.hl7.org/Special/committees/cic";

        Dictionary<String, Resource> resources = new Dictionary<string, Resource>();

        bool Component_HasMember = false;

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
            if (name.Contains(" "))
                throw new Exception("Structure Def name can not contains spaces");

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

        SDefEditor CreateFragment(String name,
            String title,
            String mapName,
            String baseDefinition)
        {
            SDefEditor retVal = this.CreateEditor(name,
                title,
                mapName,
                baseDefinition,
                "Fragment/{name}");
            retVal.SetIsFrag();
            retVal.SDef.Abstract = true;
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
                Title = $"{title}",
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
                Title = $"{title} ValueSet",
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

        void ComponentMGCalcificationType(SDefEditor e)
        {
            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("calcificationType",
                Self.MGCodeCalcificationType.ToCodeableConcept(),
                Self.MGCalcificationTypeVS.Value(),
                BindingStrength.Required,
                0,
                "1");
        }

        void ComponentMGCalcificationDistribution(SDefEditor e)
        {
            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("calcificationDistribution",
                Self.MGCodeCalcificationDistribution.ToCodeableConcept(),
                Self.MGCalcificationDistributionVS.Value(),
                BindingStrength.Required,
                0,
                "1");
        }

        void ComponentSliceBiRads(SDefEditor e)
        {
            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("biRadsAssessmentCategory",
                Self.CodeBiRads.ToCodeableConcept(),
                Self.BiRadsAssessmentCategoriesVS.Value(),
                BindingStrength.Required,
                0,
                "1");
        }

        void ComponentSliceObservedCount(SDefEditor e)
        {
            e.StartComponentSliceing();

            String sliceName = "observedCount";

            ElementTreeSlice slice = e.AppendSlice("component", sliceName, 0, "1");
            {
                ElementDefinition valueX = new ElementDefinition
                {
                    Path = $"{slice.ElementDefinition.Path}.value[x]",
                    ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]"
                };

                valueX
                    .Types("integer", "Range")
                    .SetCardinality(1, "1")
                    .SetDefinition(new Markdown()
                        .Paragraph("Count of an object.")
                        .Paragraph("This is either an integer count, or a Range (min..max) count.")
                        .Paragraph($"A range value with no maximum specified implies count is min or more.")
                        .Paragraph($"A range value with no minimum specified implies count is max or less.")
                     )
                    ;
                ;
                slice.CreateNode(valueX);
            }
        }

        void ComponentSliceConsistentWith(SDefEditor e)
        {
            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("consistentWith",
                Self.CodeBiRads.ToCodeableConcept(),
                Self.ConsistentWithVS.Value(),
                BindingStrength.Extensible,
                0,
                "*");
        }

    }
}
