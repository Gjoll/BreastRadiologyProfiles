﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadiology.XUnitTests
{
    public class IGBuilder : ConverterBase
    {
        FileCleaner fc;

        String outputDir;
        String resourceDir => Path.Combine(this.outputDir, "resources");
        String pagecontentDir => Path.Combine(this.outputDir, "pagecontent");

        String imagesDir => Path.Combine(this.outputDir, "images");

        //String IgPath => Path.Combine(this.outputDir, "IGBreastRad.json");
        String ImpGuidePath => Path.Combine(this.outputDir, this.impGuideName);
        String impGuideName;


        //ProfilesEditor profilesEditor;
        //ExamplesEditor examplesEditor;
        //ExtensionsEditor extensionsEditor;
        //CodeSystemsEditor codeSystemsEditor;
        //ValueSetsEditor valueSetsEditor;
        ImplementationGuideEditor implementationGuide;

        public IGBuilder(FileCleaner fc, String outputDir)
        {
            this.outputDir = outputDir;
            if (Directory.Exists(this.resourceDir) == false)
                Directory.CreateDirectory(this.resourceDir);

            if (Directory.Exists(this.pagecontentDir) == false)
                Directory.CreateDirectory(this.pagecontentDir);

            if (Directory.Exists(this.imagesDir) == false)
                Directory.CreateDirectory(this.imagesDir);

            this.fc = fc;
        }

        public void SaveAll()
        {
            this.implementationGuide.Save(this.ImpGuidePath);
            this.fc?.Mark(this.ImpGuidePath);

            //this.fc?.Mark(this.IgPath);

            //this.examplesEditor.Save();
            //this.profilesEditor.Save();
            //this.extensionsEditor.Save();
            //this.codeSystemsEditor.Save();
            //this.valueSetsEditor.Save();
        }

        public void Start(String impGuidePath)
        {
            //this.examplesEditor = new ExamplesEditor(this.outputDir);
            //this.profilesEditor = new ProfilesEditor(this.outputDir);
            //this.extensionsEditor = new ExtensionsEditor(this.outputDir);
            //this.codeSystemsEditor = new CodeSystemsEditor(this.outputDir);
            //this.valueSetsEditor = new ValueSetsEditor(this.outputDir);

            this.impGuideName = Path.GetFileName(impGuidePath);
            this.implementationGuide = new ImplementationGuideEditor(impGuidePath);
        }

        void CopyFiles(String inputDir, String inputMask, String outputDir)
        {
            foreach (String inputPath in Directory.GetFiles(inputDir, inputMask))
            {
                String outputPath = Path.Combine(outputDir, Path.GetFileName(inputPath));

                File.Copy(inputPath, outputPath, true);
                this.fc?.Mark(outputPath);
            }
        }

        public void AddPageContent(String inputDir)
        {
            this.CopyFiles(inputDir, "*.xml", this.pagecontentDir);
        }

        public void AddImages(String inputDir)
        {
            this.CopyFiles(inputDir, "*.svg", this.imagesDir);
        }

        HashSet<String> groupIds = new HashSet<string>();

        public void AddGrouping(String groupId, String name, String description)
        {
            this.implementationGuide.AddGrouping(groupId, name, description);
            if (this.groupIds.Contains(groupId))
                throw new Exception($"Group already added");
            this.groupIds.Add(groupId);
        }

        void RemoveFragmentExtensions(DomainResource r)
        {
            void Rem(List<Extension> extensions)
            {
                Int32 i = 0;
                while (i < extensions.Count)
                {
                    Extension e = extensions[i];
                    if (e.Url.StartsWith(Global.BaseFragmentUrl, new StringComparison()))
                        extensions.RemoveAt(i);
                    else
                        i += 1;
                }
            }

            Rem(r.Extension);

            StructureDefinition sd = r as StructureDefinition;
            if (sd != null)
            {
                foreach (ElementDefinition ed in sd.Snapshot.Element)
                    Rem(ed.Extension);
                foreach (ElementDefinition ed in sd.Differential.Element)
                    Rem(ed.Extension);
            }
        }


        public void AddResources(params String[] inputDirs)
        {
            const String fcn = "AddResources";

            String Group(DomainResource resource)
            {
                Extension groupExtension = resource.GetExtension(Global.GroupExtensionUrl);
                if (resource == null)
                    throw new Exception($"StructureDefinition {resource.Id} lacks group extension");
                FhirString value = groupExtension.Value as FhirString;
                if (value == null)
                    throw new Exception($"StructureDefinition {resource.Id} lacks group extension value");
                return value.Value;
            }

            String GetGroupPath(DomainResource resource)
            {
                String groupPath = Group(resource);

                String groupId = groupPath.BaseUriPart();
                if (this.groupIds.Contains(groupId) == false)
                {
                    this.ConversionError(this.GetType().Name,
                        fcn,
                        $"Group {groupId} not defined");
                    return null;
                }

                return groupId;
            }

            void Save(DomainResource r, String outputName)
            {
                this.RemoveFragmentExtensions(r);
                String outputPath = Path.Combine(this.resourceDir, outputName);
                r.SaveJson(outputPath);
                this.fc?.Mark(outputPath);
            }

            List<StructureDefinition> structureDefinitions = new List<StructureDefinition>();
            List<ValueSet> valueSets = new List<ValueSet>();
            List<CodeSystem> codeSystems = new List<CodeSystem>();

            foreach (String inputDir in inputDirs)
            {
                foreach (String file in Directory.GetFiles(inputDir))
                {
                    String fhirText = File.ReadAllText(file);
                    FhirJsonParser parser = new FhirJsonParser();
                    var resource = parser.Parse(fhirText, typeof(Resource));
                    switch (resource)
                    {
                        case StructureDefinition structureDefinition:
                            structureDefinitions.Add(structureDefinition);
                            break;

                        case CodeSystem codeSystem:
                            codeSystems.Add(codeSystem);
                            break;

                        case ValueSet valueSet:
                            valueSets.Add(valueSet);
                            break;

                        default:
                            throw new NotImplementedException($"Unknown resource type '{file}'");
                    }
                }
            }

            structureDefinitions.Sort((a, b) => String.Compare(Group(a), Group(b), new System.StringComparison()));
            valueSets.Sort((a, b) => String.Compare(a.Name, b.Name, new System.StringComparison()));
            codeSystems.Sort((a, b) => String.Compare(a.Name, b.Name, new System.StringComparison()));

            foreach (CodeSystem codeSystem in codeSystems)
            {
                String groupId = GetGroupPath(codeSystem);
                Save(codeSystem, $"CodeSystem-{codeSystem.Name}.json");
                this.implementationGuide.AddIGResource($"CodeSystem/{codeSystem.Name}", codeSystem.Title,
                    codeSystem.Description.ToString(), groupId, false);
            }

            foreach (ValueSet valueSet in valueSets)
            {
                String groupId = GetGroupPath(valueSet);
                Save(valueSet, $"ValueSet-{valueSet.Name}.json");
                this.implementationGuide.AddIGResource($"ValueSet/{valueSet.Name}", valueSet.Title,
                    valueSet.Description.ToString(), groupId, false);
            }

            foreach (StructureDefinition structureDefinition in structureDefinitions)
            {
                String fixedName = $"StructureDefinition-{structureDefinition.Name}";

                if (structureDefinition.Snapshot == null)
                    SnapshotCreator.Create(structureDefinition);

                Extension isFragmentExtension = structureDefinition.GetExtension(Global.IsFragmentExtensionUrl);
                // Dont add fragments to IG.
                if (isFragmentExtension == null)
                {
                    String groupId = GetGroupPath(structureDefinition);
                    Save(structureDefinition, $"{fixedName}.json");
                    String shortDescription = structureDefinition.Snapshot.Element[0].Short;

                    this.implementationGuide.AddIGResource($"StructureDefinition/{structureDefinition.Name}",
                        structureDefinition.Title,
                        shortDescription,
                        groupId,
                        false);
                }
                else
                {
                }
            }
        }

        public void AddFragments(String inputDir)
        {
            //const String fcn = "AddFragments";

            void Save(DomainResource r, String outputName)
            {
                this.RemoveFragmentExtensions(r);

                String outputPath = Path.Combine(this.resourceDir, outputName);
                r.SaveJson(outputPath);
                this.fc?.Mark(outputPath);
            }

            List<StructureDefinition> structureDefinitions = new List<StructureDefinition>();
            foreach (String file in Directory.GetFiles(inputDir))
            {
                String fhirText = File.ReadAllText(file);
                FhirJsonParser parser = new FhirJsonParser();
                var resource = parser.Parse(fhirText, typeof(Resource));
                switch (resource)
                {
                    case StructureDefinition structureDefinition:
                        Extension isFragmentExtension = structureDefinition.GetExtension(Global.IsFragmentExtensionUrl);
                        // Onlu add fragments to IG.
                        if (isFragmentExtension != null)
                        {
                            Int32 index = structureDefinition.Url.LastIndexOf('/');
                            structureDefinitions.Add(structureDefinition);
                        }

                        break;
                }
            }

            structureDefinitions.Sort((a, b) => String.Compare(a.Url, b.Url, new System.StringComparison()));

            foreach (StructureDefinition structureDefinition in structureDefinitions)
            {
                String fixedName = $"StructureDefinition-{structureDefinition.Name}";

                if (structureDefinition.Snapshot == null)
                    SnapshotCreator.Create(structureDefinition);
                Extension isFragmentExtension = structureDefinition.GetExtension(Global.IsFragmentExtensionUrl);
                {
                    String groupId = "Fragments";
                    Save(structureDefinition, $"{fixedName}.json");
                    String shortDescription = $"Fragment '{structureDefinition.Snapshot.Element[0].Short}'";

                    this.implementationGuide.AddIGResource($"StructureDefinition/{structureDefinition.Name}",
                        structureDefinition.Title,
                        shortDescription,
                        groupId,
                        false);
                }
            }
        }
    }
}