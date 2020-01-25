using FhirKhit.Tools;
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
        class CSInfo
        {
            public CodeSystem CodeSystem;
            public CodeEditor ClassCode { get; }

            public CSInfo()
            {
                ClassCode = new CodeEditor();
                this.ClassCode.Load("TemplateValueSet.txt");
            }
        };

        class VSInfo
        {
            public ValueSet ValueSet;
            public CodeEditor ClassCode;
        };

        class FragInfo
        {
            public List<FragInfo> ReferencedFragments = new List<FragInfo>();
            public StructureDefinition StructDef;
            public CodeEditor InterfaceCode;
            public CodeEditor ClassCode;
            public ElementTreeNode DiffNodes;
        };

        Dictionary<String, CSInfo> codeSystems;
        Dictionary<String, CSInfo> localCodeSystems;
        Dictionary<String, VSInfo> valueSets;
        Dictionary<String, FragInfo> sdFragments;

        public String OutputDir { get; set; } = ".";
        public bool CleanFlag { get; set; } = false;
        FileCleaner fc = new FileCleaner();

        public CSBuilder()
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            this.codeSystems = new Dictionary<string, CSInfo>(comparer);
            this.localCodeSystems = new Dictionary<string, CSInfo>(comparer);
            this.valueSets = new Dictionary<string, VSInfo>(comparer);
            this.sdFragments = new Dictionary<string, FragInfo>(comparer);
        }

        String MachineName(String s)
        {
            return s.Replace("<", " Less Than ")
            .Replace(">", " Greater Than ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .ToMachineName();
        }
        String CodeName(string code) => $"Code_{MachineName(code)}";
        String InterfaceName(FragInfo fi) => $"I{MachineName(fi.StructDef.Name)}";
        String ClassName(FragInfo fi) => $"{MachineName(fi.StructDef.Name)}";
        String CodeSystemName(CSInfo ci) => $"{MachineName(ci.CodeSystem.Name)}";
        String ValueSetName(VSInfo vi) => $"{MachineName(vi.ValueSet.Name)}";
        String PropertyName(string name) => $"{MachineName(name)}";

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
                case CodeSystem cs:
                    {
                        CSInfo ci = new CSInfo
                        {
                            CodeSystem = cs,
                        };
                        codeSystems.Add(cs.Url, ci);
                    }
                    break;

                case ValueSet vs:
                    {
                        VSInfo vi = new VSInfo
                        {
                            ValueSet = vs,
                            ClassCode = new CodeEditor()
                        };
                        vi.ClassCode.Load("TemplateValueSet.txt");
                        valueSets.Add(vs.Url, vi);
                    }
                    break;

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
                        this.sdFragments.Add(sd.Url.Trim(), fi);
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

        void BuildHasMembers(FragInfo fragInfo)
        {
            HashSet<string> items = new HashSet<string>();

            void Build2(FragInfo fi, ElementTreeSlice slice, Int32 level)
            {
                if (slice.ElementDefinition.Type.Count != 1)
                    throw new Exception($"invalid hasMember type count");
                if (slice.ElementDefinition.Type[0].Code != "Reference")
                    throw new Exception($"invalid hasMember type");
                if (slice.ElementDefinition.Type[0].TargetProfile.Count() != 1)
                    throw new Exception($"invalid hasMember targetProfile count");
                String reference = slice.ElementDefinition.Type[0].TargetProfile.First();
                if (this.sdFragments.TryGetValue(reference.Trim(), out FragInfo refFrag) == false)
                    throw new Exception($"missing hasMember reference {reference}");
                if (items.Contains(slice.Name))
                    return;
                items.Add(slice.Name);
                String refClassName = ClassName(refFrag);
                String refInterfaceName = InterfaceName(refFrag);
                String fieldName = PropertyName(slice.Name);

                if (fragInfo.ClassCode != null)
                {
                    fragInfo.ClassCode.Blocks.Find("Fields")
                        .AppendCode($"public List<{refInterfaceName}> {fieldName} {{get;}} = new List<{refInterfaceName}>();")
                        ;
                }

                if (level == 0)
                {
                    fragInfo.InterfaceCode.Blocks.Find("Fields")
                        .AppendCode($"List<{refInterfaceName}> {fieldName} {{get;}}")
                        ;
                }
            }

            void Build(FragInfo fi, Int32 level)
            {
                if (fi.StructDef.BaseDefinition != Global.ObservationUrl)
                    return;
                if (fi.DiffNodes.TryGetElementNode("Observation.hasMember", out ElementTreeNode hasMemberNode) == false)
                    return;
                if (hasMemberNode.Slices.Count <= 1)
                    return;
                foreach (ElementTreeSlice slice in hasMemberNode.Slices.Skip(1))
                    Build2(fi, slice, level);
            }

            VisitFragments(Build, fragInfo);
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
                .AppendCode($"public interface {InterfaceName(fi)} {interfaces.ToString()}")
                ;

            if (fi.ClassCode != null)
            {
                CodeBlockNested cHdr = fi.ClassCode.Blocks.Find("Header");
                cHdr.Clear();
                cHdr
                    .AppendCode($"public class {ClassName(fi)} : BreastRadBase, {InterfaceName(fi)}")
                    ;
            }
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

        /// <summary>
        /// Create local code systems for those that are not defined in this project.
        /// Add all value set codes taht reference this code system into it.
        /// </summary>
        /// <param name="vi"></param>
        void BuildLocalCodeSystem(VSInfo vi)
        {
            foreach (ValueSet.ConceptSetComponent component in vi.ValueSet.Compose.Include)
            {
                foreach (ValueSet.ConceptReferenceComponent concept in component.Concept)
                {
                    // if code system not found
                    if (this.codeSystems.TryGetValue(component.System, out CSInfo ci) == false)
                    {
                        if (this.localCodeSystems.TryGetValue(component.System, out ci) == false)
                        {
                            ci = new CSInfo
                            {
                                CodeSystem = new CodeSystem
                                {
                                    Name = component.System.LastUriPart(),
                                    Url = component.System
                                }
                            };
                            this.localCodeSystems.Add(component.System, ci);
                        }

                        CodeSystem.ConceptDefinitionComponent c = new CodeSystem.ConceptDefinitionComponent
                        {
                            Code = concept.Code,
                            Display = concept.Display
                        };
                        ci.CodeSystem.Concept.Add(c);
                    }
                }
            }
        }

        void BuildLocalCodeSystems()
        {
            foreach (VSInfo vi in this.valueSets.Values)
                BuildLocalCodeSystem(vi);
            foreach (KeyValuePair<string, CSInfo> item in this.localCodeSystems)
                this.codeSystems.Add(item.Key, item.Value);
            this.localCodeSystems = null;
        }

        void BuildValueSet(VSInfo vi)
        {
            CodeBlockNested vsHdr = vi.ClassCode.Blocks.Find("Header");
            CodeBlockNested vsFields = vi.ClassCode.Blocks.Find("Fields");

            vsHdr
                .AppendCode($"public class {ValueSetName(vi)}")
                ;

            vsFields
                .DefineBlock(out CodeBlockNested definitionsBlock)
                .DefineBlock(out CodeBlockNested fieldsBlock)
                .BlankLine()
                .AppendCode($"public List<Coding> Members;")
                .BlankLine()
                .AppendCode($"public {ValueSetName(vi)}()")
                .OpenBrace()
                .AppendCode($"this.Members = new List<Coding>();")
                .DefineBlock(out CodeBlockNested constructorBlock)
                .CloseBrace()
                ;

            definitionsBlock
                .AppendLine("/// <summary>")
                .AppendLine("/// This class creates a type for codings of this class, that explicitly converts to Coding")
                .AppendLine("/// Allows type checking for these codes.")
                .AppendLine("/// </summary>")
                 .AppendCode($"public class TCoding")
                .OpenBrace()
                .AppendCode($"Coding value;")
                .AppendCode($"public static explicit operator Coding(TCoding tCode)")
                .OpenBrace()
                .AppendCode($"return tCode.value;")
                .CloseBrace()
                .BlankLine()
                .AppendCode($"public TCoding(Coding value)")
                .OpenBrace()
                .AppendCode($"this.value= value;")
                .CloseBrace()
                .CloseBrace()
                ;

            if (vi.ValueSet.Compose.Exclude.Count > 0)
                throw new NotImplementedException("Have not implemented ValueSet.Compose.Exclude");

            foreach (ValueSet.ConceptSetComponent component in vi.ValueSet.Compose.Include)
            {
                if (component.Filter.Count > 0)
                    throw new NotImplementedException("Have not implemented ValueSet.Compose.Include.Filter");
                foreach (ValueSet.ConceptReferenceComponent concept in component.Concept)
                {
                    String codeName = this.CodeName(concept.Code);

                    if (this.codeSystems.TryGetValue(component.System, out CSInfo ci) == false)
                        throw new Exception($"CodeSystem {component.System} not found");
                    String codingReference = $"{this.CodeSystemName(ci)}.{codeName}";
                    fieldsBlock
                        .AppendCode($"public TCoding {codeName} = new TCoding({codingReference});")
                        ;
                    constructorBlock
                        .AppendCode($"this.Members.Add({codingReference});")
                        ;
                }
            }
        }

        void BuildValueSets()
        {
            foreach (VSInfo vi in this.valueSets.Values)
                BuildValueSet(vi);
        }

        void BuildCodeSystem(CSInfo ci)
        {
            CodeBlockNested csHdr = ci.ClassCode.Blocks.Find("Header");
            CodeBlockNested csFields = ci.ClassCode.Blocks.Find("Fields");

            csHdr
                .AppendCode($"public class {CodeSystemName(ci)}")
                ;

            csFields
                .AppendCode($"const string System = \"{ci.CodeSystem.Url}\";");
            ;

            if (ci.CodeSystem.Filter.Count > 0)
                throw new NotImplementedException("Have not implemented CodeSystem.Filter");

            foreach (CodeSystem.ConceptDefinitionComponent component in ci.CodeSystem.Concept)
            {
                String display = component.Display?.Replace("\"", "'");
                String code = component.Code;

                csFields
                    .BlankLine()
                    .AppendLine("/// <summary>")
                    ;
                if (component.Definition != null)
                {
                    foreach (String line in component.Definition.Split('\n'))
                    {
                        String s = line.Trim().Replace("\r", "").Replace("%", "\\%");
                        csFields.AppendLine($"/// {s}");
                    }
                }

                csFields
                    .AppendLine("/// </summary>")
                    .AppendCode($"public static Coding {CodeName(component.Code)} = new Coding(System, \"{code}\", \"{display}\");")
                    ;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        void BuildCodeSystems()
        {
            foreach (CSInfo ci in this.codeSystems.Values)
                BuildCodeSystem(ci);
        }

        void SaveAll()
        {
            foreach (FragInfo fi in this.sdFragments.Values)
            {
                Save(fi.InterfaceCode, Path.Combine(this.OutputDir, "Generated", "Interfaces", $"{InterfaceName(fi)}.cs"));
                if (fi.ClassCode != null)
                    Save(fi.ClassCode, Path.Combine(this.OutputDir, "Generated", "Class", $"{ClassName(fi)}.cs"));
            }

            foreach (CSInfo ci in this.codeSystems.Values)
                Save(ci.ClassCode, Path.Combine(this.OutputDir, "Generated", "CodeSystems", $"{CodeSystemName(ci)}.cs"));

            foreach (VSInfo vi in this.valueSets.Values)
                Save(vi.ClassCode, Path.Combine(this.OutputDir, "Generated", "ValueSets", $"{ValueSetName(vi)}.cs"));
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
            BuildLocalCodeSystems();
            BuildCodeSystems();
            BuildValueSets();
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
                        if (sdFragments.TryGetValue(extUrl.Value.Trim(), out FragInfo reference) == false)
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

        delegate void VisitFragment(FragInfo fi, Int32 level);

        void VisitFragments(VisitFragment vi,
            FragInfo fragBase)
        {
            HashSet<FragInfo> visitedFrags = new HashSet<FragInfo>();

            void Visit(VisitFragment vi,
                FragInfo fi,
                Int32 level)
            {
                if (visitedFrags.Contains(fi))
                    return;
                vi(fi, level);
                visitedFrags.Add(fi);
                foreach (FragInfo refFrag in fragBase.ReferencedFragments)
                    Visit(vi, refFrag, level + 1);
            }

            Visit(vi, fragBase, 0);
        }

        public void Dispose()
        {
            this?.fc.Dispose();
        }
    }
}
