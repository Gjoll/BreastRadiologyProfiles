using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        public String UMLS => this.currentRow[this.BreastData.umlsCol].ToString();
    }
}
