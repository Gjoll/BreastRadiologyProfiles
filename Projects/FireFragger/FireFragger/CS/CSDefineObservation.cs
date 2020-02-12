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
    /// <summary>
    /// Perform Observation specific build
    /// </summary>
    class CSDefineObservation : CSDefineBase
    {
        public CSDefineObservation(CSBuilder csBuilder,
                    FragInfo fragBase) : base(csBuilder, fragBase)
        {
        }

        void DefineHasMembers(FragInfo fragInfo)
        {
            List<String> interfaceFields = new List<string>();
            List<String> classFields = new List<string>();
            List<String> classInstantiations = new List<string>();

            HashSet<string> items = new HashSet<string>();

            void BuildSlice(FragInfo fi, ElementTreeSlice slice, Int32 level)
            {
                if (slice.ElementDefinition.Type.Count != 1)
                    throw new Exception($"invalid hasMember type count");
                if (slice.ElementDefinition.Type[0].Code != "Reference")
                    throw new Exception($"invalid hasMember type");
                if (slice.ElementDefinition.Type[0].TargetProfile.Count() != 1)
                    throw new Exception($"invalid hasMember targetProfile count");
                String reference = slice.ElementDefinition.Type[0].TargetProfile.First();
                if (this.csBuilder.SDFragments.TryGetValue(reference.Trim(), out FragInfo refFrag) == false)
                    throw new Exception($"missing hasMember reference {reference}");
                if (items.Contains(slice.Name))
                    return;

                items.Add(slice.Name);
                String refClassName = CSBuilder.ClassName(refFrag);
                String refInterfaceName = CSBuilder.InterfaceName(refFrag);
                String fieldName = CSBuilder.PropertyName(slice.Name);

                classFields.Add($"public MemberList<{refInterfaceName}> {fieldName} {{get;}}");
                if (level == 0)
                    interfaceFields.Add($"MemberList<{refInterfaceName}> {fieldName} {{get;}}");

                Int32 min = 0;
                if (slice.ElementDefinition.Min.HasValue)
                    min = slice.ElementDefinition.Min.Value;
                Int32 max = -1;
                if (String.IsNullOrEmpty(slice.ElementDefinition.Max) == false)
                {
                    if (slice.ElementDefinition.Max != "*")
                        max = Int32.Parse(slice.ElementDefinition.Max);
                }
                classInstantiations.Add($"this.{fieldName} = CreateHasMemberList<{refInterfaceName}>({min}, {max});");
            }

            void Build(FragInfo fi, Int32 level)
            {
                if (fi.BaseDefinitionUrl != Global.ObservationUrl)
                    return;
                if (fi.DiffNodes.TryGetElementNode("Observation.hasMember", out ElementTreeNode hasMemberNode) == false)
                    return;
                if (hasMemberNode.Slices.Count <= 1)
                    return;
                foreach (ElementTreeSlice slice in hasMemberNode.Slices.Skip(1))
                    BuildSlice(fi, slice, level);
            }

            if (fragInfo.ClassEditor == null)
                return;

            VisitFragments(Build, fragInfo);

            if (classFields.Count == 0)
                return;

            {
                CodeEditor hasMemberClassFrag = new CodeEditor();
                hasMemberClassFrag.Load(Path.Combine("Templates", "HasMemberClassFrag.txt"));
                fragInfo.ClassEditor.AddUserMacro("HasMemberFields", classFields);
                fragInfo.ClassEditor.AddUserMacro("HasMemberDefinitions", classInstantiations);
                CodeBlockMerger cbm = new CodeBlockMerger(fragInfo.ClassEditor);
                cbm.Merge(hasMemberClassFrag);
            }

            {
                CodeEditor hasMemberInterfaceFrag = new CodeEditor();
                hasMemberInterfaceFrag.Load(Path.Combine("Templates", "HasMemberInterfaceFrag.txt"));
                fragInfo.InterfaceEditor.AddUserMacro("HasMemberFields", interfaceFields);
                CodeBlockMerger cbm = new CodeBlockMerger(fragInfo.InterfaceEditor);
                cbm.Merge(hasMemberInterfaceFrag);
            }
        }

        public override void Build()
        {
            DefineHasMembers(this.fragBase);
        }
    }
}
