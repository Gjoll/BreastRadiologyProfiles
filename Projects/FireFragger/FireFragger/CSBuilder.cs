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
        class FragInfo
        {
            public StructureDefinition StructDef;
            public CodeEditor InterfaceCode;
        };

        public String OutputDir { get; set; } = ".";
        public bool CleanFlag { get; set; } = false;
        FileCleaner fc = new FileCleaner();

        Dictionary<String, FragInfo> sdFragments = new Dictionary<string, FragInfo>();

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
                    {
                        FragInfo fi = new FragInfo
                        {
                            StructDef = sd,
                            InterfaceCode = new CodeEditor()
                        };
                        fi.InterfaceCode.Load("FragmentTemplate.txt");
                        this.sdFragments.Add(sd.Url, fi);
                    }
                    break;

                default:
                    this.ConversionError(this.GetType().Name,
                       fcn,
                       $"Unimplemented fragment resource type {domainResource.GetType().Name} file {path}");
                    return;
            }
        }

        void BuildFragment(FragInfo fi)
        {
            const String fcn = "BuildFragment";

            this.ConversionInfo(this.GetType().Name,
               fcn,
               $"Processing fragment {fi.StructDef.Name}");

            BuildHeader(fi);
        }

        void BuildHeader(FragInfo fi)
        {
            CodeBlockNested hdr = fi.InterfaceCode.Blocks.Find("Header");
            hdr.Clear();
            hdr
                .AppendLine($"public interface I{fi.StructDef.Name}")
                ;
        }


        void Save(FragInfo fi)
        {
            Save(fi.InterfaceCode, Path.Combine(this.OutputDir, "Generated", "Interfaces", $"I{fi.StructDef.Name}.cs"));
        }

        void Save(CodeEditor code, String path)
        {
            String dir = Path.GetDirectoryName(path);
            if (Directory.Exists(dir) == false)
                Directory.CreateDirectory(dir);
            this.fc.Mark(path);
            code.Save(path);
        }

        void BuildFragments()
        {
            foreach (FragInfo fi in this.sdFragments.Values)
                BuildFragment(fi);
        }

        void SaveAll()
        {
            foreach (FragInfo fi in this.sdFragments.Values)
                Save(fi);
        }

        public void Build()
        {
            if (Directory.Exists(this.OutputDir) == false)
                Directory.CreateDirectory(this.OutputDir);

            if (this.CleanFlag)
            {
                this.fc = new FileCleaner();
                fc.Add(Path.Combine(this.OutputDir, "Generated"));
            }

            BuildFragments();
            SaveAll();

            fc?.Dispose();
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
