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
                    String validWith = App("", row[0], "MG"); ;
                    validWith = App(validWith, row[1], "MRI");
                    validWith = App(validWith, row[2], "NM");
                    validWith = App(validWith, row[3], "US");

                    void AppIfNotNull(String name, Object value)
                    {
                        if (value is System.DBNull)
                            return;

                        String sValue = value.ToString();
                        sValue = sValue.Trim()
                            .Replace("\r", "")
                            .Replace("\n", "")
                            ;
                        if (String.IsNullOrEmpty(sValue) == false)
                            concept
                                .AppendLine($"    .{name}(\"{sValue}\")");
                    }

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
                        .AppendLine($"    )")
                        .AppendLine($"    .MammoId(\"{penId}\")")
                        .AppendLine($"    .ValidModalities({validWith})")
                        ;

                    AppIfNotNull("SetDicom", row[9]);
                    AppIfNotNull("SetSnomedCode", row[11]);
                    AppIfNotNull("SetOneToMany", row[12]);
                    AppIfNotNull("SetSnomedDescription", row[13]);
                    AppIfNotNull("SetICD10", row[14]);
                    AppIfNotNull("SetComment", row[15]);
                    AppIfNotNull("SetUMLS", row[16]);
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

        void WriteDescriptions()
        {
            CodeBlockNested cb = null;

            String Val(Object t)
            {
                switch (t)
                {
                    case DBNull dbNullValue:
                        return null;

                    case Double dbl:
                        return dbl.ToString();

                    case String stringValue:
                        return stringValue;

                    default:
                        throw new Exception("Invalid excel cell value");
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
                        case '�':
                        case '�':
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

            // Get rid of empty strings, and strings liek C1234
            bool CheckText(String t)
            {
                if (String.IsNullOrEmpty(t))
                    return false;
                if (t[0] != 'C')
                    return true;
                for (Int32 i = 1; i < t.Length; i++)
                {
                    if (Char.IsDigit(t[i]) == false)
                        return true;
                }
                return false;
            }
            void DoRow(DataRow row)
            {
                String id = Val(row[5]);
                if (String.IsNullOrEmpty(id))
                    return;
                String text = Val(row[17]);

                if (CheckText(text) == false)
                    return;
                cb
                    .AppendLine($"Add(\"{id}\", ")
                    .AppendLine($"    \"UMLS\", ")
                    .AppendLine($"    new String[]")
                    .AppendLine($"    {{")
                ;
                String[] lines = FormatMultiLineText(text).ToArray();

                foreach (String line in lines)
                    cb.AppendLine($"        {line}");
                cb.AppendLine($"    }});");
            }

            CodeEditor editor = new CodeEditor();
            editor.Load(Path.Combine(DirHelper.FindParentDir("BreastRadiology.XUnitTests"),
                        "ResourcesMaker",
                        "MammoIDDescriptions.cs"));

            cb = editor.Blocks.Find("Data");
            cb.Clear();

            foreach (DataRow row in this.sheet3.Values)
                DoRow(row);
            editor.Save();
        }

        void WriteIds(String outputCodePath,
            String csBlockName,
            params String[] penIds)
        {
            CodeEditor editor = new CodeEditor();
            editor.Load(Path.Combine(DirHelper.FindParentDir("BreastRadiology.XUnitTests"),
                        "ResourcesMaker",
                        outputCodePath));

            CodeBlockNested concepts = editor.Blocks.Find(csBlockName);
            if (concepts == null)
                throw new Exception($"Can not find editor block {csBlockName}");

            CodeBlockNested concept = null;
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

                String validWith = App("", row[1], "MG"); ;
                validWith = App(validWith, row[2], "MRI");
                validWith = App(validWith, row[3], "NM");
                validWith = App(validWith, row[4], "US");

                concept
                    .AppendLine($"new ConceptDef()")
                    .AppendLine($"    .SetCode(\"{conceptBlockName}\")")
                    .AppendLine($"    .SetDisplay(\"{code}\")")
                    .AppendLine($"    .SetDefinition(new Definition()")
                    .AppendLine($"        .Line(\"[PR] {code}\")")
                    .AppendLine($"        .MammoId(\"{penId}\")")
                    .AppendLine($"    )")
                    .AppendLine($"    .ValidModalities({validWith})")
                    ;
            }

            editor.Save();
        }

        [TestMethod]
        public void WriteCode()
        {
            DataSet ds = this.ReadGregDS();
            LoadSheet3(ds);

            WriteDescriptions();
            WriteIds(@"Common\Abnormalities\AbnormalityCyst.cs", "Type", "69", "610", "657", "617", "636", "609", "661");
            WriteIds(@"Common\Abnormalities\AbnormalityDuct.cs", "Type", "694.602", "693.614");
            WriteIds(@"Common\Abnormalities\AbnormalityFibroAdenoma.cs", "Type", "70", "695");
            WriteIds(@"Common\Abnormalities\AbnormalityLymphNode.cs", "Type", "648", "649", "662", "665", "650", "651", "652", "666", "663");
            WriteIds(@"Common\Abnormalities\AbnormalityMass.cs", "Type", "58", "621", "697", "613", "608");
            WriteCS(ds, "Recommendation", @"Common\ServiceRecommendation.cs", "RecommendationsCS");
            WriteCS(ds, "CorrspondsWith", @"Common\CorrespondsWithCS.cs", "CorrespondsWithCS");
            WriteCS(ds, "ConsistentWith", @"Common\ConsistentWith.cs", "ConsistentWithCS");
            WriteCS(ds, "ConsistentWithQualifier", @"Common\ConsistentWith.cs", "ConsistentWithQualifierCS");
            WriteCS(ds, "ForeignBody", @"Common\Abnormalities\AbnormalityForeignObject.cs", "ForeignObjectCS");
            WriteCS(ds, "NotPreviousSeen", @"Common\NotPreviouslySeenCS.cs", "NotPreviouslySeenCS");
            WriteCS(ds, "Margin", @"Common\MarginCS.cs", "MarginCS");
            WriteCS(ds, "Shape", @"Common\ShapeCS.cs", "ShapeCS");
            WriteCS(ds, "ChangeFromPrior", @"Common\ObservedChangesCS.cs", "ChangesCS");

            List<String> itemsToIgnore = new List<string>();
            itemsToIgnore.Add("ARCHITECTURAL DISTORTION");
            WriteCS(ds, "AssocFindings", @"Common\AssociatedFeatures\ObservedFeature.cs", "ObservedFeatureCS", itemsToIgnore);
        }
        public DataSet ReadGregDS()
        {
            String filePath = Path.Combine(BaseDir,
                "..",
                "BRDocs",
                "Breast-Reporting Value-sets GG V3.xlsx");

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
}
