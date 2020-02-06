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
    class ExcelData
    {
        DataTable dataTable;
        Dictionary<String, DataRow> rows = new Dictionary<string, DataRow>();
        String filePath;

        Int32 mgCol = -1;
        Int32 mriCol = -1;
        Int32 nmCol = -1;
        Int32 usCol = -1;
        Int32 idMammoCol = -1;
        Int32 listBoxNameCol = -1;
        Int32 structureCol = -1;
        Int32 itemNameCol = -1;
        Int32 dicomCol = -1;
        Int32 snoMedCol = -1;
        Int32 snoMedDescriptionCol = -1;
        Int32 icd10Col = -1;
        Int32 umlsCol = -1;
        Int32 acrCol = -1;

        public ExcelData(String filePath,
            String sheetName)
        {
            this.filePath = filePath;
            DataSet dataSet = this.ReadSpreadSheet(filePath);
            DataTable originalTable = dataSet.Tables[sheetName];
            this.dataTable = GetHeadings(originalTable);
            this.LoadRows(originalTable);
        }

        DataTable GetHeadings(DataTable tblSource)
        {
            DataTable retVal = new DataTable("Sheet3");
            DataRow row = tblSource.Rows[0];

            void Read()
            {
                object[] items = row.ItemArray;
                for (Int32 i = 0; i < items.Length; i++)
                {
                    switch (items[i])
                    {
                        case DBNull dbNullValue:
                            retVal.Columns.Add("");
                            break;
                        case String stringValue:
                            DataColumn col = new DataColumn(stringValue, typeof(String));
                            retVal.Columns.Add(col);

                            switch (stringValue.Trim().ToUpper())
                            {
                                case "MG": this.mgCol = i; break;
                                case "MRI": mriCol = i; break;
                                case "NM": nmCol = i; break;
                                case "US": usCol = i; break;
                                case "ID_MAMMO": this.idMammoCol = i; break;
                                case "LISTBOX_NAME": listBoxNameCol = i; break;
                                case "STRUCTURE": structureCol = i; break;
                                case "ITEM_NAME": itemNameCol = i; break;
                                case "DICOM_CODE": dicomCol = i; break;
                                case "SNOMED": snoMedCol = i; break;
                                case "SNOMED DESCRIPTION": snoMedDescriptionCol = i; break;
                                case "ICD10":  icd10Col = i; break;
                                case "UMLS": umlsCol = i; break;
                                case "ACR": this.acrCol = i; break;
                            }
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }
            }
            Read();
            if (this.acrCol == -1)
            {
                this.acrCol = this.idMammoCol + 1;
                row[this.acrCol] = "ACR";
            }
            return retVal;
        }

        void LoadRows(DataTable originalData)
        {
            for (Int32 rowIndex = 1; rowIndex < originalData.Rows.Count; rowIndex++)
            {
                DataRow r = originalData.Rows[rowIndex];
                this.dataTable.Rows.Add(r.ItemArray);
                switch (r[this.idMammoCol])
                {
                    case DBNull dbNullValue:
                        break;
                    default:
                        String key = r[this.idMammoCol].ToString();
                        if (rows.ContainsKey(key))
                        {
                            ResourcesMaker.Self.ConversionWarn("GGPatcher",
                                "LoadRows",
                                $"Mammo id {key} already exists");
                        }
                        else
                            rows.Add(key, r);
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
            workbook.Worksheets.Add(this.dataTable);
            workbook.SaveAs(this.filePath);

        }

        DataSet ReadSpreadSheet(String filePath)
        {
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
