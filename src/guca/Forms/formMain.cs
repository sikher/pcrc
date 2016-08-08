//
// GUCA - Gurmukhi Unicode Conversion Application
//
// Copyright © 2004 Sukhjinder Sidhu
// Released under the GNU General Public Licence (see accompanying licence.txt)
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//
// Contact the author at: sukhuk@users.sourceforge.net
//
// http://www-124.ibm.com/icu/dropbox/C-sharp-LocaleNames.html

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Unicode.Gurmukhi.Forms
{
	/// <summary>
	/// Summary description for formMain.
	/// </summary>
	public class formMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.GroupBox groupOriginalText;
		public System.Windows.Forms.TextBox textOriginalText;
		private System.Windows.Forms.Button buttonConvert;
		private System.Windows.Forms.GroupBox groupConvertedText;
		public System.Windows.Forms.TextBox textConvertedText;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.Splitter splitterMain;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuTools;
		public System.Windows.Forms.MenuItem menuToolsConvert;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuHelpAbout;
		private System.Windows.Forms.MenuItem menuFileOpen;
		private System.Windows.Forms.MenuItem menuFileSave;
		private System.Windows.Forms.MenuItem menuFileSaveAs;
		private System.Windows.Forms.MenuItem mnuFileDash2;
		private System.Windows.Forms.MenuItem menuFileDash1;
		private System.Windows.Forms.MenuItem menuFileDash3;
		private System.Windows.Forms.MenuItem menuFileExport;
		private System.Windows.Forms.MenuItem menuFileExportXHTML;
		private System.Windows.Forms.ProgressBar progressMain;
		private System.Windows.Forms.MenuItem menuToolsDash1;
		private System.Windows.Forms.MenuItem menuToolsOptions;
		private System.Windows.Forms.MenuItem menuHelpQuickHelp;
		private System.Windows.Forms.MenuItem menuHelpDash1;
		private System.Windows.Forms.MenuItem menuHelpContents;
		private System.Windows.Forms.MainMenu menuMain;
		private System.Windows.Forms.MenuItem menuToolsDash2;
		private System.Windows.Forms.MenuItem menuFileDash4;
		private System.Windows.Forms.MenuItem menuFileLanguage;
		private System.Windows.Forms.MenuItem menuFileLanguageEnglish;
		private System.Windows.Forms.MenuItem menuFileLanguagePunjabi;
		private System.Windows.Forms.MenuItem menuToolsCharCodeViewer;
		private System.Windows.Forms.Button buttonRepair;
		private System.Windows.Forms.MenuItem menuToolsRepair;
		private System.Windows.Forms.MenuItem menuToolsBatchProcessor;
		private System.Windows.Forms.MenuItem menuToolsRomanise;
		private System.Windows.Forms.MenuItem menuToolsDash3;
		public System.Windows.Forms.MenuItem menuToolsConvertLipitoUnicode;
		public System.Windows.Forms.MenuItem menuToolsConvertDash1;
		private Skybound.VisualStyles.VisualStyleProvider visualStyleProvider;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public formMain()
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(formMain));
			this.panelTop = new System.Windows.Forms.Panel();
			this.groupOriginalText = new System.Windows.Forms.GroupBox();
			this.textOriginalText = new System.Windows.Forms.TextBox();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.buttonRepair = new System.Windows.Forms.Button();
			this.buttonConvert = new System.Windows.Forms.Button();
			this.groupConvertedText = new System.Windows.Forms.GroupBox();
			this.textConvertedText = new System.Windows.Forms.TextBox();
			this.progressMain = new System.Windows.Forms.ProgressBar();
			this.splitterMain = new System.Windows.Forms.Splitter();
			this.menuMain = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuFileOpen = new System.Windows.Forms.MenuItem();
			this.menuFileDash1 = new System.Windows.Forms.MenuItem();
			this.menuFileSave = new System.Windows.Forms.MenuItem();
			this.menuFileSaveAs = new System.Windows.Forms.MenuItem();
			this.mnuFileDash2 = new System.Windows.Forms.MenuItem();
			this.menuFileExport = new System.Windows.Forms.MenuItem();
			this.menuFileExportXHTML = new System.Windows.Forms.MenuItem();
			this.menuFileDash3 = new System.Windows.Forms.MenuItem();
			this.menuFileLanguage = new System.Windows.Forms.MenuItem();
			this.menuFileLanguageEnglish = new System.Windows.Forms.MenuItem();
			this.menuFileLanguagePunjabi = new System.Windows.Forms.MenuItem();
			this.menuFileDash4 = new System.Windows.Forms.MenuItem();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuTools = new System.Windows.Forms.MenuItem();
			this.menuToolsConvert = new System.Windows.Forms.MenuItem();
			this.menuToolsConvertLipitoUnicode = new System.Windows.Forms.MenuItem();
			this.menuToolsConvertDash1 = new System.Windows.Forms.MenuItem();
			this.menuToolsRepair = new System.Windows.Forms.MenuItem();
			this.menuToolsDash1 = new System.Windows.Forms.MenuItem();
			this.menuToolsBatchProcessor = new System.Windows.Forms.MenuItem();
			this.menuToolsCharCodeViewer = new System.Windows.Forms.MenuItem();
			this.menuToolsDash2 = new System.Windows.Forms.MenuItem();
			this.menuToolsRomanise = new System.Windows.Forms.MenuItem();
			this.menuToolsDash3 = new System.Windows.Forms.MenuItem();
			this.menuToolsOptions = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpContents = new System.Windows.Forms.MenuItem();
			this.menuHelpQuickHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpDash1 = new System.Windows.Forms.MenuItem();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			this.visualStyleProvider = new Skybound.VisualStyles.VisualStyleProvider();
			this.panelTop.SuspendLayout();
			this.groupOriginalText.SuspendLayout();
			this.panelBottom.SuspendLayout();
			this.groupConvertedText.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.AccessibleDescription = resources.GetString("panelTop.AccessibleDescription");
			this.panelTop.AccessibleName = resources.GetString("panelTop.AccessibleName");
			this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panelTop.Anchor")));
			this.panelTop.AutoScroll = ((bool)(resources.GetObject("panelTop.AutoScroll")));
			this.panelTop.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panelTop.AutoScrollMargin")));
			this.panelTop.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panelTop.AutoScrollMinSize")));
			this.panelTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTop.BackgroundImage")));
			this.panelTop.Controls.Add(this.groupOriginalText);
			this.panelTop.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panelTop.Dock")));
			this.panelTop.Enabled = ((bool)(resources.GetObject("panelTop.Enabled")));
			this.panelTop.Font = ((System.Drawing.Font)(resources.GetObject("panelTop.Font")));
			this.panelTop.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panelTop.ImeMode")));
			this.panelTop.Location = ((System.Drawing.Point)(resources.GetObject("panelTop.Location")));
			this.panelTop.Name = "panelTop";
			this.panelTop.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panelTop.RightToLeft")));
			this.panelTop.Size = ((System.Drawing.Size)(resources.GetObject("panelTop.Size")));
			this.panelTop.TabIndex = ((int)(resources.GetObject("panelTop.TabIndex")));
			this.panelTop.Text = resources.GetString("panelTop.Text");
			this.panelTop.Visible = ((bool)(resources.GetObject("panelTop.Visible")));
			this.visualStyleProvider.SetVisualStyleSupport(this.panelTop, true);
			this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
			// 
			// groupOriginalText
			// 
			this.groupOriginalText.AccessibleDescription = resources.GetString("groupOriginalText.AccessibleDescription");
			this.groupOriginalText.AccessibleName = resources.GetString("groupOriginalText.AccessibleName");
			this.groupOriginalText.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupOriginalText.Anchor")));
			this.groupOriginalText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupOriginalText.BackgroundImage")));
			this.groupOriginalText.Controls.Add(this.textOriginalText);
			this.groupOriginalText.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupOriginalText.Dock")));
			this.groupOriginalText.Enabled = ((bool)(resources.GetObject("groupOriginalText.Enabled")));
			this.groupOriginalText.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupOriginalText.Font = ((System.Drawing.Font)(resources.GetObject("groupOriginalText.Font")));
			this.groupOriginalText.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupOriginalText.ImeMode")));
			this.groupOriginalText.Location = ((System.Drawing.Point)(resources.GetObject("groupOriginalText.Location")));
			this.groupOriginalText.Name = "groupOriginalText";
			this.groupOriginalText.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupOriginalText.RightToLeft")));
			this.groupOriginalText.Size = ((System.Drawing.Size)(resources.GetObject("groupOriginalText.Size")));
			this.groupOriginalText.TabIndex = ((int)(resources.GetObject("groupOriginalText.TabIndex")));
			this.groupOriginalText.TabStop = false;
			this.groupOriginalText.Text = resources.GetString("groupOriginalText.Text");
			this.groupOriginalText.Visible = ((bool)(resources.GetObject("groupOriginalText.Visible")));
			this.visualStyleProvider.SetVisualStyleSupport(this.groupOriginalText, true);
			// 
			// textOriginalText
			// 
			this.textOriginalText.AccessibleDescription = resources.GetString("textOriginalText.AccessibleDescription");
			this.textOriginalText.AccessibleName = resources.GetString("textOriginalText.AccessibleName");
			this.textOriginalText.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("textOriginalText.Anchor")));
			this.textOriginalText.AutoSize = ((bool)(resources.GetObject("textOriginalText.AutoSize")));
			this.textOriginalText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textOriginalText.BackgroundImage")));
			this.textOriginalText.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("textOriginalText.Dock")));
			this.textOriginalText.Enabled = ((bool)(resources.GetObject("textOriginalText.Enabled")));
			this.textOriginalText.Font = ((System.Drawing.Font)(resources.GetObject("textOriginalText.Font")));
			this.textOriginalText.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("textOriginalText.ImeMode")));
			this.textOriginalText.Location = ((System.Drawing.Point)(resources.GetObject("textOriginalText.Location")));
			this.textOriginalText.MaxLength = ((int)(resources.GetObject("textOriginalText.MaxLength")));
			this.textOriginalText.Multiline = ((bool)(resources.GetObject("textOriginalText.Multiline")));
			this.textOriginalText.Name = "textOriginalText";
			this.textOriginalText.PasswordChar = ((char)(resources.GetObject("textOriginalText.PasswordChar")));
			this.textOriginalText.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("textOriginalText.RightToLeft")));
			this.textOriginalText.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("textOriginalText.ScrollBars")));
			this.textOriginalText.Size = ((System.Drawing.Size)(resources.GetObject("textOriginalText.Size")));
			this.textOriginalText.TabIndex = ((int)(resources.GetObject("textOriginalText.TabIndex")));
			this.textOriginalText.Text = resources.GetString("textOriginalText.Text");
			this.textOriginalText.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("textOriginalText.TextAlign")));
			this.textOriginalText.Visible = ((bool)(resources.GetObject("textOriginalText.Visible")));
			this.visualStyleProvider.SetVisualStyleSupport(this.textOriginalText, true);
			this.textOriginalText.WordWrap = ((bool)(resources.GetObject("textOriginalText.WordWrap")));
			// 
			// panelBottom
			// 
			this.panelBottom.AccessibleDescription = resources.GetString("panelBottom.AccessibleDescription");
			this.panelBottom.AccessibleName = resources.GetString("panelBottom.AccessibleName");
			this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panelBottom.Anchor")));
			this.panelBottom.AutoScroll = ((bool)(resources.GetObject("panelBottom.AutoScroll")));
			this.panelBottom.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panelBottom.AutoScrollMargin")));
			this.panelBottom.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panelBottom.AutoScrollMinSize")));
			this.panelBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBottom.BackgroundImage")));
			this.panelBottom.Controls.Add(this.buttonRepair);
			this.panelBottom.Controls.Add(this.buttonConvert);
			this.panelBottom.Controls.Add(this.groupConvertedText);
			this.panelBottom.Controls.Add(this.progressMain);
			this.panelBottom.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panelBottom.Dock")));
			this.panelBottom.Enabled = ((bool)(resources.GetObject("panelBottom.Enabled")));
			this.panelBottom.Font = ((System.Drawing.Font)(resources.GetObject("panelBottom.Font")));
			this.panelBottom.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panelBottom.ImeMode")));
			this.panelBottom.Location = ((System.Drawing.Point)(resources.GetObject("panelBottom.Location")));
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panelBottom.RightToLeft")));
			this.panelBottom.Size = ((System.Drawing.Size)(resources.GetObject("panelBottom.Size")));
			this.panelBottom.TabIndex = ((int)(resources.GetObject("panelBottom.TabIndex")));
			this.panelBottom.Text = resources.GetString("panelBottom.Text");
			this.panelBottom.Visible = ((bool)(resources.GetObject("panelBottom.Visible")));
			this.visualStyleProvider.SetVisualStyleSupport(this.panelBottom, true);
			this.panelBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBottom_Paint);
			// 
			// buttonRepair
			// 
			this.buttonRepair.AccessibleDescription = resources.GetString("buttonRepair.AccessibleDescription");
			this.buttonRepair.AccessibleName = resources.GetString("buttonRepair.AccessibleName");
			this.buttonRepair.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonRepair.Anchor")));
			this.buttonRepair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRepair.BackgroundImage")));
			this.buttonRepair.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonRepair.Dock")));
			this.buttonRepair.Enabled = ((bool)(resources.GetObject("buttonRepair.Enabled")));
			this.buttonRepair.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonRepair.FlatStyle")));
			this.buttonRepair.Font = ((System.Drawing.Font)(resources.GetObject("buttonRepair.Font")));
			this.buttonRepair.Image = ((System.Drawing.Image)(resources.GetObject("buttonRepair.Image")));
			this.buttonRepair.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonRepair.ImageAlign")));
			this.buttonRepair.ImageIndex = ((int)(resources.GetObject("buttonRepair.ImageIndex")));
			this.buttonRepair.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonRepair.ImeMode")));
			this.buttonRepair.Location = ((System.Drawing.Point)(resources.GetObject("buttonRepair.Location")));
			this.buttonRepair.Name = "buttonRepair";
			this.buttonRepair.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonRepair.RightToLeft")));
			this.buttonRepair.Size = ((System.Drawing.Size)(resources.GetObject("buttonRepair.Size")));
			this.buttonRepair.TabIndex = ((int)(resources.GetObject("buttonRepair.TabIndex")));
			this.buttonRepair.Text = resources.GetString("buttonRepair.Text");
			this.buttonRepair.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonRepair.TextAlign")));
			this.buttonRepair.Visible = ((bool)(resources.GetObject("buttonRepair.Visible")));
			this.visualStyleProvider.SetVisualStyleSupport(this.buttonRepair, true);
			this.buttonRepair.Click += new System.EventHandler(this.buttonRepair_Click);
			// 
			// buttonConvert
			// 
			this.buttonConvert.AccessibleDescription = resources.GetString("buttonConvert.AccessibleDescription");
			this.buttonConvert.AccessibleName = resources.GetString("buttonConvert.AccessibleName");
			this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonConvert.Anchor")));
			this.buttonConvert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonConvert.BackgroundImage")));
			this.buttonConvert.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonConvert.Dock")));
			this.buttonConvert.Enabled = ((bool)(resources.GetObject("buttonConvert.Enabled")));
			this.buttonConvert.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonConvert.FlatStyle")));
			this.buttonConvert.Font = ((System.Drawing.Font)(resources.GetObject("buttonConvert.Font")));
			this.buttonConvert.Image = ((System.Drawing.Image)(resources.GetObject("buttonConvert.Image")));
			this.buttonConvert.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonConvert.ImageAlign")));
			this.buttonConvert.ImageIndex = ((int)(resources.GetObject("buttonConvert.ImageIndex")));
			this.buttonConvert.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonConvert.ImeMode")));
			this.buttonConvert.Location = ((System.Drawing.Point)(resources.GetObject("buttonConvert.Location")));
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonConvert.RightToLeft")));
			this.buttonConvert.Size = ((System.Drawing.Size)(resources.GetObject("buttonConvert.Size")));
			this.buttonConvert.TabIndex = ((int)(resources.GetObject("buttonConvert.TabIndex")));
			this.buttonConvert.Text = resources.GetString("buttonConvert.Text");
			this.buttonConvert.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonConvert.TextAlign")));
			this.buttonConvert.Visible = ((bool)(resources.GetObject("buttonConvert.Visible")));
			this.visualStyleProvider.SetVisualStyleSupport(this.buttonConvert, true);
			this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
			// 
			// groupConvertedText
			// 
			this.groupConvertedText.AccessibleDescription = resources.GetString("groupConvertedText.AccessibleDescription");
			this.groupConvertedText.AccessibleName = resources.GetString("groupConvertedText.AccessibleName");
			this.groupConvertedText.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupConvertedText.Anchor")));
			this.groupConvertedText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupConvertedText.BackgroundImage")));
			this.groupConvertedText.Controls.Add(this.textConvertedText);
			this.groupConvertedText.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupConvertedText.Dock")));
			this.groupConvertedText.Enabled = ((bool)(resources.GetObject("groupConvertedText.Enabled")));
			this.groupConvertedText.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupConvertedText.Font = ((System.Drawing.Font)(resources.GetObject("groupConvertedText.Font")));
			this.groupConvertedText.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupConvertedText.ImeMode")));
			this.groupConvertedText.Location = ((System.Drawing.Point)(resources.GetObject("groupConvertedText.Location")));
			this.groupConvertedText.Name = "groupConvertedText";
			this.groupConvertedText.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupConvertedText.RightToLeft")));
			this.groupConvertedText.Size = ((System.Drawing.Size)(resources.GetObject("groupConvertedText.Size")));
			this.groupConvertedText.TabIndex = ((int)(resources.GetObject("groupConvertedText.TabIndex")));
			this.groupConvertedText.TabStop = false;
			this.groupConvertedText.Text = resources.GetString("groupConvertedText.Text");
			this.groupConvertedText.Visible = ((bool)(resources.GetObject("groupConvertedText.Visible")));
			this.visualStyleProvider.SetVisualStyleSupport(this.groupConvertedText, true);
			// 
			// textConvertedText
			// 
			this.textConvertedText.AccessibleDescription = resources.GetString("textConvertedText.AccessibleDescription");
			this.textConvertedText.AccessibleName = resources.GetString("textConvertedText.AccessibleName");
			this.textConvertedText.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("textConvertedText.Anchor")));
			this.textConvertedText.AutoSize = ((bool)(resources.GetObject("textConvertedText.AutoSize")));
			this.textConvertedText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textConvertedText.BackgroundImage")));
			this.textConvertedText.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("textConvertedText.Dock")));
			this.textConvertedText.Enabled = ((bool)(resources.GetObject("textConvertedText.Enabled")));
			this.textConvertedText.Font = ((System.Drawing.Font)(resources.GetObject("textConvertedText.Font")));
			this.textConvertedText.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("textConvertedText.ImeMode")));
			this.textConvertedText.Location = ((System.Drawing.Point)(resources.GetObject("textConvertedText.Location")));
			this.textConvertedText.MaxLength = ((int)(resources.GetObject("textConvertedText.MaxLength")));
			this.textConvertedText.Multiline = ((bool)(resources.GetObject("textConvertedText.Multiline")));
			this.textConvertedText.Name = "textConvertedText";
			this.textConvertedText.PasswordChar = ((char)(resources.GetObject("textConvertedText.PasswordChar")));
			this.textConvertedText.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("textConvertedText.RightToLeft")));
			this.textConvertedText.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("textConvertedText.ScrollBars")));
			this.textConvertedText.Size = ((System.Drawing.Size)(resources.GetObject("textConvertedText.Size")));
			this.textConvertedText.TabIndex = ((int)(resources.GetObject("textConvertedText.TabIndex")));
			this.textConvertedText.Text = resources.GetString("textConvertedText.Text");
			this.textConvertedText.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("textConvertedText.TextAlign")));
			this.textConvertedText.Visible = ((bool)(resources.GetObject("textConvertedText.Visible")));
			this.visualStyleProvider.SetVisualStyleSupport(this.textConvertedText, true);
			this.textConvertedText.WordWrap = ((bool)(resources.GetObject("textConvertedText.WordWrap")));
			// 
			// progressMain
			// 
			this.progressMain.AccessibleDescription = resources.GetString("progressMain.AccessibleDescription");
			this.progressMain.AccessibleName = resources.GetString("progressMain.AccessibleName");
			this.progressMain.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("progressMain.Anchor")));
			this.progressMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("progressMain.BackgroundImage")));
			this.progressMain.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("progressMain.Dock")));
			this.progressMain.Enabled = ((bool)(resources.GetObject("progressMain.Enabled")));
			this.progressMain.Font = ((System.Drawing.Font)(resources.GetObject("progressMain.Font")));
			this.progressMain.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("progressMain.ImeMode")));
			this.progressMain.Location = ((System.Drawing.Point)(resources.GetObject("progressMain.Location")));
			this.progressMain.Name = "progressMain";
			this.progressMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("progressMain.RightToLeft")));
			this.progressMain.Size = ((System.Drawing.Size)(resources.GetObject("progressMain.Size")));
			this.progressMain.TabIndex = ((int)(resources.GetObject("progressMain.TabIndex")));
			this.progressMain.Text = resources.GetString("progressMain.Text");
			this.progressMain.Visible = ((bool)(resources.GetObject("progressMain.Visible")));
			// 
			// splitterMain
			// 
			this.splitterMain.AccessibleDescription = resources.GetString("splitterMain.AccessibleDescription");
			this.splitterMain.AccessibleName = resources.GetString("splitterMain.AccessibleName");
			this.splitterMain.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("splitterMain.Anchor")));
			this.splitterMain.BackColor = System.Drawing.SystemColors.Control;
			this.splitterMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitterMain.BackgroundImage")));
			this.splitterMain.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("splitterMain.Dock")));
			this.splitterMain.Enabled = ((bool)(resources.GetObject("splitterMain.Enabled")));
			this.splitterMain.Font = ((System.Drawing.Font)(resources.GetObject("splitterMain.Font")));
			this.splitterMain.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("splitterMain.ImeMode")));
			this.splitterMain.Location = ((System.Drawing.Point)(resources.GetObject("splitterMain.Location")));
			this.splitterMain.MinExtra = ((int)(resources.GetObject("splitterMain.MinExtra")));
			this.splitterMain.MinSize = ((int)(resources.GetObject("splitterMain.MinSize")));
			this.splitterMain.Name = "splitterMain";
			this.splitterMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("splitterMain.RightToLeft")));
			this.splitterMain.Size = ((System.Drawing.Size)(resources.GetObject("splitterMain.Size")));
			this.splitterMain.TabIndex = ((int)(resources.GetObject("splitterMain.TabIndex")));
			this.splitterMain.TabStop = false;
			this.splitterMain.Visible = ((bool)(resources.GetObject("splitterMain.Visible")));
			// 
			// menuMain
			// 
			this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuTools,
																					 this.menuHelp});
			this.menuMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("menuMain.RightToLeft")));
			// 
			// menuFile
			// 
			this.menuFile.Enabled = ((bool)(resources.GetObject("menuFile.Enabled")));
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFileOpen,
																					 this.menuFileDash1,
																					 this.menuFileSave,
																					 this.menuFileSaveAs,
																					 this.mnuFileDash2,
																					 this.menuFileExport,
																					 this.menuFileDash3,
																					 this.menuFileLanguage,
																					 this.menuFileDash4,
																					 this.menuFileExit});
			this.menuFile.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFile.Shortcut")));
			this.menuFile.ShowShortcut = ((bool)(resources.GetObject("menuFile.ShowShortcut")));
			this.menuFile.Text = resources.GetString("menuFile.Text");
			this.menuFile.Visible = ((bool)(resources.GetObject("menuFile.Visible")));
			// 
			// menuFileOpen
			// 
			this.menuFileOpen.Enabled = ((bool)(resources.GetObject("menuFileOpen.Enabled")));
			this.menuFileOpen.Index = 0;
			this.menuFileOpen.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileOpen.Shortcut")));
			this.menuFileOpen.ShowShortcut = ((bool)(resources.GetObject("menuFileOpen.ShowShortcut")));
			this.menuFileOpen.Text = resources.GetString("menuFileOpen.Text");
			this.menuFileOpen.Visible = ((bool)(resources.GetObject("menuFileOpen.Visible")));
			this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
			// 
			// menuFileDash1
			// 
			this.menuFileDash1.Enabled = ((bool)(resources.GetObject("menuFileDash1.Enabled")));
			this.menuFileDash1.Index = 1;
			this.menuFileDash1.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileDash1.Shortcut")));
			this.menuFileDash1.ShowShortcut = ((bool)(resources.GetObject("menuFileDash1.ShowShortcut")));
			this.menuFileDash1.Text = resources.GetString("menuFileDash1.Text");
			this.menuFileDash1.Visible = ((bool)(resources.GetObject("menuFileDash1.Visible")));
			// 
			// menuFileSave
			// 
			this.menuFileSave.Enabled = ((bool)(resources.GetObject("menuFileSave.Enabled")));
			this.menuFileSave.Index = 2;
			this.menuFileSave.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileSave.Shortcut")));
			this.menuFileSave.ShowShortcut = ((bool)(resources.GetObject("menuFileSave.ShowShortcut")));
			this.menuFileSave.Text = resources.GetString("menuFileSave.Text");
			this.menuFileSave.Visible = ((bool)(resources.GetObject("menuFileSave.Visible")));
			this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
			// 
			// menuFileSaveAs
			// 
			this.menuFileSaveAs.Enabled = ((bool)(resources.GetObject("menuFileSaveAs.Enabled")));
			this.menuFileSaveAs.Index = 3;
			this.menuFileSaveAs.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileSaveAs.Shortcut")));
			this.menuFileSaveAs.ShowShortcut = ((bool)(resources.GetObject("menuFileSaveAs.ShowShortcut")));
			this.menuFileSaveAs.Text = resources.GetString("menuFileSaveAs.Text");
			this.menuFileSaveAs.Visible = ((bool)(resources.GetObject("menuFileSaveAs.Visible")));
			this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
			// 
			// mnuFileDash2
			// 
			this.mnuFileDash2.Enabled = ((bool)(resources.GetObject("mnuFileDash2.Enabled")));
			this.mnuFileDash2.Index = 4;
			this.mnuFileDash2.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuFileDash2.Shortcut")));
			this.mnuFileDash2.ShowShortcut = ((bool)(resources.GetObject("mnuFileDash2.ShowShortcut")));
			this.mnuFileDash2.Text = resources.GetString("mnuFileDash2.Text");
			this.mnuFileDash2.Visible = ((bool)(resources.GetObject("mnuFileDash2.Visible")));
			// 
			// menuFileExport
			// 
			this.menuFileExport.Enabled = ((bool)(resources.GetObject("menuFileExport.Enabled")));
			this.menuFileExport.Index = 5;
			this.menuFileExport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuFileExportXHTML});
			this.menuFileExport.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileExport.Shortcut")));
			this.menuFileExport.ShowShortcut = ((bool)(resources.GetObject("menuFileExport.ShowShortcut")));
			this.menuFileExport.Text = resources.GetString("menuFileExport.Text");
			this.menuFileExport.Visible = ((bool)(resources.GetObject("menuFileExport.Visible")));
			// 
			// menuFileExportXHTML
			// 
			this.menuFileExportXHTML.Enabled = ((bool)(resources.GetObject("menuFileExportXHTML.Enabled")));
			this.menuFileExportXHTML.Index = 0;
			this.menuFileExportXHTML.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileExportXHTML.Shortcut")));
			this.menuFileExportXHTML.ShowShortcut = ((bool)(resources.GetObject("menuFileExportXHTML.ShowShortcut")));
			this.menuFileExportXHTML.Text = resources.GetString("menuFileExportXHTML.Text");
			this.menuFileExportXHTML.Visible = ((bool)(resources.GetObject("menuFileExportXHTML.Visible")));
			this.menuFileExportXHTML.Click += new System.EventHandler(this.menuFileExportXHTML_Click);
			// 
			// menuFileDash3
			// 
			this.menuFileDash3.Enabled = ((bool)(resources.GetObject("menuFileDash3.Enabled")));
			this.menuFileDash3.Index = 6;
			this.menuFileDash3.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileDash3.Shortcut")));
			this.menuFileDash3.ShowShortcut = ((bool)(resources.GetObject("menuFileDash3.ShowShortcut")));
			this.menuFileDash3.Text = resources.GetString("menuFileDash3.Text");
			this.menuFileDash3.Visible = ((bool)(resources.GetObject("menuFileDash3.Visible")));
			// 
			// menuFileLanguage
			// 
			this.menuFileLanguage.Enabled = ((bool)(resources.GetObject("menuFileLanguage.Enabled")));
			this.menuFileLanguage.Index = 7;
			this.menuFileLanguage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuFileLanguageEnglish,
																							 this.menuFileLanguagePunjabi});
			this.menuFileLanguage.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileLanguage.Shortcut")));
			this.menuFileLanguage.ShowShortcut = ((bool)(resources.GetObject("menuFileLanguage.ShowShortcut")));
			this.menuFileLanguage.Text = resources.GetString("menuFileLanguage.Text");
			this.menuFileLanguage.Visible = ((bool)(resources.GetObject("menuFileLanguage.Visible")));
			// 
			// menuFileLanguageEnglish
			// 
			this.menuFileLanguageEnglish.Checked = true;
			this.menuFileLanguageEnglish.Enabled = ((bool)(resources.GetObject("menuFileLanguageEnglish.Enabled")));
			this.menuFileLanguageEnglish.Index = 0;
			this.menuFileLanguageEnglish.RadioCheck = true;
			this.menuFileLanguageEnglish.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileLanguageEnglish.Shortcut")));
			this.menuFileLanguageEnglish.ShowShortcut = ((bool)(resources.GetObject("menuFileLanguageEnglish.ShowShortcut")));
			this.menuFileLanguageEnglish.Text = resources.GetString("menuFileLanguageEnglish.Text");
			this.menuFileLanguageEnglish.Visible = ((bool)(resources.GetObject("menuFileLanguageEnglish.Visible")));
			// 
			// menuFileLanguagePunjabi
			// 
			this.menuFileLanguagePunjabi.Enabled = ((bool)(resources.GetObject("menuFileLanguagePunjabi.Enabled")));
			this.menuFileLanguagePunjabi.Index = 1;
			this.menuFileLanguagePunjabi.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileLanguagePunjabi.Shortcut")));
			this.menuFileLanguagePunjabi.ShowShortcut = ((bool)(resources.GetObject("menuFileLanguagePunjabi.ShowShortcut")));
			this.menuFileLanguagePunjabi.Text = resources.GetString("menuFileLanguagePunjabi.Text");
			this.menuFileLanguagePunjabi.Visible = ((bool)(resources.GetObject("menuFileLanguagePunjabi.Visible")));
			this.menuFileLanguagePunjabi.Click += new System.EventHandler(this.menuFileLanguagePunjabi_Click);
			// 
			// menuFileDash4
			// 
			this.menuFileDash4.Enabled = ((bool)(resources.GetObject("menuFileDash4.Enabled")));
			this.menuFileDash4.Index = 8;
			this.menuFileDash4.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileDash4.Shortcut")));
			this.menuFileDash4.ShowShortcut = ((bool)(resources.GetObject("menuFileDash4.ShowShortcut")));
			this.menuFileDash4.Text = resources.GetString("menuFileDash4.Text");
			this.menuFileDash4.Visible = ((bool)(resources.GetObject("menuFileDash4.Visible")));
			// 
			// menuFileExit
			// 
			this.menuFileExit.Enabled = ((bool)(resources.GetObject("menuFileExit.Enabled")));
			this.menuFileExit.Index = 9;
			this.menuFileExit.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuFileExit.Shortcut")));
			this.menuFileExit.ShowShortcut = ((bool)(resources.GetObject("menuFileExit.ShowShortcut")));
			this.menuFileExit.Text = resources.GetString("menuFileExit.Text");
			this.menuFileExit.Visible = ((bool)(resources.GetObject("menuFileExit.Visible")));
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuTools
			// 
			this.menuTools.Enabled = ((bool)(resources.GetObject("menuTools.Enabled")));
			this.menuTools.Index = 1;
			this.menuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuToolsConvert,
																					  this.menuToolsRepair,
																					  this.menuToolsDash1,
																					  this.menuToolsBatchProcessor,
																					  this.menuToolsCharCodeViewer,
																					  this.menuToolsDash2,
																					  this.menuToolsRomanise,
																					  this.menuToolsDash3,
																					  this.menuToolsOptions});
			this.menuTools.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuTools.Shortcut")));
			this.menuTools.ShowShortcut = ((bool)(resources.GetObject("menuTools.ShowShortcut")));
			this.menuTools.Text = resources.GetString("menuTools.Text");
			this.menuTools.Visible = ((bool)(resources.GetObject("menuTools.Visible")));
			// 
			// menuToolsConvert
			// 
			this.menuToolsConvert.Enabled = ((bool)(resources.GetObject("menuToolsConvert.Enabled")));
			this.menuToolsConvert.Index = 0;
			this.menuToolsConvert.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuToolsConvertLipitoUnicode,
																							 this.menuToolsConvertDash1});
			this.menuToolsConvert.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsConvert.Shortcut")));
			this.menuToolsConvert.ShowShortcut = ((bool)(resources.GetObject("menuToolsConvert.ShowShortcut")));
			this.menuToolsConvert.Text = resources.GetString("menuToolsConvert.Text");
			this.menuToolsConvert.Visible = ((bool)(resources.GetObject("menuToolsConvert.Visible")));
			// 
			// menuToolsConvertLipitoUnicode
			// 
			this.menuToolsConvertLipitoUnicode.Checked = true;
			this.menuToolsConvertLipitoUnicode.DefaultItem = true;
			this.menuToolsConvertLipitoUnicode.Enabled = ((bool)(resources.GetObject("menuToolsConvertLipitoUnicode.Enabled")));
			this.menuToolsConvertLipitoUnicode.Index = 0;
			this.menuToolsConvertLipitoUnicode.RadioCheck = true;
			this.menuToolsConvertLipitoUnicode.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsConvertLipitoUnicode.Shortcut")));
			this.menuToolsConvertLipitoUnicode.ShowShortcut = ((bool)(resources.GetObject("menuToolsConvertLipitoUnicode.ShowShortcut")));
			this.menuToolsConvertLipitoUnicode.Text = resources.GetString("menuToolsConvertLipitoUnicode.Text");
			this.menuToolsConvertLipitoUnicode.Visible = ((bool)(resources.GetObject("menuToolsConvertLipitoUnicode.Visible")));
			this.menuToolsConvertLipitoUnicode.Click += new System.EventHandler(this.menuToolsConvertLipitoUnicode_Click);
			// 
			// menuToolsConvertDash1
			// 
			this.menuToolsConvertDash1.Enabled = ((bool)(resources.GetObject("menuToolsConvertDash1.Enabled")));
			this.menuToolsConvertDash1.Index = 1;
			this.menuToolsConvertDash1.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsConvertDash1.Shortcut")));
			this.menuToolsConvertDash1.ShowShortcut = ((bool)(resources.GetObject("menuToolsConvertDash1.ShowShortcut")));
			this.menuToolsConvertDash1.Text = resources.GetString("menuToolsConvertDash1.Text");
			this.menuToolsConvertDash1.Visible = ((bool)(resources.GetObject("menuToolsConvertDash1.Visible")));
			// 
			// menuToolsRepair
			// 
			this.menuToolsRepair.Enabled = ((bool)(resources.GetObject("menuToolsRepair.Enabled")));
			this.menuToolsRepair.Index = 1;
			this.menuToolsRepair.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsRepair.Shortcut")));
			this.menuToolsRepair.ShowShortcut = ((bool)(resources.GetObject("menuToolsRepair.ShowShortcut")));
			this.menuToolsRepair.Text = resources.GetString("menuToolsRepair.Text");
			this.menuToolsRepair.Visible = ((bool)(resources.GetObject("menuToolsRepair.Visible")));
			this.menuToolsRepair.Click += new System.EventHandler(this.buttonRepair_Click);
			// 
			// menuToolsDash1
			// 
			this.menuToolsDash1.Enabled = ((bool)(resources.GetObject("menuToolsDash1.Enabled")));
			this.menuToolsDash1.Index = 2;
			this.menuToolsDash1.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsDash1.Shortcut")));
			this.menuToolsDash1.ShowShortcut = ((bool)(resources.GetObject("menuToolsDash1.ShowShortcut")));
			this.menuToolsDash1.Text = resources.GetString("menuToolsDash1.Text");
			this.menuToolsDash1.Visible = ((bool)(resources.GetObject("menuToolsDash1.Visible")));
			// 
			// menuToolsBatchProcessor
			// 
			this.menuToolsBatchProcessor.Enabled = ((bool)(resources.GetObject("menuToolsBatchProcessor.Enabled")));
			this.menuToolsBatchProcessor.Index = 3;
			this.menuToolsBatchProcessor.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsBatchProcessor.Shortcut")));
			this.menuToolsBatchProcessor.ShowShortcut = ((bool)(resources.GetObject("menuToolsBatchProcessor.ShowShortcut")));
			this.menuToolsBatchProcessor.Text = resources.GetString("menuToolsBatchProcessor.Text");
			this.menuToolsBatchProcessor.Visible = ((bool)(resources.GetObject("menuToolsBatchProcessor.Visible")));
			this.menuToolsBatchProcessor.Click += new System.EventHandler(this.menuToolsBatchProcessor_Click);
			// 
			// menuToolsCharCodeViewer
			// 
			this.menuToolsCharCodeViewer.Enabled = ((bool)(resources.GetObject("menuToolsCharCodeViewer.Enabled")));
			this.menuToolsCharCodeViewer.Index = 4;
			this.menuToolsCharCodeViewer.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsCharCodeViewer.Shortcut")));
			this.menuToolsCharCodeViewer.ShowShortcut = ((bool)(resources.GetObject("menuToolsCharCodeViewer.ShowShortcut")));
			this.menuToolsCharCodeViewer.Text = resources.GetString("menuToolsCharCodeViewer.Text");
			this.menuToolsCharCodeViewer.Visible = ((bool)(resources.GetObject("menuToolsCharCodeViewer.Visible")));
			this.menuToolsCharCodeViewer.Click += new System.EventHandler(this.menuToolsCharCodeViewer_Click);
			// 
			// menuToolsDash2
			// 
			this.menuToolsDash2.Enabled = ((bool)(resources.GetObject("menuToolsDash2.Enabled")));
			this.menuToolsDash2.Index = 5;
			this.menuToolsDash2.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsDash2.Shortcut")));
			this.menuToolsDash2.ShowShortcut = ((bool)(resources.GetObject("menuToolsDash2.ShowShortcut")));
			this.menuToolsDash2.Text = resources.GetString("menuToolsDash2.Text");
			this.menuToolsDash2.Visible = ((bool)(resources.GetObject("menuToolsDash2.Visible")));
			// 
			// menuToolsRomanise
			// 
			this.menuToolsRomanise.Enabled = ((bool)(resources.GetObject("menuToolsRomanise.Enabled")));
			this.menuToolsRomanise.Index = 6;
			this.menuToolsRomanise.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsRomanise.Shortcut")));
			this.menuToolsRomanise.ShowShortcut = ((bool)(resources.GetObject("menuToolsRomanise.ShowShortcut")));
			this.menuToolsRomanise.Text = resources.GetString("menuToolsRomanise.Text");
			this.menuToolsRomanise.Visible = ((bool)(resources.GetObject("menuToolsRomanise.Visible")));
			this.menuToolsRomanise.Click += new System.EventHandler(this.menuToolsRomanise_Click);
			// 
			// menuToolsDash3
			// 
			this.menuToolsDash3.Enabled = ((bool)(resources.GetObject("menuToolsDash3.Enabled")));
			this.menuToolsDash3.Index = 7;
			this.menuToolsDash3.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsDash3.Shortcut")));
			this.menuToolsDash3.ShowShortcut = ((bool)(resources.GetObject("menuToolsDash3.ShowShortcut")));
			this.menuToolsDash3.Text = resources.GetString("menuToolsDash3.Text");
			this.menuToolsDash3.Visible = ((bool)(resources.GetObject("menuToolsDash3.Visible")));
			// 
			// menuToolsOptions
			// 
			this.menuToolsOptions.Enabled = ((bool)(resources.GetObject("menuToolsOptions.Enabled")));
			this.menuToolsOptions.Index = 8;
			this.menuToolsOptions.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuToolsOptions.Shortcut")));
			this.menuToolsOptions.ShowShortcut = ((bool)(resources.GetObject("menuToolsOptions.ShowShortcut")));
			this.menuToolsOptions.Text = resources.GetString("menuToolsOptions.Text");
			this.menuToolsOptions.Visible = ((bool)(resources.GetObject("menuToolsOptions.Visible")));
			this.menuToolsOptions.Click += new System.EventHandler(this.menuToolsOptions_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Enabled = ((bool)(resources.GetObject("menuHelp.Enabled")));
			this.menuHelp.Index = 2;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuHelpContents,
																					 this.menuHelpQuickHelp,
																					 this.menuHelpDash1,
																					 this.menuHelpAbout});
			this.menuHelp.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuHelp.Shortcut")));
			this.menuHelp.ShowShortcut = ((bool)(resources.GetObject("menuHelp.ShowShortcut")));
			this.menuHelp.Text = resources.GetString("menuHelp.Text");
			this.menuHelp.Visible = ((bool)(resources.GetObject("menuHelp.Visible")));
			// 
			// menuHelpContents
			// 
			this.menuHelpContents.Enabled = ((bool)(resources.GetObject("menuHelpContents.Enabled")));
			this.menuHelpContents.Index = 0;
			this.menuHelpContents.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuHelpContents.Shortcut")));
			this.menuHelpContents.ShowShortcut = ((bool)(resources.GetObject("menuHelpContents.ShowShortcut")));
			this.menuHelpContents.Text = resources.GetString("menuHelpContents.Text");
			this.menuHelpContents.Visible = ((bool)(resources.GetObject("menuHelpContents.Visible")));
			this.menuHelpContents.Click += new System.EventHandler(this.menuHelpContents_Click);
			// 
			// menuHelpQuickHelp
			// 
			this.menuHelpQuickHelp.Enabled = ((bool)(resources.GetObject("menuHelpQuickHelp.Enabled")));
			this.menuHelpQuickHelp.Index = 1;
			this.menuHelpQuickHelp.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuHelpQuickHelp.Shortcut")));
			this.menuHelpQuickHelp.ShowShortcut = ((bool)(resources.GetObject("menuHelpQuickHelp.ShowShortcut")));
			this.menuHelpQuickHelp.Text = resources.GetString("menuHelpQuickHelp.Text");
			this.menuHelpQuickHelp.Visible = ((bool)(resources.GetObject("menuHelpQuickHelp.Visible")));
			this.menuHelpQuickHelp.Click += new System.EventHandler(this.menuHelpQuickHelp_Click);
			// 
			// menuHelpDash1
			// 
			this.menuHelpDash1.Enabled = ((bool)(resources.GetObject("menuHelpDash1.Enabled")));
			this.menuHelpDash1.Index = 2;
			this.menuHelpDash1.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuHelpDash1.Shortcut")));
			this.menuHelpDash1.ShowShortcut = ((bool)(resources.GetObject("menuHelpDash1.ShowShortcut")));
			this.menuHelpDash1.Text = resources.GetString("menuHelpDash1.Text");
			this.menuHelpDash1.Visible = ((bool)(resources.GetObject("menuHelpDash1.Visible")));
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Enabled = ((bool)(resources.GetObject("menuHelpAbout.Enabled")));
			this.menuHelpAbout.Index = 3;
			this.menuHelpAbout.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuHelpAbout.Shortcut")));
			this.menuHelpAbout.ShowShortcut = ((bool)(resources.GetObject("menuHelpAbout.ShowShortcut")));
			this.menuHelpAbout.Text = resources.GetString("menuHelpAbout.Text");
			this.menuHelpAbout.Visible = ((bool)(resources.GetObject("menuHelpAbout.Visible")));
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// formMain
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.splitterMain);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelTop);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Menu = this.menuMain;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "formMain";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.formMain_Load);
			this.Activated += new System.EventHandler(this.formMain_Activated);
			this.panelTop.ResumeLayout(false);
			this.groupOriginalText.ResumeLayout(false);
			this.panelBottom.ResumeLayout(false);
			this.groupConvertedText.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		bool bFirstLoad = false;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Skybound.VisualStyles.VisualStyleProvider.EnableVisualStyles();
			//Application.EnableVisualStyles(); 
			Application.Run(new formMain());
		}

		private void StartConvert()
		{
			StartConvert(false, "");
		}

		private void StartConvert(bool bUseMapping, string sMappingFile)
		{
			if (buttonConvert.Text == "&Cancel")
			{
				ProgramResources.Convert.Cancel();
				return;
			}

			if (textOriginalText.Text.Length > 5000000)
			{
				if (MessageBox.Show("The text you wish to convert is quite large and may take a while to process.  Do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
					return;
			}
			
			progressMain.Value = 0;
			progressMain.Minimum = 0;
			progressMain.Maximum = 100;

			menuFile.Enabled = false;
			menuHelp.Enabled = false;
			menuTools.Enabled = false;
			buttonRepair.Enabled = false;

			this.Cursor = Cursors.WaitCursor;

			buttonConvert.Text = "&Cancel";

			ProgramResources.InitEngine();
			ProgramResources.Convert.ProgressBar = progressMain;

			if (bUseMapping == true)
			{
				ProgramResources.Convert.LoadMapping(sMappingFile);
				ProgramResources.sConvertString = ProgramResources.Convert.Convert(textOriginalText.Text, ConversionType.Mapping);
			}
			else
			{
				ProgramResources.sConvertString = ProgramResources.Convert.Convert(textOriginalText.Text, ConversionType.Internal);
			}
			
			textConvertedText.Text = ProgramResources.sConvertString;

			progressMain.Value = 0;

			buttonConvert.Text = "&Convert (F5)";

			buttonRepair.Enabled = true;
			menuFile.Enabled = true;
			menuHelp.Enabled = true;
			menuTools.Enabled = true;
			this.Cursor = Cursors.Default;
		}

		private void buttonConvert_Click(object sender, System.EventArgs e)
		{
			if (menuToolsConvertLipitoUnicode.Checked == true)
				StartConvert();
			else
			{
				IEnumerator Iter = menuToolsConvert.MenuItems.GetEnumerator();

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
						StartConvert(true, (string)Item.Tag);
						return;
					}
				}
			}
		}

		private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			formAbout formNew = new formAbout();
			formNew.ShowDialog(this);
		}

		private void menuFileExit_Click(object sender, System.EventArgs e)
		{
			formMain.ActiveForm.Close();
		}

		private void menuFileOpen_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.CheckFileExists = true;
			openFile.Title = "Open...";
			openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			openFile.FilterIndex = 2;

			if(openFile.ShowDialog() == DialogResult.OK)
			{
				try
				{
					StreamReader streamRead = File.OpenText(openFile.FileName);
					textOriginalText.Text = streamRead.ReadToEnd();
				}
				catch (Exception exp)
				{
					MessageBox.Show("Unable to open file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}				
			}
		}

		private void menuFileExportXHTML_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog exportFile = new SaveFileDialog();
			exportFile.RestoreDirectory = true;
			exportFile.Title = "Export...";
			exportFile.Filter = "HTML files (*.html, *.htm)|*.html;*.htm|All files (*.*)|*.*";
			exportFile.FilterIndex = 1;

			if(exportFile.ShowDialog() == DialogResult.OK)
			{
				String sExportFileName = exportFile.FileName;
				
				try
				{
					if (File.Exists(sExportFileName) == true)
						File.Delete(sExportFileName);

					StreamWriter streamWrite;

					CSettings Settings = new CSettings(true);
					String sProgram = Application.ProductName.ToLower();
				
					if (Settings.GetSetting(sProgram, "output", "utf16", false) == true)
						streamWrite = new StreamWriter(sExportFileName, false, System.Text.Encoding.Unicode);
					else
						streamWrite = new StreamWriter(sExportFileName, false, System.Text.Encoding.UTF8);				
				
					bool bXHTML11 = Settings.GetSetting(sProgram, "output", "xhtml11", false);

					String sLang;
					if (Settings.GetSetting(sProgram, "locale", "genericpa", false) == true)
						sLang = "pa";
					else
						sLang = "pa-IN";

					// Create XHTML
					String sHeader = "";

					if (Settings.GetSetting(sProgram, "output", "include_xml_decl", false) == true)
					{
						if (streamWrite.Encoding == System.Text.Encoding.UTF8)
							sHeader = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
						else if (streamWrite.Encoding == System.Text.Encoding.Unicode)
							sHeader = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n";					 
					}

					if (bXHTML11 == true)
						sHeader += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">\r\n";
					else
						sHeader += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n";

					sHeader += "<!-- \r\n\r\n";
					sHeader += "    This XHTML file was automatically generated by GUCA.\r\n\r\n";
					if (Settings.GetSetting(sProgram, "output", "include_xml_decl", false) == true)
					{
						sHeader += "    If you wish to publish this page online, please remove the XML\r\n";
						sHeader += "    declaration as this can cause problems with browsers that do not\r\n";
						if (bXHTML11 == true)
							sHeader += "    fully support XHTML 1.1.\r\n\r\n";
						else
							sHeader += "    fully support XHTML 1.0.\r\n\r\n";
					}
					sHeader += "-->\r\n";
					if (bXHTML11 == true)
						sHeader += "<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"" + sLang + "\">\r\n";
					else
						sHeader += "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" + sLang + "\" xml:lang=\"" + sLang + "\">\r\n";
					
					sHeader += "    <head>\r\n";
					sHeader += "        <title>GUCA Export</title>\r\n" ;
					if (streamWrite.Encoding == System.Text.Encoding.UTF8)
						sHeader += "        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n";
					else if (streamWrite.Encoding == System.Text.Encoding.Unicode)
						sHeader += "        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-16\" />\r\n";
					sHeader += "        <style type=\"text/css\">\r\n        <!--\r\n";
					sHeader += "            p,h1,h2,h3,h4,h5,h6            {font-family: Saab, Raavi, Saraswati5, Arial Unicode MS, Tahoma, Verdana, Arial; font-weight: normal;}\r\n";
					sHeader += "            .microtext   {font-family: Tahoma, Verdana, Arial; font-size: 10px; font-weight: normal;}\r\n";
					sHeader += "        -->\r\n        </style>\r\n";
					sHeader += "    </head>\r\n";
					sHeader += "    <body>\r\n";

					String sBody = "";

					String sFooter;
					if (bXHTML11 == true)
						sFooter = "        <p class=\"microtext\" xml:lang=\"en\">This file was generated automatically using the <a href=\"http://guca.sourceforge.net/\">Gurmukhi Unicode Conversion Application</a> and is fully compliant with <a href=\"http://validator.w3.org/\">XHTML</a> and <a href=\"http://jigsaw.w3.org/css-validator/\">CSS</a> standards.</p>\r\n";
					else
						sFooter = "        <p class=\"microtext\" lang=\"en\" xml:lang=\"en\">This file was generated automatically using the <a href=\"http://guca.sourceforge.net/\">Gurmukhi Unicode Conversion Application</a> and is fully compliant with <a href=\"http://validator.w3.org/\">XHTML</a> and <a href=\"http://jigsaw.w3.org/css-validator/\">CSS</a> standards.</p>\r\n";

					sFooter += "    </body>\r\n</html>";

					sBody += "        <p>\r\n";
					sBody += ProgramResources.sConvertString.Replace("\r\n", "<br/>\r\n");
					sBody += "\r\n        </p>\r\n";				

					sBody.Replace("&", "&amp;");
					sBody.Replace("<", "&lt;");

					streamWrite.Write(sHeader);
					streamWrite.Write(sBody);
					streamWrite.Write(sFooter);

					streamWrite.Close();
				}
				catch (Exception exp)
				{
					MessageBox.Show("Unable to export file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}	

			}
		}

		private void menuFileSave_Click(object sender, System.EventArgs e)
		{
			if (ProgramResources.sFileName == "")
			{
				SaveFileDialog saveFile = new SaveFileDialog();
				saveFile.RestoreDirectory = true;
				saveFile.Title = "Save...";
				saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
				saveFile.FilterIndex = 1;

				if(saveFile.ShowDialog() == DialogResult.OK)
				{
					ProgramResources.sFileName = saveFile.FileName;
					this.SaveFile();
				}
			}
			else
			{
				this.SaveFile();
			}
		}

		private void menuFileSaveAs_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.RestoreDirectory = true;
			saveFile.Title = "Save As...";
			saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			saveFile.FilterIndex = 1;

			if(saveFile.ShowDialog() == DialogResult.OK)
			{
				ProgramResources.sFileName = saveFile.FileName;
				this.SaveFile();
			}
		}

		private void SaveFile()
		{
			try
			{
				if (File.Exists(ProgramResources.sFileName) == true)
					File.Delete(ProgramResources.sFileName);

				StreamWriter streamWrite;
				CSettings Settings = new CSettings(true);
				String sProgram = Application.ProductName.ToLower();

				if (Settings.GetSetting(sProgram, "output", "utf16", false) == true)
					streamWrite = new StreamWriter(ProgramResources.sFileName, false, System.Text.Encoding.Unicode);
				else
					streamWrite = new StreamWriter(ProgramResources.sFileName, false, System.Text.Encoding.UTF8);				

				streamWrite.Write(textConvertedText.Text);
				streamWrite.Close();
			}
			catch (Exception exp)
			{
				MessageBox.Show("Unable to save file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}	
		}

		private void menuToolsOptions_Click(object sender, System.EventArgs e)
		{
			formOptions formNew = new formOptions();
			formNew.ShowDialog(this);
		}

		private void menuHelpContents_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(ProgramResources.sApplicationDirectory + "help.html");
			}
			catch
			{
				MessageBox.Show("GUCA was unable to open the user documentation.  Please check that the appropriate files are in the current directory.", "GUCA", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}			
		}

		private void menuHelpQuickHelp_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("GUCA is designed to convert ASCII based Gurmukhi text into its Unicode equivalent.\r\n\r\nTo get started, enter text into the top text area and then press convert.  The corresponding Unicode text will be shown below.  Although the conversion engine is fairly accurate, errors in the original text might not show up clearly until conversion and therefore the resulting text will require proof-reading.\r\n\r\nFor details regarding the repair process, please see the main help files.", "Quick Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public void ChangeOriginalFont(System.Drawing.Font font)
		{
			ChangeOriginalFont(font, SystemColors.WindowText);
		}

		public void ChangeConvertedFont(System.Drawing.Font font)
		{
			ChangeConvertedFont(font, SystemColors.WindowText);
		}

		public void ChangeOriginalFont(System.Drawing.Font font, System.Drawing.Color colour)
		{
			textOriginalText.Font = font;
			textOriginalText.ForeColor = colour;
		}

		public void ChangeConvertedFont(System.Drawing.Font font, System.Drawing.Color colour)
		{
			textConvertedText.Font = font;
			textConvertedText.ForeColor = colour;
		}


		private void menuToolsBatchProcessor_Click(object sender, System.EventArgs e)
		{
			formBatchProcessor frmConvert = new formBatchProcessor();
			frmConvert.ShowDialog(this);
		}

		private void buttonRepair_Click(object sender, System.EventArgs e)
		{
			if (buttonRepair.Text == "&Cancel (F6)")
			{
				ProgramResources.Convert.Cancel();
				return;
			}

			if (textOriginalText.Text.Length > 5000000)
			{
				if (MessageBox.Show("The text you wish to repair is quite large and may take a while to process.  Do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
					return;
			}
			
			progressMain.Value = 0;
			progressMain.Minimum = 0;
			progressMain.Maximum = 100;

			menuFile.Enabled = false;
			menuHelp.Enabled = false;
			menuToolsOptions.Enabled = false;
			menuToolsConvert.Enabled = false;
			menuToolsBatchProcessor.Enabled = false;
			buttonConvert.Enabled = false;

			this.Cursor = Cursors.WaitCursor;

			buttonRepair.Text = "&Cancel (F6)";
			menuToolsRepair.Text = "&Cancel Repair";

			ProgramResources.InitEngine();
			ProgramResources.Convert.ProgressBar = progressMain;
			ProgramResources.sConvertString = ProgramResources.Convert.Convert(textOriginalText.Text, ConversionType.Repair);
			textConvertedText.Text = ProgramResources.sConvertString;

			progressMain.Value = 0;

			buttonRepair.Text = "&Repair (F6)";
			menuToolsRepair.Text = "&Repair";

			buttonConvert.Enabled = true;
			menuFile.Enabled = true;
			menuHelp.Enabled = true;
			menuToolsOptions.Enabled = true;
			menuToolsConvert.Enabled = true;
			menuToolsBatchProcessor.Enabled = true;
			this.Cursor = Cursors.Default;
		}

		private void menuToolsCharCodeViewer_Click(object sender, System.EventArgs e)
		{
			formCode frmCodeViewer = new formCode();
			frmCodeViewer.ShowDialog(this);
		}

		public void menuCustomConversion_Click(object sender, System.EventArgs e)
		{
			TaggedMenuItem Item = (TaggedMenuItem)sender;
			StartConvert(true, (string)Item.Tag);
		}

		private void menuFileLanguagePunjabi_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("A Punjabi translation of GUCA should be available shortly - I hope!", "Coming soon...", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void panelBottom_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void menuToolsRomanise_Click(object sender, System.EventArgs e)
		{
			Transliterator TransLit = new Transliterator();

			textConvertedText.Text = TransLit.ToLatin(textOriginalText.Text);
		}

		private void formMain_VisibleChanged(object sender, System.EventArgs e)
		{
		}

		private void formMain_Activated(object sender, System.EventArgs e)
		{
		
			// Shouldn't really be used here.  But the only
			// time the visible state changes is when loading
			if (this.Visible == true && bFirstLoad == false)
			{
				bFirstLoad = true;
				Application.DoEvents();
				formLoading Loading = new formLoading();
				Loading.ShowDialog(this);
			}
		}

		private void formMain_Load(object sender, System.EventArgs e)
		{
		
		}

		private void panelTop_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void menuToolsConvertLipitoUnicode_Click(object sender, System.EventArgs e)
		{
			StartConvert();
		}

	}
}
