using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using FhirKhit.Tools;
using ClosedXML.Excel;

namespace BreastRadiology.XUnitTests
{
    class GGPatcher
    {
        public static GGPatcher Self => GetSelf();
        static GGPatcher self;

        static  GGPatcher GetSelf()
        {
            if (GGPatcher.self == null)
                GGPatcher.self = new GGPatcher();
            return GGPatcher.self;
        }

        DataSet dataSetGG;
        DataTable sheet3;
        Dictionary<String, DataRow> rows = new Dictionary<string, DataRow>();
        String filePath;
        String[] headings;
        Int32 idMammoCol = -1;
        Int32 acrCol = -1;

        GGPatcher()
        {
            this.dataSetGG = this.ReadSpreadSheet();
            this.sheet3 = this.dataSetGG.Tables["Sheet3"];
            this.headings = GetHeadings(this.sheet3);
            this.LoadRows(this.sheet3, this.rows);
        }

        String[] GetHeadings(DataTable tblSource)
        {
            List<String> retVal = new List<string>();
            DataRow row = tblSource.Rows[0];
            Int32 i = 1;

            void Read()
            {
                object[] items = row.ItemArray;
                for (Int32 i = 0; i < items.Length; i++)
                {
                    switch (items[i])
                    {
                        case DBNull dbNullValue: 
                            break;

                        case String stringValue:
                            retVal.Add(stringValue);
                            switch (stringValue)
                            {
                                case "ID_MAMMO":
                                    this.idMammoCol = i;
                                    break;
                                case "ACR":
                                    this.acrCol = i;
                                    break;
                            }
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }
            }
            Read();
            return retVal.ToArray();
        }

        void LoadRows(DataTable tbl,
            Dictionary<String, DataRow> rows)
        {
            for (Int32 rowIndex = 1; rowIndex < tbl.Rows.Count; rowIndex++)
            {
                DataRow r = tbl.Rows[rowIndex];
                switch (r[this.idMammoCol])
                {
                    case DBNull dbNullValue:
                        break;
                    default:
                        try
                        {
                            rows.Add(r[this.idMammoCol].ToString(), r);
                        }
                        catch (Exception e)
                        {
                            ResourcesMaker.Self.ConversionWarn("GGPatcher",
                                "LoadRows",
                                $"Error adding Mammo id {r[this.idMammoCol]}");
                        }
                        break;
                }
            }
        }

        public void PatchACRText(String mammoId, String[] lines)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String line in lines)
                sb.AppendLine(line);
            if (this.rows.TryGetValue(mammoId, out DataRow row) == false)
            {
                ResourcesMaker.Self.ConversionWarn("GGPatcher",
                    "PatchACRText",
                    $"Cant find row for Mammo id {mammoId}");
                return;
            }

            row[acrCol] = sb.ToString();
        }

        public void Save()
        {
            File.Delete(this.filePath);
            XLWorkbook workbook = new XLWorkbook();
            workbook.Worksheets.Add(this.dataSetGG);
            workbook.SaveAs(this.filePath);

        }

        DataSet ReadSpreadSheet()
        {
            this.filePath= Path.Combine(DirHelper.FindParentDir("HL7"),
                "BRDocs",
                "Breast-Reporting Value-sets GG V3.xlsx");

            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
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
