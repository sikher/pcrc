namespace Metamorph.Forms
{
    partial class BatchProcessor
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
            this.progressMain = new System.Windows.Forms.ProgressBar();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabOptionsFiles = new System.Windows.Forms.TabPage();
            this.groupAddFiles = new System.Windows.Forms.GroupBox();
            this.buttonFilesBrowse = new System.Windows.Forms.Button();
            this.textFilesMatching = new System.Windows.Forms.TextBox();
            this.labelFilesMatching = new System.Windows.Forms.Label();
            this.textFilesPath = new System.Windows.Forms.TextBox();
            this.labelFilesPath = new System.Windows.Forms.Label();
            this.buttonAddPath = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.groupFiles = new System.Windows.Forms.GroupBox();
            this.listFiles = new System.Windows.Forms.ListView();
            this.columnFilesFilename = new System.Windows.Forms.ColumnHeader();
            this.columnFilesPath = new System.Windows.Forms.ColumnHeader();
            this.columnFilesSize = new System.Windows.Forms.ColumnHeader();
            this.tabOptionsXML = new System.Windows.Forms.TabPage();
            this.groupEditTags = new System.Windows.Forms.GroupBox();
            this.textTagsEquals = new System.Windows.Forms.TextBox();
            this.labelTagsEquals = new System.Windows.Forms.Label();
            this.textTagsAttribute = new System.Windows.Forms.TextBox();
            this.labelTagsAttribute = new System.Windows.Forms.Label();
            this.textTagsTag = new System.Windows.Forms.TextBox();
            this.labelTagsTag = new System.Windows.Forms.Label();
            this.buttonTagAdd = new System.Windows.Forms.Button();
            this.buttonTagRemove = new System.Windows.Forms.Button();
            this.groupTags = new System.Windows.Forms.GroupBox();
            this.listTags = new System.Windows.Forms.ListView();
            this.columnTagsTag = new System.Windows.Forms.ColumnHeader();
            this.columnTagsAttribute = new System.Windows.Forms.ColumnHeader();
            this.columnTagsEquals = new System.Windows.Forms.ColumnHeader();
            this.tabOptionsOptions = new System.Windows.Forms.TabPage();
            this.groupSaveAs = new System.Windows.Forms.GroupBox();
            this.checkReplaceExtension = new System.Windows.Forms.CheckBox();
            this.labelSuffix = new System.Windows.Forms.Label();
            this.textSaveAsSuffix = new System.Windows.Forms.TextBox();
            this.panelFormats = new System.Windows.Forms.Panel();
            this.splitFormat = new System.Windows.Forms.SplitContainer();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.checkReplaceExistingFiles = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioFormatXML = new System.Windows.Forms.RadioButton();
            this.labelInputFormat = new System.Windows.Forms.Label();
            this.radioFormatText = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressCurrent = new System.Windows.Forms.ProgressBar();
            this.groupInputFormat = new System.Windows.Forms.GroupBox();
            this.splitInputFormat = new System.Windows.Forms.SplitContainer();
            this.listInputFormat = new System.Windows.Forms.ListBox();
            this.listInputOptions = new System.Windows.Forms.CheckedListBox();
            this.groupOutputFormat = new System.Windows.Forms.GroupBox();
            this.splitOutputFormat = new System.Windows.Forms.SplitContainer();
            this.listOutputFormat = new System.Windows.Forms.ListBox();
            this.listOutputOptions = new System.Windows.Forms.CheckedListBox();
            this.tabOptions.SuspendLayout();
            this.tabOptionsFiles.SuspendLayout();
            this.groupAddFiles.SuspendLayout();
            this.groupFiles.SuspendLayout();
            this.tabOptionsXML.SuspendLayout();
            this.groupEditTags.SuspendLayout();
            this.groupTags.SuspendLayout();
            this.tabOptionsOptions.SuspendLayout();
            this.groupSaveAs.SuspendLayout();
            this.panelFormats.SuspendLayout();
            this.splitFormat.Panel1.SuspendLayout();
            this.splitFormat.Panel2.SuspendLayout();
            this.splitFormat.SuspendLayout();
            this.groupOptions.SuspendLayout();
            this.groupInputFormat.SuspendLayout();
            this.splitInputFormat.Panel1.SuspendLayout();
            this.splitInputFormat.Panel2.SuspendLayout();
            this.splitInputFormat.SuspendLayout();
            this.groupOutputFormat.SuspendLayout();
            this.splitOutputFormat.Panel1.SuspendLayout();
            this.splitOutputFormat.Panel2.SuspendLayout();
            this.splitOutputFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressMain
            // 
            this.progressMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressMain.Location = new System.Drawing.Point(8, 352);
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(486, 19);
            this.progressMain.TabIndex = 1;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.Location = new System.Drawing.Point(328, 405);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(80, 24);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "&Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOptions.Controls.Add(this.tabOptionsFiles);
            this.tabOptions.Controls.Add(this.tabOptionsXML);
            this.tabOptions.Controls.Add(this.tabOptionsOptions);
            this.tabOptions.Location = new System.Drawing.Point(8, 8);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(488, 336);
            this.tabOptions.TabIndex = 4;
            // 
            // tabOptionsFiles
            // 
            this.tabOptionsFiles.Controls.Add(this.groupAddFiles);
            this.tabOptionsFiles.Controls.Add(this.groupFiles);
            this.tabOptionsFiles.Location = new System.Drawing.Point(4, 22);
            this.tabOptionsFiles.Name = "tabOptionsFiles";
            this.tabOptionsFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptionsFiles.Size = new System.Drawing.Size(480, 310);
            this.tabOptionsFiles.TabIndex = 0;
            this.tabOptionsFiles.Text = "Files";
            this.tabOptionsFiles.UseVisualStyleBackColor = true;
            // 
            // groupAddFiles
            // 
            this.groupAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAddFiles.Controls.Add(this.buttonFilesBrowse);
            this.groupAddFiles.Controls.Add(this.textFilesMatching);
            this.groupAddFiles.Controls.Add(this.labelFilesMatching);
            this.groupAddFiles.Controls.Add(this.textFilesPath);
            this.groupAddFiles.Controls.Add(this.labelFilesPath);
            this.groupAddFiles.Controls.Add(this.buttonAddPath);
            this.groupAddFiles.Controls.Add(this.buttonAddFile);
            this.groupAddFiles.Controls.Add(this.buttonRemove);
            this.groupAddFiles.Location = new System.Drawing.Point(8, 8);
            this.groupAddFiles.Name = "groupAddFiles";
            this.groupAddFiles.Size = new System.Drawing.Size(464, 104);
            this.groupAddFiles.TabIndex = 5;
            this.groupAddFiles.TabStop = false;
            this.groupAddFiles.Text = "Add Files";
            // 
            // buttonFilesBrowse
            // 
            this.buttonFilesBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFilesBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonFilesBrowse.Location = new System.Drawing.Point(424, 16);
            this.buttonFilesBrowse.Name = "buttonFilesBrowse";
            this.buttonFilesBrowse.Size = new System.Drawing.Size(35, 20);
            this.buttonFilesBrowse.TabIndex = 9;
            this.buttonFilesBrowse.Text = "...";
            this.buttonFilesBrowse.Click += new System.EventHandler(this.buttonFilesBrowse_Click);
            // 
            // textFilesMatching
            // 
            this.textFilesMatching.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textFilesMatching.Location = new System.Drawing.Point(64, 40);
            this.textFilesMatching.Name = "textFilesMatching";
            this.textFilesMatching.Size = new System.Drawing.Size(392, 20);
            this.textFilesMatching.TabIndex = 8;
            this.textFilesMatching.Text = ".";
            // 
            // labelFilesMatching
            // 
            this.labelFilesMatching.AutoSize = true;
            this.labelFilesMatching.Location = new System.Drawing.Point(8, 43);
            this.labelFilesMatching.Name = "labelFilesMatching";
            this.labelFilesMatching.Size = new System.Drawing.Size(54, 13);
            this.labelFilesMatching.TabIndex = 7;
            this.labelFilesMatching.Text = "Matching:";
            // 
            // textFilesPath
            // 
            this.textFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textFilesPath.Location = new System.Drawing.Point(64, 16);
            this.textFilesPath.Name = "textFilesPath";
            this.textFilesPath.Size = new System.Drawing.Size(352, 20);
            this.textFilesPath.TabIndex = 6;
            this.textFilesPath.Text = "C:\\";
            // 
            // labelFilesPath
            // 
            this.labelFilesPath.AutoSize = true;
            this.labelFilesPath.Location = new System.Drawing.Point(8, 19);
            this.labelFilesPath.Name = "labelFilesPath";
            this.labelFilesPath.Size = new System.Drawing.Size(32, 13);
            this.labelFilesPath.TabIndex = 5;
            this.labelFilesPath.Text = "Path:";
            // 
            // buttonAddPath
            // 
            this.buttonAddPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddPath.Location = new System.Drawing.Point(184, 72);
            this.buttonAddPath.Name = "buttonAddPath";
            this.buttonAddPath.Size = new System.Drawing.Size(91, 24);
            this.buttonAddPath.TabIndex = 4;
            this.buttonAddPath.Text = "Add Folder";
            this.buttonAddPath.Click += new System.EventHandler(this.buttonAddPath_Click);
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddFile.Location = new System.Drawing.Point(280, 72);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(91, 24);
            this.buttonAddFile.TabIndex = 2;
            this.buttonAddFile.Text = "Add Files...";
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRemove.Location = new System.Drawing.Point(376, 72);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(83, 24);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // groupFiles
            // 
            this.groupFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFiles.Controls.Add(this.listFiles);
            this.groupFiles.Location = new System.Drawing.Point(8, 120);
            this.groupFiles.Name = "groupFiles";
            this.groupFiles.Size = new System.Drawing.Size(464, 176);
            this.groupFiles.TabIndex = 4;
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
            this.listFiles.Size = new System.Drawing.Size(448, 150);
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
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
            // tabOptionsXML
            // 
            this.tabOptionsXML.Controls.Add(this.groupEditTags);
            this.tabOptionsXML.Controls.Add(this.groupTags);
            this.tabOptionsXML.Location = new System.Drawing.Point(4, 22);
            this.tabOptionsXML.Name = "tabOptionsXML";
            this.tabOptionsXML.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptionsXML.Size = new System.Drawing.Size(480, 310);
            this.tabOptionsXML.TabIndex = 1;
            this.tabOptionsXML.Text = "XML Tags";
            this.tabOptionsXML.UseVisualStyleBackColor = true;
            // 
            // groupEditTags
            // 
            this.groupEditTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEditTags.Controls.Add(this.textTagsEquals);
            this.groupEditTags.Controls.Add(this.labelTagsEquals);
            this.groupEditTags.Controls.Add(this.textTagsAttribute);
            this.groupEditTags.Controls.Add(this.labelTagsAttribute);
            this.groupEditTags.Controls.Add(this.textTagsTag);
            this.groupEditTags.Controls.Add(this.labelTagsTag);
            this.groupEditTags.Controls.Add(this.buttonTagAdd);
            this.groupEditTags.Controls.Add(this.buttonTagRemove);
            this.groupEditTags.Location = new System.Drawing.Point(8, 8);
            this.groupEditTags.Name = "groupEditTags";
            this.groupEditTags.Size = new System.Drawing.Size(464, 104);
            this.groupEditTags.TabIndex = 6;
            this.groupEditTags.TabStop = false;
            this.groupEditTags.Text = "Edit Tags";
            // 
            // textTagsEquals
            // 
            this.textTagsEquals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textTagsEquals.Location = new System.Drawing.Point(312, 40);
            this.textTagsEquals.Name = "textTagsEquals";
            this.textTagsEquals.Size = new System.Drawing.Size(144, 20);
            this.textTagsEquals.TabIndex = 10;
            this.textTagsEquals.Text = ".";
            // 
            // labelTagsEquals
            // 
            this.labelTagsEquals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTagsEquals.AutoSize = true;
            this.labelTagsEquals.Location = new System.Drawing.Point(256, 44);
            this.labelTagsEquals.Name = "labelTagsEquals";
            this.labelTagsEquals.Size = new System.Drawing.Size(51, 13);
            this.labelTagsEquals.TabIndex = 9;
            this.labelTagsEquals.Text = "Matches:";
            // 
            // textTagsAttribute
            // 
            this.textTagsAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textTagsAttribute.Location = new System.Drawing.Point(64, 40);
            this.textTagsAttribute.Name = "textTagsAttribute";
            this.textTagsAttribute.Size = new System.Drawing.Size(184, 20);
            this.textTagsAttribute.TabIndex = 8;
            this.textTagsAttribute.Text = "name";
            // 
            // labelTagsAttribute
            // 
            this.labelTagsAttribute.AutoSize = true;
            this.labelTagsAttribute.Location = new System.Drawing.Point(8, 43);
            this.labelTagsAttribute.Name = "labelTagsAttribute";
            this.labelTagsAttribute.Size = new System.Drawing.Size(49, 13);
            this.labelTagsAttribute.TabIndex = 7;
            this.labelTagsAttribute.Text = "Attribute:";
            // 
            // textTagsTag
            // 
            this.textTagsTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textTagsTag.Location = new System.Drawing.Point(64, 16);
            this.textTagsTag.Name = "textTagsTag";
            this.textTagsTag.Size = new System.Drawing.Size(392, 20);
            this.textTagsTag.TabIndex = 6;
            this.textTagsTag.Text = ".";
            // 
            // labelTagsTag
            // 
            this.labelTagsTag.AutoSize = true;
            this.labelTagsTag.Location = new System.Drawing.Point(8, 19);
            this.labelTagsTag.Name = "labelTagsTag";
            this.labelTagsTag.Size = new System.Drawing.Size(29, 13);
            this.labelTagsTag.TabIndex = 5;
            this.labelTagsTag.Text = "Tag:";
            // 
            // buttonTagAdd
            // 
            this.buttonTagAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTagAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonTagAdd.Location = new System.Drawing.Point(280, 72);
            this.buttonTagAdd.Name = "buttonTagAdd";
            this.buttonTagAdd.Size = new System.Drawing.Size(91, 24);
            this.buttonTagAdd.TabIndex = 2;
            this.buttonTagAdd.Text = "Add Tag";
            this.buttonTagAdd.Click += new System.EventHandler(this.buttonTagAdd_Click);
            // 
            // buttonTagRemove
            // 
            this.buttonTagRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTagRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonTagRemove.Location = new System.Drawing.Point(376, 72);
            this.buttonTagRemove.Name = "buttonTagRemove";
            this.buttonTagRemove.Size = new System.Drawing.Size(83, 24);
            this.buttonTagRemove.TabIndex = 3;
            this.buttonTagRemove.Text = "Remove";
            this.buttonTagRemove.Click += new System.EventHandler(this.buttonTagRemove_Click);
            // 
            // groupTags
            // 
            this.groupTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTags.Controls.Add(this.listTags);
            this.groupTags.Location = new System.Drawing.Point(8, 120);
            this.groupTags.Name = "groupTags";
            this.groupTags.Size = new System.Drawing.Size(464, 176);
            this.groupTags.TabIndex = 5;
            this.groupTags.TabStop = false;
            this.groupTags.Text = "Tags";
            // 
            // listTags
            // 
            this.listTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTagsTag,
            this.columnTagsAttribute,
            this.columnTagsEquals});
            this.listTags.FullRowSelect = true;
            this.listTags.HideSelection = false;
            this.listTags.Location = new System.Drawing.Point(8, 18);
            this.listTags.Name = "listTags";
            this.listTags.Size = new System.Drawing.Size(448, 150);
            this.listTags.TabIndex = 0;
            this.listTags.UseCompatibleStateImageBehavior = false;
            this.listTags.View = System.Windows.Forms.View.Details;
            // 
            // columnTagsTag
            // 
            this.columnTagsTag.Text = "Tag";
            this.columnTagsTag.Width = 150;
            // 
            // columnTagsAttribute
            // 
            this.columnTagsAttribute.Text = "Attribute";
            this.columnTagsAttribute.Width = 130;
            // 
            // columnTagsEquals
            // 
            this.columnTagsEquals.Text = "Equals";
            this.columnTagsEquals.Width = 130;
            // 
            // tabOptionsOptions
            // 
            this.tabOptionsOptions.Controls.Add(this.groupSaveAs);
            this.tabOptionsOptions.Controls.Add(this.panelFormats);
            this.tabOptionsOptions.Controls.Add(this.groupOptions);
            this.tabOptionsOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptionsOptions.Name = "tabOptionsOptions";
            this.tabOptionsOptions.Size = new System.Drawing.Size(480, 310);
            this.tabOptionsOptions.TabIndex = 2;
            this.tabOptionsOptions.Text = "Other Options";
            this.tabOptionsOptions.UseVisualStyleBackColor = true;
            // 
            // groupSaveAs
            // 
            this.groupSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSaveAs.Controls.Add(this.checkReplaceExtension);
            this.groupSaveAs.Controls.Add(this.labelSuffix);
            this.groupSaveAs.Controls.Add(this.textSaveAsSuffix);
            this.groupSaveAs.Location = new System.Drawing.Point(8, 56);
            this.groupSaveAs.Name = "groupSaveAs";
            this.groupSaveAs.Size = new System.Drawing.Size(464, 40);
            this.groupSaveAs.TabIndex = 18;
            this.groupSaveAs.TabStop = false;
            this.groupSaveAs.Text = "Save As";
            // 
            // checkReplaceExtension
            // 
            this.checkReplaceExtension.AutoSize = true;
            this.checkReplaceExtension.Checked = true;
            this.checkReplaceExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkReplaceExtension.Location = new System.Drawing.Point(280, 16);
            this.checkReplaceExtension.Name = "checkReplaceExtension";
            this.checkReplaceExtension.Size = new System.Drawing.Size(130, 17);
            this.checkReplaceExtension.TabIndex = 16;
            this.checkReplaceExtension.Text = "Replace file extension";
            this.checkReplaceExtension.UseVisualStyleBackColor = true;
            // 
            // labelSuffix
            // 
            this.labelSuffix.AutoSize = true;
            this.labelSuffix.Location = new System.Drawing.Point(8, 16);
            this.labelSuffix.Name = "labelSuffix";
            this.labelSuffix.Size = new System.Drawing.Size(61, 13);
            this.labelSuffix.TabIndex = 2;
            this.labelSuffix.Text = "New Suffix:";
            // 
            // textSaveAsSuffix
            // 
            this.textSaveAsSuffix.Location = new System.Drawing.Point(80, 13);
            this.textSaveAsSuffix.Name = "textSaveAsSuffix";
            this.textSaveAsSuffix.Size = new System.Drawing.Size(192, 20);
            this.textSaveAsSuffix.TabIndex = 0;
            this.textSaveAsSuffix.Text = ".new.xml";
            // 
            // panelFormats
            // 
            this.panelFormats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFormats.Controls.Add(this.splitFormat);
            this.panelFormats.Location = new System.Drawing.Point(0, 104);
            this.panelFormats.Name = "panelFormats";
            this.panelFormats.Size = new System.Drawing.Size(480, 200);
            this.panelFormats.TabIndex = 17;
            // 
            // splitFormat
            // 
            this.splitFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitFormat.Location = new System.Drawing.Point(0, 0);
            this.splitFormat.Name = "splitFormat";
            // 
            // splitFormat.Panel1
            // 
            this.splitFormat.Panel1.Controls.Add(this.groupInputFormat);
            this.splitFormat.Panel1MinSize = 100;
            // 
            // splitFormat.Panel2
            // 
            this.splitFormat.Panel2.Controls.Add(this.groupOutputFormat);
            this.splitFormat.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitFormat.Panel2MinSize = 100;
            this.splitFormat.Size = new System.Drawing.Size(480, 200);
            this.splitFormat.SplitterDistance = 233;
            this.splitFormat.TabIndex = 0;
            // 
            // groupOptions
            // 
            this.groupOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupOptions.Controls.Add(this.checkReplaceExistingFiles);
            this.groupOptions.Controls.Add(this.radioButton1);
            this.groupOptions.Controls.Add(this.radioFormatXML);
            this.groupOptions.Controls.Add(this.labelInputFormat);
            this.groupOptions.Controls.Add(this.radioFormatText);
            this.groupOptions.Location = new System.Drawing.Point(8, 8);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(464, 40);
            this.groupOptions.TabIndex = 1;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // checkReplaceExistingFiles
            // 
            this.checkReplaceExistingFiles.AutoSize = true;
            this.checkReplaceExistingFiles.Location = new System.Drawing.Point(280, 16);
            this.checkReplaceExistingFiles.Name = "checkReplaceExistingFiles";
            this.checkReplaceExistingFiles.Size = new System.Drawing.Size(125, 17);
            this.checkReplaceExistingFiles.TabIndex = 15;
            this.checkReplaceExistingFiles.Text = "Replace existing files";
            this.checkReplaceExistingFiles.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(216, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.Text = "XHTML";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioFormatXML
            // 
            this.radioFormatXML.AutoSize = true;
            this.radioFormatXML.Checked = true;
            this.radioFormatXML.Location = new System.Drawing.Point(160, 16);
            this.radioFormatXML.Name = "radioFormatXML";
            this.radioFormatXML.Size = new System.Drawing.Size(47, 17);
            this.radioFormatXML.TabIndex = 13;
            this.radioFormatXML.TabStop = true;
            this.radioFormatXML.Text = "XML";
            this.radioFormatXML.UseVisualStyleBackColor = true;
            // 
            // labelInputFormat
            // 
            this.labelInputFormat.AutoSize = true;
            this.labelInputFormat.Location = new System.Drawing.Point(6, 18);
            this.labelInputFormat.Name = "labelInputFormat";
            this.labelInputFormat.Size = new System.Drawing.Size(69, 13);
            this.labelInputFormat.TabIndex = 1;
            this.labelInputFormat.Text = "Input Format:";
            // 
            // radioFormatText
            // 
            this.radioFormatText.AutoSize = true;
            this.radioFormatText.Location = new System.Drawing.Point(83, 16);
            this.radioFormatText.Name = "radioFormatText";
            this.radioFormatText.Size = new System.Drawing.Size(72, 17);
            this.radioFormatText.TabIndex = 0;
            this.radioFormatText.Text = "Plain Text";
            this.radioFormatText.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(416, 405);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 24);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "C&ancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressCurrent
            // 
            this.progressCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressCurrent.Location = new System.Drawing.Point(8, 376);
            this.progressCurrent.Name = "progressCurrent";
            this.progressCurrent.Size = new System.Drawing.Size(486, 19);
            this.progressCurrent.TabIndex = 6;
            // 
            // groupInputFormat
            // 
            this.groupInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInputFormat.Controls.Add(this.splitInputFormat);
            this.groupInputFormat.Location = new System.Drawing.Point(8, 0);
            this.groupInputFormat.Name = "groupInputFormat";
            this.groupInputFormat.Size = new System.Drawing.Size(224, 200);
            this.groupInputFormat.TabIndex = 24;
            this.groupInputFormat.TabStop = false;
            this.groupInputFormat.Text = "Input Format";
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
            this.splitInputFormat.Size = new System.Drawing.Size(218, 181);
            this.splitInputFormat.SplitterDistance = 115;
            this.splitInputFormat.TabIndex = 0;
            // 
            // listInputFormat
            // 
            this.listInputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listInputFormat.IntegralHeight = false;
            this.listInputFormat.Location = new System.Drawing.Point(4, 0);
            this.listInputFormat.Name = "listInputFormat";
            this.listInputFormat.Size = new System.Drawing.Size(110, 176);
            this.listInputFormat.TabIndex = 2;
            this.listInputFormat.SelectedIndexChanged += new System.EventHandler(this.listInputFormat_SelectedIndexChanged);
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
            this.listInputOptions.Size = new System.Drawing.Size(95, 176);
            this.listInputOptions.TabIndex = 3;
            // 
            // groupOutputFormat
            // 
            this.groupOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupOutputFormat.Controls.Add(this.splitOutputFormat);
            this.groupOutputFormat.Location = new System.Drawing.Point(0, 0);
            this.groupOutputFormat.Name = "groupOutputFormat";
            this.groupOutputFormat.Size = new System.Drawing.Size(234, 200);
            this.groupOutputFormat.TabIndex = 25;
            this.groupOutputFormat.TabStop = false;
            this.groupOutputFormat.Text = "Output Format";
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
            this.splitOutputFormat.Size = new System.Drawing.Size(228, 181);
            this.splitOutputFormat.SplitterDistance = 120;
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
            this.listOutputFormat.Size = new System.Drawing.Size(115, 176);
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
            this.listOutputOptions.Size = new System.Drawing.Size(100, 176);
            this.listOutputOptions.TabIndex = 3;
            // 
            // BatchProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 438);
            this.Controls.Add(this.progressCurrent);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabOptions);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.progressMain);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "BatchProcessor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Processor";
            this.Load += new System.EventHandler(this.BatchProcessor_Load);
            this.tabOptions.ResumeLayout(false);
            this.tabOptionsFiles.ResumeLayout(false);
            this.groupAddFiles.ResumeLayout(false);
            this.groupAddFiles.PerformLayout();
            this.groupFiles.ResumeLayout(false);
            this.tabOptionsXML.ResumeLayout(false);
            this.groupEditTags.ResumeLayout(false);
            this.groupEditTags.PerformLayout();
            this.groupTags.ResumeLayout(false);
            this.tabOptionsOptions.ResumeLayout(false);
            this.groupSaveAs.ResumeLayout(false);
            this.groupSaveAs.PerformLayout();
            this.panelFormats.ResumeLayout(false);
            this.splitFormat.Panel1.ResumeLayout(false);
            this.splitFormat.Panel2.ResumeLayout(false);
            this.splitFormat.ResumeLayout(false);
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.groupInputFormat.ResumeLayout(false);
            this.splitInputFormat.Panel1.ResumeLayout(false);
            this.splitInputFormat.Panel2.ResumeLayout(false);
            this.splitInputFormat.ResumeLayout(false);
            this.groupOutputFormat.ResumeLayout(false);
            this.splitOutputFormat.Panel1.ResumeLayout(false);
            this.splitOutputFormat.Panel2.ResumeLayout(false);
            this.splitOutputFormat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressMain;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabOptionsFiles;
        private System.Windows.Forms.TabPage tabOptionsXML;
        private System.Windows.Forms.TabPage tabOptionsOptions;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.RadioButton radioFormatXML;
        private System.Windows.Forms.Label labelInputFormat;
        private System.Windows.Forms.RadioButton radioFormatText;
        private System.Windows.Forms.GroupBox groupFiles;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.ColumnHeader columnFilesFilename;
        private System.Windows.Forms.ColumnHeader columnFilesPath;
        private System.Windows.Forms.ColumnHeader columnFilesSize;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupTags;
        private System.Windows.Forms.ListView listTags;
        private System.Windows.Forms.ColumnHeader columnTagsTag;
        private System.Windows.Forms.ColumnHeader columnTagsAttribute;
        private System.Windows.Forms.ColumnHeader columnTagsEquals;
        private System.Windows.Forms.GroupBox groupAddFiles;
        private System.Windows.Forms.Button buttonAddPath;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TextBox textFilesMatching;
        private System.Windows.Forms.Label labelFilesMatching;
        private System.Windows.Forms.TextBox textFilesPath;
        private System.Windows.Forms.Label labelFilesPath;
        private System.Windows.Forms.Button buttonFilesBrowse;
        private System.Windows.Forms.GroupBox groupEditTags;
        private System.Windows.Forms.TextBox textTagsAttribute;
        private System.Windows.Forms.Label labelTagsAttribute;
        private System.Windows.Forms.TextBox textTagsTag;
        private System.Windows.Forms.Label labelTagsTag;
        private System.Windows.Forms.Button buttonTagAdd;
        private System.Windows.Forms.Button buttonTagRemove;
        private System.Windows.Forms.TextBox textTagsEquals;
        private System.Windows.Forms.Label labelTagsEquals;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panelFormats;
        private System.Windows.Forms.SplitContainer splitFormat;
        private System.Windows.Forms.ProgressBar progressCurrent;
        private System.Windows.Forms.GroupBox groupSaveAs;
        private System.Windows.Forms.Label labelSuffix;
        private System.Windows.Forms.TextBox textSaveAsSuffix;
        private System.Windows.Forms.CheckBox checkReplaceExistingFiles;
        private System.Windows.Forms.CheckBox checkReplaceExtension;
        private System.Windows.Forms.GroupBox groupInputFormat;
        private System.Windows.Forms.SplitContainer splitInputFormat;
        public System.Windows.Forms.ListBox listInputFormat;
        private System.Windows.Forms.CheckedListBox listInputOptions;
        private System.Windows.Forms.GroupBox groupOutputFormat;
        private System.Windows.Forms.SplitContainer splitOutputFormat;
        public System.Windows.Forms.ListBox listOutputFormat;
        private System.Windows.Forms.CheckedListBox listOutputOptions;
    }
}