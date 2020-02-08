using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Specification.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using PreFhir;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Model;
using System.Collections.Generic;
using BreastRadiology.XUnitTests;
using System.Drawing;
using ExcelDataReader;
using System.Data;
using System.Globalization;
using System.Linq;
using BreastRadiology.Shared;
using Newtonsoft.Json.Linq;

namespace BreastRadiology.XUnitTests
{
    class Info : IConversionInfo
    {
        void Msg(String import, string className, string method, string msg)
        {
            Trace.WriteLine($"{import} [{className}.{method}] '{msg}'");
        }

        public void ConversionError(string className, string method, string msg) => Msg("Err", className, method, msg);

        public void ConversionInfo(string className, string method, string msg) => Msg("Info", className, method, msg);

        public void ConversionWarn(string className, string method, string msg) => Msg("Warn", className, method, msg);
    }

    [TestClass]
    public sealed class BuildGG
    {
        const String BaseDirName = "BreastRadiologyProfiles";

        String BaseDir
        {
            get
            {
                if (this.baseDirFull == null)
                    this.baseDirFull = DirHelper.FindParentDir(BaseDirName);
                return this.baseDirFull;
            }
        }

        String baseDirFull;

        ExcelData spreadSheetData;

        Int32 ICD10Col => this.spreadSheetData.icd10Col;
        Int32 DicomCol => this.spreadSheetData.dicomCol;
        Int32 SnomedCol => this.spreadSheetData.snoMedCol;
        Int32 SnomedDescriptionCol => this.spreadSheetData.snoMedDescriptionCol;
        Int32 ACRCol => this.spreadSheetData.acrCol;
        Int32 UMLSCol => this.spreadSheetData.umlsCol;

