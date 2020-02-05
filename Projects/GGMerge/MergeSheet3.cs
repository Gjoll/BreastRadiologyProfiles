using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGMerge
{
    class MergeSheet3
    {
        DataSet dsSource;
        DataSet dsDestination;

        public MergeSheet3()
        {
        }

        String[] headings;

        public void Merge(String pathSource,
            String pathDestination)
        {
            this.dsSource = this.ReadSpreadSheet(pathSource);
            this.dsDestination = this.ReadSpreadSheet(pathDestination);

            DataTable tblSource = this.dsSource.Tables["Sheet3"];
            if (tblSource == null)
                throw new Exception("Table \"Sheet3\" not found");

            DataTable tblDestination = this.dsDestination.Tables["Sheet3"];
            if (tblSource == null)
                throw new Exception("Table \"Sheet3\" not found");

            String[] headingSource = GetHeadings(tblSource);
            String[] headingDestination = GetHeadings(tblDestination);
            Compare(headingSource, headingDestination);
        }

        void Compare(String[] headingSource, String[] headingDestination)
        {
            if (headingSource.Length != headingDestination.Length)
                throw new Exception("Header's do not match");

            for (Int32 i = 0; i < headingSource.Length; i++)
                if (headingSource[i] != headingDestination[i])
                    throw new Exception($"Heading's{i} {headingSource[i]} and {headingDestination[i]} do not match");
        }

        String[] GetHeadings(DataTable tblSource)
        {
            List<String> retVal = new List<string>();
            DataRow row = tblSource.Rows[0];
            Int32 i = 1;

            void Read()
            {
                while (true)
                {
                    switch (row[i++])
                    {
                        case DBNull dbNullValue: return;
                        case String stringValue:
                            retVal.Add(stringValue);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
            Read();
            return retVal.ToArray();
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
