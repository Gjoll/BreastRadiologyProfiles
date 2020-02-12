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

            this.ClassWriteCode
                .AppendCode($"ClearSection();")
                ;

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
                CodeableConcept sectionCode = (CodeableConcept) codeNode.ElementDefinition.Pattern;
                if (sectionCode.Coding.Count != 1)
                    throw new Exception("Invalid section code");
                Coding code = sectionCode.Coding[0];

                String[] references = this.References(entryNode);
                String reference;
                if (references.Length == 1)
                {
                    String url = references[0];
                    reference = url.LastUriPart();
                    if (url.Trim().ToLower().StartsWith("http://hl7.org/fhir/structuredefinition/"))
                        reference += "Base";
                }
                else
                    reference = "ResourceBase";

                Int32 max = ToMax(sectionSlice.ElementDefinition.Max);
                String propertyName = sliceName.ToMachineName();
                String sectionCodeName = $"{propertyName}SectionCode";

                this.ClassFields
                    .BlankLine()
                    .SummaryOpen()
                    .Summary($"Section {sliceName}")
                    .Summary($"{sectionSlice.ElementDefinition.ElementId}")
                    .SummaryClose()
                    .AppendCode($"Coding {sectionCodeName} = new Coding(\"{code.System}\", \"{code.Code}\");")
                    ;

                if (max == 1)
                {
                    this.ClassFields
                        .AppendCode($"public {reference} {propertyName} {{ get; set; }}")
                        ;

                    this.ClassReadCode
                        .BlankLine()
                        .AppendCode($"this.{propertyName} = ReadSection<{reference}>(resourceBag, this.{sectionCodeName});")
                        ;
                }
                else
                {
                    this.ClassFields
                        .AppendCode($"public List<{reference}> {propertyName} {{ get; }} = new List<{reference}>();")
                        ;

                    this.ClassReadCode
                        .AppendCode($"ReadSection<{reference}>(resourceBag, {sectionCodeName}, {sectionSlice.ElementDefinition.Min}, {max}, this.{propertyName});")
                        ;
                }

                this.ClassWriteCode
                    .AppendCode($"WriteSection<{reference}>(\"{title}\", {sectionCodeName}, {sectionSlice.ElementDefinition.Min}, {max}, this.{propertyName});")
                    ;

                if (max == 1)
                    this.InterfaceFields
                            .AppendCode($"{reference} {propertyName} {{ get; set; }}")
                        ;
                else
                    this.InterfaceFields
                            .AppendCode($"List<{reference}> {propertyName} {{ get; }}")
                        ;
            }
        }

        public override void Build()
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
