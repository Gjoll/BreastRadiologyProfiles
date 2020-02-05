using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGMerge
{
    public partial class GGMerge : Form
    {
        public GGMerge()
        {
            InitializeComponent();
        }

        String sourcePath = null;
        String destPath = null;

        private void Merge_Click(object sender, EventArgs e)
        {
            try
            {
                SelectSpreadSheets s = new SelectSpreadSheets();
                s.tbDestination.Text = this.destPath;
                s.tbSource.Text = this.sourcePath;
                s.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
