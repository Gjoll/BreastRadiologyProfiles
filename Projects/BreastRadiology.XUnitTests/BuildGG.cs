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
using Newtonsoft.Json.Linq;

namespace BreastRadiology.XUnitTests
{
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


        public BuildGG()
        {
        }

        String CodeValue(String value)
        {
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
            CodeBlockNested concept = null;

            for (Int32 i = 1; i < dataTbl.Rows.Count; i++)
            {
                String term = ",";
                if (i == dataTbl.Rows.Count - 1)
                    term = "";

                DataRow row = dataTbl.Rows[i];
                String code = row[7].ToString();
                if (itemsToIgnore.Contains(code.Trim().ToUpper()) == false)
                {
                    String validWith = App("", row[0], "MG");
                    ;
                    validWith = App(validWith, row[1], "MRI");
                    validWith = App(validWith, row[2], "NM");
                    validWith = App(validWith, row[3], "US");

                    String conceptBlockName = CodeValue(code);
                    CodeBlockNested conceptOuter = concepts.Find(conceptBlockName);
                    if (conceptOuter == null)
                    {
                        conceptOuter = concepts.AppendBlock(conceptBlockName);
                        concept = conceptOuter.AppendBlock("AutoGen");
                        conceptOuter
                            .AppendLine(term)
                            ;
                    }
                    else
                    {
                        concept = conceptOuter.Find("AutoGen");
                        concept.Clear();
                    }

                    String penId = row[4].ToString();

                    concept
                        .AppendLine($"new ConceptDef()")
                        .AppendLine($"    .SetCode(\"{conceptBlockName}\")")
                        .AppendLine($"    .SetDisplay(\"{code}\")")
                        .AppendLine($"    .SetDefinition(\"[PR] {code}\")")
                        .AppendLine($"    .MammoId(\"{penId}\")")
                        .AppendLine($"    .ValidModalities({validWith})")
                        ;

                    AppIfNotNull(concept, "SetDicom", row[9]);
                    AppIfNotNull(concept, "SetSnomedCode", row[11]);
                    AppIfNotNull(concept, "SetOneToMany", row[12]);
                    AppIfNotNull(concept, "SetSnomedDescription", row[13]);
                    AppIfNotNull(concept, "SetICD10", row[14]);
                    AppIfNotNull(concept, "SetComment", row[15]);
                    AppIfNotNull(concept, "SetUMLS", row[16]);
                }
            }

            editor.Save();
        }

        Dictionary<String, DataRow> sheet3 = new Dictionary<string, DataRow>();

        void LoadSheet3(DataSet ds)
        {
            DataTable dataTbl = ds.Tables["Sheet3"];
            if (dataTbl == null)
                throw new Exception($"Table {"Sheet3"} not found");

            void DoRow(DataRow row)
            {
                String penId = row[5].ToString().Trim();
                if (penId == "?????")
                    return;
                if (penId.Length == 0)
                    return;

                if (sheet3.TryAdd(penId, row) == false)
                    Trace.WriteLine($"Duplicate PenId {penId}");
            }

            for (Int32 i = 1; i < dataTbl.Rows.Count; i++)
            {
                DataRow row = dataTbl.Rows[i];
                DoRow(row);
            }
        }

