using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using DubCheckEncoding.Import;

namespace DubCheckEncoding.App
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnBrowseImportFile_Click(object sender, EventArgs e)
		{
			if (dlgOpenImportFile.ShowDialog() == DialogResult.OK)
			{
				txtImportFilePath.Text = dlgOpenImportFile.FileName;
			}
		}

		private void btnBrowseOutputFile_Click(object sender, EventArgs e)
		{
			if (dlgSaveOutputFile.ShowDialog() == DialogResult.OK)
			{
				txtOutputFilePath.Text = dlgSaveOutputFile.FileName;
			}
		}

		private void btnEncode_Click(object sender, EventArgs e)
		{			
			var importer = new Importer(txtImportFilePath.Text, txtOutputFilePath.Text);
			var result = importer.Import();
			switch (result)
			{
					case ImportResult.ImportFileMissing:
						MessageBox.Show("Import file missing", 
										"Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					case ImportResult.OutputFileMissing:
						MessageBox.Show("Output file missing", 
										"Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					case ImportResult.BadFormat:
						MessageBox.Show("Incorrect input file format", 
										"Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					case ImportResult.WriteAccessDenied:
						MessageBox.Show("Output file access problem", 
										"Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					case ImportResult.BadInputFileType:
						MessageBox.Show("Input file is not a comma-delimited (*.csv) file. Please choose another one"
										, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					default:
						MessageBox.Show("Encoding done successfully", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
			}				
		}

		private void txtImportFilePath_TextChanged(object sender, EventArgs e)
		{
			RefreshEncodeButtonStatus();
		}

		private void txtOutputFilePath_TextChanged(object sender, EventArgs e)
		{
			RefreshEncodeButtonStatus();
		}

		private void RefreshEncodeButtonStatus()
		{
			btnEncode.Enabled = !((String.IsNullOrWhiteSpace(txtImportFilePath.Text))
			                     || (String.IsNullOrWhiteSpace(txtOutputFilePath.Text)));
		}

		private void linkLblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Exe version
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fvi.FileVersion;

			// Dll assembly
			Assembly dllAssembly = Assembly.GetAssembly(typeof(Importer));
			FileVersionInfo dllfvi = FileVersionInfo.GetVersionInfo(dllAssembly.Location);
			string dllVersion = dllfvi.FileVersion;

			string resultString = String.Format("Program version: {0}\nLibrary version: {1}\nLast change date: {2}",
				version, dllVersion, ConfigurationManager.AppSettings["VersionDate"]);
			MessageBox.Show(resultString, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
