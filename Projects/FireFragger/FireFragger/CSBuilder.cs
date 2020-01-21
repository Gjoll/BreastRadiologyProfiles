using FhirKhit.Tools;
using FhirKhit.Tools.R4;
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
            public List<FragInfo> ReferencedFragments = new List<FragInfo>();
            public StructureDefinition StructDef;
            public CodeEditor InterfaceCode;
            public CodeEditor ClassCode;
            public ElementTreeNode SnapNodes;
        };

        public String OutputDir { get; set; } = ".";
        public bool CleanFlag { get; set; } = false;
        FileCleaner fc = new FileCleaner();

        Dictionary<String, FragInfo> sdFragments = new Dictionary<string, FragInfo>();

        /// <summary>
        /// Add all fragment resources in indicated directory.
        /// </summary>
        public void AddFragmentDir(String fragDir,
            String searchPattern)
        {
            foreach (String filePath in Directory.GetFiles(fragDir, searchPattern))
            {
                this.AddFragment(filePath);
            }

            foreach (String subDir in Directory.GetDirectories(fragDir))
            {
                this.AddFragmentDir(subDir, searchPattern);
            }
        }

        public void AddFragment(String filePath)
        {
            const String fcn = "AddFragment";

            DomainResource domainResource;

            switch (Path.GetExtension(filePath).ToUpper(CultureInfo.InvariantCulture))
            {
                case ".XML":
                    {
                        FhirXmlParser parser = new FhirXmlParser();
                        domainResource = parser.Parse<DomainResource>(File.ReadAllText(filePath));
                        break;
                    }

                case ".JSON":
                    {
                        FhirJsonParser parser = new FhirJsonParser();
                        domainResource = parser.Parse<DomainResource>(File.ReadAllText(filePath));
                        break;
                    }

                default:
                    throw new Exception($"Unknown extension for serialized fhir resource '{filePath}'");
            }

            switch (domainResource)
            {
                case StructureDefinition sd:
                    {
                        ElementTreeLoader l = new ElementTreeLoader(this);
                        ElementTreeNode diffNode = null;

                        FragInfo fi = new FragInfo
                        {
                            StructDef = sd,
                            InterfaceCode = new CodeEditor(),
                            ClassCode = new CodeEditor(),
                            SnapNodes = l.Create(sd.Differential.Element)
                        };
                        fi.InterfaceCode.Load("TemplateInterface.txt");
                        fi.ClassCode.Load("TemplateClass.txt");
                        this.sdFragments.Add(sd.Url.ToLower().Trim(), fi);
                    }
                    break;

                default:
                    this.ConversionError(this.GetType().Name,
                       fcn,
                       $"Unimplemented fragment resource type {domainResource.GetType().Name} file {filePath}");
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
            BuildHasMembers(fi);
        }

        void BuildHasMembers(FragInfo fi)
        {
            HashSet<string> items = new HashSet<string>();

            void Build(FragInfo fi)
            {
                if (fi.StructDef.BaseDefinition != Global.ObservationUrl)
                    return;

            }

            VisitFragments(Build, fi);
        }

        void BuildHeader(FragInfo fi)
        {
            CodeBlockNested iHdr = fi.InterfaceCode.Blocks.Find("Header");
            CodeBlockNested cHdr = fi.ClassCode.Blocks.Find("Header");
            StringBuilder interfaces = new StringBuilder();
            String comma = "";
            if (fi.ReferencedFragments.Count > 0)
            {
                interfaces.Append(" : ");
                foreach (FragInfo refFrag in fi.ReferencedFragments)
                {
                    interfaces.Append($"{comma}I{refFrag.StructDef.Name}");
                    comma = ", ";
                }
            }

            iHdr.Clear();
            iHdr
                .AppendLine($"public interface I{fi.StructDef.Name} {interfaces.ToString()}")
                ;

            cHdr.Clear();
            cHdr
                .AppendLine($"public class {fi.StructDef.Name} : BreastRadBase, I{fi.StructDef.Name}")
                ;
        }


        void Save(FragInfo fi)
        {
            Save(fi.InterfaceCode, Path.Combine(this.OutputDir, "Generated", "Interfaces", $"I{fi.StructDef.Name}.cs"));
            Save(fi.ClassCode, Path.Combine(this.OutputDir, "Generated", "Class", $"{fi.StructDef.Name}.cs"));
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

            BuildReferences();
            BuildFragments();
            SaveAll();

            fc?.Dispose();
        }

        void BuildReferences()
        {
            const String fcn = "BuildReferences";

            foreach (FragInfo fi in this.sdFragments.Values)
            {
                foreach (Extension e in fi.StructDef.Extension.ToArray())
                {
                    if (e.Url.ToLower().Trim() == Global.FragmentUrl)
                    {
                        FhirUrl extUrl = (FhirUrl)e.Value;
                        String url = extUrl.Value.ToLower().Trim();
                        if (sdFragments.TryGetValue(url, out FragInfo reference) == false)
                        {
                            this.ConversionError(this.GetType().Name,
                               fcn,
                               $"Cant find fragment {extUrl}");
                        }
                        else
                        {
                            fi.ReferencedFragments.Add(reference);
                        }
                    }
                }
            }
        }

        bool IsFragment(DomainResource r)
        {
            Extension isFragmentExtension = r.GetExtension(Global.IsFragmentExtensionUrl);
            return (isFragmentExtension != null);
        }

        delegate void VisitFragment(FragInfo fi);

        void VisitFragments(VisitFragment vi,
            FragInfo fragBase)
        {
            HashSet<FragInfo> visitedFrags = new HashSet<FragInfo>();

            void Visit(VisitFragment vi,
                FragInfo fi)
            {
                if (visitedFrags.Contains(fi))
                    return;
                vi(fi);
                visitedFrags.Add(fi);

                foreach (FragInfo refFrag in fragBase.ReferencedFragments)
                {
                    Visit(vi, refFrag);
                }
            }

            Visit(vi, fragBase);
        }

        public void Dispose()
        {
            this?.fc.Dispose();
        }
    }
}