        IEnumerable<String> FormatMultiLineText(String text)
        {
            const Int32 Maxlen = 48;
            Int32 i = 0;
            Int32 len = 0;

            StringBuilder sb = new StringBuilder();
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

                    case '\n':
                        if (len > 0)
                        {
                            sb.Append("\",\n\"");
                            len = 0;
                        }

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

        void WriteIds(String outputCodePath,
            String csBlockName,
            IEnumerable<String> penIdsEnum)
        {
            String[] penIds = penIdsEnum.ToArray();
            CodeBlockNested concept = null;

            CodeEditor editor = new CodeEditor();
            editor.Load(Path.Combine(DirHelper.FindParentDir("BreastRadiology.XUnitTests"),
                "ResourcesMaker",
                outputCodePath));

            CodeBlockNested concepts = editor.Blocks.Find(csBlockName);
            if (concepts == null)
                throw new Exception($"Can not find editor block {csBlockName}");

            for (Int32 i = 0; i < penIds.Length; i++)
            {
                String term = ",";
                if (i == penIds.Length - 1)
                    term = "";

                String penId = penIds[i];

                if (this.sheet3.TryGetValue(penId, out DataRow row) == false)
                    throw new Exception($"Missing value for penid '{penId}'");

                String code = row[8].ToString();
                String conceptBlockName = CodeValue(code);
                CodeBlockNested conceptOuter = concepts.Find(conceptBlockName);
                if (conceptOuter == null)
                {
                    conceptOuter = concepts.AppendBlock(conceptBlockName);
                    concept = conceptOuter.AppendBlock("AutoGen");
                    conceptOuter
                        .AppendLine(term)
                        ;
                }
                else
                {
                    concept = conceptOuter.Find("AutoGen");
                    concept.Clear();
                }

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

                String validWith = App("", row[1], "MG");
                ;
                validWith = App(validWith, row[2], "MRI");
                validWith = App(validWith, row[3], "NM");
                validWith = App(validWith, row[4], "US");

                concept
                    .AppendLine($"new ConceptDef()")
                    .AppendLine($"    .SetCode(\"{conceptBlockName}\")")
                    .AppendLine($"    .SetDisplay(\"{code}\")")
                    .AppendLine($"    .SetDefinition(\"[PR] {code}\")")
                    .AppendLine($"    .MammoId(\"{penId}\")")
                    .AppendLine($"    .ValidModalities({validWith})")
                    ;

                AppIfNotNull(concept, "SetDicom", row[10]);
                AppIfNotNull(concept, "SetSnomedCode", row[12]);
                AppIfNotNull(concept, "SetOneToMany", row[13]);
                AppIfNotNull(concept, "SetSnomedDescription", row[14]);
                AppIfNotNull(concept, "SetICD10", row[15]);
                AppIfNotNull(concept, "SetComment", row[16]);
                AppIfNotNull(concept, "SetUMLS", row[17]);
            }
            editor.Save();
        }

        IEnumerable<String> Filter(String listBoxName,
            String structure)
        {
            List<String> retVal = new List<string>();

            bool IsMatch(DataRow dr)
            {
                if (dr[6].ToString() != listBoxName)
                    return false;
                if (dr[7].ToString() != structure)
                    return false;
                return true;
            }

            foreach (KeyValuePair<String, DataRow> item in this.sheet3)
            {
                if (IsMatch(item.Value))
                    retVal.Add(item.Key);
            }
            return retVal.ToArray();
        }


        [TestMethod]
        public void WriteCode()
        {
            DataSet ds = this.ReadGregDS();
            LoadSheet3(ds);

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
            WriteIds(@"Common\MarginCS.cs", "MarginCS", Filter("Profile Abnormality", "margin"));
            WriteIds(@"Common\OrientationCS.cs", "Codes", Filter("Size and Distance", "Orientation"));
            WriteIds(@"Common\ShapeCS.cs", "Codes", Filter("Profile Abnormality", "shape"));
            WriteIds(@"Common\ObservedChangesCS.cs", "Codes", Filter("Change From Prior", "Change From Prior"));

            WriteIds(@"FindingMG\MGBreastDensity.cs", "Codes", Filter("Profile Abnormality", "density"));

            {
                List<String> itemsToIgnore = new List<string>();
                itemsToIgnore.Add("ARCHITECTURAL DISTORTION");
                //WriteCS(ds, "AssocFindings", @"Common\AssociatedFeatures\ObservedFeature.cs", "ObservedFeatureCS", itemsToIgnore);
                WriteIds(@"Common\AssociatedFeatures\ObservedFeature.cs", "ObservedFeatureCS",
                    Filter("Associated findings", "Associated findings").Remove(itemsToIgnore));
            }
        }
        public DataSet ReadGregDS()
        {
            String filePath = Path.Combine(BaseDir,
                "..",
                "BRDocs",
                "BreastData.xlsx");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)

                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    return reader.AsDataSet();
                }
            }
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
