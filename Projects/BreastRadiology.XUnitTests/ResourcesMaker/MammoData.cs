using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    public class MammoData
    {
        public static MammoData Self => self;
        static MammoData self = new MammoData();

        public ExcelData BreastData;

        public MammoData()
        {
            String filePath = Path.Combine(DirHelper.FindParentDir("HL7"),
                "BRDocs",
                "BreastData.xlsx");

            BreastData = new ExcelData(filePath, "Sheet3");
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
