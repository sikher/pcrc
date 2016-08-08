using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Unicode.Gurmukhi.Forms
{
	/// <summary>
	/// Summary description for formMultipleFiles.
	/// </summary>
	public class formBatchProcessor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupToolDetails;
		private System.Windows.Forms.GroupBox groupFiles;
		private System.Windows.Forms.ListView listFiles;
		private System.Windows.Forms.ColumnHeader columnFilesFilename;
		private System.Windows.Forms.ColumnHeader columnFilesPath;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.GroupBox groupConverting;
		private System.Windows.Forms.ProgressBar progressCurrent;
		private System.Windows.Forms.ProgressBar progressTotal;
		private System.Windows.Forms.ColumnHeader columnFilesSize;
		private System.Windows.Forms.Button buttonConvert;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelIntro;

		private bool m_bCancel = false;
		private System.Windows.Forms.Button buttonRepair;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public formBatchProcessor()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupToolDetails = new System.Windows.Forms.GroupBox();
			this.labelIntro = new System.Windows.Forms.Label();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.groupFiles = new System.Windows.Forms.GroupBox();
			this.listFiles = new System.Windows.Forms.ListView();
			this.columnFilesFilename = new System.Windows.Forms.ColumnHeader();
			this.columnFilesPath = new System.Windows.Forms.ColumnHeader();
			this.columnFilesSize = new System.Windows.Forms.ColumnHeader();
			this.groupConverting = new System.Windows.Forms.GroupBox();
			this.progressCurrent = new System.Windows.Forms.ProgressBar();
			this.progressTotal = new System.Windows.Forms.ProgressBar();
			this.buttonConvert = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonRepair = new System.Windows.Forms.Button();
			this.groupToolDetails.SuspendLayout();
			this.groupFiles.SuspendLayout();
			this.groupConverting.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupToolDetails
			// 
			this.groupToolDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupToolDetails.Controls.Add(this.labelIntro);
			this.groupToolDetails.Controls.Add(this.buttonAdd);
			this.groupToolDetails.Controls.Add(this.buttonRemove);
			this.groupToolDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupToolDetails.Location = new System.Drawing.Point(8, 8);
			this.groupToolDetails.Name = "groupToolDetails";
			this.groupToolDetails.Size = new System.Drawing.Size(502, 56);
			this.groupToolDetails.TabIndex = 0;
			this.groupToolDetails.TabStop = false;
			this.groupToolDetails.Text = "Tool Details";
			// 
			// labelIntro
			// 
			this.labelIntro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelIntro.Location = new System.Drawing.Point(8, 18);
			this.labelIntro.Name = "labelIntro";
			this.labelIntro.Size = new System.Drawing.Size(430, 31);
			this.labelIntro.TabIndex = 0;
			this.labelIntro.Text = "This tool enables you to convert or repair multiple files at once.  To begin, add" +
				" files by pressing the \'+\' button and then press \'Convert\' or \'Repair\' as approp" +
				"riate.";
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonAdd.Location = new System.Drawing.Point(438, 18);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(24, 32);
			this.buttonAdd.TabIndex = 0;
			this.buttonAdd.Text = "+";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonRemove.Location = new System.Drawing.Point(472, 18);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(24, 32);
			this.buttonRemove.TabIndex = 1;
			this.buttonRemove.Text = "-";
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// groupFiles
			// 
			this.groupFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupFiles.Controls.Add(this.listFiles);
			this.groupFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupFiles.Location = new System.Drawing.Point(8, 72);
			this.groupFiles.Name = "groupFiles";
			this.groupFiles.Size = new System.Drawing.Size(502, 232);
			this.groupFiles.TabIndex = 2;
			this.groupFiles.TabStop = false;
			this.groupFiles.Text = "Files";
			// 
			// listFiles
			// 
			this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnFilesFilename,
																						this.columnFilesPath,
																						this.columnFilesSize});
			this.listFiles.FullRowSelect = true;
			this.listFiles.HideSelection = false;
			this.listFiles.Location = new System.Drawing.Point(8, 18);
			this.listFiles.Name = "listFiles";
			this.listFiles.Size = new System.Drawing.Size(486, 206);
			this.listFiles.TabIndex = 0;
			this.listFiles.View = System.Windows.Forms.View.Details;
			// 
			// columnFilesFilename
			// 
			this.columnFilesFilename.Text = "File name";
			this.columnFilesFilename.Width = 220;
			// 
			// columnFilesPath
			// 
			this.columnFilesPath.Text = "Path";
			this.columnFilesPath.Width = 120;
			// 
			// columnFilesSize
			// 
			this.columnFilesSize.Text = "Size (bytes)";
			this.columnFilesSize.Width = 80;
			// 
			// groupConverting
			// 
			this.groupConverting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupConverting.Controls.Add(this.progressCurrent);
			this.groupConverting.Controls.Add(this.progressTotal);
			this.groupConverting.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupConverting.Location = new System.Drawing.Point(8, 8);
			this.groupConverting.Name = "groupConverting";
			this.groupConverting.Size = new System.Drawing.Size(502, 56);
			this.groupConverting.TabIndex = 2;
			this.groupConverting.TabStop = false;
			this.groupConverting.Text = "Converting...";
			this.groupConverting.Visible = false;
			// 
			// progressCurrent
			// 
			this.progressCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressCurrent.Location = new System.Drawing.Point(296, 20);
			this.progressCurrent.Name = "progressCurrent";
			this.progressCurrent.Size = new System.Drawing.Size(198, 24);
			this.progressCurrent.TabIndex = 1;
			// 
			// progressTotal
			// 
			this.progressTotal.Location = new System.Drawing.Point(8, 20);
			this.progressTotal.Name = "progressTotal";
			this.progressTotal.Size = new System.Drawing.Size(280, 24);
			this.progressTotal.TabIndex = 0;
			// 
			// buttonConvert
			// 
			this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonConvert.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonConvert.Location = new System.Drawing.Point(256, 312);
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.Size = new System.Drawing.Size(80, 24);
			this.buttonConvert.TabIndex = 4;
			this.buttonConvert.Text = "&Convert";
			this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.Location = new System.Drawing.Point(432, 312);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 24);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "C&ancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonRepair
			// 
			this.buttonRepair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRepair.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonRepair.Location = new System.Drawing.Point(344, 312);
			this.buttonRepair.Name = "buttonRepair";
			this.buttonRepair.Size = new System.Drawing.Size(80, 24);
			this.buttonRepair.TabIndex = 5;
			this.buttonRepair.Text = "&Repair";
			this.buttonRepair.Click += new System.EventHandler(this.buttonRepair_Click);
			// 
			// formBatchProcessor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(520, 346);
			this.ControlBox = false;
			this.Controls.Add(this.buttonRepair);
			this.Controls.Add(this.buttonConvert);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.groupFiles);
			this.Controls.Add(this.groupToolDetails);
			this.Controls.Add(this.groupConverting);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(528, 354);
			this.Name = "formBatchProcessor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Batch Processor";
			this.Load += new System.EventHandler(this.formMultipleFiles_Load);
			this.groupToolDetails.ResumeLayout(false);
			this.groupFiles.ResumeLayout(false);
			this.groupConverting.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void formMultipleFiles_Load(object sender, System.EventArgs e)
		{
		
		}

		private void buttonAdd_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dialogOpen = new OpenFileDialog();
			dialogOpen.Multiselect = true;
			dialogOpen.Title = "Add files...";
			dialogOpen.Filter = "All files (*.*)|*.*";

			if (dialogOpen.ShowDialog(this) == DialogResult.OK)
			{
				for (int iCounter = 0; iCounter <= dialogOpen.FileNames.GetUpperBound(0); iCounter++)
				{
					ListViewItem item = new ListViewItem();
					string sFileName = dialogOpen.FileNames[iCounter];
					item.Text = sFileName.Substring(sFileName.LastIndexOf(Path.DirectorySeparatorChar) + 1);
					item.SubItems.Add(sFileName);
					FileInfo file = new FileInfo(sFileName);
					item.SubItems.Add(file.Length.ToString("N0"));
					listFiles.Items.Add(item);
				}
			}
		}

		private void buttonRemove_Click(object sender, System.EventArgs e)
		{
			foreach(ListViewItem item in listFiles.Items)
			{
				if (item.Selected == true)
					item.Remove();
			}
		}

		private void buttonConvert_Click(object sender, System.EventArgs e)
		{
			ProgramResources.InitEngine();
			ProgramResources.Convert.ProgressBar = progressCurrent;
			CSettings Settings = new CSettings(true);
			String sProgram = Application.ProductName.ToLower();

			groupConverting.Text = "Converting...";
			groupConverting.Visible = true;
			groupToolDetails.Visible = false;
			buttonConvert.Enabled = false;
			buttonRepair.Enabled = false;
			progressTotal.Value = 0;
			progressTotal.Minimum = 0;
			progressTotal.Maximum = listFiles.Items.Count;

			m_bCancel = false;

			// Unselect items
			foreach(ListViewItem item in listFiles.SelectedItems)
				item.Selected = false;

			bool bRenameOriginal = Settings.GetSetting(sProgram, "output", "renameoriginal", true);
			string sExtension = Settings.GetSetting(sProgram, "output", "extension", ".bak");

			bool bUseMapping = false;
			string sMappingFile = "";

			if (((formMain)this.Owner).menuToolsConvertLipitoUnicode.Checked == false)
			{
				IEnumerator Iter = ((formMain)this.Owner).menuToolsConvert.MenuItems.GetEnumerator();

				int iCounter = 0;

				while(Iter.MoveNext())
				{
					// Prevents invalid cast on first & second menu item
					iCounter++;

					if (iCounter <= 2)
						continue;

					TaggedMenuItem Item = (TaggedMenuItem)Iter.Current;

					if (Item.Checked == true)
					{
						bUseMapping = true;
						sMappingFile = (string)Item.Tag;
					}
				}
			}

			if (bUseMapping)
				ProgramResources.Convert.LoadMapping(sMappingFile);

			foreach(ListViewItem item in listFiles.Items)
			{
				try
				{
					item.Selected = true;

					StreamReader streamRead = File.OpenText(item.SubItems[1].Text);
					String strOutput = streamRead.ReadToEnd();
					streamRead.Close();

					string sNewFileName;

					if (bRenameOriginal == true)
					{
						File.Move(item.SubItems[1].Text, item.SubItems[1].Text + sExtension);
						sNewFileName = item.SubItems[1].Text;
					}
					else
					{
						sNewFileName = item.SubItems[1].Text + sExtension;
					}

					StreamWriter streamWrite;

					if (Settings.GetSetting(sProgram, "output", "utf16", false) == true)
						streamWrite = new StreamWriter(sNewFileName, false, System.Text.Encoding.Unicode);
					else
						streamWrite = new StreamWriter(sNewFileName, false, System.Text.Encoding.UTF8);				

					if (bUseMapping)
						streamWrite.Write(ProgramResources.Convert.Convert(strOutput, ConversionType.Mapping));
					else
						streamWrite.Write(ProgramResources.Convert.Convert(strOutput, ConversionType.Internal));

					streamWrite.Close();
					progressTotal.Increment(1);	

					item.Selected = false;

					if (m_bCancel == true)
						break;
				}
				catch (Exception exp)
				{
					MessageBox.Show("Unable to open file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}		
			}

			buttonConvert.Enabled = true;
			buttonRepair.Enabled = true;
			groupToolDetails.Visible = true;
			groupConverting.Visible = false;	
			groupConverting.Text = "";
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			if (groupConverting.Visible == true)
			{
				if (MessageBox.Show("Abort conversion?", "Abort?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					m_bCancel = true;
					ProgramResources.Convert.Cancel();
				}
			}
			else
			{
				this.Close();
			}
		}

		private void buttonRepair_Click(object sender, System.EventArgs e)
		{
			ProgramResources.InitEngine();
			ProgramResources.Convert.ProgressBar = progressCurrent;
			CSettings Settings = new CSettings(true);
			String sProgram = Application.ProductName.ToLower();

			groupConverting.Text = "Repairing...";
			groupConverting.Visible = true;
			groupToolDetails.Visible = false;
			buttonConvert.Enabled = false;
			buttonRepair.Enabled = false;
			progressTotal.Value = 0;
			progressTotal.Minimum = 0;
			progressTotal.Maximum = listFiles.Items.Count;

			m_bCancel = false;

			// Unselect items
			foreach(ListViewItem item in listFiles.SelectedItems)
				item.Selected = false;

			bool bRenameOriginal = Settings.GetSetting(sProgram, "output", "renameoriginal", true);
			string sExtension = Settings.GetSetting(sProgram, "output", "extension", ".bak");

			foreach(ListViewItem item in listFiles.Items)
			{
				try
				{
					item.Selected = true;

					StreamReader streamRead = File.OpenText(item.SubItems[1].Text);
					String strOutput = streamRead.ReadToEnd();
					streamRead.Close();

					string sNewFileName;

					if (bRenameOriginal == true)
					{
						File.Move(item.SubItems[1].Text, item.SubItems[1].Text + sExtension);
						sNewFileName = item.SubItems[1].Text;
					}
					else
					{
						sNewFileName = item.SubItems[1].Text + sExtension;
					}

					StreamWriter streamWrite;

					if (Settings.GetSetting(sProgram, "output", "utf16", false) == true)
						streamWrite = new StreamWriter(sNewFileName, false, System.Text.Encoding.Unicode);
					else
						streamWrite = new StreamWriter(sNewFileName, false, System.Text.Encoding.UTF8);

					streamWrite.Write(ProgramResources.Convert.Convert(strOutput, ConversionType.Repair));
					streamWrite.Close();
					progressTotal.Increment(1);	

					item.Selected = false;

					if (m_bCancel == true)
						break;
				}
				catch (Exception exp)
				{
					MessageBox.Show("Unable to open file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}		
			}

			buttonConvert.Enabled = true;
			buttonRepair.Enabled = true;
			groupToolDetails.Visible = true;
			groupConverting.Visible = false;
			groupConverting.Text = "";
		}

		private void buttonOptions_Click(object sender, System.EventArgs e)
		{
			formOptions formNew = new formOptions();
			formNew.ShowDialog(this);
		}

	}
}
