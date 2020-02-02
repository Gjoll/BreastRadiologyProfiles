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
            bool eolFlag = true;


            void MakeEOLN()
            {
                if (this.eolFlag == true)
                    return;
                this.sb.AppendLine("");
                this.eolFlag = true;
            }

            public Definition CiteStart(String citationSource)
            {
                MakeEOLN();
                this.sb.AppendLine($"[{citationSource}]");
                this.eolFlag = true;
                return this;
            }

            public Definition CiteEnd()
            {
                MakeEOLN();
                //this.sb.AppendLine($"    -- {citationSource}");
                return this;
            }

            public Definition Text(String line)
            {
                this.eolFlag = false;
                this.sb.Append(line);
                return this;
            }

            public Definition Line(String line)
            {
                this.eolFlag = true;
                this.sb.AppendLine(line);
                return this;
            }

            public Definition MammoId(String id)
            {
                if (MammoIDDescriptions.Self.TryGet(id, out MammoIDDescriptions.Description description) == false)
                    return this;
                this.CiteStart(description.Source);
                foreach (String line in description.Text)
                    this.Line(line);
                this.CiteEnd();
                return this;
            }

            public override string ToString() => this.ToText();

            public String ToText()
            {
                return this.sb.ToString();
            }
        }

        class ConceptDef
        {
            public String Code { get; set; }
            public String Display { get; set; }
            public String Definition
            {
                get
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(this.definitionText);
                    if (String.IsNullOrEmpty(this.modalities) == false)
                        sb.AppendLine(this.modalities);
                    return sb.ToString();
                }
            }
            String modalities { get; set; }

            String definitionText;

            public ConceptDef()
            {
            }

            public ConceptDef SetCode(String value)
            {
                this.Code = value;
                return this;
            }

            public ConceptDef SetDisplay(String value)
            {
                this.Display= value;
                return this;
            }

            public ConceptDef SetDefinition(Definition def)
            {
                this.definitionText = def.ToString();
                return this;
            }

            public ConceptDef(Coding code, Definition definition)
            {
                this.Code = code.Code;
                this.Display = code.Display;
                this.definitionText = definition.ToString();
            }

            public ConceptDef(String code, String display, Definition definition)
            {
                String definitionStr = definition.ToString();
                if (String.IsNullOrWhiteSpace(code) == true)
                    throw new Exception("Empty code");
                if (String.IsNullOrWhiteSpace(display) == true)
                    throw new Exception("Empty Display");
                if (String.IsNullOrWhiteSpace(definitionStr) == true)
                    throw new Exception("Empty definition");
                this.Code = code;
                this.Display = display;
                this.definitionText = definitionStr;
            }

            public ConceptDef ValidModalities(Modalities modalities)
            {
                StringBuilder sb = new StringBuilder();
                void Add(Modalities flag)
                {
                    if ((modalities & flag) == flag)
                        sb.Append($" {flag.ToString()}");
                }

                sb.Append("Valid for the following modalities:");
                Add(Modalities.MG);
                Add(Modalities.US);
                Add(Modalities.MRI);
                Add(Modalities.NM);
                sb.AppendLine(".");
                this.modalities = sb.ToString();
                return this;
            }

            public ConceptDef SetDicom(String value)
            {
                return this;
            }

            public ConceptDef SetPenCode(String value)
            {
                return this;
            }

            public ConceptDef SetSnomedCode(String value)
            {
                return this;
            }

            public ConceptDef SetOneToMany(String value)
            {
                return this;
            }

            public ConceptDef SetSnomedDescription(String value)
            {
                return this;
            }

            public ConceptDef SetICD10(String value)
            {
                return this;
            }

            public ConceptDef SetComment(String value)
            {
                return this;
            }

            public ConceptDef SetUMLS(String value)
            {
                return this;
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

        public static Markdown componentDefinition = new Markdown()
                                    .Paragraph($"This is one component of a group of components that comprise the observation.")
            ;

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
            SDefEditor retVal = this.CreateEditor(name, title, mapName, baseDefinition, groupPath);

            retVal.IntroDoc = new IntroDoc();
            retVal.IntroDoc.TryAddUserMacro("FocusPath", FocusMapMaker.FocusMapName(retVal.SDef.Url.LastUriPart()));
            retVal.IntroDoc.TryAddUserMacro("TitleArticle", this.Article(title));
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
            retVal.IntroDoc.TryAddUserMacro("TitleArticle", this.Article(title));
            retVal.IntroDoc.TryAddUserMacro("Title", title);
            retVal.IntroDoc.Load("Fragment",
                Path.Combine(this.pageDir, $"StructureDefinition-{name}-intro.xml"));

            retVal.SDef.Version = "Fragment";       // this will get stripped out when unfrag'd.

            return retVal;
        }

        String CodeSystemUrl(String name) => $"{Global.BreastRadBaseUrl}CodeSystem/{name}";

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
                Url = this.CodeSystemUrl(name),
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
            CodeSystem cs = null)
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

            this.resources.Add(Path.Combine(this.resourceDir, $"ValueSet-{name}.json"), vs);
            vs.AddExtension(Global.ResourceMapNameUrl, new FhirString(mapName));

            if (cs == null)
                return vs;

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
            this.CompositionSectionSliceCodesCS.Value();
            this.ComponentSliceCodesCS.Value();
            this.BreastRadiologyDocument.Value();
            this.BreastRadiologyReport.Value();
            this.UnitsOfLengthVS.Value();

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
                if (sDefEditor.Write(out String fragmentName))
                    this.fc?.Mark(fragmentName);
                if (sDefEditor.IntroDoc != null)
                {
                    String path = sDefEditor.IntroDoc.Save();
                    this.fc?.Mark(path);
                }
            }
        }

        IntroDoc CreateIntroDocVS(ValueSet binding)
        {
            IntroDoc doc = new IntroDoc();
            doc.TryAddUserMacro("TitleArticle", this.Article(binding.Title));
            doc.TryAddUserMacro("Title", binding.Title);
            doc.TryAddUserMacro("FocusPath", FocusMapMaker.FocusMapName(binding.Name));
            doc.Load("ValueSet",
                Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
            return doc;
        }
    }
}
