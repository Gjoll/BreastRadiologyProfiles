﻿using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
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
            public ElementTreeNode DiffNodes;
        };

        public String OutputDir { get; set; } = ".";
        public bool CleanFlag { get; set; } = false;
        FileCleaner fc = new FileCleaner();

        Dictionary<String, FragInfo> sdFragments = new Dictionary<string, FragInfo>();
        String InterfaceName(FragInfo fi) => $"I{fi.StructDef.Name}";
        String ClassName(FragInfo fi) => $"{fi.StructDef.Name}";

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
                            DiffNodes = l.Create(sd.Differential.Element)
                        };
                        fi.InterfaceCode.Load("TemplateInterface.txt");

                        if (this.IsFragment(sd) == false)
                        {
                            fi.ClassCode = new CodeEditor();
                            fi.ClassCode.Load("TemplateClass.txt");
                        }
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

            void Build2(FragInfo fi, ElementTreeSlice slice)
            {
                if (slice.ElementDefinition.Type.Count != 1)
                    throw new Exception($"invalid hasMember type count");
                if (slice.ElementDefinition.Type[0].Code != "Reference")
                    throw new Exception($"invalid hasMember type");
                if (slice.ElementDefinition.Type[0].TargetProfile.Count() != 1)
                    throw new Exception($"invalid hasMember targetProfile count");
                String reference = slice.ElementDefinition.Type[0].TargetProfile.First();
                if (this.sdFragments.TryGetValue(reference.ToLower().Trim(), out FragInfo refFrag) == false)
                    throw new Exception($"missing hasMember reference {reference}");
                if (items.Contains(slice.Name))
                    return;
                items.Add(slice.Name);

                String refClassName = ClassName(refFrag);
                String refInterfaceName = InterfaceName(refFrag);
                String fieldName = slice.Name;

                if (fi.ClassCode != null)
                {
                    fi.ClassCode.Blocks.Find("Fields")
                        .AppendLine($"public List<{refClassName}> {fieldName};")
                        ;
                }
            }

            void Build(FragInfo fi)
            {
                if (fi.StructDef.BaseDefinition != Global.ObservationUrl)
                    return;
                if (fi.DiffNodes.TryGetElementNode("Observation.hasMember", out ElementTreeNode hasMemberNode) == false)
                    return;
                if (hasMemberNode.Slices.Count <= 1)
                    return;
                foreach (ElementTreeSlice slice in hasMemberNode.Slices.Skip(1))
                    Build2(fi, slice);
            }


            VisitFragments(Build, fi);
        }

        void BuildHeader(FragInfo fi)
        {
            CodeBlockNested iHdr = fi.InterfaceCode.Blocks.Find("Header");
            StringBuilder interfaces = new StringBuilder();
            String comma = "";
            if (fi.ReferencedFragments.Count > 0)
            {
                interfaces.Append(" : ");
                foreach (FragInfo refFrag in fi.ReferencedFragments)
                {
                    interfaces.Append($"{comma}{InterfaceName(refFrag)}");
                    comma = ", ";
                }
            }

            iHdr.Clear();
            iHdr
                .AppendLine($"public interface {InterfaceName(fi)} {interfaces.ToString()}")
                ;

            if (fi.ClassCode != null)
            {
                CodeBlockNested cHdr = fi.ClassCode.Blocks.Find("Header");
                cHdr.Clear();
                cHdr
                    .AppendLine($"public class {ClassName(fi)} : BreastRadBase, {InterfaceName(fi)}")
                    ;
            }
        }


        void Save(FragInfo fi)
        {
            Save(fi.InterfaceCode, Path.Combine(this.OutputDir, "Generated", "Interfaces", $"{InterfaceName(fi)}.cs"));
            if (fi.ClassCode != null)
                Save(fi.ClassCode, Path.Combine(this.OutputDir, "Generated", "Class", $"{ClassName(fi)}.cs"));
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
