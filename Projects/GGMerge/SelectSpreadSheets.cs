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
            CheckPaths();
        }

        private void tbSource_TextChanged(object sender, EventArgs e)
        {
            CheckPaths();
        }

        void CheckPaths()
        {
            this.btnOk.Enabled = false;
            if (String.IsNullOrEmpty(this.tbDestination.Text))
                return;
            if (String.IsNullOrEmpty(this.tbSource.Text))
                return;
            if (File.Exists(this.tbDestination.Text) == false)
                return;
            if (File.Exists(this.tbSource.Text) == false)
                return;
            this.btnOk.Enabled = true;

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
    }
}
