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
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Unicode.Gurmukhi.Forms
{
	/// <summary>
	/// Summary description for formOptions.
	/// </summary>
	public class formOptions : System.Windows.Forms.Form
	{
		private CSettings Settings;

		private System.Windows.Forms.CheckBox checkErrorCorrection;
		private System.Windows.Forms.CheckBox checkConvertNumbers;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.GroupBox groupConversionSettings;
		private System.Windows.Forms.GroupBox groupFonts;
		private System.Windows.Forms.GroupBox groupUnicodeVersion;
		private System.Windows.Forms.RadioButton radioUnicode3;
		private System.Windows.Forms.RadioButton radioUnicode4;
		private System.Windows.Forms.ToolTip tipMain;
		private System.Windows.Forms.Button btnOriginalTextFont;
		private System.Windows.Forms.Button btnConvertedTextFont;
		private System.ComponentModel.IContainer components;

		private Font fontOriginal;
		private System.Windows.Forms.TabControl tabOptions;
		private System.Windows.Forms.TabPage tabOptionsGeneral;
		private System.Windows.Forms.TabPage tabOptionsConversionRepair;
		private System.Windows.Forms.GroupBox groupRepairSettings;
		private System.Windows.Forms.CheckBox checkRepairISCII;
		private System.Windows.Forms.CheckBox checkRepairRepositionI;
		private System.Windows.Forms.GroupBox groupBatchProcessor;
		private System.Windows.Forms.Label labelExtension;
		private System.Windows.Forms.TextBox textExtension;
		private System.Windows.Forms.CheckBox checkRenameOriginalFile;
		private System.Windows.Forms.CheckBox checkNormaliseText;
		private System.Windows.Forms.TabPage tabOptionsMappings;
		private System.Windows.Forms.GroupBox groupCustomMappings;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.TextBox textMappingsDirectory;
		private System.Windows.Forms.GroupBox groupRecognisedMappings;
		private System.Windows.Forms.ListView listRecognisedMapping;
		private System.Windows.Forms.ColumnHeader columnFrom;
		private System.Windows.Forms.ColumnHeader columnTo;
		private System.Windows.Forms.ColumnHeader columnVersion;
		private System.Windows.Forms.GroupBox groupLocaleType;
		private System.Windows.Forms.RadioButton radioPunjabiGeneric;
		private System.Windows.Forms.RadioButton radioPunjabiIndia;
		private System.Windows.Forms.GroupBox groupUnicodeTransformation;
		private System.Windows.Forms.RadioButton radioOutputUTF8;
		private System.Windows.Forms.RadioButton radioOutputUTF16;
		private System.Windows.Forms.GroupBox groupXHTMLSettings;
		private System.Windows.Forms.CheckBox checkXHTMLXMLDec;
		private System.Windows.Forms.RadioButton radioXHTML11;
		private System.Windows.Forms.RadioButton radioXHTML10;
		private System.Windows.Forms.Button buttonRemoveMapping;
		private System.Windows.Forms.Button buttonAddMapping;
		private System.Windows.Forms.Button buttonMappingDetails;
		private System.Windows.Forms.GroupBox groupOrganise;
		private Skybound.VisualStyles.VisualStyleProvider visualStyleProvider;
		private Font fontConverted;

		public formOptions()
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
			this.components = new System.ComponentModel.Container();
			this.checkErrorCorrection = new System.Windows.Forms.CheckBox();
			this.checkConvertNumbers = new System.Windows.Forms.CheckBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.groupConversionSettings = new System.Windows.Forms.GroupBox();
			this.groupFonts = new System.Windows.Forms.GroupBox();
			this.btnConvertedTextFont = new System.Windows.Forms.Button();
			this.btnOriginalTextFont = new System.Windows.Forms.Button();
			this.groupUnicodeVersion = new System.Windows.Forms.GroupBox();
			this.radioUnicode3 = new System.Windows.Forms.RadioButton();
			this.radioUnicode4 = new System.Windows.Forms.RadioButton();
			this.tipMain = new System.Windows.Forms.ToolTip(this.components);
			this.checkRepairISCII = new System.Windows.Forms.CheckBox();
			this.checkRepairRepositionI = new System.Windows.Forms.CheckBox();
			this.checkRenameOriginalFile = new System.Windows.Forms.CheckBox();
			this.textExtension = new System.Windows.Forms.TextBox();
			this.checkNormaliseText = new System.Windows.Forms.CheckBox();
			this.radioPunjabiGeneric = new System.Windows.Forms.RadioButton();
			this.radioPunjabiIndia = new System.Windows.Forms.RadioButton();
			this.radioOutputUTF8 = new System.Windows.Forms.RadioButton();
			this.radioOutputUTF16 = new System.Windows.Forms.RadioButton();
			this.checkXHTMLXMLDec = new System.Windows.Forms.CheckBox();
			this.radioXHTML11 = new System.Windows.Forms.RadioButton();
			this.radioXHTML10 = new System.Windows.Forms.RadioButton();
			this.buttonMappingDetails = new System.Windows.Forms.Button();
			this.buttonRemoveMapping = new System.Windows.Forms.Button();
			this.buttonAddMapping = new System.Windows.Forms.Button();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.tabOptions = new System.Windows.Forms.TabControl();
			this.tabOptionsGeneral = new System.Windows.Forms.TabPage();
			this.groupXHTMLSettings = new System.Windows.Forms.GroupBox();
			this.groupUnicodeTransformation = new System.Windows.Forms.GroupBox();
			this.groupLocaleType = new System.Windows.Forms.GroupBox();
			this.groupBatchProcessor = new System.Windows.Forms.GroupBox();
			this.labelExtension = new System.Windows.Forms.Label();
			this.tabOptionsConversionRepair = new System.Windows.Forms.TabPage();
			this.groupRepairSettings = new System.Windows.Forms.GroupBox();
			this.tabOptionsMappings = new System.Windows.Forms.TabPage();
			this.groupOrganise = new System.Windows.Forms.GroupBox();
			this.groupRecognisedMappings = new System.Windows.Forms.GroupBox();
			this.listRecognisedMapping = new System.Windows.Forms.ListView();
			this.columnFrom = new System.Windows.Forms.ColumnHeader();
			this.columnTo = new System.Windows.Forms.ColumnHeader();
			this.columnVersion = new System.Windows.Forms.ColumnHeader();
			this.groupCustomMappings = new System.Windows.Forms.GroupBox();
			this.textMappingsDirectory = new System.Windows.Forms.TextBox();
			this.visualStyleProvider = new Skybound.VisualStyles.VisualStyleProvider();
			this.groupConversionSettings.SuspendLayout();
			this.groupFonts.SuspendLayout();
			this.groupUnicodeVersion.SuspendLayout();
			this.tabOptions.SuspendLayout();
			this.tabOptionsGeneral.SuspendLayout();
			this.groupXHTMLSettings.SuspendLayout();
			this.groupUnicodeTransformation.SuspendLayout();
			this.groupLocaleType.SuspendLayout();
			this.groupBatchProcessor.SuspendLayout();
			this.tabOptionsConversionRepair.SuspendLayout();
			this.groupRepairSettings.SuspendLayout();
			this.tabOptionsMappings.SuspendLayout();
			this.groupOrganise.SuspendLayout();
			this.groupRecognisedMappings.SuspendLayout();
			this.groupCustomMappings.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkErrorCorrection
			// 
			this.checkErrorCorrection.Checked = true;
			this.checkErrorCorrection.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkErrorCorrection.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkErrorCorrection.Location = new System.Drawing.Point(8, 16);
			this.checkErrorCorrection.Name = "checkErrorCorrection";
			this.checkErrorCorrection.Size = new System.Drawing.Size(152, 24);
			this.checkErrorCorrection.TabIndex = 22;
			this.checkErrorCorrection.Text = "Automated error correction";
			this.tipMain.SetToolTip(this.checkErrorCorrection, "Removes hidden duplicates from ASCII text.");
			this.visualStyleProvider.SetVisualStyleSupport(this.checkErrorCorrection, true);
			// 
			// checkConvertNumbers
			// 
			this.checkConvertNumbers.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkConvertNumbers.Location = new System.Drawing.Point(8, 40);
			this.checkConvertNumbers.Name = "checkConvertNumbers";
			this.checkConvertNumbers.Size = new System.Drawing.Size(152, 24);
			this.checkConvertNumbers.TabIndex = 23;
			this.checkConvertNumbers.Text = "Convert numbers";
			this.tipMain.SetToolTip(this.checkConvertNumbers, "Convert numbers into traditional Punjabi numerals.  This is recommended for older" +
				" texts.");
			this.visualStyleProvider.SetVisualStyleSupport(this.checkConvertNumbers, true);
			// 
			// buttonCancel
			// 
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.Location = new System.Drawing.Point(416, 232);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 24);
			this.buttonCancel.TabIndex = 38;
			this.buttonCancel.Text = "&Cancel";
			this.visualStyleProvider.SetVisualStyleSupport(this.buttonCancel, true);
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(328, 232);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 24);
			this.buttonOK.TabIndex = 37;
			this.buttonOK.Text = "&OK";
			this.visualStyleProvider.SetVisualStyleSupport(this.buttonOK, true);
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// groupConversionSettings
			// 
			this.groupConversionSettings.Controls.Add(this.checkConvertNumbers);
			this.groupConversionSettings.Controls.Add(this.checkErrorCorrection);
			this.groupConversionSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupConversionSettings.Location = new System.Drawing.Point(8, 8);
			this.groupConversionSettings.Name = "groupConversionSettings";
			this.groupConversionSettings.Size = new System.Drawing.Size(168, 72);
			this.groupConversionSettings.TabIndex = 21;
			this.groupConversionSettings.TabStop = false;
			this.groupConversionSettings.Text = "Conversion Settings";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupConversionSettings, true);
			// 
			// groupFonts
			// 
			this.groupFonts.Controls.Add(this.btnConvertedTextFont);
			this.groupFonts.Controls.Add(this.btnOriginalTextFont);
			this.groupFonts.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupFonts.Location = new System.Drawing.Point(8, 8);
			this.groupFonts.Name = "groupFonts";
			this.groupFonts.Size = new System.Drawing.Size(152, 96);
			this.groupFonts.TabIndex = 1;
			this.groupFonts.TabStop = false;
			this.groupFonts.Text = "Fonts";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupFonts, true);
			// 
			// btnConvertedTextFont
			// 
			this.btnConvertedTextFont.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnConvertedTextFont.Location = new System.Drawing.Point(8, 56);
			this.btnConvertedTextFont.Name = "btnConvertedTextFont";
			this.btnConvertedTextFont.Size = new System.Drawing.Size(136, 24);
			this.btnConvertedTextFont.TabIndex = 3;
			this.btnConvertedTextFont.Text = "Converted Text Font";
			this.tipMain.SetToolTip(this.btnConvertedTextFont, "Change the converted text font.");
			this.visualStyleProvider.SetVisualStyleSupport(this.btnConvertedTextFont, true);
			this.btnConvertedTextFont.Click += new System.EventHandler(this.btnConvertedTextFont_Click);
			// 
			// btnOriginalTextFont
			// 
			this.btnOriginalTextFont.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOriginalTextFont.Location = new System.Drawing.Point(8, 24);
			this.btnOriginalTextFont.Name = "btnOriginalTextFont";
			this.btnOriginalTextFont.Size = new System.Drawing.Size(136, 24);
			this.btnOriginalTextFont.TabIndex = 2;
			this.btnOriginalTextFont.Text = "Original Text Font";
			this.tipMain.SetToolTip(this.btnOriginalTextFont, "Change the original text font.");
			this.visualStyleProvider.SetVisualStyleSupport(this.btnOriginalTextFont, true);
			this.btnOriginalTextFont.Click += new System.EventHandler(this.btnOriginalTextFont_Click);
			// 
			// groupUnicodeVersion
			// 
			this.groupUnicodeVersion.Controls.Add(this.radioUnicode3);
			this.groupUnicodeVersion.Controls.Add(this.radioUnicode4);
			this.groupUnicodeVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupUnicodeVersion.Location = new System.Drawing.Point(168, 112);
			this.groupUnicodeVersion.Name = "groupUnicodeVersion";
			this.groupUnicodeVersion.Size = new System.Drawing.Size(136, 72);
			this.groupUnicodeVersion.TabIndex = 15;
			this.groupUnicodeVersion.TabStop = false;
			this.groupUnicodeVersion.Text = "Unicode Version";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupUnicodeVersion, true);
			// 
			// radioUnicode3
			// 
			this.radioUnicode3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioUnicode3.Location = new System.Drawing.Point(8, 16);
			this.radioUnicode3.Name = "radioUnicode3";
			this.radioUnicode3.Size = new System.Drawing.Size(80, 24);
			this.radioUnicode3.TabIndex = 16;
			this.radioUnicode3.Text = "Unicode 3";
			this.tipMain.SetToolTip(this.radioUnicode3, "Use this option to maintain compatibility at the expense of two rarely used chara" +
				"cters.");
			this.visualStyleProvider.SetVisualStyleSupport(this.radioUnicode3, true);
			// 
			// radioUnicode4
			// 
			this.radioUnicode4.Checked = true;
			this.radioUnicode4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioUnicode4.Location = new System.Drawing.Point(8, 40);
			this.radioUnicode4.Name = "radioUnicode4";
			this.radioUnicode4.Size = new System.Drawing.Size(80, 24);
			this.radioUnicode4.TabIndex = 17;
			this.radioUnicode4.TabStop = true;
			this.radioUnicode4.Text = "Unicode 4";
			this.tipMain.SetToolTip(this.radioUnicode4, "Use this for newer fonts.  Adds support for two more Gurmukhi characters.  This c" +
				"an cause older fonts to display boxes ([]) for missing characters.");
			this.visualStyleProvider.SetVisualStyleSupport(this.radioUnicode4, true);
			// 
			// checkRepairISCII
			// 
			this.checkRepairISCII.Checked = true;
			this.checkRepairISCII.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkRepairISCII.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkRepairISCII.Location = new System.Drawing.Point(8, 16);
			this.checkRepairISCII.Name = "checkRepairISCII";
			this.checkRepairISCII.Size = new System.Drawing.Size(152, 24);
			this.checkRepairISCII.TabIndex = 25;
			this.checkRepairISCII.Text = "Repair ISCII 91 Extensions";
			this.tipMain.SetToolTip(this.checkRepairISCII, "Repairs text that was created using the proposed - but not adopted - ISCII 1991 e" +
				"xtensions to Unicode.");
			this.visualStyleProvider.SetVisualStyleSupport(this.checkRepairISCII, true);
			// 
			// checkRepairRepositionI
			// 
			this.checkRepairRepositionI.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkRepairRepositionI.Location = new System.Drawing.Point(8, 64);
			this.checkRepairRepositionI.Name = "checkRepairRepositionI";
			this.checkRepairRepositionI.Size = new System.Drawing.Size(152, 24);
			this.checkRepairRepositionI.TabIndex = 27;
			this.checkRepairRepositionI.Text = "Reposition I (U+0A3F)";
			this.tipMain.SetToolTip(this.checkRepairRepositionI, "Repositions the vowel sign I (\"ਿ\", U+0A3F) so that it is encoded on the right of " +
				"the character it applies to.");
			this.visualStyleProvider.SetVisualStyleSupport(this.checkRepairRepositionI, true);
			// 
			// checkRenameOriginalFile
			// 
			this.checkRenameOriginalFile.Checked = true;
			this.checkRenameOriginalFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkRenameOriginalFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkRenameOriginalFile.Location = new System.Drawing.Point(8, 16);
			this.checkRenameOriginalFile.Name = "checkRenameOriginalFile";
			this.checkRenameOriginalFile.Size = new System.Drawing.Size(120, 24);
			this.checkRenameOriginalFile.TabIndex = 5;
			this.checkRenameOriginalFile.Text = "Rename original file";
			this.tipMain.SetToolTip(this.checkRenameOriginalFile, "This renames the old file with the extension specified and returns the new file w" +
				"ith the original file name.");
			this.visualStyleProvider.SetVisualStyleSupport(this.checkRenameOriginalFile, true);
			// 
			// textExtension
			// 
			this.textExtension.Location = new System.Drawing.Point(8, 64);
			this.textExtension.Name = "textExtension";
			this.textExtension.Size = new System.Drawing.Size(120, 21);
			this.textExtension.TabIndex = 7;
			this.textExtension.Text = ".bak";
			this.tipMain.SetToolTip(this.textExtension, "The specified file extension.");
			this.visualStyleProvider.SetVisualStyleSupport(this.textExtension, true);
			// 
			// checkNormaliseText
			// 
			this.checkNormaliseText.Checked = true;
			this.checkNormaliseText.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkNormaliseText.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkNormaliseText.Location = new System.Drawing.Point(8, 40);
			this.checkNormaliseText.Name = "checkNormaliseText";
			this.checkNormaliseText.Size = new System.Drawing.Size(152, 24);
			this.checkNormaliseText.TabIndex = 26;
			this.checkNormaliseText.Text = "Normalise Text";
			this.tipMain.SetToolTip(this.checkNormaliseText, "Normalises the text.  This helps when analysing and search text.");
			this.visualStyleProvider.SetVisualStyleSupport(this.checkNormaliseText, true);
			// 
			// radioPunjabiGeneric
			// 
			this.radioPunjabiGeneric.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioPunjabiGeneric.Location = new System.Drawing.Point(8, 40);
			this.radioPunjabiGeneric.Name = "radioPunjabiGeneric";
			this.radioPunjabiGeneric.Size = new System.Drawing.Size(136, 24);
			this.radioPunjabiGeneric.TabIndex = 14;
			this.radioPunjabiGeneric.Text = "Punjabi (Generic, pa)";
			this.tipMain.SetToolTip(this.radioPunjabiGeneric, "Set the default output locale to generic Punjabi.  This means that although the t" +
				"ext is Punjabi, it is not localised to any country.");
			this.visualStyleProvider.SetVisualStyleSupport(this.radioPunjabiGeneric, true);
			// 
			// radioPunjabiIndia
			// 
			this.radioPunjabiIndia.Checked = true;
			this.radioPunjabiIndia.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioPunjabiIndia.Location = new System.Drawing.Point(8, 16);
			this.radioPunjabiIndia.Name = "radioPunjabiIndia";
			this.radioPunjabiIndia.Size = new System.Drawing.Size(136, 24);
			this.radioPunjabiIndia.TabIndex = 13;
			this.radioPunjabiIndia.TabStop = true;
			this.radioPunjabiIndia.Text = "Punjabi (India, pa-IN)";
			this.tipMain.SetToolTip(this.radioPunjabiIndia, "Set the default output locale to Indian Punjabi.  This generally means Punjabi te" +
				"xt written in Gurmukhi.");
			this.visualStyleProvider.SetVisualStyleSupport(this.radioPunjabiIndia, true);
			// 
			// radioOutputUTF8
			// 
			this.radioOutputUTF8.Checked = true;
			this.radioOutputUTF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioOutputUTF8.Location = new System.Drawing.Point(8, 16);
			this.radioOutputUTF8.Name = "radioOutputUTF8";
			this.radioOutputUTF8.Size = new System.Drawing.Size(128, 24);
			this.radioOutputUTF8.TabIndex = 19;
			this.radioOutputUTF8.TabStop = true;
			this.radioOutputUTF8.Text = "Output to UTF-8";
			this.tipMain.SetToolTip(this.radioOutputUTF8, "Outputs data to UTF-8 which is an 8 bit Unicode encoding format.");
			this.visualStyleProvider.SetVisualStyleSupport(this.radioOutputUTF8, true);
			// 
			// radioOutputUTF16
			// 
			this.radioOutputUTF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioOutputUTF16.Location = new System.Drawing.Point(8, 40);
			this.radioOutputUTF16.Name = "radioOutputUTF16";
			this.radioOutputUTF16.Size = new System.Drawing.Size(128, 24);
			this.radioOutputUTF16.TabIndex = 20;
			this.radioOutputUTF16.Text = "Output to UTF-16";
			this.tipMain.SetToolTip(this.radioOutputUTF16, "Outputs data to UTF-16 which is a 16 bit Unicode encoding format.  If you are out" +
				"putting lots of text on one document, UTF-16 may save disk space.");
			this.visualStyleProvider.SetVisualStyleSupport(this.radioOutputUTF16, true);
			// 
			// checkXHTMLXMLDec
			// 
			this.checkXHTMLXMLDec.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkXHTMLXMLDec.Location = new System.Drawing.Point(8, 64);
			this.checkXHTMLXMLDec.Name = "checkXHTMLXMLDec";
			this.checkXHTMLXMLDec.Size = new System.Drawing.Size(144, 24);
			this.checkXHTMLXMLDec.TabIndex = 11;
			this.checkXHTMLXMLDec.Text = "Include XML declaration";
			this.tipMain.SetToolTip(this.checkXHTMLXMLDec, "Select this option if you wish the XHTML documents to be parsed by an XML parser." +
				"  This is not required as the Unicode BOM is automatically added to all exported" +
				" documents.");
			this.visualStyleProvider.SetVisualStyleSupport(this.checkXHTMLXMLDec, true);
			// 
			// radioXHTML11
			// 
			this.radioXHTML11.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioXHTML11.Location = new System.Drawing.Point(8, 40);
			this.radioXHTML11.Name = "radioXHTML11";
			this.radioXHTML11.Size = new System.Drawing.Size(144, 24);
			this.radioXHTML11.TabIndex = 10;
			this.radioXHTML11.Text = "XHTML 1.1";
			this.tipMain.SetToolTip(this.radioXHTML11, "Recommended for newer browsers, especially the Mozilla family.");
			this.visualStyleProvider.SetVisualStyleSupport(this.radioXHTML11, true);
			// 
			// radioXHTML10
			// 
			this.radioXHTML10.Checked = true;
			this.radioXHTML10.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioXHTML10.Location = new System.Drawing.Point(8, 16);
			this.radioXHTML10.Name = "radioXHTML10";
			this.radioXHTML10.Size = new System.Drawing.Size(144, 24);
			this.radioXHTML10.TabIndex = 9;
			this.radioXHTML10.TabStop = true;
			this.radioXHTML10.Text = "XHTML 1.0 Transitional";
			this.tipMain.SetToolTip(this.radioXHTML10, "Recommended for compatibility with older browsers while still being XML compliant" +
				".");
			this.visualStyleProvider.SetVisualStyleSupport(this.radioXHTML10, true);
			// 
			// buttonMappingDetails
			// 
			this.buttonMappingDetails.Location = new System.Drawing.Point(8, 48);
			this.buttonMappingDetails.Name = "buttonMappingDetails";
			this.buttonMappingDetails.Size = new System.Drawing.Size(136, 24);
			this.buttonMappingDetails.TabIndex = 36;
			this.buttonMappingDetails.Text = "Details...";
			this.tipMain.SetToolTip(this.buttonMappingDetails, "View details about the selected mapping file.");
			this.visualStyleProvider.SetVisualStyleSupport(this.buttonMappingDetails, true);
			this.buttonMappingDetails.Click += new System.EventHandler(this.buttonMappingDetails_Click);
			// 
			// buttonRemoveMapping
			// 
			this.buttonRemoveMapping.Location = new System.Drawing.Point(80, 16);
			this.buttonRemoveMapping.Name = "buttonRemoveMapping";
			this.buttonRemoveMapping.Size = new System.Drawing.Size(64, 24);
			this.buttonRemoveMapping.TabIndex = 35;
			this.buttonRemoveMapping.Text = "Remove";
			this.tipMain.SetToolTip(this.buttonRemoveMapping, "Remove a mapping file.");
			this.visualStyleProvider.SetVisualStyleSupport(this.buttonRemoveMapping, true);
			this.buttonRemoveMapping.Click += new System.EventHandler(this.buttonRemoveMapping_Click);
			// 
			// buttonAddMapping
			// 
			this.buttonAddMapping.Location = new System.Drawing.Point(8, 16);
			this.buttonAddMapping.Name = "buttonAddMapping";
			this.buttonAddMapping.Size = new System.Drawing.Size(64, 24);
			this.buttonAddMapping.TabIndex = 34;
			this.buttonAddMapping.Text = "Add";
			this.tipMain.SetToolTip(this.buttonAddMapping, "Add a mapping file.");
			this.visualStyleProvider.SetVisualStyleSupport(this.buttonAddMapping, true);
			this.buttonAddMapping.Click += new System.EventHandler(this.buttonAddMapping_Click);
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonBrowse.Location = new System.Drawing.Point(8, 56);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(72, 24);
			this.buttonBrowse.TabIndex = 32;
			this.buttonBrowse.Text = "Browse...";
			this.tipMain.SetToolTip(this.buttonBrowse, "Find the directory where you wish to store mapping files.");
			this.visualStyleProvider.SetVisualStyleSupport(this.buttonBrowse, true);
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// tabOptions
			// 
			this.tabOptions.Controls.Add(this.tabOptionsGeneral);
			this.tabOptions.Controls.Add(this.tabOptionsConversionRepair);
			this.tabOptions.Controls.Add(this.tabOptionsMappings);
			this.tabOptions.Location = new System.Drawing.Point(8, 8);
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.SelectedIndex = 0;
			this.tabOptions.Size = new System.Drawing.Size(488, 216);
			this.tabOptions.TabIndex = 0;
			// 
			// tabOptionsGeneral
			// 
			this.tabOptionsGeneral.Controls.Add(this.groupXHTMLSettings);
			this.tabOptionsGeneral.Controls.Add(this.groupUnicodeTransformation);
			this.tabOptionsGeneral.Controls.Add(this.groupLocaleType);
			this.tabOptionsGeneral.Controls.Add(this.groupBatchProcessor);
			this.tabOptionsGeneral.Controls.Add(this.groupFonts);
			this.tabOptionsGeneral.Controls.Add(this.groupUnicodeVersion);
			this.tabOptionsGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabOptionsGeneral.Name = "tabOptionsGeneral";
			this.tabOptionsGeneral.Size = new System.Drawing.Size(480, 190);
			this.tabOptionsGeneral.TabIndex = 0;
			this.tabOptionsGeneral.Text = "General";
			this.visualStyleProvider.SetVisualStyleSupport(this.tabOptionsGeneral, true);
			// 
			// groupXHTMLSettings
			// 
			this.groupXHTMLSettings.Controls.Add(this.checkXHTMLXMLDec);
			this.groupXHTMLSettings.Controls.Add(this.radioXHTML11);
			this.groupXHTMLSettings.Controls.Add(this.radioXHTML10);
			this.groupXHTMLSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupXHTMLSettings.Location = new System.Drawing.Point(312, 8);
			this.groupXHTMLSettings.Name = "groupXHTMLSettings";
			this.groupXHTMLSettings.Size = new System.Drawing.Size(160, 96);
			this.groupXHTMLSettings.TabIndex = 8;
			this.groupXHTMLSettings.TabStop = false;
			this.groupXHTMLSettings.Text = "XHTML Settings";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupXHTMLSettings, true);
			// 
			// groupUnicodeTransformation
			// 
			this.groupUnicodeTransformation.Controls.Add(this.radioOutputUTF8);
			this.groupUnicodeTransformation.Controls.Add(this.radioOutputUTF16);
			this.groupUnicodeTransformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupUnicodeTransformation.Location = new System.Drawing.Point(312, 112);
			this.groupUnicodeTransformation.Name = "groupUnicodeTransformation";
			this.groupUnicodeTransformation.Size = new System.Drawing.Size(160, 72);
			this.groupUnicodeTransformation.TabIndex = 18;
			this.groupUnicodeTransformation.TabStop = false;
			this.groupUnicodeTransformation.Text = "Unicode Transformation";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupUnicodeTransformation, true);
			// 
			// groupLocaleType
			// 
			this.groupLocaleType.Controls.Add(this.radioPunjabiGeneric);
			this.groupLocaleType.Controls.Add(this.radioPunjabiIndia);
			this.groupLocaleType.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupLocaleType.Location = new System.Drawing.Point(8, 112);
			this.groupLocaleType.Name = "groupLocaleType";
			this.groupLocaleType.Size = new System.Drawing.Size(152, 72);
			this.groupLocaleType.TabIndex = 12;
			this.groupLocaleType.TabStop = false;
			this.groupLocaleType.Text = "Default Locale Type";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupLocaleType, true);
			// 
			// groupBatchProcessor
			// 
			this.groupBatchProcessor.Controls.Add(this.textExtension);
			this.groupBatchProcessor.Controls.Add(this.labelExtension);
			this.groupBatchProcessor.Controls.Add(this.checkRenameOriginalFile);
			this.groupBatchProcessor.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBatchProcessor.Location = new System.Drawing.Point(168, 8);
			this.groupBatchProcessor.Name = "groupBatchProcessor";
			this.groupBatchProcessor.Size = new System.Drawing.Size(136, 96);
			this.groupBatchProcessor.TabIndex = 4;
			this.groupBatchProcessor.TabStop = false;
			this.groupBatchProcessor.Text = "Batch Processor";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupBatchProcessor, true);
			// 
			// labelExtension
			// 
			this.labelExtension.Location = new System.Drawing.Point(8, 48);
			this.labelExtension.Name = "labelExtension";
			this.labelExtension.Size = new System.Drawing.Size(112, 16);
			this.labelExtension.TabIndex = 6;
			this.labelExtension.Text = "File extension:";
			this.visualStyleProvider.SetVisualStyleSupport(this.labelExtension, true);
			// 
			// tabOptionsConversionRepair
			// 
			this.tabOptionsConversionRepair.Controls.Add(this.groupRepairSettings);
			this.tabOptionsConversionRepair.Controls.Add(this.groupConversionSettings);
			this.tabOptionsConversionRepair.Location = new System.Drawing.Point(4, 22);
			this.tabOptionsConversionRepair.Name = "tabOptionsConversionRepair";
			this.tabOptionsConversionRepair.Size = new System.Drawing.Size(480, 190);
			this.tabOptionsConversionRepair.TabIndex = 0;
			this.tabOptionsConversionRepair.Text = "Conversion and Repair";
			this.visualStyleProvider.SetVisualStyleSupport(this.tabOptionsConversionRepair, true);
			// 
			// groupRepairSettings
			// 
			this.groupRepairSettings.Controls.Add(this.checkNormaliseText);
			this.groupRepairSettings.Controls.Add(this.checkRepairRepositionI);
			this.groupRepairSettings.Controls.Add(this.checkRepairISCII);
			this.groupRepairSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupRepairSettings.Location = new System.Drawing.Point(8, 88);
			this.groupRepairSettings.Name = "groupRepairSettings";
			this.groupRepairSettings.Size = new System.Drawing.Size(168, 96);
			this.groupRepairSettings.TabIndex = 24;
			this.groupRepairSettings.TabStop = false;
			this.groupRepairSettings.Text = "Repair Settings";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupRepairSettings, true);
			// 
			// tabOptionsMappings
			// 
			this.tabOptionsMappings.Controls.Add(this.groupOrganise);
			this.tabOptionsMappings.Controls.Add(this.groupRecognisedMappings);
			this.tabOptionsMappings.Controls.Add(this.groupCustomMappings);
			this.tabOptionsMappings.Location = new System.Drawing.Point(4, 22);
			this.tabOptionsMappings.Name = "tabOptionsMappings";
			this.tabOptionsMappings.Size = new System.Drawing.Size(480, 190);
			this.tabOptionsMappings.TabIndex = 0;
			this.tabOptionsMappings.Text = "Mappings";
			this.visualStyleProvider.SetVisualStyleSupport(this.tabOptionsMappings, true);
			// 
			// groupOrganise
			// 
			this.groupOrganise.Controls.Add(this.buttonMappingDetails);
			this.groupOrganise.Controls.Add(this.buttonRemoveMapping);
			this.groupOrganise.Controls.Add(this.buttonAddMapping);
			this.groupOrganise.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupOrganise.Location = new System.Drawing.Point(320, 104);
			this.groupOrganise.Name = "groupOrganise";
			this.groupOrganise.Size = new System.Drawing.Size(152, 80);
			this.groupOrganise.TabIndex = 33;
			this.groupOrganise.TabStop = false;
			this.groupOrganise.Text = "Organise";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupOrganise, true);
			// 
			// groupRecognisedMappings
			// 
			this.groupRecognisedMappings.Controls.Add(this.listRecognisedMapping);
			this.groupRecognisedMappings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupRecognisedMappings.Location = new System.Drawing.Point(8, 8);
			this.groupRecognisedMappings.Name = "groupRecognisedMappings";
			this.groupRecognisedMappings.Size = new System.Drawing.Size(304, 176);
			this.groupRecognisedMappings.TabIndex = 28;
			this.groupRecognisedMappings.TabStop = false;
			this.groupRecognisedMappings.Text = "Recognised Mappings";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupRecognisedMappings, true);
			// 
			// listRecognisedMapping
			// 
			this.listRecognisedMapping.CheckBoxes = true;
			this.listRecognisedMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									this.columnFrom,
																									this.columnTo,
																									this.columnVersion});
			this.listRecognisedMapping.FullRowSelect = true;
			this.listRecognisedMapping.Location = new System.Drawing.Point(8, 16);
			this.listRecognisedMapping.Name = "listRecognisedMapping";
			this.listRecognisedMapping.Size = new System.Drawing.Size(288, 152);
			this.listRecognisedMapping.TabIndex = 29;
			this.tipMain.SetToolTip(this.listRecognisedMapping, "A list of all mappings.  The tick mark indicates the default mapping.");
			this.listRecognisedMapping.View = System.Windows.Forms.View.Details;
			this.listRecognisedMapping.SelectedIndexChanged += new System.EventHandler(this.listRecognisedMapping_SelectedIndexChanged);
			this.listRecognisedMapping.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listRecognisedMapping_ItemCheck);
			// 
			// columnFrom
			// 
			this.columnFrom.Text = "From";
			this.columnFrom.Width = 110;
			// 
			// columnTo
			// 
			this.columnTo.Text = "To";
			this.columnTo.Width = 95;
			// 
			// columnVersion
			// 
			this.columnVersion.Text = "Version";
			this.columnVersion.Width = 55;
			// 
			// groupCustomMappings
			// 
			this.groupCustomMappings.Controls.Add(this.textMappingsDirectory);
			this.groupCustomMappings.Controls.Add(this.buttonBrowse);
			this.groupCustomMappings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupCustomMappings.Location = new System.Drawing.Point(320, 8);
			this.groupCustomMappings.Name = "groupCustomMappings";
			this.groupCustomMappings.Size = new System.Drawing.Size(152, 88);
			this.groupCustomMappings.TabIndex = 30;
			this.groupCustomMappings.TabStop = false;
			this.groupCustomMappings.Text = "Mapping Directory";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupCustomMappings, true);
			// 
			// textMappingsDirectory
			// 
			this.textMappingsDirectory.Location = new System.Drawing.Point(8, 24);
			this.textMappingsDirectory.Name = "textMappingsDirectory";
			this.textMappingsDirectory.Size = new System.Drawing.Size(136, 21);
			this.textMappingsDirectory.TabIndex = 31;
			this.textMappingsDirectory.Text = "%ProgramDir%\\Mappings\\";
			this.visualStyleProvider.SetVisualStyleSupport(this.textMappingsDirectory, true);
			// 
			// formOptions
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(506, 264);
			this.Controls.Add(this.tabOptions);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "formOptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Options";
			this.Load += new System.EventHandler(this.formOptions_Load);
			this.groupConversionSettings.ResumeLayout(false);
			this.groupFonts.ResumeLayout(false);
			this.groupUnicodeVersion.ResumeLayout(false);
			this.tabOptions.ResumeLayout(false);
			this.tabOptionsGeneral.ResumeLayout(false);
			this.groupXHTMLSettings.ResumeLayout(false);
			this.groupUnicodeTransformation.ResumeLayout(false);
			this.groupLocaleType.ResumeLayout(false);
			this.groupBatchProcessor.ResumeLayout(false);
			this.tabOptionsConversionRepair.ResumeLayout(false);
			this.groupRepairSettings.ResumeLayout(false);
			this.tabOptionsMappings.ResumeLayout(false);
			this.groupOrganise.ResumeLayout(false);
			this.groupRecognisedMappings.ResumeLayout(false);
			this.groupCustomMappings.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			// Revert back to old fonts
			((formMain)this.Owner).textOriginalText.Font = fontOriginal;
			((formMain)this.Owner).textConvertedText.Font = fontConverted;

			PopulateMenu();

			this.Close();
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			Settings = new CSettings(true);
			string sProgram = Application.ProductName.ToLower();

			Settings.SaveSetting(sProgram, "conversion", "error_correction", checkErrorCorrection.Checked);
			Settings.SaveSetting(sProgram, "conversion", "convert_numbers", checkConvertNumbers.Checked);
			Settings.SaveSetting(sProgram, "output", "include_xml_decl", checkXHTMLXMLDec.Checked);
			Settings.SaveSetting(sProgram, "repair", "iscii91", checkRepairISCII.Checked);
			Settings.SaveSetting(sProgram, "repair", "repositioni", checkRepairRepositionI.Checked);
			Settings.SaveSetting(sProgram, "repair", "normalisetext", checkNormaliseText.Checked);
			Settings.SaveSetting(sProgram, "output", "renameoriginal", checkRenameOriginalFile.Checked);
			Settings.SaveSetting(sProgram, "output", "extension", textExtension.Text);
			Settings.SaveSetting(sProgram, "output", "utf16", radioOutputUTF16.Checked);		// Default UTF-8
			Settings.SaveSetting(sProgram, "output", "xhtml11", radioXHTML11.Checked);			// Default XHTML 1.0
			Settings.SaveSetting(sProgram, "unicode", "unicode4", radioUnicode4.Checked);		// Default Unicode 3
			Settings.SaveSetting(sProgram, "locale", "genericpa", radioPunjabiGeneric.Checked);	// Default pa-IN
			Settings.SaveSetting(sProgram, "mappings", "directory", textMappingsDirectory.Text);// Mapping Directory
			

			Settings.SaveSetting(sProgram, "originalfont", "name", ((formMain)this.Owner).textOriginalText.Font.Name);	
			Settings.SaveSetting(sProgram, "originalfont", "size", ((formMain)this.Owner).textOriginalText.Font.Size.ToString());
			Settings.SaveSetting(sProgram, "originalfont", "colour", ((formMain)this.Owner).textOriginalText.ForeColor.ToArgb());	
			Settings.SaveSetting(sProgram, "originalfont", "style", ((formMain)this.Owner).textOriginalText.Font.Style.ToString());	
			Settings.SaveSetting(sProgram, "convertedfont", "name", ((formMain)this.Owner).textConvertedText.Font.Name);	
			Settings.SaveSetting(sProgram, "convertedfont", "size", ((formMain)this.Owner).textConvertedText.Font.Size.ToString());
			Settings.SaveSetting(sProgram, "convertedfont", "colour", ((formMain)this.Owner).textConvertedText.ForeColor.ToArgb());	
			Settings.SaveSetting(sProgram, "convertedfont", "style", ((formMain)this.Owner).textConvertedText.Font.Style.ToString());	

			IEnumerator Iter; 
			string sDefaultPath = "";

			if (listRecognisedMapping.Items[0].Checked == true)
			{
				Settings.SaveSetting(sProgram, "mappings", "defaultpath", "");
			}
			else
			{
				Iter = listRecognisedMapping.Items.GetEnumerator();
			
				while(Iter.MoveNext())
				{
					ListViewItem Item = (ListViewItem)Iter.Current;
					
					if(Item.Checked == true)
					{
						Settings.SaveSetting(sProgram, "mappings", "defaultpath", (string)Item.Tag);
						sDefaultPath = (string)Item.Tag;
						break;
					}
				}
			}

			PopulateMenu();

			this.Close();
		}

		private void PopulateMenu()
		{
			Settings = new CSettings(true);
			formMain formCurrent = ((formMain)this.Owner);
			string sProgram = Application.ProductName.ToLower();

			string sMappingPath = Settings.GetSetting(sProgram, "mappings", "defaultpath", "");
			

			IEnumerator Iter = formCurrent.menuToolsConvert.MenuItems.GetEnumerator();

			int iCounter = 0;

			ArrayList RemoveMenuItems = new ArrayList(32);

			while(Iter.MoveNext())
			{
				// Prevents invalid cast on first & second menu item
				iCounter++;

				if (iCounter <= 2)
					continue;

				MenuItem Item = (MenuItem)Iter.Current;

				RemoveMenuItems.Add(Item);
			}

			RemoveMenuItems.TrimToSize();

			Iter = RemoveMenuItems.GetEnumerator();

			while(Iter.MoveNext())
				formCurrent.menuToolsConvert.MenuItems.Remove((MenuItem)Iter.Current);

			string[] sMappings = ProgramResources.Convert.ListMappings(Settings.GetSetting(sProgram, "mappings", "directory", ProgramResources.sApplicationDirectory));

			Iter = sMappings.GetEnumerator();
			
			while(Iter.MoveNext())
			{
				MappingDetails Current =  ProgramResources.Convert.GetDetails((string)Iter.Current);
				TaggedMenuItem Item = new TaggedMenuItem(Current.sFrom + " > " + Current.sTo);
				Item.Tag = Current.sFileName;
				Item.RadioCheck = true;
				Item.Click += new EventHandler(formCurrent.menuCustomConversion_Click);

				formCurrent.menuToolsConvert.MenuItems.Add(Item);
			}

			if (sMappingPath == "")
			{
				formCurrent.menuToolsConvert.MenuItems[0].Checked = true;
				formCurrent.menuToolsConvert.MenuItems[0].DefaultItem = true;
				formCurrent.menuToolsConvert.MenuItems[0].Shortcut = Shortcut.F5;
			}
			else
			{
				Iter = formCurrent.menuToolsConvert.MenuItems.GetEnumerator();

				iCounter = 0;

				while(Iter.MoveNext())
				{
					// Prevents invalid cast on first & second menu item
					iCounter++;

					if (iCounter <= 2)
						continue;

					TaggedMenuItem Item = (TaggedMenuItem)Iter.Current;

					if ((string)Item.Tag == sMappingPath)
					{
						formCurrent.menuToolsConvert.MenuItems[0].Checked = false;
						formCurrent.menuToolsConvert.MenuItems[0].DefaultItem = false;
						formCurrent.menuToolsConvert.MenuItems[0].Shortcut = Shortcut.None;
						Item.Shortcut = Shortcut.F5;
						Item.DefaultItem = true;
						Item.Checked = true;
						break;
					}
				}
			}
		}

		private void formOptions_Load(object sender, System.EventArgs e)
		{
			Settings = new CSettings(true);
			string sProgram = Application.ProductName.ToLower();

			checkErrorCorrection.Checked = Settings.GetSetting(sProgram, "conversion", "error_correction", true);
			checkConvertNumbers.Checked = Settings.GetSetting(sProgram, "conversion", "convert_numbers", false);
			checkRepairISCII.Checked = Settings.GetSetting(sProgram, "repair", "iscii91", true);
			checkNormaliseText.Checked = Settings.GetSetting(sProgram, "repair", "normalisetext", true);
			checkRepairRepositionI.Checked = Settings.GetSetting(sProgram, "repair", "repositioni", false);
			checkXHTMLXMLDec.Checked = Settings.GetSetting(sProgram, "output", "include_xml_decl", false);
			radioOutputUTF16.Checked = Settings.GetSetting(sProgram, "output", "utf16", false);
			radioOutputUTF8.Checked = !Settings.GetSetting(sProgram, "output", "utf16", false);
			radioXHTML11.Checked = Settings.GetSetting(sProgram, "output", "xhtml11", false);
			radioXHTML10.Checked = !Settings.GetSetting(sProgram, "output", "xhtml11", false);
			radioUnicode4.Checked = Settings.GetSetting(sProgram, "unicode", "unicode4", true);
			radioUnicode3.Checked = !Settings.GetSetting(sProgram, "unicode", "unicode4", true);
			radioPunjabiGeneric.Checked = Settings.GetSetting(sProgram, "locale", "genericpa", false);
			radioPunjabiIndia.Checked = !Settings.GetSetting(sProgram, "locale", "genericpa", false);

			checkRenameOriginalFile.Checked = Settings.GetSetting(sProgram, "output", "renameoriginal", true);
			textExtension.Text = Settings.GetSetting(sProgram, "output", "extension", ".bak");
			textMappingsDirectory.Text = Settings.GetSetting(sProgram, "mappings", "directory", ProgramResources.sApplicationDirectory);

			fontOriginal = ((formMain)this.Owner).textOriginalText.Font;
			fontConverted = ((formMain)this.Owner).textConvertedText.Font;

			AddMappings(textMappingsDirectory.Text);

		}

		private void AddMappings(string sMappingDirectory)
		{
			listRecognisedMapping.Items.Clear();

			string[] sMappings = ProgramResources.Convert.ListMappings(sMappingDirectory);
			
			ListViewItem LipiItem = new ListViewItem();
			LipiItem.Text = "AnmolLipi";
			LipiItem.Checked = true;
			LipiItem.SubItems.Add("Unicode");
			listRecognisedMapping.Items.Add(LipiItem);	

			string sProgram = Application.ProductName.ToLower();
			string sDefaultPath = Settings.GetSetting(sProgram, "mappings", "defaultpath", "");

			IEnumerator Iter = sMappings.GetEnumerator();
			
			while(Iter.MoveNext())
			{
				MappingDetails Current = ProgramResources.Convert.GetDetails((string)Iter.Current);
				ListViewItem Item = new ListViewItem();
				Item.Text = Current.sFrom;
				Item.Tag = Current.sFileName;
				Item.SubItems.Add(Current.sTo);
				Item.SubItems.Add(Current.sVersion);

				if (sDefaultPath.ToLower() == Current.sFileName.ToLower())
					Item.Checked = true;

				listRecognisedMapping.Items.Add(Item);		
			}
		}

		private void btnOriginalTextFont_Click(object sender, System.EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.ShowColor = true;
			fontDialog.AllowScriptChange = true;
			fontDialog.FontMustExist = true;
			
			fontDialog.Font = ((formMain)this.Owner).textOriginalText.Font;
			fontDialog.Color = ((formMain)this.Owner).textOriginalText.ForeColor;

			if(fontDialog.ShowDialog(this) != DialogResult.Cancel )
			{
				((formMain)this.Owner).ChangeOriginalFont(fontDialog.Font, fontDialog.Color);
			}
		}

		private void btnConvertedTextFont_Click(object sender, System.EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.ShowColor = true;
			fontDialog.AllowScriptChange = true;
			fontDialog.FontMustExist = true;	

			fontDialog.Font = ((formMain)this.Owner).textConvertedText.Font;
			fontDialog.Color = ((formMain)this.Owner).textConvertedText.ForeColor;

			if(fontDialog.ShowDialog(this) != DialogResult.Cancel )
			{
				((formMain)this.Owner).ChangeConvertedFont(fontDialog.Font, fontDialog.Color);
			}
		}

		private void buttonBrowse_Click(object sender, System.EventArgs e)
		{
			try
			{
				FolderBrowserDialog formBrowse = new FolderBrowserDialog();

				formBrowse.SelectedPath = textMappingsDirectory.Text;
				formBrowse.ShowNewFolderButton = true;
				formBrowse.Description = "Select a folder...";
				formBrowse.ShowDialog(this);

				textMappingsDirectory.Text = formBrowse.SelectedPath;

				AddMappings(formBrowse.SelectedPath);
			}
			catch (Exception ex)
			{

			}
		}

		private void listRecognisedMapping_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			IEnumerator Iter = listRecognisedMapping.Items.GetEnumerator();
			
			while(Iter.MoveNext())
			{
				ListViewItem Current = (ListViewItem)Iter.Current;
				if (Current.Index != e.Index)
					Current.Checked = false;
			}
		}

		private void listRecognisedMapping_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			if (listRecognisedMapping.SelectedItems.Count == 1 &&
				listRecognisedMapping.SelectedItems[0].Index == 0)
				buttonRemoveMapping.Enabled = false;
			else
				buttonRemoveMapping.Enabled = true;

		}

		private void buttonRemoveMapping_Click(object sender, System.EventArgs e)
		{
			if (listRecognisedMapping.SelectedItems.Count < 1)
			{
				MessageBox.Show("Please select a mapping to remove.", "Gurmukhi Unicode Conversion Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (MessageBox.Show("You have selected one or more mapping files to be removed.  Once you have removed a mapping file, you will not be able to add it again unless you have a backup copy.  Are you sure you wish to do this?", "Gurmukhi Unicode Conversion Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				bool bSkipFirst = false;

				if (listRecognisedMapping.SelectedItems[0].Index == 0)
					bSkipFirst = true;

				IEnumerator Iter = listRecognisedMapping.Items.GetEnumerator();
			
				while(Iter.MoveNext())
				{
					if (bSkipFirst)
					{
						bSkipFirst = false;
						continue;
					}

					ListViewItem Item = (ListViewItem)Iter.Current;

					try
					{
						if (Item.Selected == true)
							File.Delete((string)Item.Tag);
					}
					catch (Exception exp)
					{
						MessageBox.Show("Unable to delete file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}	
					
				}

				AddMappings(Settings.GetSetting(Application.ProductName.ToLower(), "mappings", "directory", ProgramResources.sApplicationDirectory));
			}
		}

		private void buttonAddMapping_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.CheckFileExists = true;
			openFile.Title = "Open...";
			openFile.Filter = "Gurmukhi Mapping Files (*.gmf)|*.gmf|All files (*.*)|*.*";
			openFile.FilterIndex = 2;

			if(openFile.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string sCopyTo = Settings.GetSetting(Application.ProductName.ToLower(), "mappings", "directory", ProgramResources.sApplicationDirectory) + Path.DirectorySeparatorChar + Path.GetFileName(openFile.FileName);

					if (File.Exists(sCopyTo))
					{
						if (MessageBox.Show("A copy of the mapping file you have selected is already present.  Do you wish to replace it?", "Gurmukhi Unicode Conversion Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
							return;
					}

					File.Copy(openFile.FileName, sCopyTo, true);

					AddMappings(Settings.GetSetting(Application.ProductName.ToLower(), "mappings", "directory", ProgramResources.sApplicationDirectory));
				}
				catch (Exception exp)
				{
					MessageBox.Show("Unable to open file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}				
			}
		}

		private void buttonMappingDetails_Click(object sender, System.EventArgs e)
		{
			if (listRecognisedMapping.SelectedItems.Count < 1)
			{
				MessageBox.Show("Please select a mapping.", "Gurmukhi Unicode Conversion Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (listRecognisedMapping.Items[0].Selected == true)
			{
				MessageBox.Show("AnmolLipi to Unicode\n\n" + "Author: Sukhjinder Sidhu\n\n" +
								"Converts Lipi based fonts into Unicode using a high-speed internal conversion routine.", "Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			bool bFirst = true;

			IEnumerator Iter = listRecognisedMapping.Items.GetEnumerator();
			
			ConversionEngine MapDetails = new ConversionEngine();

			while(Iter.MoveNext())
			{
				if (bFirst)
				{
					bFirst = false;
					continue;
				}

				ListViewItem Item = (ListViewItem)Iter.Current;

				if (Item.Selected == true)
				{
					MappingDetails Details = MapDetails.GetDetails((string)Item.Tag);	
					
					MessageBox.Show(Details.sFrom +" to " + Details.sTo + "\n\n" + "Author: "+ Details.sAuthor + "\n\n" +
					"Version: " + Details.sVersion, "Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
					
				}
			}
		}


	}
}
