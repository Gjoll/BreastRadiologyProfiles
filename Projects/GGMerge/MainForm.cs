using BreastRadiology.Shared;
using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGMerge
{
    public partial class GGMerge : Form, IConversionInfo
    {
        public GGMerge()
        {
            InitializeComponent();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);
        }

        String sourcePath = null;
        String destPath = null;

        private void Merge_Click(object sender, EventArgs e)
        {
            try
            {
                FormMergeSheet s = new FormMergeSheet();
                s.tbDestination.Text = this.destPath;
                s.tbSource.Text = this.sourcePath;
                s.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCleanup_Click(object sender, EventArgs e)
        {
            ExcelData source;

            bool IsGargage(String text)
            {
                text = text.ToUpper();
                if ((text.Length == 0) || (text[0] != 'C'))
                    return false;
                for (Int32 i = 1; i < text.Length; i++)
                    if (Char.IsDigit(text[i]) == false)
                        return false;
                return true;
            }

            void CleanupUMLS(DataRow row)
            {
                String text = row[source.umlsCol].ToString();
                if (IsGargage(text))
                    text = "";

                row[source.umlsCol] = text;
            }

            String baseDir = DirHelper.FindParentDir("BreastRadiologyProfiles");
            String filePath = Path.Combine(baseDir,
                "..",
                "BRDocs",
                "BreastData.xlsx");
            source = new ExcelData(this, filePath, "Sheet3");

            foreach (DataRow row in source.rows.Values)
            {
                CleanupUMLS(row);
            }
            source.Save();
        }
        void Msg(String import, string className, string method, string msg)
        {
        }

        public void ConversionError(string className, string method, string msg) => Msg("Err", className, method, msg);

        public void ConversionInfo(string className, string method, string msg) => Msg("Info", className, method, msg);

        public void ConversionWarn(string className, string method, string msg) => Msg("Warn", className, method, msg);

        private void GGMerge_Load(object sender, EventArgs e)
        {

        }
    }
}
