namespace Steganography
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.FileInfo = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.OpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveAs = new System.Windows.Forms.Button();
            this.HideText = new System.Windows.Forms.Button();
            this.StegoMethod = new System.Windows.Forms.ComboBox();
            this.ExtractText = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 569);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.FileInfo);
            this.groupBox5.Location = new System.Drawing.Point(524, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(221, 354);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "File EXIF";
            // 
            // FileInfo
            // 
            this.FileInfo.Location = new System.Drawing.Point(6, 19);
            this.FileInfo.Multiline = true;
            this.FileInfo.Name = "FileInfo";
            this.FileInfo.ReadOnly = true;
            this.FileInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FileInfo.Size = new System.Drawing.Size(209, 327);
            this.FileInfo.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.OpenFile);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.SaveAs);
            this.groupBox4.Controls.Add(this.HideText);
            this.groupBox4.Controls.Add(this.StegoMethod);
            this.groupBox4.Controls.Add(this.ExtractText);
            this.groupBox4.Location = new System.Drawing.Point(524, 379);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(221, 181);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(6, 57);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(209, 23);
            this.OpenFile.TabIndex = 7;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Method";
            // 
            // SaveAs
            // 
            this.SaveAs.Location = new System.Drawing.Point(6, 144);
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(209, 23);
            this.SaveAs.TabIndex = 0;
            this.SaveAs.Text = "Save As";
            this.SaveAs.UseVisualStyleBackColor = true;
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // HideText
            // 
            this.HideText.Location = new System.Drawing.Point(6, 86);
            this.HideText.Name = "HideText";
            this.HideText.Size = new System.Drawing.Size(209, 23);
            this.HideText.TabIndex = 4;
            this.HideText.Text = "Hide Text";
            this.HideText.UseVisualStyleBackColor = true;
            this.HideText.Click += new System.EventHandler(this.HideText_Click);
            // 
            // StegoMethod
            // 
            this.StegoMethod.FormattingEnabled = true;
            this.StegoMethod.Items.AddRange(new object[] {
            "Least Significant Bits (LSB)",
            "EXIF modification"});
            this.StegoMethod.Location = new System.Drawing.Point(6, 30);
            this.StegoMethod.Name = "StegoMethod";
            this.StegoMethod.Size = new System.Drawing.Size(209, 21);
            this.StegoMethod.TabIndex = 5;
            this.StegoMethod.SelectedIndexChanged += new System.EventHandler(this.StegoMethod_SelectedIndexChanged);
            // 
            // ExtractText
            // 
            this.ExtractText.Location = new System.Drawing.Point(6, 115);
            this.ExtractText.Name = "ExtractText";
            this.ExtractText.Size = new System.Drawing.Size(209, 23);
            this.ExtractText.TabIndex = 3;
            this.ExtractText.Text = "Extract Text";
            this.ExtractText.UseVisualStyleBackColor = true;
            this.ExtractText.Click += new System.EventHandler(this.ExtractText_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(751, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 541);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Text";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(262, 513);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 541);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 513);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1056, 591);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steganography";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox StegoMethod;
        private System.Windows.Forms.Button SaveAs;
        private System.Windows.Forms.Button HideText;
        private System.Windows.Forms.Button ExtractText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox FileInfo;
        private System.Windows.Forms.Button OpenFile;
    }
}

