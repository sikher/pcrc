using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Metamorph.Classes;

namespace Metamorph.Forms
{
    /// <summary>
    /// Summary description for Options.
    /// </summary>
    public class Options : System.Windows.Forms.Form
    {

        private bool bLoading = false;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabMappings;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupLocaleType;
        private System.Windows.Forms.RadioButton radioPunjabiGeneric;
        private System.Windows.Forms.RadioButton radioPunjabiIndia;
        private System.Windows.Forms.RadioButton radioOtherLocale;
        private System.Windows.Forms.TextBox textOtherLocale;
        private System.Windows.Forms.GroupBox groupInstalledMappings;
        private System.Windows.Forms.ColumnHeader columnFrom;
        private System.Windows.Forms.ColumnHeader columnTo;
        private System.Windows.Forms.ColumnHeader columnVersion;
        private System.Windows.Forms.Button buttonMappingDetails;
        private System.Windows.Forms.GroupBox groupOutputTextFont;
        private System.Windows.Forms.ComboBox comboOutputSize;
        private System.Windows.Forms.CheckBox checkOutputItalic;
        private System.Windows.Forms.CheckBox checkOutputBold;
        private System.Windows.Forms.ComboBox comboOutputFont;
        private System.Windows.Forms.GroupBox groupInputTextFont;
        private System.Windows.Forms.ComboBox comboInputSize;
        private System.Windows.Forms.CheckBox checkInputItalic;
        private System.Windows.Forms.CheckBox checkInputBold;
        private System.Windows.Forms.ComboBox comboInputFont;
        private System.Windows.Forms.RadioButton radioPunjabiPakistan;
        private System.Windows.Forms.Button buttonUninstallMapping;
        private System.Windows.Forms.Button buttonInstallMapping;
        private System.Windows.Forms.ListView listRecognisedMappings;
        private TabPage tabOutput;
        private GroupBox groupXHTMLSettings;
        private CheckBox checkXHTMLXMLDec;
        private RadioButton radioXHTML11;
        private RadioButton radioXHTML10;
        private GroupBox groupUnicodeTransformation;
        private RadioButton radioOutputUTF8;
        private RadioButton radioOutputUTF16;
        private Button buttonApply;
        private TabPage tabUnicodeConversion;
        private GroupBox groupUnicodeNumbers;
        private RadioButton radioNumberGurmukhi;
        private RadioButton radioNumberLatin;
        private GroupBox groupUnicodeGeneral;
        private CheckBox checkBindiTippiCorrection;
        private CheckBox checkErrorCorrection;
        private RadioButton radioNumberKeep;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Options()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupLocaleType = new System.Windows.Forms.GroupBox();
            this.radioPunjabiPakistan = new System.Windows.Forms.RadioButton();
            this.textOtherLocale = new System.Windows.Forms.TextBox();
            this.radioOtherLocale = new System.Windows.Forms.RadioButton();
            this.radioPunjabiGeneric = new System.Windows.Forms.RadioButton();
            this.radioPunjabiIndia = new System.Windows.Forms.RadioButton();
            this.groupOutputTextFont = new System.Windows.Forms.GroupBox();
            this.comboOutputSize = new System.Windows.Forms.ComboBox();
            this.checkOutputItalic = new System.Windows.Forms.CheckBox();
            this.checkOutputBold = new System.Windows.Forms.CheckBox();
            this.comboOutputFont = new System.Windows.Forms.ComboBox();
            this.groupInputTextFont = new System.Windows.Forms.GroupBox();
            this.comboInputSize = new System.Windows.Forms.ComboBox();
            this.checkInputItalic = new System.Windows.Forms.CheckBox();
            this.checkInputBold = new System.Windows.Forms.CheckBox();
            this.comboInputFont = new System.Windows.Forms.ComboBox();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.groupXHTMLSettings = new System.Windows.Forms.GroupBox();
            this.checkXHTMLXMLDec = new System.Windows.Forms.CheckBox();
            this.radioXHTML11 = new System.Windows.Forms.RadioButton();
            this.radioXHTML10 = new System.Windows.Forms.RadioButton();
            this.groupUnicodeTransformation = new System.Windows.Forms.GroupBox();
            this.radioOutputUTF8 = new System.Windows.Forms.RadioButton();
            this.radioOutputUTF16 = new System.Windows.Forms.RadioButton();
            this.tabUnicodeConversion = new System.Windows.Forms.TabPage();
            this.groupUnicodeNumbers = new System.Windows.Forms.GroupBox();
            this.radioNumberKeep = new System.Windows.Forms.RadioButton();
            this.radioNumberGurmukhi = new System.Windows.Forms.RadioButton();
            this.radioNumberLatin = new System.Windows.Forms.RadioButton();
            this.groupUnicodeGeneral = new System.Windows.Forms.GroupBox();
            this.checkBindiTippiCorrection = new System.Windows.Forms.CheckBox();
            this.checkErrorCorrection = new System.Windows.Forms.CheckBox();
            this.tabMappings = new System.Windows.Forms.TabPage();
            this.groupInstalledMappings = new System.Windows.Forms.GroupBox();
            this.buttonMappingDetails = new System.Windows.Forms.Button();
            this.buttonInstallMapping = new System.Windows.Forms.Button();
            this.buttonUninstallMapping = new System.Windows.Forms.Button();
            this.listRecognisedMappings = new System.Windows.Forms.ListView();
            this.columnFrom = new System.Windows.Forms.ColumnHeader();
            this.columnTo = new System.Windows.Forms.ColumnHeader();
            this.columnVersion = new System.Windows.Forms.ColumnHeader();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupLocaleType.SuspendLayout();
            this.groupOutputTextFont.SuspendLayout();
            this.groupInputTextFont.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.groupXHTMLSettings.SuspendLayout();
            this.groupUnicodeTransformation.SuspendLayout();
            this.tabUnicodeConversion.SuspendLayout();
            this.groupUnicodeNumbers.SuspendLayout();
            this.groupUnicodeGeneral.SuspendLayout();
            this.tabMappings.SuspendLayout();
            this.groupInstalledMappings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabGeneral);
            this.tabMain.Controls.Add(this.tabOutput);
            this.tabMain.Controls.Add(this.tabUnicodeConversion);
            this.tabMain.Controls.Add(this.tabMappings);
            this.tabMain.Location = new System.Drawing.Point(8, 10);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(416, 256);
            this.tabMain.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupLocaleType);
            this.tabGeneral.Controls.Add(this.groupOutputTextFont);
            this.tabGeneral.Controls.Add(this.groupInputTextFont);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(408, 230);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupLocaleType
            // 
            this.groupLocaleType.Controls.Add(this.radioPunjabiPakistan);
            this.groupLocaleType.Controls.Add(this.textOtherLocale);
            this.groupLocaleType.Controls.Add(this.radioOtherLocale);
            this.groupLocaleType.Controls.Add(this.radioPunjabiGeneric);
            this.groupLocaleType.Controls.Add(this.radioPunjabiIndia);
            this.groupLocaleType.Location = new System.Drawing.Point(8, 104);
            this.groupLocaleType.Name = "groupLocaleType";
            this.groupLocaleType.Size = new System.Drawing.Size(192, 120);
            this.groupLocaleType.TabIndex = 13;
            this.groupLocaleType.TabStop = false;
            this.groupLocaleType.Text = "Default Locale Type";
            // 
            // radioPunjabiPakistan
            // 
            this.radioPunjabiPakistan.Location = new System.Drawing.Point(8, 40);
            this.radioPunjabiPakistan.Name = "radioPunjabiPakistan";
            this.radioPunjabiPakistan.Size = new System.Drawing.Size(176, 24);
            this.radioPunjabiPakistan.TabIndex = 17;
            this.radioPunjabiPakistan.Text = "Pakistani Punjabi (pa-PK)";
            this.radioPunjabiPakistan.CheckedChanged += new System.EventHandler(this.radioPunjabiPakistan_CheckedChanged);
            // 
            // textOtherLocale
            // 
            this.textOtherLocale.Enabled = false;
            this.textOtherLocale.Location = new System.Drawing.Point(64, 88);
            this.textOtherLocale.MaxLength = 32;
            this.textOtherLocale.Name = "textOtherLocale";
            this.textOtherLocale.Size = new System.Drawing.Size(120, 20);
            this.textOtherLocale.TabIndex = 16;
            this.textOtherLocale.Text = "pa-IN";
            this.textOtherLocale.TextChanged += new System.EventHandler(this.textOtherLocale_TextChanged);
            // 
            // radioOtherLocale
            // 
            this.radioOtherLocale.Location = new System.Drawing.Point(8, 88);
            this.radioOtherLocale.Name = "radioOtherLocale";
            this.radioOtherLocale.Size = new System.Drawing.Size(176, 24);
            this.radioOtherLocale.TabIndex = 15;
            this.radioOtherLocale.Text = "Other:";
            this.radioOtherLocale.CheckedChanged += new System.EventHandler(this.radioOtherLocale_CheckedChanged);
            // 
            // radioPunjabiGeneric
            // 
            this.radioPunjabiGeneric.Location = new System.Drawing.Point(8, 64);
            this.radioPunjabiGeneric.Name = "radioPunjabiGeneric";
            this.radioPunjabiGeneric.Size = new System.Drawing.Size(176, 24);
            this.radioPunjabiGeneric.TabIndex = 14;
            this.radioPunjabiGeneric.Text = "Generic Punjabi (pa)";
            this.radioPunjabiGeneric.CheckedChanged += new System.EventHandler(this.radioOtherLocale_CheckedChanged);
            // 
            // radioPunjabiIndia
            // 
            this.radioPunjabiIndia.Checked = true;
            this.radioPunjabiIndia.Location = new System.Drawing.Point(8, 16);
            this.radioPunjabiIndia.Name = "radioPunjabiIndia";
            this.radioPunjabiIndia.Size = new System.Drawing.Size(176, 24);
            this.radioPunjabiIndia.TabIndex = 13;
            this.radioPunjabiIndia.TabStop = true;
            this.radioPunjabiIndia.Text = "Indian Punjabi (pa-IN)";
            this.radioPunjabiIndia.CheckedChanged += new System.EventHandler(this.radioOtherLocale_CheckedChanged);
            // 
            // groupOutputTextFont
            // 
            this.groupOutputTextFont.Controls.Add(this.comboOutputSize);
            this.groupOutputTextFont.Controls.Add(this.checkOutputItalic);
            this.groupOutputTextFont.Controls.Add(this.checkOutputBold);
            this.groupOutputTextFont.Controls.Add(this.comboOutputFont);
            this.groupOutputTextFont.Location = new System.Drawing.Point(208, 8);
            this.groupOutputTextFont.Name = "groupOutputTextFont";
            this.groupOutputTextFont.Size = new System.Drawing.Size(192, 88);
            this.groupOutputTextFont.TabIndex = 1;
            this.groupOutputTextFont.TabStop = false;
            this.groupOutputTextFont.Text = "Output Text Font";
            // 
            // comboOutputSize
            // 
            this.comboOutputSize.IntegralHeight = false;
            this.comboOutputSize.ItemHeight = 13;
            this.comboOutputSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.comboOutputSize.Location = new System.Drawing.Point(8, 56);
            this.comboOutputSize.MaxLength = 6;
            this.comboOutputSize.Name = "comboOutputSize";
            this.comboOutputSize.Size = new System.Drawing.Size(56, 21);
            this.comboOutputSize.TabIndex = 23;
            this.comboOutputSize.Text = "12";
            this.comboOutputSize.SelectedIndexChanged += new System.EventHandler(this.comboConvertedTextSize_SelectedIndexChanged);
            this.comboOutputSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboOriginalTextSize_KeyPress);
            // 
            // checkOutputItalic
            // 
            this.checkOutputItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkOutputItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOutputItalic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkOutputItalic.Location = new System.Drawing.Point(160, 56);
            this.checkOutputItalic.Name = "checkOutputItalic";
            this.checkOutputItalic.Size = new System.Drawing.Size(24, 24);
            this.checkOutputItalic.TabIndex = 21;
            this.checkOutputItalic.Text = "I";
            this.checkOutputItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkOutputItalic.CheckedChanged += new System.EventHandler(this.checkOutputItalic_CheckedChanged);
            // 
            // checkOutputBold
            // 
            this.checkOutputBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkOutputBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOutputBold.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkOutputBold.Location = new System.Drawing.Point(128, 56);
            this.checkOutputBold.Name = "checkOutputBold";
            this.checkOutputBold.Size = new System.Drawing.Size(24, 24);
            this.checkOutputBold.TabIndex = 20;
            this.checkOutputBold.Text = "B";
            this.checkOutputBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkOutputBold.CheckedChanged += new System.EventHandler(this.checkOutputBold_CheckedChanged);
            // 
            // comboOutputFont
            // 
            this.comboOutputFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOutputFont.Location = new System.Drawing.Point(8, 24);
            this.comboOutputFont.Name = "comboOutputFont";
            this.comboOutputFont.Size = new System.Drawing.Size(176, 21);
            this.comboOutputFont.TabIndex = 19;
            this.comboOutputFont.SelectedIndexChanged += new System.EventHandler(this.comboConvertedTextFont_SelectedIndexChanged);
            // 
            // groupInputTextFont
            // 
            this.groupInputTextFont.Controls.Add(this.comboInputSize);
            this.groupInputTextFont.Controls.Add(this.checkInputItalic);
            this.groupInputTextFont.Controls.Add(this.checkInputBold);
            this.groupInputTextFont.Controls.Add(this.comboInputFont);
            this.groupInputTextFont.Location = new System.Drawing.Point(8, 8);
            this.groupInputTextFont.Name = "groupInputTextFont";
            this.groupInputTextFont.Size = new System.Drawing.Size(192, 88);
            this.groupInputTextFont.TabIndex = 0;
            this.groupInputTextFont.TabStop = false;
            this.groupInputTextFont.Text = "Input Text Font";
            // 
            // comboInputSize
            // 
            this.comboInputSize.IntegralHeight = false;
            this.comboInputSize.ItemHeight = 13;
            this.comboInputSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.comboInputSize.Location = new System.Drawing.Point(8, 56);
            this.comboInputSize.MaxLength = 6;
            this.comboInputSize.Name = "comboInputSize";
            this.comboInputSize.Size = new System.Drawing.Size(56, 21);
            this.comboInputSize.TabIndex = 18;
            this.comboInputSize.Text = "12";
            this.comboInputSize.SelectedIndexChanged += new System.EventHandler(this.comboInputSize_SelectedIndexChanged);
            this.comboInputSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboOriginalTextSize_KeyPress);
            // 
            // checkInputItalic
            // 
            this.checkInputItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkInputItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInputItalic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkInputItalic.Location = new System.Drawing.Point(160, 56);
            this.checkInputItalic.Name = "checkInputItalic";
            this.checkInputItalic.Size = new System.Drawing.Size(24, 24);
            this.checkInputItalic.TabIndex = 16;
            this.checkInputItalic.Text = "I";
            this.checkInputItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkInputItalic.CheckedChanged += new System.EventHandler(this.checkInputItalic_CheckedChanged);
            // 
            // checkInputBold
            // 
            this.checkInputBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkInputBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInputBold.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkInputBold.Location = new System.Drawing.Point(128, 56);
            this.checkInputBold.Name = "checkInputBold";
            this.checkInputBold.Size = new System.Drawing.Size(24, 24);
            this.checkInputBold.TabIndex = 15;
            this.checkInputBold.Text = "B";
            this.checkInputBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkInputBold.CheckedChanged += new System.EventHandler(this.checkInputBold_CheckedChanged);
            // 
            // comboInputFont
            // 
            this.comboInputFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInputFont.Location = new System.Drawing.Point(8, 24);
            this.comboInputFont.Name = "comboInputFont";
            this.comboInputFont.Size = new System.Drawing.Size(176, 21);
            this.comboInputFont.TabIndex = 1;
            this.comboInputFont.SelectedIndexChanged += new System.EventHandler(this.comboOriginalTextFont_SelectedIndexChanged);
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.groupXHTMLSettings);
            this.tabOutput.Controls.Add(this.groupUnicodeTransformation);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Size = new System.Drawing.Size(408, 230);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // groupXHTMLSettings
            // 
            this.groupXHTMLSettings.Controls.Add(this.checkXHTMLXMLDec);
            this.groupXHTMLSettings.Controls.Add(this.radioXHTML11);
            this.groupXHTMLSettings.Controls.Add(this.radioXHTML10);
            this.groupXHTMLSettings.Location = new System.Drawing.Point(8, 8);
            this.groupXHTMLSettings.Name = "groupXHTMLSettings";
            this.groupXHTMLSettings.Size = new System.Drawing.Size(192, 96);
            this.groupXHTMLSettings.TabIndex = 19;
            this.groupXHTMLSettings.TabStop = false;
            this.groupXHTMLSettings.Text = "XHTML Settings";
            // 
            // checkXHTMLXMLDec
            // 
            this.checkXHTMLXMLDec.Location = new System.Drawing.Point(8, 64);
            this.checkXHTMLXMLDec.Name = "checkXHTMLXMLDec";
            this.checkXHTMLXMLDec.Size = new System.Drawing.Size(176, 24);
            this.checkXHTMLXMLDec.TabIndex = 11;
            this.checkXHTMLXMLDec.Text = "Include XML declaration";
            this.checkXHTMLXMLDec.CheckedChanged += new System.EventHandler(this.checkXHTMLXMLDec_CheckedChanged);
            // 
            // radioXHTML11
            // 
            this.radioXHTML11.Location = new System.Drawing.Point(8, 40);
            this.radioXHTML11.Name = "radioXHTML11";
            this.radioXHTML11.Size = new System.Drawing.Size(176, 24);
            this.radioXHTML11.TabIndex = 10;
            this.radioXHTML11.Text = "XHTML 1.1";
            this.radioXHTML11.CheckedChanged += new System.EventHandler(this.radioXHTML11_CheckedChanged);
            // 
            // radioXHTML10
            // 
            this.radioXHTML10.Checked = true;
            this.radioXHTML10.Location = new System.Drawing.Point(8, 16);
            this.radioXHTML10.Name = "radioXHTML10";
            this.radioXHTML10.Size = new System.Drawing.Size(176, 24);
            this.radioXHTML10.TabIndex = 9;
            this.radioXHTML10.TabStop = true;
            this.radioXHTML10.Text = "XHTML 1.0 Transitional";
            this.radioXHTML10.CheckedChanged += new System.EventHandler(this.radioXHTML10_CheckedChanged);
            // 
            // groupUnicodeTransformation
            // 
            this.groupUnicodeTransformation.Controls.Add(this.radioOutputUTF8);
            this.groupUnicodeTransformation.Controls.Add(this.radioOutputUTF16);
            this.groupUnicodeTransformation.Location = new System.Drawing.Point(8, 112);
            this.groupUnicodeTransformation.Name = "groupUnicodeTransformation";
            this.groupUnicodeTransformation.Size = new System.Drawing.Size(192, 72);
            this.groupUnicodeTransformation.TabIndex = 20;
            this.groupUnicodeTransformation.TabStop = false;
            this.groupUnicodeTransformation.Text = "Unicode Transformation";
            // 
            // radioOutputUTF8
            // 
            this.radioOutputUTF8.Checked = true;
            this.radioOutputUTF8.Location = new System.Drawing.Point(8, 16);
            this.radioOutputUTF8.Name = "radioOutputUTF8";
            this.radioOutputUTF8.Size = new System.Drawing.Size(176, 24);
            this.radioOutputUTF8.TabIndex = 19;
            this.radioOutputUTF8.TabStop = true;
            this.radioOutputUTF8.Text = "Output to UTF-8";
            this.radioOutputUTF8.CheckedChanged += new System.EventHandler(this.radioOutputUTF8_CheckedChanged);
            // 
            // radioOutputUTF16
            // 
            this.radioOutputUTF16.Location = new System.Drawing.Point(8, 40);
            this.radioOutputUTF16.Name = "radioOutputUTF16";
            this.radioOutputUTF16.Size = new System.Drawing.Size(176, 24);
            this.radioOutputUTF16.TabIndex = 20;
            this.radioOutputUTF16.Text = "Output to UTF-16";
            this.radioOutputUTF16.CheckedChanged += new System.EventHandler(this.radioOutputUTF16_CheckedChanged);
            // 
            // tabUnicodeConversion
            // 
            this.tabUnicodeConversion.Controls.Add(this.groupUnicodeNumbers);
            this.tabUnicodeConversion.Controls.Add(this.groupUnicodeGeneral);
            this.tabUnicodeConversion.Location = new System.Drawing.Point(4, 22);
            this.tabUnicodeConversion.Name = "tabUnicodeConversion";
            this.tabUnicodeConversion.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnicodeConversion.Size = new System.Drawing.Size(408, 230);
            this.tabUnicodeConversion.TabIndex = 4;
            this.tabUnicodeConversion.Text = "Unicode Conversion";
            this.tabUnicodeConversion.UseVisualStyleBackColor = true;
            // 
            // groupUnicodeNumbers
            // 
            this.groupUnicodeNumbers.Controls.Add(this.radioNumberKeep);
            this.groupUnicodeNumbers.Controls.Add(this.radioNumberGurmukhi);
            this.groupUnicodeNumbers.Controls.Add(this.radioNumberLatin);
            this.groupUnicodeNumbers.Location = new System.Drawing.Point(8, 88);
            this.groupUnicodeNumbers.Name = "groupUnicodeNumbers";
            this.groupUnicodeNumbers.Size = new System.Drawing.Size(192, 96);
            this.groupUnicodeNumbers.TabIndex = 27;
            this.groupUnicodeNumbers.TabStop = false;
            this.groupUnicodeNumbers.Text = "Number Format";
            // 
            // radioNumberKeep
            // 
            this.radioNumberKeep.Checked = true;
            this.radioNumberKeep.Location = new System.Drawing.Point(8, 64);
            this.radioNumberKeep.Name = "radioNumberKeep";
            this.radioNumberKeep.Size = new System.Drawing.Size(122, 24);
            this.radioNumberKeep.TabIndex = 44;
            this.radioNumberKeep.TabStop = true;
            this.radioNumberKeep.Text = "Keep as is";
            this.radioNumberKeep.UseVisualStyleBackColor = true;
            this.radioNumberKeep.CheckedChanged += new System.EventHandler(this.radioNumberKeep_CheckedChanged);
            // 
            // radioNumberGurmukhi
            // 
            this.radioNumberGurmukhi.Location = new System.Drawing.Point(8, 40);
            this.radioNumberGurmukhi.Name = "radioNumberGurmukhi";
            this.radioNumberGurmukhi.Size = new System.Drawing.Size(128, 25);
            this.radioNumberGurmukhi.TabIndex = 43;
            this.radioNumberGurmukhi.Text = "Convert to Gurmukhi";
            this.radioNumberGurmukhi.UseVisualStyleBackColor = true;
            this.radioNumberGurmukhi.CheckedChanged += new System.EventHandler(this.radioNumberGurmukhi_CheckedChanged);
            // 
            // radioNumberLatin
            // 
            this.radioNumberLatin.Location = new System.Drawing.Point(8, 16);
            this.radioNumberLatin.Name = "radioNumberLatin";
            this.radioNumberLatin.Size = new System.Drawing.Size(104, 24);
            this.radioNumberLatin.TabIndex = 42;
            this.radioNumberLatin.Text = "Convert to Latin";
            this.radioNumberLatin.UseVisualStyleBackColor = true;
            this.radioNumberLatin.CheckedChanged += new System.EventHandler(this.radioNumberLatin_CheckedChanged);
            // 
            // groupUnicodeGeneral
            // 
            this.groupUnicodeGeneral.Controls.Add(this.checkBindiTippiCorrection);
            this.groupUnicodeGeneral.Controls.Add(this.checkErrorCorrection);
            this.groupUnicodeGeneral.Location = new System.Drawing.Point(8, 8);
            this.groupUnicodeGeneral.Name = "groupUnicodeGeneral";
            this.groupUnicodeGeneral.Size = new System.Drawing.Size(192, 72);
            this.groupUnicodeGeneral.TabIndex = 26;
            this.groupUnicodeGeneral.TabStop = false;
            this.groupUnicodeGeneral.Text = "General Settings";
            // 
            // checkBindiTippiCorrection
            // 
            this.checkBindiTippiCorrection.Location = new System.Drawing.Point(8, 40);
            this.checkBindiTippiCorrection.Name = "checkBindiTippiCorrection";
            this.checkBindiTippiCorrection.Size = new System.Drawing.Size(176, 24);
            this.checkBindiTippiCorrection.TabIndex = 29;
            this.checkBindiTippiCorrection.Text = "Bindi and tippi correction";
            this.checkBindiTippiCorrection.CheckedChanged += new System.EventHandler(this.checkBindiTippiCorrection_CheckedChanged);
            // 
            // checkErrorCorrection
            // 
            this.checkErrorCorrection.Checked = true;
            this.checkErrorCorrection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkErrorCorrection.Location = new System.Drawing.Point(8, 16);
            this.checkErrorCorrection.Name = "checkErrorCorrection";
            this.checkErrorCorrection.Size = new System.Drawing.Size(176, 24);
            this.checkErrorCorrection.TabIndex = 28;
            this.checkErrorCorrection.Text = "Intelligent error correction";
            this.checkErrorCorrection.CheckedChanged += new System.EventHandler(this.checkErrorCorrection_CheckedChanged_1);
            // 
            // tabMappings
            // 
            this.tabMappings.Controls.Add(this.groupInstalledMappings);
            this.tabMappings.Location = new System.Drawing.Point(4, 22);
            this.tabMappings.Name = "tabMappings";
            this.tabMappings.Size = new System.Drawing.Size(408, 230);
            this.tabMappings.TabIndex = 3;
            this.tabMappings.Text = "Mappings";
            this.tabMappings.UseVisualStyleBackColor = true;
            // 
            // groupInstalledMappings
            // 
            this.groupInstalledMappings.Controls.Add(this.buttonMappingDetails);
            this.groupInstalledMappings.Controls.Add(this.buttonInstallMapping);
            this.groupInstalledMappings.Controls.Add(this.buttonUninstallMapping);
            this.groupInstalledMappings.Controls.Add(this.listRecognisedMappings);
            this.groupInstalledMappings.Location = new System.Drawing.Point(8, 8);
            this.groupInstalledMappings.Name = "groupInstalledMappings";
            this.groupInstalledMappings.Size = new System.Drawing.Size(392, 216);
            this.groupInstalledMappings.TabIndex = 29;
            this.groupInstalledMappings.TabStop = false;
            this.groupInstalledMappings.Text = "Installed Mappings";
            // 
            // buttonMappingDetails
            // 
            this.buttonMappingDetails.Location = new System.Drawing.Point(8, 184);
            this.buttonMappingDetails.Name = "buttonMappingDetails";
            this.buttonMappingDetails.Size = new System.Drawing.Size(72, 24);
            this.buttonMappingDetails.TabIndex = 38;
            this.buttonMappingDetails.Text = "Details...";
            this.buttonMappingDetails.Click += new System.EventHandler(this.buttonMappingDetails_Click);
            // 
            // buttonInstallMapping
            // 
            this.buttonInstallMapping.Location = new System.Drawing.Point(232, 184);
            this.buttonInstallMapping.Name = "buttonInstallMapping";
            this.buttonInstallMapping.Size = new System.Drawing.Size(72, 24);
            this.buttonInstallMapping.TabIndex = 36;
            this.buttonInstallMapping.Text = "Install";
            this.buttonInstallMapping.Click += new System.EventHandler(this.buttonInstallMapping_Click);
            // 
            // buttonUninstallMapping
            // 
            this.buttonUninstallMapping.Location = new System.Drawing.Point(312, 184);
            this.buttonUninstallMapping.Name = "buttonUninstallMapping";
            this.buttonUninstallMapping.Size = new System.Drawing.Size(72, 24);
            this.buttonUninstallMapping.TabIndex = 37;
            this.buttonUninstallMapping.Text = "Uninstall";
            this.buttonUninstallMapping.Click += new System.EventHandler(this.buttonUninstallMapping_Click);
            // 
            // listRecognisedMappings
            // 
            this.listRecognisedMappings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFrom,
            this.columnTo,
            this.columnVersion});
            this.listRecognisedMappings.FullRowSelect = true;
            this.listRecognisedMappings.Location = new System.Drawing.Point(8, 16);
            this.listRecognisedMappings.Name = "listRecognisedMappings";
            this.listRecognisedMappings.Size = new System.Drawing.Size(376, 160);
            this.listRecognisedMappings.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listRecognisedMappings.TabIndex = 29;
            this.listRecognisedMappings.UseCompatibleStateImageBehavior = false;
            this.listRecognisedMappings.View = System.Windows.Forms.View.Details;
            this.listRecognisedMappings.SelectedIndexChanged += new System.EventHandler(this.listRecognisedMappings_SelectedIndexChanged);
            // 
            // columnFrom
            // 
            this.columnFrom.Text = "From";
            this.columnFrom.Width = 130;
            // 
            // columnTo
            // 
            this.columnTo.Text = "To";
            this.columnTo.Width = 130;
            // 
            // columnVersion
            // 
            this.columnVersion.Text = "Version";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(256, 272);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 24);
            this.buttonCancel.TabIndex = 40;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(170, 272);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(80, 24);
            this.buttonOK.TabIndex = 39;
            this.buttonOK.Text = "&OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(342, 272);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(80, 24);
            this.buttonApply.TabIndex = 41;
            this.buttonApply.Text = "&Apply";
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // Options
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(434, 304);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Closed += new System.EventHandler(this.Options_Closed);
            this.Load += new System.EventHandler(this.Options_Load);
            this.tabMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupLocaleType.ResumeLayout(false);
            this.groupLocaleType.PerformLayout();
            this.groupOutputTextFont.ResumeLayout(false);
            this.groupInputTextFont.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.groupXHTMLSettings.ResumeLayout(false);
            this.groupUnicodeTransformation.ResumeLayout(false);
            this.tabUnicodeConversion.ResumeLayout(false);
            this.groupUnicodeNumbers.ResumeLayout(false);
            this.groupUnicodeGeneral.ResumeLayout(false);
            this.tabMappings.ResumeLayout(false);
            this.groupInstalledMappings.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void Options_Load(object sender, System.EventArgs e)
        {
            bLoading = true;

            System.Drawing.Text.InstalledFontCollection ifc = new System.Drawing.Text.InstalledFontCollection();

            // Load font list
            comboInputFont.DataSource = ifc.Families;
            comboInputFont.DisplayMember = "Name";

            comboOutputFont.DataSource = ifc.Families;
            comboOutputFont.DisplayMember = "Name";

            bLoading = false;

            // Select default fonts after the loading stage

            Font inputFont = ((MainForm)this.Owner).textInputText.Font;
            Font outputFont = ((MainForm)this.Owner).textOutputText.Font;

            comboInputFont.Text = inputFont.Name;
            comboOutputFont.Text = outputFont.Name;

            comboInputSize.Text = inputFont.SizeInPoints.ToString();
            comboOutputSize.Text = outputFont.SizeInPoints.ToString();

            checkInputBold.Checked = inputFont.Bold;
            checkOutputBold.Checked = outputFont.Bold;

            checkInputItalic.Checked = inputFont.Italic;
            checkOutputItalic.Checked = outputFont.Italic;

            // Load settings 
            // Default settings MUST be set in the Settings class and 
            // not on the Options UI.


            Settings.LoadSettings();

            switch (Settings.DefaultLocale)
            {
                case Settings.LocaleType.Indian:
                    radioPunjabiIndia.Checked = true;
                    break;

                case Settings.LocaleType.Pakistani:
                    radioPunjabiPakistan.Checked = true;
                    break;

                case Settings.LocaleType.Generic:
                    radioPunjabiGeneric.Checked = true;
                    break;

                case Settings.LocaleType.Other:
                    radioOtherLocale.Checked = true;
                    textOtherLocale.Text = Settings.OtherLocale;
                    break;
            }

            checkErrorCorrection.Checked = Settings.ErrorCorrection;
            checkBindiTippiCorrection.Checked = Settings.BindiTippiCorrection;

            radioXHTML10.Checked = !Settings.XHTML11;
            radioXHTML11.Checked = Settings.XHTML11;

            checkXHTMLXMLDec.Checked = Settings.XMLDeclaration;

            radioOutputUTF8.Checked = !Settings.OutputUTF16;
            radioOutputUTF16.Checked = Settings.OutputUTF16;


            switch (Settings.NumberConversion)
            {
                case Settings.NumberConversionType.Latin:
                    radioNumberLatin.Checked = true;
                    radioNumberGurmukhi.Checked = false;
                    radioNumberKeep.Checked = false;
                    break;

                case Settings.NumberConversionType.Gurmukhi:
                    radioNumberLatin.Checked = false;
                    radioNumberGurmukhi.Checked = true;
                    radioNumberKeep.Checked = false;
                    break;

                default:
                    radioNumberLatin.Checked = false;
                    radioNumberGurmukhi.Checked = false;
                    radioNumberKeep.Checked = true;
                    break;
            }

            LoadMappings();

            buttonUninstallMapping.Enabled = false;
            buttonMappingDetails.Enabled = false;
            buttonApply.Enabled = false;
        }

        private void LoadMappings()
        {
            // Load mapping list

            listRecognisedMappings.Items.Clear();

            string[] sMappings = ConversionEngine.ListMappings(Settings.MappingDirectory);

            ConversionEngine converter = new ConversionEngine();

            Settings.LoadMappings();
            if (sMappings != null)
            {
                foreach (string sCurrent in sMappings)
                {
                    MappingDetails Current = ConversionEngine.LoadMapping(sCurrent);

                    ListViewItem Item = new ListViewItem();
                    if (Current.sFrom == "__gurmukhi__")
                        Item.Text = "Gurmukhi IEF";
                    else if (Current.sFrom == "__interindic__")
                        Item.Text = "InterIndic";
                    else
                        Item.Text = Current.sFrom;

                    Item.Tag = Current.sFileName;

                    if (Current.sTo == "__gurmukhi__")
                        Item.SubItems.Add("Gurmukhi IEF");
                    else if (Current.sTo == "__interindic__")
                        Item.SubItems.Add("InterIndic");
                    else
                        Item.SubItems.Add(Current.sTo);

                    Item.SubItems.Add(Current.sVersion);

                    listRecognisedMappings.Items.Add(Item);
                }
            }

            if (listRecognisedMappings.Items.Count == 0)
            {
                buttonMappingDetails.Enabled = false;
                buttonUninstallMapping.Enabled = false;
            }
        }

        private void comboOriginalTextFont_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            buttonApply.Enabled = true;

            if (!bLoading && comboInputSize.Text != "")
            {
                FontFamily family = new FontFamily(comboInputFont.Text);

                if (!family.IsStyleAvailable(FontStyle.Bold))
                    checkInputBold.Enabled = false;
                else
                    checkInputBold.Enabled = true;

                if (!family.IsStyleAvailable(FontStyle.Italic))
                    checkInputItalic.Enabled = false;
                else
                    checkInputItalic.Enabled = true;
            }
        }

        private void comboOriginalTextSize_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 && e.KeyChar != '.')
                e.Handled = true;
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void comboConvertedTextFont_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            buttonApply.Enabled = true;

            if (!bLoading && comboOutputFont.Text != "")
            {
                FontFamily family = new FontFamily(comboOutputFont.Text);

                if (!family.IsStyleAvailable(FontStyle.Bold))
                    checkOutputBold.Enabled = false;
                else
                    checkOutputBold.Enabled = true;

                if (!family.IsStyleAvailable(FontStyle.Italic))
                    checkOutputItalic.Enabled = false;
                else
                    checkOutputItalic.Enabled = true;
            }
        }

        private void comboConvertedTextSize_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioOtherLocale_CheckedChanged(object sender, System.EventArgs e)
        {
            buttonApply.Enabled = true;

            if (radioOtherLocale.Checked)
                textOtherLocale.Enabled = true;
            else
                textOtherLocale.Enabled = false;
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            // Save settings 
            SaveSettings();	

            Close();
        }

        /// <summary>
        /// Saves the settings
        /// </summary>
        private void SaveSettings()
        {
            Settings.InputFont = comboInputFont.Text;
            Settings.InputBold = checkInputBold.Checked;
            Settings.InputItalic = checkInputItalic.Checked;
            Settings.InputSize = float.Parse(comboInputSize.Text);

            Settings.OutputFont = comboOutputFont.Text;
            Settings.OutputBold = checkOutputBold.Checked;
            Settings.OutputItalic = checkOutputItalic.Checked;
            Settings.OutputSize = float.Parse(comboOutputSize.Text);

            if (radioPunjabiIndia.Checked)
                Settings.DefaultLocale = Settings.LocaleType.Indian;
            else if (radioPunjabiPakistan.Checked)
                Settings.DefaultLocale = Settings.LocaleType.Pakistani;
            else if (radioPunjabiGeneric.Checked)
                Settings.DefaultLocale = Settings.LocaleType.Generic;
            else if (radioOtherLocale.Checked)
                Settings.DefaultLocale = Settings.LocaleType.Other;

            Settings.OtherLocale = textOtherLocale.Text;

            Settings.ErrorCorrection = checkErrorCorrection.Checked;
            Settings.BindiTippiCorrection = checkBindiTippiCorrection.Checked;

            Settings.XHTML11 = radioXHTML11.Checked;

            Settings.XMLDeclaration = checkXHTMLXMLDec.Checked;

            Settings.OutputUTF16 = radioOutputUTF16.Checked;

            if (radioNumberLatin.Checked)
                Settings.NumberConversion = Settings.NumberConversionType.Latin;
            else if (radioNumberGurmukhi.Checked)
                Settings.NumberConversion = Settings.NumberConversionType.Gurmukhi;
            else if (radioNumberKeep.Checked)
                Settings.NumberConversion = Settings.NumberConversionType.Keep;

            Settings.SaveSettings();

            Settings.LoadFontStyles(((MainForm)Owner).textInputText, ((MainForm)Owner).textOutputText);
        }

        private void checkRenameOriginalFile_CheckedChanged(object sender, System.EventArgs e)
        {
        }

        private void buttonInstallMapping_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.Title = "Open...";
            openFile.Filter = "Metamorph Mapping Files (*.mmf)|*.mmf|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.Multiselect = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    foreach (string strFile in openFile.FileNames)
                    {
                        string sCopyTo = Settings.MappingDirectory + Path.DirectorySeparatorChar + Path.GetFileName(strFile);

                        if (File.Exists(sCopyTo))
                        {
                            if (MessageBox.Show("The following mapping file is already present: " + strFile + "\nDo you wish to replace it?", "Metamorph", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                continue;
                        }

                        File.Copy(strFile, sCopyTo, true);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file!\n\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadMappings();  //Reload list
        }

        private void buttonUninstallMapping_Click(object sender, System.EventArgs e)
        {


            if (MessageBox.Show("Are you sure you wish to remove the selected file(s)?", "Metamorph", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            foreach (ListViewItem Item in listRecognisedMappings.SelectedItems)
            {
                try
                {
                    File.Delete((String)Item.Tag);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to delete" + (String)Item.Tag + "!\n\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadMappings();  //Reload list
        }

        /*private void listRecognisedMappings_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            IEnumerator Iter = listRecognisedMappings.Items.GetEnumerator();
			
            while(Iter.MoveNext())
            {
                ListViewItem Current = (ListViewItem)Iter.Current;
                if (Current.Index != e.Index)
                    Current.Checked = false;
            }
        }*/

        private void Options_Closed(object sender, System.EventArgs e)
        {
            Settings.LoadInputList(((MainForm)Owner).listInputFormat, ((MainForm)Owner).listOutputFormat);
        }

        private void buttonMappingDetails_Click(object sender, System.EventArgs e)
        {
            foreach (ListViewItem Item in listRecognisedMappings.SelectedItems)
            {
                MappingDetails mdDetails = ConversionEngine.LoadMapping((String)Item.Tag);

                MessageBox.Show(Item.SubItems[0].Text + " -> " + Item.SubItems[1].Text + "\n\nAuthor: " + mdDetails.sAuthor + "\nVersion: " + mdDetails.sVersion + "\nDescription: " + mdDetails.sDescription, "Metamorph", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void listRecognisedMappings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listRecognisedMappings.SelectedItems.Count > 0)
            {
                buttonMappingDetails.Enabled = true;
                buttonUninstallMapping.Enabled = true;
            }
            else
            {
                buttonMappingDetails.Enabled = false;
                buttonUninstallMapping.Enabled = false;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveSettings();
            buttonApply.Enabled = false;
        }

        private void radioOutputUTF16_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioOutputUTF8_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void textExtension_TextChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioNameNew_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioRenameOriginal_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void checkXHTMLXMLDec_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioXHTML11_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioXHTML10_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void checkErrorCorrection_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void checkOutputBold_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void checkOutputItalic_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void textOtherLocale_TextChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioPunjabiPakistan_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void comboInputSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void checkInputBold_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void checkInputItalic_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void checkErrorCorrection_CheckedChanged_1(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void checkBindiTippiCorrection_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioNumberLatin_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioNumberGurmukhi_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void radioNumberKeep_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

    }
}