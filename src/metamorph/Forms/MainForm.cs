using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;

using Metamorph.Classes;

namespace Metamorph.Forms
{
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private bool bFirstLoad = false;
        private System.Windows.Forms.ToolTip tipMain;
		public System.Windows.Forms.MainMenu menuMain;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuFileOpen;
		private System.Windows.Forms.MenuItem menuFileDash1;
		private System.Windows.Forms.MenuItem menuFileSave;
		private System.Windows.Forms.MenuItem menuFileSaveAs;
		private System.Windows.Forms.MenuItem mnuFileDash2;
		private System.Windows.Forms.MenuItem menuFileExport;
		private System.Windows.Forms.MenuItem menuFileExportXHTML;
		private System.Windows.Forms.MenuItem menuFileDash3;
		private System.Windows.Forms.MenuItem menuFileLanguage;
		private System.Windows.Forms.MenuItem menuFileLanguageEnglish;
		private System.Windows.Forms.MenuItem menuFileLanguagePunjabi;
		private System.Windows.Forms.MenuItem menuFileDash4;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuEdit;
		private System.Windows.Forms.MenuItem menuEditUndo;
		private System.Windows.Forms.MenuItem menuEditDash1;
		private System.Windows.Forms.MenuItem menuEditCut;
		private System.Windows.Forms.MenuItem menuEditCopy;
		private System.Windows.Forms.MenuItem menuEditPaste;
		private System.Windows.Forms.MenuItem menuEditDash2;
		private System.Windows.Forms.MenuItem menuEditSelectAll;
		private System.Windows.Forms.MenuItem menuTools;
		public System.Windows.Forms.MenuItem menuToolsConvert;
		private System.Windows.Forms.MenuItem menuToolsDash1;
		private System.Windows.Forms.MenuItem menuToolsBatchProcessor;
		private System.Windows.Forms.MenuItem menuToolsDash2;
		private System.Windows.Forms.MenuItem menuToolsOptions;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuHelpContents;
		private System.Windows.Forms.MenuItem menuHelpDash1;
        private System.Windows.Forms.MenuItem menuHelpAbout;
        private System.Windows.Forms.MenuItem menuToolsCharViewer;
		private System.ComponentModel.IContainer components;

        private ConversionEngine converter = new ConversionEngine();

		// Windows 9x does not support Unicode properly, so that
		// when Gurmukhi is displayed in a text box, all that is stored
		// is ?.  Thus when exporting, no Gurmukhi characters are recognised.
		// We can fix this by storing the conversion string separately.
        public static string sCurrentText = "";
        private Button buttonConvert;
        private CheckBox checkAutoFont;
        private Button buttonClear;
        private ProgressBar progressMain;
        private Panel panelTopHalf;
        private SplitContainer splitMain;
        private SplitContainer splitCentral;
        private GroupBox groupOriginalText;
        public TextBox textInputText;
        private GroupBox groupConvertedText;
        public TextBox textOutputText;
        private SplitContainer splitRight;
        private GroupBox groupInputFormat;
        private GroupBox groupOutputFormat;
        private SplitContainer splitInputFormat;
        public ListBox listInputFormat;
        private CheckedListBox listInputOptions;
        private SplitContainer splitOutputFormat;
        public ListBox listOutputFormat;
        private CheckedListBox listOutputOptions;

