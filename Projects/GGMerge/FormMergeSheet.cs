using ClosedXML.Excel;
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
using DocumentFormat.OpenXml.Wordprocessing;

namespace GGMerge
{
    public partial class FormMergeSheet : Form
    {
        String[] headings;

        public FormMergeSheet()
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

        public bool Merge(String pathSource,
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

            this.headings = headingDestination;

            LoadRows(tblSource, this.rowsSource);
            LoadRows(tblDestination, this.rowsDestination);
            if (MergeRows() == false)
                return false;

            File.Delete(this.tbDestination.Text);
            XLWorkbook workbook = new XLWorkbook();
            workbook.Worksheets.Add(this.dsDestination);
            workbook.SaveAs(this.tbDestination.Text);
            return true;
        }

        bool MergeRows()
        {
            foreach (KeyValuePair<String, DataRow> item in this.rowsSource)
            {
                if (MergeRow(item) == false)
                    return false;
            }

            return true;
        }

        bool MergeRow(KeyValuePair<String, DataRow> item)
        {
            if (this.rowsDestination.TryGetValue(item.Key, out DataRow rowDest) == false)
            {
                DialogResult res = MessageBox.Show($"Can not find row {item.Key} in destination table",
                    "Error",
                    MessageBoxButtons.OKCancel);
                switch (res)
                {
                    case DialogResult.OK:
                        return true;

                    case DialogResult.Cancel:
                        return false;

                    default:
                        throw new NotImplementedException();
                }
            }

            return this.MergeCols(item.Key, item.Value, rowDest);
        }

        bool MergeCols(String mammoId, 
            DataRow rowSource, 
            DataRow rowDest)
        {
            for (Int32 i = 0; i < this.headings.Length; i++)
            {
                if (i != this.idMammoCol)
                    MergeCol(mammoId, i, rowSource, rowDest);
            }
            return true;
        }

        bool MergeCol(String mammoId, 
            Int32 i,
            DataRow rowSource, 
            DataRow rowDest)
        {
            String sourceText = rowSource[i].ToString();
            String destText = rowDest[i].ToString();
            if (String.Compare(sourceText, destText) == 0)
                return true;

            if (destText.Length == 0)
            {
                rowDest[i] = rowSource[i];
                return true;
            }

            this.tbMammoId.Text = mammoId;
            this.tbColumnName.Text = this.headings[i];
            this.tbSourceData.Text = sourceText;
            this.tbDestData.Text = destText;

            DialogResult res = MessageBox.Show($"Overwrite destination?",
                "Query",
                MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
                    rowDest[i] = rowSource[i];
                    return true;

                case DialogResult.No:
                    return true;

                default:
                    throw new NotImplementedException();
            }

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
                            String key = r[this.idMammoCol].ToString();
                            if (String.IsNullOrEmpty(key) == false)
                                rows.Add(key, r);
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

            void Read()
            {
                object[] items = row.ItemArray;
                for (Int32 i = 0; i < items.Length; i++)
                {
                    switch (items[i])
                    {
                        case DBNull dbNullValue:
                            retVal.Add("");
                            break;
                        case String stringValue:
                            switch (stringValue.Trim().ToUpper())
                            {
                                case "ID_MAMMO": this.idMammoCol = i; break;
                            }
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
