﻿namespace GGMerge
{
    partial class GGMerge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Merge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Merge
            // 
            this.Merge.Location = new System.Drawing.Point(12, 12);
            this.Merge.Name = "Merge";
            this.Merge.Size = new System.Drawing.Size(215, 23);
            this.Merge.TabIndex = 0;
            this.Merge.Text = "Merge Sheet3";
            this.Merge.UseVisualStyleBackColor = true;
            this.Merge.Click += new System.EventHandler(this.Merge_Click);
            // 
            // GGMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 218);
            this.Controls.Add(this.Merge);
            this.Name = "GGMerge";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Merge;
    }
}

