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


                    concept
                        .AppendLine($"new ConceptDef()")
                        .AppendLine($"    .SetCode(\"{conceptBlockName}\")")
                        .AppendLine($"    .SetDisplay(\"{code}\")")
                        .AppendLine($"    .SetDefinition(new Definition()")
                        .AppendLine($"        .Line(\"[PR] {code}\")")
                        .AppendLine($"    )")
                        .AppendLine($"    .ValidModalities({validWith})")
                        ;

                    AppIfNotNull("SetDicom", row[9]);
                    AppIfNotNull("SetPenCode", row[10]);
                    AppIfNotNull("SetSnomedCode", row[11]);
                    AppIfNotNull("SetOneToMany", row[12]);
                    AppIfNotNull("SetSnomedDescription", row[13]);
                    AppIfNotNull("SetICD10", row[11]);
                    AppIfNotNull("SetComment", row[15]);
                    AppIfNotNull("SetUMLS", row[16]);
                }
            }

            editor.Save();
        }

        void WriteDescriptions(DataSet ds)
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
            void DoRow(DataRow row)
            {
                String id = Val(row[5]);
                if (String.IsNullOrEmpty(id))
                    return;
                String text = Val(row[9]);
                if (String.IsNullOrEmpty(text))
                    return;
                cb
                    .AppendLine($"Add(\"{id}\", \"UMLS\", \"{text}\")")
                ;
            }

            DataTable dataTbl = ds.Tables["Sheet3"];
            if (dataTbl == null)
                throw new Exception($"Table {"Sheet3"} not found");

            CodeEditor editor = new CodeEditor();
            editor.Load(Path.Combine(DirHelper.FindParentDir("BreastRadiology.XUnitTests"),
                        "ResourcesMaker",
                        "MammoIDDescriptions.cs"));

            cb = editor.Blocks.Find("Data");

            for (Int32 i = 1; i < dataTbl.Rows.Count; i++)
            {
                DataRow row = dataTbl.Rows[i];
                DoRow(row);
            }
            editor.Save();
        }

        [TestMethod]
        public void WriteCode()
        {
            DataSet ds = this.ReadGregDS();
            WriteDescriptions(ds);
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
                "Breast-Reporting Value-sets GG V2.xlsx");

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