		public static string sFileName = "";

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.buttonConvert = new System.Windows.Forms.Button();
            this.checkAutoFont = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MainMenu(this.components);
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
            this.menuEdit = new System.Windows.Forms.MenuItem();
            this.menuEditUndo = new System.Windows.Forms.MenuItem();
            this.menuEditDash1 = new System.Windows.Forms.MenuItem();
            this.menuEditCut = new System.Windows.Forms.MenuItem();
            this.menuEditCopy = new System.Windows.Forms.MenuItem();
            this.menuEditPaste = new System.Windows.Forms.MenuItem();
            this.menuEditDash2 = new System.Windows.Forms.MenuItem();
            this.menuEditSelectAll = new System.Windows.Forms.MenuItem();
            this.menuTools = new System.Windows.Forms.MenuItem();
            this.menuToolsConvert = new System.Windows.Forms.MenuItem();
            this.menuToolsDash1 = new System.Windows.Forms.MenuItem();
            this.menuToolsBatchProcessor = new System.Windows.Forms.MenuItem();
            this.menuToolsCharViewer = new System.Windows.Forms.MenuItem();
            this.menuToolsDash2 = new System.Windows.Forms.MenuItem();
            this.menuToolsOptions = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.menuHelpContents = new System.Windows.Forms.MenuItem();
            this.menuHelpDash1 = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.progressMain = new System.Windows.Forms.ProgressBar();
            this.panelTopHalf = new System.Windows.Forms.Panel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitCentral = new System.Windows.Forms.SplitContainer();
            this.groupOriginalText = new System.Windows.Forms.GroupBox();
            this.textInputText = new System.Windows.Forms.TextBox();
            this.groupConvertedText = new System.Windows.Forms.GroupBox();
            this.textOutputText = new System.Windows.Forms.TextBox();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.groupInputFormat = new System.Windows.Forms.GroupBox();
            this.groupOutputFormat = new System.Windows.Forms.GroupBox();
            this.splitInputFormat = new System.Windows.Forms.SplitContainer();
            this.listInputOptions = new System.Windows.Forms.CheckedListBox();
            this.listInputFormat = new System.Windows.Forms.ListBox();
            this.splitOutputFormat = new System.Windows.Forms.SplitContainer();
            this.listOutputFormat = new System.Windows.Forms.ListBox();
            this.listOutputOptions = new System.Windows.Forms.CheckedListBox();
            this.panelTopHalf.SuspendLayout();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.splitCentral.Panel1.SuspendLayout();
            this.splitCentral.Panel2.SuspendLayout();
            this.splitCentral.SuspendLayout();
            this.groupOriginalText.SuspendLayout();
            this.groupConvertedText.SuspendLayout();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            this.groupInputFormat.SuspendLayout();
            this.groupOutputFormat.SuspendLayout();
            this.splitInputFormat.Panel1.SuspendLayout();
            this.splitInputFormat.Panel2.SuspendLayout();
            this.splitInputFormat.SuspendLayout();
            this.splitOutputFormat.Panel1.SuspendLayout();
            this.splitOutputFormat.Panel2.SuspendLayout();
            this.splitOutputFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonConvert.Location = new System.Drawing.Point(568, 376);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(88, 24);
            this.buttonConvert.TabIndex = 21;
            this.buttonConvert.Text = "&Convert";
            this.tipMain.SetToolTip(this.buttonConvert, "Clear text from all text boxes.");
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // checkAutoFont
            // 
            this.checkAutoFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkAutoFont.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkAutoFont.Checked = true;
            this.checkAutoFont.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAutoFont.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkAutoFont.Location = new System.Drawing.Point(40, 376);
            this.checkAutoFont.Name = "checkAutoFont";
            this.checkAutoFont.Size = new System.Drawing.Size(32, 24);
            this.checkAutoFont.TabIndex = 20;
            this.checkAutoFont.Text = "AF";
            this.checkAutoFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipMain.SetToolTip(this.checkAutoFont, "Automatically change fonts based on input/output format.");
            this.checkAutoFont.Visible = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonClear.Location = new System.Drawing.Point(8, 376);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(24, 24);
            this.buttonClear.TabIndex = 19;
            this.buttonClear.Text = "C";
            this.tipMain.SetToolTip(this.buttonClear, "Clear text from all text boxes.");
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // menuMain
            // 
            this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuTools,
            this.menuHelp});
            // 
            // menuFile
            // 
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
            this.menuFile.Text = "&File";
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Index = 0;
            this.menuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuFileOpen.Text = "&Open...";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileDash1
            // 
            this.menuFileDash1.Index = 1;
            this.menuFileDash1.Text = "-";
            // 
            // menuFileSave
            // 
            this.menuFileSave.Index = 2;
            this.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuFileSave.Text = "&Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Index = 3;
            this.menuFileSaveAs.Text = "Save &As...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // mnuFileDash2
            // 
            this.mnuFileDash2.Index = 4;
            this.mnuFileDash2.Text = "-";
            // 
            // menuFileExport
            // 
            this.menuFileExport.Index = 5;
            this.menuFileExport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileExportXHTML});
            this.menuFileExport.Text = "&Export";
            // 
            // menuFileExportXHTML
            // 
            this.menuFileExportXHTML.Index = 0;
            this.menuFileExportXHTML.Shortcut = System.Windows.Forms.Shortcut.F12;
            this.menuFileExportXHTML.Text = "X&HTML";
            this.menuFileExportXHTML.Click += new System.EventHandler(this.menuFileExportXHTML_Click);
            // 
            // menuFileDash3
            // 
            this.menuFileDash3.Index = 6;
            this.menuFileDash3.Text = "-";
            // 
            // menuFileLanguage
            // 
            this.menuFileLanguage.Index = 7;
            this.menuFileLanguage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileLanguageEnglish,
            this.menuFileLanguagePunjabi});
            this.menuFileLanguage.Text = "&Language";
            this.menuFileLanguage.Visible = false;
            // 
            // menuFileLanguageEnglish
            // 
            this.menuFileLanguageEnglish.Checked = true;
            this.menuFileLanguageEnglish.Index = 0;
            this.menuFileLanguageEnglish.RadioCheck = true;
            this.menuFileLanguageEnglish.Text = "&English";
            // 
            // menuFileLanguagePunjabi
            // 
            this.menuFileLanguagePunjabi.Index = 1;
            this.menuFileLanguagePunjabi.Text = "&ਪੰਜਾਬੀ";
            // 
            // menuFileDash4
            // 
            this.menuFileDash4.Index = 8;
            this.menuFileDash4.Text = "-";
            this.menuFileDash4.Visible = false;
            // 
            // menuFileExit
            // 
            this.menuFileExit.Index = 9;
            this.menuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Index = 1;
            this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuEditUndo,
            this.menuEditDash1,
            this.menuEditCut,
            this.menuEditCopy,
            this.menuEditPaste,
            this.menuEditDash2,
            this.menuEditSelectAll});
            this.menuEdit.Text = "&Edit";
            // 
            // menuEditUndo
            // 
            this.menuEditUndo.Index = 0;
            this.menuEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuEditUndo.Text = "&Undo";
            this.menuEditUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
            // 
            // menuEditDash1
            // 
            this.menuEditDash1.Index = 1;
            this.menuEditDash1.Text = "-";
            // 
            // menuEditCut
            // 
            this.menuEditCut.Index = 2;
            this.menuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuEditCut.Text = "Cut";
            this.menuEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
            // 
            // menuEditCopy
            // 
            this.menuEditCopy.Index = 3;
            this.menuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuEditCopy.Text = "Copy";
            this.menuEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
            // 
            // menuEditPaste
            // 
            this.menuEditPaste.Index = 4;
            this.menuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuEditPaste.Text = "Paste";
            this.menuEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
            // 
            // menuEditDash2
            // 
            this.menuEditDash2.Index = 5;
            this.menuEditDash2.Text = "-";
            // 
            // menuEditSelectAll
            // 
            this.menuEditSelectAll.Index = 6;
            this.menuEditSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.menuEditSelectAll.Text = "Select All";
            this.menuEditSelectAll.Click += new System.EventHandler(this.menuEditSelectAll_Click);
            // 
            // menuTools
            // 
            this.menuTools.Index = 2;
            this.menuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToolsConvert,
            this.menuToolsDash1,
            this.menuToolsBatchProcessor,
            this.menuToolsCharViewer,
            this.menuToolsDash2,
            this.menuToolsOptions});
            this.menuTools.Text = "&Tools";
            // 
            // menuToolsConvert
            // 
            this.menuToolsConvert.Index = 0;
            this.menuToolsConvert.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuToolsConvert.Text = "&Convert";
            this.menuToolsConvert.Click += new System.EventHandler(this.menuToolsConvert_Click);
            // 
            // menuToolsDash1
            // 
            this.menuToolsDash1.Index = 1;
            this.menuToolsDash1.Text = "-";
            // 
            // menuToolsBatchProcessor
            // 
            this.menuToolsBatchProcessor.Index = 2;
            this.menuToolsBatchProcessor.Text = "&Batch Processor...";
            this.menuToolsBatchProcessor.Click += new System.EventHandler(this.menuToolsBatchProcessor_Click);
            // 
            // menuToolsCharViewer
            // 
            this.menuToolsCharViewer.Index = 3;
            this.menuToolsCharViewer.Text = "Character &Viewer...";
            this.menuToolsCharViewer.Click += new System.EventHandler(this.menuToolsCharViewer_Click);
            // 
            // menuToolsDash2
            // 
            this.menuToolsDash2.Index = 4;
            this.menuToolsDash2.Text = "-";
            // 
            // menuToolsOptions
            // 
            this.menuToolsOptions.Index = 5;
            this.menuToolsOptions.Text = "&Options...";
            this.menuToolsOptions.Click += new System.EventHandler(this.menuToolsOptions_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 3;
            this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpContents,
            this.menuHelpDash1,
            this.menuHelpAbout});
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpContents
            // 
            this.menuHelpContents.Index = 0;
            this.menuHelpContents.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuHelpContents.Text = "&Contents";
            this.menuHelpContents.Click += new System.EventHandler(this.menuHelpContents_Click);
            // 
            // menuHelpDash1
            // 
            this.menuHelpDash1.Index = 1;
            this.menuHelpDash1.Text = "-";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 2;
            this.menuHelpAbout.Text = "&About Metamorph...";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // progressMain
            // 
            this.progressMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressMain.Location = new System.Drawing.Point(40, 376);
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(520, 24);
            this.progressMain.TabIndex = 18;
            // 
            // panelTopHalf
            // 
            this.panelTopHalf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTopHalf.Controls.Add(this.splitMain);
            this.panelTopHalf.Location = new System.Drawing.Point(0, 0);
            this.panelTopHalf.Name = "panelTopHalf";
            this.panelTopHalf.Size = new System.Drawing.Size(664, 368);
            this.panelTopHalf.TabIndex = 0;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitCentral);
            this.splitMain.Panel1MinSize = 100;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitRight);
            this.splitMain.Panel2MinSize = 100;
            this.splitMain.Size = new System.Drawing.Size(664, 368);
            this.splitMain.SplitterDistance = 369;
            this.splitMain.TabIndex = 0;
            // 
            // splitCentral
            // 
            this.splitCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCentral.Location = new System.Drawing.Point(0, 0);
            this.splitCentral.Name = "splitCentral";
            this.splitCentral.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCentral.Panel1
            // 
            this.splitCentral.Panel1.Controls.Add(this.groupOriginalText);
            // 
            // splitCentral.Panel2
            // 
            this.splitCentral.Panel2.Controls.Add(this.groupConvertedText);
            this.splitCentral.Size = new System.Drawing.Size(369, 368);
            this.splitCentral.SplitterDistance = 182;
            this.splitCentral.TabIndex = 0;
            // 
            // groupOriginalText
            // 
            this.groupOriginalText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupOriginalText.Controls.Add(this.textInputText);
            this.groupOriginalText.Location = new System.Drawing.Point(8, 8);
            this.groupOriginalText.Name = "groupOriginalText";
            this.groupOriginalText.Size = new System.Drawing.Size(360, 168);
            this.groupOriginalText.TabIndex = 2;
            this.groupOriginalText.TabStop = false;
            this.groupOriginalText.Text = "Input Text";
            // 
            // textInputText
            // 
            this.textInputText.AcceptsReturn = true;
            this.textInputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInputText.Location = new System.Drawing.Point(8, 16);
            this.textInputText.MaxLength = 0;
            this.textInputText.Multiline = true;
            this.textInputText.Name = "textInputText";
            this.textInputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInputText.Size = new System.Drawing.Size(344, 144);
            this.textInputText.TabIndex = 0;
            // 
            // groupConvertedText
            // 
            this.groupConvertedText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupConvertedText.Controls.Add(this.textOutputText);
            this.groupConvertedText.Location = new System.Drawing.Point(8, 0);
            this.groupConvertedText.Name = "groupConvertedText";
            this.groupConvertedText.Size = new System.Drawing.Size(360, 182);
            this.groupConvertedText.TabIndex = 17;
            this.groupConvertedText.TabStop = false;
            this.groupConvertedText.Text = "Output Text";
            // 
            // textOutputText
            // 
            this.textOutputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textOutputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOutputText.Location = new System.Drawing.Point(8, 16);
            this.textOutputText.MaxLength = 0;
            this.textOutputText.Multiline = true;
            this.textOutputText.Name = "textOutputText";
            this.textOutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOutputText.Size = new System.Drawing.Size(344, 158);
            this.textOutputText.TabIndex = 0;
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Location = new System.Drawing.Point(0, 0);
            this.splitRight.Name = "splitRight";
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRight.Panel1
            // 
            this.splitRight.Panel1.Controls.Add(this.groupInputFormat);
            // 
            // splitRight.Panel2
            // 
            this.splitRight.Panel2.Controls.Add(this.groupOutputFormat);
            this.splitRight.Size = new System.Drawing.Size(291, 368);
            this.splitRight.SplitterDistance = 182;
            this.splitRight.TabIndex = 0;
            // 
            // groupInputFormat
            // 
            this.groupInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInputFormat.Controls.Add(this.splitInputFormat);
            this.groupInputFormat.Location = new System.Drawing.Point(1, 7);
            this.groupInputFormat.Name = "groupInputFormat";
            this.groupInputFormat.Size = new System.Drawing.Size(279, 169);
            this.groupInputFormat.TabIndex = 23;
            this.groupInputFormat.TabStop = false;
            this.groupInputFormat.Text = "Input Format";
            // 
            // groupOutputFormat
            // 
            this.groupOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupOutputFormat.Controls.Add(this.splitOutputFormat);
            this.groupOutputFormat.Location = new System.Drawing.Point(0, 0);
            this.groupOutputFormat.Name = "groupOutputFormat";
            this.groupOutputFormat.Size = new System.Drawing.Size(280, 182);
            this.groupOutputFormat.TabIndex = 24;
            this.groupOutputFormat.TabStop = false;
            this.groupOutputFormat.Text = "Output Format";
            // 
            // splitInputFormat
            // 
            this.splitInputFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitInputFormat.Location = new System.Drawing.Point(3, 16);
            this.splitInputFormat.Name = "splitInputFormat";
            // 
            // splitInputFormat.Panel1
            // 
            this.splitInputFormat.Panel1.Controls.Add(this.listInputFormat);
            // 
            // splitInputFormat.Panel2
            // 
            this.splitInputFormat.Panel2.Controls.Add(this.listInputOptions);
            this.splitInputFormat.Size = new System.Drawing.Size(273, 150);
            this.splitInputFormat.SplitterDistance = 145;
            this.splitInputFormat.TabIndex = 0;
            // 
            // listInputOptions
            // 
            this.listInputOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listInputOptions.FormattingEnabled = true;
            this.listInputOptions.HorizontalScrollbar = true;
            this.listInputOptions.IntegralHeight = false;
            this.listInputOptions.Location = new System.Drawing.Point(0, 0);
            this.listInputOptions.Name = "listInputOptions";
            this.listInputOptions.Size = new System.Drawing.Size(120, 145);
            this.listInputOptions.TabIndex = 3;
            // 
            // listInputFormat
            // 
            this.listInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listInputFormat.IntegralHeight = false;
            this.listInputFormat.Location = new System.Drawing.Point(4, 0);
            this.listInputFormat.Name = "listInputFormat";
            this.listInputFormat.Size = new System.Drawing.Size(140, 145);
            this.listInputFormat.TabIndex = 2;
            this.listInputFormat.SelectedIndexChanged += new System.EventHandler(this.listInputFormat_SelectedIndexChanged);
            // 
            // splitOutputFormat
            // 
            this.splitOutputFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitOutputFormat.Location = new System.Drawing.Point(3, 16);
            this.splitOutputFormat.Name = "splitOutputFormat";
            // 
            // splitOutputFormat.Panel1
            // 
            this.splitOutputFormat.Panel1.Controls.Add(this.listOutputFormat);
            // 
            // splitOutputFormat.Panel2
            // 
            this.splitOutputFormat.Panel2.Controls.Add(this.listOutputOptions);
            this.splitOutputFormat.Size = new System.Drawing.Size(274, 163);
            this.splitOutputFormat.SplitterDistance = 145;
            this.splitOutputFormat.TabIndex = 1;
            // 
            // listOutputFormat
            // 
            this.listOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listOutputFormat.IntegralHeight = false;
            this.listOutputFormat.Location = new System.Drawing.Point(4, 0);
            this.listOutputFormat.Name = "listOutputFormat";
            this.listOutputFormat.Size = new System.Drawing.Size(140, 158);
            this.listOutputFormat.TabIndex = 2;
            this.listOutputFormat.SelectedIndexChanged += new System.EventHandler(this.listOutputFormat_SelectedIndexChanged);
            // 
            // listOutputOptions
            // 
            this.listOutputOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listOutputOptions.FormattingEnabled = true;
            this.listOutputOptions.HorizontalScrollbar = true;
            this.listOutputOptions.IntegralHeight = false;
            this.listOutputOptions.Location = new System.Drawing.Point(0, 0);
            this.listOutputOptions.Name = "listOutputOptions";
            this.listOutputOptions.Size = new System.Drawing.Size(121, 158);
            this.listOutputOptions.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(662, 406);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.checkAutoFont);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.progressMain);
            this.Controls.Add(this.panelTopHalf);
            this.Menu = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(520, 440);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metamorph";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTopHalf.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            this.splitCentral.Panel1.ResumeLayout(false);
            this.splitCentral.Panel2.ResumeLayout(false);
            this.splitCentral.ResumeLayout(false);
            this.groupOriginalText.ResumeLayout(false);
            this.groupOriginalText.PerformLayout();
            this.groupConvertedText.ResumeLayout(false);
            this.groupConvertedText.PerformLayout();
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            this.splitRight.ResumeLayout(false);
            this.groupInputFormat.ResumeLayout(false);
            this.groupOutputFormat.ResumeLayout(false);
            this.splitInputFormat.Panel1.ResumeLayout(false);
            this.splitInputFormat.Panel2.ResumeLayout(false);
            this.splitInputFormat.ResumeLayout(false);
            this.splitOutputFormat.Panel1.ResumeLayout(false);
            this.splitOutputFormat.Panel2.ResumeLayout(false);
            this.splitOutputFormat.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{

		}

		private void MainForm_Activated(object sender, System.EventArgs e)
		{
			// Shouldn't really be used here.  But the only
			// time the visible state changes is when loading
			if (this.Visible == true && bFirstLoad == false)
			{
				bFirstLoad = true;
				Loading loading = new Loading();
				Application.DoEvents();
				loading.ShowDialog(this);
			}
		}

		private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			About form = new About();
			form.ShowDialog(this);
		}

		private void menuToolsOptions_Click(object sender, System.EventArgs e)
		{
			Options form = new Options();
			form.ShowDialog(this);
		}

		private void menuFileExit_Click(object sender, System.EventArgs e)
		{
			Close();
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
					textInputText.Text = streamRead.ReadToEnd();
				}
				catch (Exception exp)
				{
					MessageBox.Show("Unable to open file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}				
			}
		}

		private void menuFileSave_Click(object sender, System.EventArgs e)
		{
			if (sFileName == "")
			{
				SaveFileDialog saveFile = new SaveFileDialog();
				saveFile.RestoreDirectory = true;
				saveFile.Title = "Save...";
				saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
				saveFile.FilterIndex = 1;

				if(saveFile.ShowDialog() == DialogResult.OK)
				{
					sFileName = saveFile.FileName;
					this.SaveFile();
				}
			}
			else
			{
				this.SaveFile();
			}
		}

		private void menuToolsCharViewer_Click(object sender, System.EventArgs e)
		{
			CharacterViewer form = new CharacterViewer();
			form.Show();
		}

		private void listInputFormat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            Settings.LoadOutputList(listInputFormat, listInputOptions, listOutputFormat, listOutputOptions);
		}

		private void menuToolsConvert_Click(object sender, System.EventArgs e)
		{
			if (listOutputFormat.SelectedItems.Count == 0) 
			{
				if (listInputFormat.SelectedItems.Count == 0)
				{
					MessageBox.Show("Please select both an input and output format.", "Metamorph", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}

			MappingDetails From = (MappingDetails)listInputFormat.SelectedItem;
			MappingDetails To = (MappingDetails)listOutputFormat.SelectedItem;

            ConversionEngine.ErrorCorrection = Settings.ErrorCorrection;
            ConversionEngine.BindiTippiCorrection = Settings.BindiTippiCorrection;
            ConversionEngine.ProgressBar = progressMain;

            string sConversion = "";

            if (From != null)
                sConversion = ConversionEngine.Convert(textInputText.Text, From);
 
			if (To != null)
                sConversion = ConversionEngine.Convert(sConversion, To);

			if (Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.Win32S)
				sCurrentText = sConversion;

			textOutputText.Text = sConversion;
		}

		private void menuEditUndo_Click(object sender, System.EventArgs e)
		{
			if (textInputText.Focused)
				textInputText.Undo();
			else if (textOutputText.Focused)
				textOutputText.Undo();
		}

		private void menuEditCut_Click(object sender, System.EventArgs e)
		{
			if (textInputText.Focused)
				textInputText.Cut();
			else if (textOutputText.Focused)
				textOutputText.Cut();
		}

		private void menuEditCopy_Click(object sender, System.EventArgs e)
		{
			if (textInputText.Focused)
				textInputText.Copy();
			else if (textOutputText.Focused)
				textOutputText.Copy();
		}

		private void menuEditPaste_Click(object sender, System.EventArgs e)
		{
			if (textInputText.Focused)
				textInputText.Paste();
			else if (textOutputText.Focused)
				textOutputText.Paste();
		}

		private void menuEditSelectAll_Click(object sender, System.EventArgs e)
		{
			if (textInputText.Focused)
				textInputText.SelectAll();
			else if (textOutputText.Focused)
				textOutputText.SelectAll();
		}

		private void buttonConvert_Click(object sender, System.EventArgs e)
		{
			menuToolsConvert_Click(sender, e);
		}

		private void menuToolsRepair_Click(object sender, System.EventArgs e)
		{
		
		}

		private void buttonRepair_Click(object sender, System.EventArgs e)
		{
			menuToolsRepair_Click(sender, e);
		}

		private void buttonClear_Click(object sender, System.EventArgs e)
		{
			textInputText.Clear();
			textOutputText.Clear();
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

			
					if (Settings.OutputUTF16 == true)
						streamWrite = new StreamWriter(sExportFileName, false, System.Text.Encoding.Unicode);
					else
						streamWrite = new StreamWriter(sExportFileName, false, System.Text.Encoding.UTF8);				
				
					bool bXHTML11 = Settings.XHTML11;

					String sLang;
					if (Settings.DefaultLocale ==  Settings.LocaleType.Generic)
						sLang = "pa";
					else if (Settings.DefaultLocale ==  Settings.LocaleType.Indian)
						sLang = "pa-IN";
					else if (Settings.DefaultLocale ==  Settings.LocaleType.Pakistani)
						sLang = "pa-PK";
					else
						sLang = Settings.OtherLocale;

					// Create XHTML
					String sHeader = "";

					if (Settings.XMLDeclaration == true)
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
					sHeader += "    This XHTML file was automatically generated by Metamorph.\r\n\r\n";
					sHeader += "-->\r\n";
					if (bXHTML11 == true)
						sHeader += "<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"" + sLang + "\">\r\n";
					else
						sHeader += "<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"" + sLang + "\" xml:lang=\"" + sLang + "\">\r\n";
					
					sHeader += "    <head>\r\n";
					sHeader += "        <title>Metamorph Export</title>\r\n" ;
					if (streamWrite.Encoding == System.Text.Encoding.UTF8)
						sHeader += "        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n";
					else if (streamWrite.Encoding == System.Text.Encoding.Unicode)
						sHeader += "        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-16\" />\r\n";
					sHeader += "        <style type=\"text/css\">\r\n        <!--\r\n";
					sHeader += "            p,h1,h2,h3,h4,h5,h6            {font-family: AnmolUni, Saab, Raavi, Saraswati5, Arial Unicode MS, Tahoma, Verdana, Arial; font-weight: normal;}\r\n";
					sHeader += "            .microtext   {font-family: Tahoma, Verdana, Arial; font-size: 10px; font-weight: normal;}\r\n";
					sHeader += "        -->\r\n        </style>\r\n";
					sHeader += "    </head>\r\n";
					sHeader += "    <body>\r\n";

					String sBody = "";

					String sFooter;
					if (bXHTML11 == true)
						sFooter = "        <p class=\"microtext\" xml:lang=\"en\">This file was generated automatically using <a href=\"http://guca.sourceforge.net/applications/metamorph/\">Metamorph</a> and is fully compliant with <a href=\"http://validator.w3.org/\">XHTML</a> and <a href=\"http://jigsaw.w3.org/css-validator/\">CSS</a> standards.</p>\r\n";
					else
						sFooter = "        <p class=\"microtext\" lang=\"en\" xml:lang=\"en\">This file was generated automatically using <a href=\"http://guca.sourceforge.net/applications/metamorph/\">Metamorph</a> and is fully compliant with <a href=\"http://validator.w3.org/\">XHTML</a> and <a href=\"http://jigsaw.w3.org/css-validator/\">CSS</a> standards.</p>\r\n";

					sFooter += "    </body>\r\n</html>";

					sBody += "        <p>\r\n";
					if (Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.Win32S)
						sBody += sCurrentText.Replace("\r\n", "<br/>\r\n");
					else
						sBody += textOutputText.Text.Replace("\r\n", "<br/>\r\n");
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

		private void menuFileSaveAs_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.RestoreDirectory = true;
			saveFile.Title = "Save As...";
			saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			saveFile.FilterIndex = 1;

			if(saveFile.ShowDialog() == DialogResult.OK)
			{
				sFileName = saveFile.FileName;
				this.SaveFile();
			}
		}

		private void SaveFile()
		{
			try
			{
				if (File.Exists(sFileName) == true)
					File.Delete(sFileName);

				StreamWriter streamWrite;

				if (Settings.OutputUTF16 == true)
					streamWrite = new StreamWriter(sFileName, false, System.Text.Encoding.Unicode);
				else
					streamWrite = new StreamWriter(sFileName, false, System.Text.Encoding.UTF8);				

				if (Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.Win32S)
					streamWrite.Write(sCurrentText);
				else
					streamWrite.Write(textOutputText.Text);
				streamWrite.Close();
			}
			catch (Exception exp)
			{
				MessageBox.Show("Unable to save file!\r\n\r\n" + exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}	
		}

		private void menuToolsBatchProcessor_Click(object sender, System.EventArgs e)
		{
            BatchProcessor form = new BatchProcessor();

            form.ShowDialog();
		}

		private void checkAutoFont_CheckedChanged(object sender, System.EventArgs e)
		{
			// TODO Auto font selection
		}

		private void menuHelpContents_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(Settings.ApplicationDirectory + "readme.txt");
			}
			catch
			{
				MessageBox.Show("Metamorph was unable to open the user documentation.  Please check that the appropriate files are in the current directory.", "Metamorph", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}		
		}

        private void splitMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.LoadOptionsList(listOutputFormat, listOutputOptions);
        }
	}
}
