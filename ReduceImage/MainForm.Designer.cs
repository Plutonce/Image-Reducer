namespace ReduceImage
{
    partial class MainForm
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
            this.BtnStart = new System.Windows.Forms.Button();
            this.SelectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LblFormat = new System.Windows.Forms.Label();
            this.CBxIFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(93, 52);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(121, 48);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Reduce Images";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LblFormat
            // 
            this.LblFormat.AutoSize = true;
            this.LblFormat.Location = new System.Drawing.Point(118, 9);
            this.LblFormat.Name = "LblFormat";
            this.LblFormat.Size = new System.Drawing.Size(71, 13);
            this.LblFormat.TabIndex = 2;
            this.LblFormat.Text = "Image Format";
            // 
            // CBxIFormat
            // 
            this.CBxIFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBxIFormat.FormattingEnabled = true;
            this.CBxIFormat.Items.AddRange(new object[] {
            "*.jpg",
            "*.jpeg",
            "*.png",
            "*.svg",
            "*.gif",
            "*.bmp"});
            this.CBxIFormat.Location = new System.Drawing.Point(93, 25);
            this.CBxIFormat.Name = "CBxIFormat";
            this.CBxIFormat.Size = new System.Drawing.Size(121, 21);
            this.CBxIFormat.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 114);
            this.Controls.Add(this.CBxIFormat);
            this.Controls.Add(this.LblFormat);
            this.Controls.Add(this.BtnStart);
            this.Name = "MainForm";
            this.Text = "Image Size Reducer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.FolderBrowserDialog SelectFolderDialog;
        private System.Windows.Forms.Label LblFormat;
        private System.Windows.Forms.ComboBox CBxIFormat;
    }
}

