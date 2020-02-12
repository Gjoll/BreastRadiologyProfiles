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
        CodeEditor resourceFactoryEditor;
        CodeBlockNested resourceFactoryProfileBlock;

        public Dictionary<String, CSInfo> CodeSystems;
        public Dictionary<String, CSInfo> LocalCodeSystems;
        public Dictionary<String, VSInfo> ValueSets;
        public Dictionary<String, FragInfo> SDFragments;
        public List<FragInfo> orderedFragments;


        public String OutputDir { get; set; } = ".";
        public bool CleanFlag { get; set; } = false;
        FileCleaner fc = new FileCleaner();

        public CSBuilder()
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            this.CodeSystems = new Dictionary<string, CSInfo>(comparer);
            this.LocalCodeSystems = new Dictionary<string, CSInfo>(comparer);
            this.ValueSets = new Dictionary<string, VSInfo>(comparer);
            this.SDFragments = new Dictionary<string, FragInfo>(comparer);
        }

        public static String MachineName(String s)
        {
            return s.Replace("<", " Less Than ")
            .Replace(">", " Greater Than ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .ToMachineName();
        }
        public static String CodeName(string code) => $"Code_{MachineName(code)}";
        public static String InterfaceName(FragInfo fi) => $"I{MachineName(fi.StructDef.Name)}";
        public static String ClassName(FragInfo fi) => $"{MachineName(fi.StructDef.Name)}";
        public static String CodeSystemName(CSInfo ci) => $"{MachineName(ci.CodeSystem.Name)}";
        public static String ValueSetName(VSInfo vi) => $"{MachineName(vi.ValueSet.Name)}";
        public static String PropertyName(string name) => $"{MachineName(name)}";

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
                        CodeSystems.Add(cs.Url, ci);
                    }
                    break;

                case ValueSet vs:
                    {
                        VSInfo vi = new VSInfo
                        {
                            ValueSet = vs,
                            ClassCode = new CodeEditor()
                        };
                        vi.ClassCode.Load(Path.Combine("Templates", "ValueSet.txt"));
                        ValueSets.Add(vs.Url, vi);
                    }
                    break;

                case StructureDefinition sd:
                    {
                        ElementTreeLoader l = new ElementTreeLoader(this);

                        FragInfo fi = new FragInfo
                        {
                            StructDef = sd,
                            InterfaceEditor = new CodeEditor(),
                            DiffNodes = l.Create(sd.Differential.Element)
                        };
                        fi.InterfaceEditor.TryAddUserMacro("InterfaceName", InterfaceName(fi));
                        fi.InterfaceEditor.Load(Path.Combine("Templates", "Interface.txt"));

                        if (this.IsFragment(sd) == false)
                        {
                            fi.ClassEditor = new CodeEditor();
                            AddMacros(fi.ClassEditor, fi);
                            fi.ClassEditor.TryAddUserMacro("ClassName", ClassName(fi));
                            fi.ClassEditor.Load(Path.Combine("Templates", "Class.txt"));
                        }
                        this.SDFragments.Add(sd.Url.Trim(), fi);
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
            if (fi.ClassEditor != null)
            {
                String url = fi.StructDef.Url.Trim().ToLower();
                this.resourceFactoryProfileBlock
                    .AppendCode("case \"{url}\":")
                    .AppendCode("    break;")
                    ;
            }

            DefineInterfaces(fi);
            switch (fi.StructDef.BaseDefinition)
            {
                case Global.ObservationUrl:
                    {
                        CSDefineObservation def = new CSDefineObservation(this, fi);
                        def.Build();
                    }
                    break;

                case Global.CompositionUrl:
                    {
                        CSDefineComposition def = new CSDefineComposition(this, fi);
                        def.Build();
                    }
                    break;

                default:
                    this.ConversionError(this.GetType().Name,
                       fcn,
                       $"No builder defined for class {fi.StructDef.BaseDefinition}");
                    break;
            }
        }

        void AddMacros(CodeEditor ce,
            FragInfo fi)
        {
            ce.TryAddUserMacro("FhirBase", fi.StructDef.BaseDefinition.LastUriPart());
        }

        void DefineInterfaces(FragInfo fi)
        {
            StringBuilder interfaces = new StringBuilder();
            foreach (FragInfo refFrag in fi.ReferencedFragments)
            {
                interfaces.Append($", {InterfaceName(refFrag)}");
            }

            AddMacros(fi.InterfaceEditor, fi);
            fi.InterfaceEditor.TryAddUserMacro("Interfaces", interfaces.ToString());
            fi.InterfaceEditor.Blocks.Find("*Header").Reload();

            if (fi.ClassEditor != null)
            {
                AddMacros(fi.ClassEditor, fi);
                fi.ClassEditor.TryAddUserMacro("Interfaces", interfaces.ToString());
                fi.ClassEditor.Blocks.Find("*Header").Reload();
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

        /// <summary>
        /// Order fragments so that fragments that are dependent on another fragment come
        /// after that fragment in the list.
        /// Circular references will cause an error.
        /// </summary>
        void OrderFragments()
        {
            orderedFragments = new List<FragInfo>();
            Int32 index;

            // Return true if fi references fiRef.
            bool ReferencesFragment(FragInfo fi, FragInfo fiRef)
            {
                foreach (FragInfo temp in fi.ReferencedFragments)
                {
                    if (temp == fiRef)
                        return true;
                    // recursive search...
                    if (ReferencesFragment(temp, fiRef) == true)
                        return true;
                }
                return false;
            }

            Int32 Search(FragInfo fi)
            {
                Int32 retVal = 0;
                for (Int32 i = 0; i < orderedFragments.Count; i++)
                    if (ReferencesFragment(fi, orderedFragments[i]) == false)
                        break;
                return retVal;
            }

            foreach (FragInfo fi in this.SDFragments.Values)
            {
                index = Search(fi);
                orderedFragments.Insert(index, fi);
            }
        }

        void BuildFragments()
        {
            OrderFragments();
            foreach (FragInfo fi in this.orderedFragments)
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
                    if (this.CodeSystems.TryGetValue(component.System, out CSInfo ci) == false)
                    {
                        if (this.LocalCodeSystems.TryGetValue(component.System, out ci) == false)
                        {
                            ci = new CSInfo
                            {
                                CodeSystem = new CodeSystem
                                {
                                    Name = component.System.LastUriPart(),
                                    Url = component.System
                                }
                            };
                            this.LocalCodeSystems.Add(component.System, ci);
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
            foreach (VSInfo vi in this.ValueSets.Values)
                BuildLocalCodeSystem(vi);
            foreach (KeyValuePair<string, CSInfo> item in this.LocalCodeSystems)
                this.CodeSystems.Add(item.Key, item.Value);
            this.LocalCodeSystems = null;
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
                .AppendLine("/// This class creates a type for codings of this class, that implicitly converts to Coding")
                .AppendLine("/// Allows type checking for these codes.")
                .AppendLine("/// </summary>")
                 .AppendCode($"public class TCoding")
                .OpenBrace()
                .AppendCode($"Coding value;")
                .AppendCode($"public static implicit operator Coding(TCoding tCode)")
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
                    String codeName = CSBuilder.CodeName(concept.Code);

                    if (this.CodeSystems.TryGetValue(component.System, out CSInfo ci) == false)
                        throw new Exception($"CodeSystem {component.System} not found");
                    String codingReference = $"{CSBuilder.CodeSystemName(ci)}.{codeName}";
                    fieldsBlock
                        .AppendCode($"public TCoding {codeName} = new TCoding({codingReference});")
                        ;
                    constructorBlock
                        .AppendCode($"this.Members.Add(this.{codeName});")
                        ;
                }
            }
        }

        void BuildValueSets()
        {
            foreach (VSInfo vi in this.ValueSets.Values)
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
            foreach (CSInfo ci in this.CodeSystems.Values)
                BuildCodeSystem(ci);
        }

        void SaveAll()
        {
            this.resourceFactoryEditor.Save();
            this.fc.Mark(this.resourceFactoryEditor.SavePath);
            foreach (FragInfo fi in this.SDFragments.Values)
            {
                Save(fi.InterfaceEditor, Path.Combine(this.OutputDir, "Generated", "Interfaces", $"{InterfaceName(fi)}.cs"));
                if (fi.ClassEditor != null)
                    Save(fi.ClassEditor, Path.Combine(this.OutputDir, "Generated", "Class", $"{ClassName(fi)}.cs"));
            }

            foreach (CSInfo ci in this.CodeSystems.Values)
                Save(ci.ClassCode, Path.Combine(this.OutputDir, "Generated", "CodeSystems", $"{CodeSystemName(ci)}.cs"));

            foreach (VSInfo vi in this.ValueSets.Values)
                Save(vi.ClassCode, Path.Combine(this.OutputDir, "Generated", "ValueSets", $"{ValueSetName(vi)}.cs"));
        }

        public void Build()
        {
            this.resourceFactoryEditor = new CodeEditor();
            this.resourceFactoryEditor.Load(Path.Combine(this.OutputDir, "Generated", "ResourceFactory.cs"));
            this.resourceFactoryProfileBlock = this.resourceFactoryEditor.Blocks.Find("Profile");
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

            foreach (FragInfo fi in this.SDFragments.Values)
            {
                foreach (Extension e in fi.StructDef.Extension.ToArray())
                {
                    if (e.Url.ToLower().Trim() == Global.FragmentUrl)
                    {
                        FhirUrl extUrl = (FhirUrl)e.Value;
                        if (SDFragments.TryGetValue(extUrl.Value.Trim(), out FragInfo reference) == false)
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

        public void Dispose()
        {
            this?.fc.Dispose();
        }
    }
}
