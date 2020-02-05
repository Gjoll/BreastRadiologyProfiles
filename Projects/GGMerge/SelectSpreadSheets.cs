using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGMerge
{
    public partial class SelectSpreadSheets : Form
    {
        public SelectSpreadSheets()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tbDestination_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void tbSource_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        void EnableButtons()
        {
            this.btnOk.Enabled = false;
            this.btnMerge.Enabled = false;
            if (String.IsNullOrEmpty(this.tbDestination.Text))
                return;
            if (String.IsNullOrEmpty(this.tbSource.Text))
                return;
            if (File.Exists(this.tbDestination.Text) == false)
                return;
            if (File.Exists(this.tbSource.Text) == false)
                return;

            this.btnOk.Enabled = true;
            this.btnMerge.Enabled = true;
        }

        bool SelectSpreadSheetFile(String startPath, out String path)
        {
            path = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = startPath;
            ofd.Filter = "Excel Files | *.xlsx";
            ofd.Title = "Select excel file";

            switch (ofd.ShowDialog())
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    path = ofd.FileName;
                    return true;
                default:
                    return false;
            }
        }

        private void tbnSelSource_Click(object sender, EventArgs e)
        {
            if (SelectSpreadSheetFile(this.tbSource.Text, out String path) == false)
                return;
            this.tbSource.Text = path;
        }

        private void btnSelDest_Click(object sender, EventArgs e)
        {
            if (SelectSpreadSheetFile(this.tbDestination.Text, out String path) == false)
                return;
            this.tbDestination.Text = path;
        }

        DataSet dsSource;
        DataSet dsDestination;
        Int32 idMammoCol = -1;

        Dictionary<String, DataRow> rowsSource = new Dictionary<string, DataRow>();
        Dictionary<String, DataRow> rowsDestination = new Dictionary<string, DataRow>();

        private void btnMerge_Click(object sender, EventArgs e)
        {
            try
            {
                Merge(this.tbSource.Text, this.tbDestination.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

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

            LoadRows(tblSource, this.rowsSource);
            LoadRows(tblDestination, this.rowsDestination);
        }

        void LoadRows(DataTable tbl,
            Dictionary<String, DataRow> rows)
        {
            for (Int32 rowIndex = 1; rowIndex < tbl.Rows.Count; rowIndex++)
            {
                DataRow r = tbl.Rows[rowIndex++];
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
                            Console.WriteLine(e);
                        }
                        break;
                }
            }
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
                    switch (row[i])
                    {
                        case DBNull dbNullValue: return;
                        case String stringValue:
                            retVal.Add(stringValue);
                            if (stringValue == "ID_MAMMO")
                                idMammoCol = i;
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    i += 1;
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