        public BuildGG()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);
        }

        String CodeValue(String value)
        {
            value = value.Trim();
            while (true)
            {
                Int32 j = value.IndexOf(' ', new StringComparison());
                if (j < 0)
                    break;
                String temp = value.Substring(0, j);
                while (value[j] == ' ')
                    j += 1;
                temp += Char.ToUpper(value[j], CultureInfo.InvariantCulture);
                temp += value.Substring(j + 1);
                value = temp;
            }

            return value;
        }

        void AppIfNotNull(CodeBlockNested concept, String name, Object value)
        {
            if (value is System.DBNull)
                return;

            String sValue = value.ToString();
            sValue = sValue.Trim()
                    .Replace("\r", "")
                    .Replace("\n", "")
                ;
            if (String.IsNullOrEmpty(sValue) == false)
            {
                String[] lines = FormatMultiLineText(sValue).ToArray();
                if (lines.Length == 1)
                {
                    concept
                        .AppendLine($"    .{name}({lines[0]})");
                }
                else
                {
                    concept
                        .AppendLine($"    .{name}({lines[0]}");
                    Int32 i = 1;
                    while (i < lines.Length - 1)
                        concept.AppendLine($"        {lines[i++]}");
                    concept.AppendLine($"        {lines[i]})");
                }
            }
        }

        public void WriteCS(DataSet ds,
            String sheetName,
            String outputCodePath,
            String csBlockName,
            List<String> itemsToIgnore = null)
        {
            if (itemsToIgnore == null)
                itemsToIgnore = new List<string>();

            String App(String s, Object t, String sb)
            {
                switch (t)
                {
                    case DBNull dbNullValue:
                        return s;

                    case String stringValue:
                        // verify we have correct column.
                        if (stringValue != sb)
                            Trace.WriteLine($"Invalid Modality '{stringValue}'. Expected {sb}");
                        if (String.IsNullOrEmpty(s) == false)
                            s += " | ";
                        s += $"Modalities.{sb}";
                        return s;

                    default:
                        throw new Exception("Invalid excel cell value");
                }
            }


            DataTable dataTbl = ds.Tables[sheetName];
            if (dataTbl == null)
                throw new Exception($"Table {sheetName} not found");

            CodeEditor editor = new CodeEditor();
            editor.Load(Path.Combine(DirHelper.FindParentDir("BreastRadiology.XUnitTests"),
                "ResourcesMaker",
                outputCodePath));
            CodeBlockNested concepts = editor.Blocks.Find(csBlockName);
            if (concepts == null)
                throw new Exception($"Can not find editor block {csBlockName}");

            for (Int32 i = 1; i < dataTbl.Rows.Count; i++)
            {
                DataRow row = dataTbl.Rows[i];
                String code = row[this.spreadSheetData.itemNameCol].ToString();
                if (itemsToIgnore.Contains(code.Trim().ToUpper()) == false)
                {
                    String validWith = App("", row[this.spreadSheetData.mgCol], "MG");
                    ;
                    validWith = App(validWith, row[this.spreadSheetData.mriCol], "MRI");
                    validWith = App(validWith, row[this.spreadSheetData.nmCol], "NM");
                    validWith = App(validWith, row[this.spreadSheetData.usCol], "US");

                    String conceptBlockName = CodeValue(code);

                    String penId = row[this.spreadSheetData.idMammoCol].ToString();

                    concepts
                        .AppendLine($"new ConceptDef()")
                        .AppendLine($"    .SetCode(\"{conceptBlockName}\")")
                        .AppendLine($"    .SetDisplay(\"{code}\")")
                        //.AppendLine($"    .SetDefinition(\"[PR] {code}\")")
                        .AppendLine($"    .MammoId(\"{penId}\")")
                        .AppendLine($"    .ValidModalities({validWith})")
                        ;

                    AppIfNotNull(concepts, "SetDicom", row[DicomCol]);
                    AppIfNotNull(concepts, "SetSnomedCode", row[SnomedCol]);
                    //AppIfNotNull(concepts, "SetOneToMany", row[12]);
                    AppIfNotNull(concepts, "SetSnomedDescription", row[SnomedDescriptionCol]);
                    //AppIfNotNull(concepts, "SetICD10", row[ICD10Col]);
                    AppIfNotNull(concepts, "SetUMLS", row[UMLSCol]);
                    AppIfNotNull(concepts, "SetACR", row[ACRCol]);

                    if (i < dataTbl.Rows.Count - 1)
                        concepts
                            .AppendLine($",");
                }
            }

            editor.Save();
        }

        IEnumerable<String> FormatMultiLineText(String text)
        {
            const Int32 Maxlen = 48;
            Int32 i = 0;
            Int32 len = 0;

            StringBuilder sb = new StringBuilder();

            void PutEoln()
            {
                sb.Append("\",\n\"");
                len = 0;
            }

            sb.Append("\"");
            while (i < text.Length)
            {
                void Add(Char c)
                {
                    sb.Append(c);
                    len += 1;
                }

                Char c = text[i++];
                switch (c)
                {
                    case '“':
                    case '”':
                    case '\"':
                        sb.Append("\\\"");
                        break;

                    case '\r':
                        break;

                    case '.':
                        Add(c);
                        if ((i < text.Length) && (text[i] == ' '))
                        {
                            i += 1;
                            Add(' ');
                            PutEoln();
                        }

                        break;

                    case '\n':
                        if (len > 0)
                            PutEoln();
                        break;

                    case ' ':
                        Add(c);
                        if (len > Maxlen)
                        {
                            sb.Append("\" +\n\"");
                            len = 0;
                        }

                        break;

                    default:
                        Add(c);
                        break;
                }
            }

            sb.Append("\"");
            return sb.ToString().Split('\n');
        }

        void WriteIds(String outputCodePath,
            String csBlockName,
            params String[] penIds)
        {
            WriteIds(outputCodePath, csBlockName, (IEnumerable<String>)penIds);
        }

        String FormatCode(String s)
        {
            Int32 index = s.ToUpper().IndexOf(" ADD PREFIX");
            if (index >= 0)
            {
                String text = s.Substring(0, index);
                String prefix = s.Substring(index + 11).Trim();
                prefix = prefix.ToMachineName();
                s = $"{prefix} {text}";
            }

            index = s.ToUpper().IndexOf("(SPELL");
            if (index >= 0)
                s = s.Substring(0, index);

            index = s.ToUpper().IndexOf("SPELL");
            if (index >= 0)
                s = s.Substring(0, index);
            return s.Trim();
        }

        void WriteIds(String outputCodePath,
            String csBlockName,
            IEnumerable<String> penIdsEnum)
        {
            String[] penIds = penIdsEnum.ToArray();

            CodeEditor editor = new CodeEditor();
            editor.Load(Path.Combine(DirHelper.FindParentDir("BreastRadiology.XUnitTests"),
                "ResourcesMaker",
                outputCodePath));

            CodeBlockNested concepts = editor.Blocks.Find(csBlockName);
            if (concepts == null)
                throw new Exception($"Can not find editor block {csBlockName}");

            concepts.Clear();
            for (Int32 i = 0; i < penIds.Length; i++)
            {
                String penId = penIds[i];

                if (this.spreadSheetData.TryGetRow(penId, out DataRow row) == false)
                    throw new Exception($"Missing value for penid '{penId}'");

                String code = FormatCode(row[this.spreadSheetData.itemNameCol].ToString());
                String conceptBlockName = CodeValue(code);

                String App(String s, Object t, String sb)
                {
                    switch (t)
                    {
                        case DBNull dbNullValue:
                            return s;

                        case String stringValue:
                            // verify we have correct column.
                            if (stringValue != sb)
                                Trace.WriteLine($"Invalid Modality '{stringValue}'. Expected {sb}");
                            if (String.IsNullOrEmpty(s) == false)
                                s += " | ";
                            s += $"Modalities.{sb}";
                            return s;

                        default:
                            throw new Exception("Invalid excel cell value");
                    }
                }

                String validWith = App("", row[this.spreadSheetData.mgCol], "MG");
                ;
                validWith = App(validWith, row[this.spreadSheetData.mriCol], "MRI");
                validWith = App(validWith, row[this.spreadSheetData.nmCol], "NM");
                validWith = App(validWith, row[this.spreadSheetData.usCol], "US");

                concepts
                    .AppendLine($"new ConceptDef()")
                    .AppendLine($"    .SetCode(\"{conceptBlockName}\")")
                    .AppendLine($"    .SetDisplay(\"{code}\")")
                    //.AppendLine($"    .SetDefinition(\"[PR] {code}\")")
                    .AppendLine($"    .MammoId(\"{penId}\")")
                    .AppendLine($"    .ValidModalities({validWith})")
                    ;

                AppIfNotNull(concepts, "SetDicom", row[DicomCol]);
                AppIfNotNull(concepts, "SetSnomedCode", row[SnomedCol]);
                //AppIfNotNull(concepts, "SetOneToMany", row[13]);
                AppIfNotNull(concepts, "SetSnomedDescription", row[SnomedDescriptionCol]);
                //AppIfNotNull(concepts, "SetICD10", row[ICD10Col]);
                AppIfNotNull(concepts, "SetUMLS", row[UMLSCol]);
                AppIfNotNull(concepts, "SetACR", row[ACRCol]);
                if (i < penIds.Length - 1)
                    concepts
                        .AppendLine($",");
            }
            editor.Save();
        }

        IEnumerable<String> Filter(String listBoxName,
            String structure)
        {
            List<String> retVal = new List<string>();

            bool IsMatch(DataRow dr)
            {
                if (dr[this.spreadSheetData.listBoxNameCol].ToString() != listBoxName)
                    return false;
                if (dr[this.spreadSheetData.structureCol].ToString() != structure)
                    return false;
                return true;
            }

            foreach (KeyValuePair<String, DataRow> item in this.spreadSheetData.rows)
            {
                if (IsMatch(item.Value))
                    retVal.Add(item.Key);
            }
            return retVal.ToArray();
        }

        List<String> FormatText(String text)
        {
            const Int32 Maxlen = 80;
            Int32 i = 0;
            Int32 len = 0;

            StringBuilder sb = new StringBuilder();

            void PutEoln()
            {
                sb.Append("\n");
                len = 0;
            }

            while (i < text.Length)
            {
                void Add(Char c)
                {
                    sb.Append(c);
                    len += 1;
                }

                Char c = text[i++];
                switch (c)
                {
                    case '“':
                    case '”':
                    case '\"':
                        sb.Append("\"");
                        break;

                    case '\r':
                        break;

                    case '.':
                        Add(c);
                        if ((i < text.Length) && (text[i] == ' '))
                        {
                            i += 1;
                            Add(' ');
                            PutEoln();
                        }

                        break;

                    case '\n':
                        if (len > 0)
                            PutEoln();
                        break;

                    case ' ':
                        Add(c);
                        if (len > Maxlen)
                            PutEoln();

                        break;

                    default:
                        Add(c);
                        break;
                }
            }
            List<String> retVal = sb.ToString().Split('\n').ToList();
            while ((retVal.Count > 0) && (String.IsNullOrWhiteSpace(retVal[^1])))
                retVal.RemoveAt(retVal.Count - 1);
            return retVal;
        }
        [TestMethod]
        public void Cleanup()
        {
            ExcelData source;

            bool IsGargage(String text)
            {
                text = text.ToUpper();
                if ((text.Length == 0) || (text[0] != 'C'))
                    return false;
                for (Int32 i = 1; i < text.Length; i++)
                    if (Char.IsDigit(text[i]) == false)
                        return false;
                return true;
            }

            bool FixCitations(String text, out String text2, out String citation)
            {
                bool FindAnchor(String anchor, out String t2, out String c)
                {
                    t2 = null;
                    c = null;
                    Int32 i = text.ToUpper().IndexOf(anchor);
                    if (i < 0)
                        return false;
                    t2 = text.Substring(0, i);
                    c = text.Substring(i).Trim();
                    return true;
                }

                if (FindAnchor("HTTP://", out text2, out citation))
                {
                    citation = $"###URL#{citation}";
                }
                else if (FindAnchor("HTTPS://", out text2, out citation))
                {
                    citation = $"###URL#{citation}";
                    return true;
                }
                else if (FindAnchor("FIFTH EDITION", out text2, out citation))
                {
                    Int32 index = citation.ToUpper().IndexOf("PG");
                    if (index > 0)
                        citation = $"###ACRMG#{citation.Substring(index + 2).Trim()}";
                    else
                        citation = $"###ACRUS#";
                    return true;
                }
                else if (FindAnchor("SECOND ADDITION", out text2, out citation))
                {
                    String name;
                    if (citation.Contains("Ultrasound"))
                        name = "ACRUS";
                    else if (citation.Contains("Magnetic Resonance Imaging"))
                        name = "ACRMRI";
                    else
                        Debugger.Break();

                    Int32 index = citation.ToUpper().IndexOf("PG");
                    if (index > 0)
                        citation = $"###ACRUS#{citation.Substring(index+2).Trim()}";
                    else
                        citation = $"###ACRUS#";
                    return true;
                }
                return false;
            }

            void CleanupUMLS(DataRow row)
            {
                String text = row[source.umlsCol].ToString();
                if (IsGargage(text))
                    text = "";

                if (FixCitations(text, out String text2, out String citation) == true)
                    text = text2;
                List<String> lines = FormatText(text).ToList();
                StringBuilder sb = new StringBuilder();
                for (Int32 i = 0; i < lines.Count; i++)
                    sb.AppendLine(lines[i]);
                if (String.IsNullOrEmpty(citation) == false) 
                    sb.AppendLine(citation);
                row[source.umlsCol] = sb.ToString();
            }

            String baseDir = DirHelper.FindParentDir("BreastRadiologyProfiles");
            String filePath = Path.Combine(baseDir,
                "..",
                "BRDocs",
                "BreastData.xlsx");
            source = new ExcelData(new Info(), filePath, "Sheet3");

            foreach (DataRow row in source.rows.Values)
            {
                CleanupUMLS(row);
            }
            source.Save();
        }


        [TestMethod]
        public void WriteCode()
        {
            this.ReadGregDS();

            WriteIds(@"Common\Abnormalities\AbnormalityCyst.cs", "Type", "69", "610", "657", "617", "636", "609", "661");
            WriteIds(@"Common\Abnormalities\AbnormalityDuct.cs", "Type", "694.602", "693.614");
            WriteIds(@"Common\Abnormalities\AbnormalityFibroAdenoma.cs", "Type", "70", "695");
            WriteIds(@"Common\Abnormalities\AbnormalityLymphNode.cs", "Type", "648", "649", "662", "665", "650", "651", "652", "666", "663");
            WriteIds(@"Common\Abnormalities\AbnormalityMass.cs", "Type", "58", "621", "697", "613", "608");
            WriteIds(@"Common\Abnormalities\AbnormalityForeignObject.cs", "Type", Filter("Finding foreign body", "foreign body"));

            WriteIds(@"Common\ServiceRecommendation.cs", "Codes", Filter("Recommendations", "Recommendation"));
            WriteIds(@"Common\CorrespondsWithCS.cs", "Codes", Filter("Corresponds", "Corrosponds with"));
            WriteIds(@"Common\ConsistentWith.cs", "Codes", Filter("Classification Consistent with", "Consistent with"));
            WriteIds(@"Common\ConsistentWith.cs", "Qualifiers", Filter("Classification Consistent with", "Consistent qualifier"));
            WriteIds(@"Common\NotPreviouslySeenCS.cs", "Codes", Filter("Not Prev Seen On", "not previous seen"));
            WriteIds(@"Common\MarginCS.cs", "Codes", Filter("Profile Abnormality", "margin"));
            WriteIds(@"Common\OrientationCS.cs", "Codes", Filter("Size and Distance", "Orientation"));
            WriteIds(@"Common\PreviouslyDemonstratedBy.cs", "Codes", Filter("Dem. By Prior", "previous demostrated by"));
            WriteIds(@"Common\ShapeCS.cs", "Codes", Filter("Profile Abnormality", "shape"));
            WriteIds(@"Common\ObservedChangesCS.cs", "Codes", Filter("Change From Prior", "Change From Prior"));
            WriteIds(@"Common\CalcificationDistributionCS.cs", "Codes", Filter("Assoc Calcs distribution", "calcification distribution"));

            WriteIds(@"FindingMG\MGAbnormalityAsymmetry.cs", "Type", "691", "643", "644", "Row542");
            WriteIds(@"FindingMG\MGAbnormalityDensity.cs", "Type", "686", "645", "646", "647");
            WriteIds(@"FindingMG\MGAbnormalityCalcification.cs", "Type", Filter("Assoc Calcs", "calcification type"));
            WriteIds(@"FindingMG\MGDensity.cs", "Codes", Filter("Profile Abnormality", "density"));
            WriteIds(@"FindingMG\MGBreastDensity.cs", "Codes", Filter("", "MG Breast Density"));

            {
                List<String> itemsToIgnore = new List<string>();
                itemsToIgnore.Add("ARCHITECTURAL DISTORTION");
                //WriteCS(ds, "AssocFindings", @"Common\AssociatedFeatures\ObservedFeature.cs", "ObservedFeatureCS", itemsToIgnore);
                WriteIds(@"Common\AssociatedFeatures\ObservedFeature.cs", "ObservedFeatureCS",
                    Filter("Associated findings", "Associated findings").Remove(itemsToIgnore));
            }
        }

        public void ReadGregDS()
        {
            String filePath = Path.Combine(BaseDir,
                "..",
                "BRDocs",
                "BreastData.xlsx");
            this.spreadSheetData = new ExcelData(new Info(), filePath, "Sheet3");
        }
    }
    public static class Extensions
    {
        public static IEnumerable<String> Remove(this IEnumerable<String> values,
            List<String> itemsToIgnore)
        {
            foreach (String value in values)
            {
                if (itemsToIgnore.Contains(value.Trim().ToUpper()) == false)
                    yield return value;
            }
        }
    }
}
