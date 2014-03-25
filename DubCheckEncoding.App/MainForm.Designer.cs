namespace DubCheckEncoding.App
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.dlgSaveOutputFile = new System.Windows.Forms.SaveFileDialog();
			this.dlgOpenImportFile = new System.Windows.Forms.OpenFileDialog();
			this.txtImportFilePath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtOutputFilePath = new System.Windows.Forms.TextBox();
			this.btnBrowseImportFile = new System.Windows.Forms.Button();
			this.btnBrowseOutputFile = new System.Windows.Forms.Button();
			this.btnEncode = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.linkLblAbout = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// dlgSaveOutputFile
			// 
			this.dlgSaveOutputFile.DefaultExt = "csv";
			this.dlgSaveOutputFile.Title = "Save file to";
			// 
			// dlgOpenImportFile
			// 
			this.dlgOpenImportFile.Filter = "Comma-delimited files(*.csv)|*.csv";
			// 
			// txtImportFilePath
			// 
			this.txtImportFilePath.Enabled = false;
			this.txtImportFilePath.Location = new System.Drawing.Point(97, 252);
			this.txtImportFilePath.Name = "txtImportFilePath";
			this.txtImportFilePath.ReadOnly = true;
			this.txtImportFilePath.Size = new System.Drawing.Size(454, 20);
			this.txtImportFilePath.TabIndex = 0;
			this.txtImportFilePath.TextChanged += new System.EventHandler(this.txtImportFilePath_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 255);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Import File Path";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 283);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Output File Path";
			// 
			// txtOutputFilePath
			// 
			this.txtOutputFilePath.Enabled = false;
			this.txtOutputFilePath.Location = new System.Drawing.Point(97, 279);
			this.txtOutputFilePath.Name = "txtOutputFilePath";
			this.txtOutputFilePath.ReadOnly = true;
			this.txtOutputFilePath.Size = new System.Drawing.Size(454, 20);
			this.txtOutputFilePath.TabIndex = 3;
			this.txtOutputFilePath.TextChanged += new System.EventHandler(this.txtOutputFilePath_TextChanged);
			// 
			// btnBrowseImportFile
			// 
			this.btnBrowseImportFile.Location = new System.Drawing.Point(557, 250);
			this.btnBrowseImportFile.Name = "btnBrowseImportFile";
			this.btnBrowseImportFile.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseImportFile.TabIndex = 4;
			this.btnBrowseImportFile.Text = "Browse";
			this.btnBrowseImportFile.UseVisualStyleBackColor = true;
			this.btnBrowseImportFile.Click += new System.EventHandler(this.btnBrowseImportFile_Click);
			// 
			// btnBrowseOutputFile
			// 
			this.btnBrowseOutputFile.Location = new System.Drawing.Point(557, 278);
			this.btnBrowseOutputFile.Name = "btnBrowseOutputFile";
			this.btnBrowseOutputFile.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseOutputFile.TabIndex = 5;
			this.btnBrowseOutputFile.Text = "Browse";
			this.btnBrowseOutputFile.UseVisualStyleBackColor = true;
			this.btnBrowseOutputFile.Click += new System.EventHandler(this.btnBrowseOutputFile_Click);
			// 
			// btnEncode
			// 
			this.btnEncode.Enabled = false;
			this.btnEncode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnEncode.Location = new System.Drawing.Point(272, 305);
			this.btnEncode.Name = "btnEncode";
			this.btnEncode.Size = new System.Drawing.Size(156, 43);
			this.btnEncode.TabIndex = 6;
			this.btnEncode.Text = "Encode";
			this.btnEncode.UseVisualStyleBackColor = true;
			this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::DupCheckEncoding.App.Properties.Resources.logo_new;
			this.pictureBox1.Location = new System.Drawing.Point(12, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(621, 241);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// linkLblAbout
			// 
			this.linkLblAbout.AutoSize = true;
			this.linkLblAbout.Location = new System.Drawing.Point(554, 322);
			this.linkLblAbout.Name = "linkLblAbout";
			this.linkLblAbout.Size = new System.Drawing.Size(76, 13);
			this.linkLblAbout.TabIndex = 8;
			this.linkLblAbout.TabStop = true;
			this.linkLblAbout.Text = "About program";
			this.linkLblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblAbout_LinkClicked);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(645, 358);
			this.Controls.Add(this.linkLblAbout);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnEncode);
			this.Controls.Add(this.btnBrowseOutputFile);
			this.Controls.Add(this.btnBrowseImportFile);
			this.Controls.Add(this.txtOutputFilePath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtImportFilePath);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "DupCheck Encoding App";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SaveFileDialog dlgSaveOutputFile;
		private System.Windows.Forms.OpenFileDialog dlgOpenImportFile;
		private System.Windows.Forms.TextBox txtImportFilePath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtOutputFilePath;
		private System.Windows.Forms.Button btnBrowseImportFile;
		private System.Windows.Forms.Button btnBrowseOutputFile;
		private System.Windows.Forms.Button btnEncode;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel linkLblAbout;
	}
}

