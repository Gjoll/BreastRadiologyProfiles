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
    class CSDefineComposition : CSDefineBase
    {
        public CSDefineComposition(CSBuilder csBuilder,
                    FragInfo fragBase) : base(csBuilder, fragBase)
        {
        }

        void DefineSections()
        {
            Int32 ToMax(String max)
            {
                if (max == "*")
                    return -1;
                return Int32.Parse(max);
            }

            if (this.fragBase.DiffNodes.TryGetElementNode("Composition.section", out ElementTreeNode sectionNode) == false)
                return;

            foreach (ElementTreeSlice sectionSlice in sectionNode.Slices.Skip(1))
            {
                String sliceName = sectionSlice.ElementDefinition.SliceName;

                ElementTreeNode GetChild(String name)
                {
                    if (this.fragBase.DiffNodes.TryGetElementNode($"{sectionSlice.ElementDefinition.ElementId}.{name}", out ElementTreeNode n) == false)
                        throw new Exception($"Cant find child {name}");
                    return n;
                }
                ElementTreeNode titleNode = GetChild("title");
                ElementTreeNode codeNode = GetChild("code");
                ElementTreeNode entryNode = GetChild("entry");

                String title = titleNode.ElementDefinition.Fixed.ToString();
                Coding code = codeNode.ElementDefinition.Pattern as Coding;

                String[] references = this.References(entryNode);
                String reference;
                if (references.Length == 1)
                    reference = references[0].LastUriPart();
                else
                    reference = "DomainResource";

                this.ClassFields
                    .BlankLine()
                    .SummaryOpen()
                    .Summary($"Section {sliceName}")
                    .Summary($"{sectionSlice.ElementDefinition.ElementId}")
                    .SummaryClose()
                    .AppendCode($"public SectionList<{reference}> {sliceName.ToMachineName()} {{ get; }}");
                ;

                this.ClassConstructor
                    .BlankLine()
                    .AppendCode($"{sliceName.ToMachineName()} = new SectionList<{reference}>(\"{title}\",")
                    .AppendCode($"        new Coding(\"{code.System}\", \"{code.Code}\"),")
                    .AppendCode($"        {sectionSlice.ElementDefinition.Min},")
                    .AppendCode($"        {ToMax(sectionSlice.ElementDefinition.Max)});")
                ;

                this.InterfaceFields
                    .AppendCode($"SectionList<{reference}> {sliceName.ToMachineName()} {{ get; }}");
                ;
            }
        }

        public void Build()
        {
            const String fcn = "Build";

            this.csBuilder.ConversionInfo(this.GetType().Name,
               fcn,
               $"Building {fragBase.StructDef.Url.LastUriPart()}");

            this.ClassFields.Clear();
            this.ClassMethods.Clear();
            this.ClassConstructor.Clear();

            this.InterfaceFields.Clear();
            this.InterfaceMethods.Clear();
            this.MergeFragments();
            DefineSections();
            this.csBuilder.ConversionInfo(this.GetType().Name,
               fcn,
               $"Completed {fragBase.StructDef.Url.LastUriPart()}");
        }
    }
}
