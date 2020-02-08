using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using BreastRadiology.Shared;

namespace BreastRadiology.XUnitTests
{
    public class MammoData
    {
        public ExcelData BreastData;

        public MammoData(IConversionInfo converter)
        {
            String filePath = Path.Combine(DirHelper.FindParentDir("HL7"),
                "BRDocs",
                "BreastData.xlsx");

            BreastData = new ExcelData(converter, filePath, "Sheet3");
        }

        String currentRowId;
        DataRow currentRow;

        public bool SelectRow(String id)
        {
            if (id == null)
                return false;

            if (currentRowId == id)
                return true;

            currentRowId = id;
            if (this.BreastData.TryGetRow(id, out this.currentRow) == true)
                return true;

            currentRowId = null;
            return false;
        }

        public String UMLS => FormatUmls();


        private String FormatUmls()
        {
            StringBuilder sb = new StringBuilder();
            List<String> lines = this.currentRow[this.BreastData.umlsCol].ToString().Split('\n').ToList();
            void CopyLines(Int32 count)
            {
                for (Int32 i = 0; i < count; i++)
                    sb.AppendLine(lines[i]);
            }

            if (lines.Count > 0)
                while ((lines.Count > 0) && String.IsNullOrWhiteSpace(lines[^1]))
                    lines.RemoveAt(lines.Count - 1);
            if (lines.Count == 0)
                return "";

            String lastLine = lines[^1];
            if (lastLine.StartsWith("###") == false)
            {
                CopyLines(lines.Count);
                return sb.ToString();
            }

            void AcrCitation(String name, String page)
            {
                sb.Append($"-- {name}");
                if (String.IsNullOrEmpty(page) == false)
                    sb.Append($"#{page}");
                sb.AppendLine("");
            }

            CopyLines(lines.Count - 1);
            lastLine = lastLine.Substring(3);
            Int32 index = lastLine.IndexOf('#');
            String citationType = lastLine.Substring(0, index);
            String page = lastLine.Substring(index+1);
            switch (citationType)
            {
                case "URL":
                    String hRef = lastLine.Substring(index + 1);
                    sb.Append($"-- {hRef}");
                    break;
                case "ACRUS":
                    AcrCitation("Breast Imaging Reporting and Data System—Mammography, Fifth Edition", page);
                    break;
                case "ACRMG":
                    AcrCitation("Breast Imaging Reporting and Data System—Ultrasound, Second Edition", page);
                    break;
            }
            return sb.ToString();
        }
    }
}
