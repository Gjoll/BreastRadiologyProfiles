using FhirKhit.Tools;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace FireFragger
{
    class CSBuilder : ConverterBase, IDisposable
    {
        public bool DebugFlag = false;
        public String OutputDir { get; set; } = ".";
        public bool CleanFlag { get; set; } = false;
        FileCleaner fc = new FileCleaner();

        Dictionary<String, StructureDefinition> sdFragments = new Dictionary<string, StructureDefinition>();

        /// <summary>
        /// Add all fragment resources in indicated directory.
        /// </summary>
        public void AddFragmentDir(String path,
            String searchPattern)
        {
            foreach (String filePath in Directory.GetFiles(path, searchPattern))
                this.AddFragment(filePath);

            foreach (String subDir in Directory.GetDirectories(path))
                this.AddFragmentDir(subDir, searchPattern);
        }

        public void AddFragment(String path)
        {
            const String fcn = "AddFragment";

            DomainResource domainResource;
            switch (Path.GetExtension(path).ToUpper(CultureInfo.InvariantCulture))
            {
                case ".XML":
                    {
                        FhirXmlParser parser = new FhirXmlParser();
                        domainResource = parser.Parse<DomainResource>(File.ReadAllText(path));
                        break;
                    }

                case ".JSON":
                    {
                        FhirJsonParser parser = new FhirJsonParser();
                        domainResource = parser.Parse<DomainResource>(File.ReadAllText(path));
                        break;
                    }

                default:
                    throw new Exception($"Unknown extension for serialized fhir resource '{path}'");
            }

            switch (domainResource)
            {
                case StructureDefinition sd:
                    this.sdFragments.Add(sd.Url, sd);
                    break;

                default:
                    this.ConversionError(this.GetType().Name,
                       fcn,
                       $"Unimplemented fragment resource type {domainResource.GetType().Name} file {path}");
                    return;
            }
        }

        void BuildFragment(StructureDefinition sdFrag)
        {
            const String fcn = "BuildFragment";

            this.ConversionInfo(this.GetType().Name,
               fcn,
               $"Processing fragment {sdFrag.Name}");

            CodeEditor code = new CodeEditor();
            code.Load("FragmentTemplate.txt");

            code.Save(Path.Combine(this.OutputDir, $"I{sdFrag.Name}"));
        }

        void BuildFragments()
        {
            foreach (StructureDefinition sdFrag in this.sdFragments.Values)
                BuildFragment(sdFrag);
        }

        public void Build()
        {
            if (Directory.Exists(this.OutputDir) == false)
                Directory.CreateDirectory(this.OutputDir);

            if (this.CleanFlag)
            {
                this.fc = new FileCleaner();
                fc.Add(this.OutputDir);
            }

            BuildFragments();
        }

        bool IsFragment(DomainResource r)
        {
            Extension isFragmentExtension = r.GetExtension(Global.IsFragmentExtensionUrl);
            return (isFragmentExtension != null);
        }

        public void Dispose()
        {
            this?.fc.Dispose();
        }
    }
}
