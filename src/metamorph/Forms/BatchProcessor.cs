using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Metamorph.Classes;
using System.Xml;
using System.Xml.XPath;
using System.Collections;

namespace Metamorph.Forms
{
    public partial class BatchProcessor : Form
    {
        private bool bCancel = false;

        public BatchProcessor()
        {
            InitializeComponent();
        }

        private struct TagRegex
        {
            public Regex Tag;
            public string Attribute;
            public Regex AttributeValueEquals;
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
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
                    FileInfo file = new FileInfo(dialogOpen.FileNames[iCounter]);
                    item.Text = file.Name;
                    item.SubItems.Add(file.DirectoryName);
                    item.SubItems.Add(file.Length.ToString("N0"));
                    listFiles.Items.Add(item);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFiles.Items)
            {
                if (item.Selected == true)
                    item.Remove();
            }
        }

        private void buttonAddPath_Click(object sender, EventArgs e)
        {
            //TODO Catch Exceptions
            Regex regFileMatcher = new Regex(textFilesMatching.Text);

            DirectoryInfo di = new DirectoryInfo(textFilesPath.Text);
            FileInfo[] fiFiles = new FileInfo[0];

            try
            {
                fiFiles = di.GetFiles();
            }
            catch (Exception)
            {}
            foreach (FileInfo file in fiFiles)
            {
                if (regFileMatcher.IsMatch(file.Name))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = file.Name;
                    item.SubItems.Add(file.DirectoryName);
                    item.SubItems.Add(file.Length.ToString("N0"));
                    listFiles.Items.Add(item);
                }
            }
        }

        private void buttonTagRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listTags.Items)
            {
                if (item.Selected == true)
                    item.Remove();
            }
        }

        private void buttonTagAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = textTagsTag.Text;
            item.SubItems.Add(textTagsAttribute.Text);
            item.SubItems.Add(textTagsEquals.Text);
            listTags.Items.Add(item);
        }

        private void BatchProcessor_Load(object sender, EventArgs e)
        {
            Settings.LoadInputList(listInputFormat, listOutputFormat);
        }

        private void listInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.LoadOutputList(listInputFormat, listInputOptions, listOutputFormat, listOutputOptions);
        }

        private void DisableForm()
        {
            tabOptions.Enabled = false;
            buttonConvert.Enabled = false;
        }

        private void EnableForm()
        {
            tabOptions.Enabled = true;
            buttonConvert.Enabled = true;
        }

        private bool InitialiseConverter()
        {
            if (listOutputFormat.SelectedItems.Count == 0 || listInputFormat.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select both an input and output format.", "Metamorph", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableForm();
                return false;
            }

            ConversionEngine.ErrorCorrection = Settings.ErrorCorrection;
            ConversionEngine.BindiTippiCorrection = Settings.BindiTippiCorrection;
            ConversionEngine.ProgressBar = progressCurrent;

            return true;
        }

        private string ConvertText(string text)
        {
            MappingDetails from = (MappingDetails)listInputFormat.SelectedItem;
            MappingDetails to = (MappingDetails)listOutputFormat.SelectedItem;
            string sConversion = text;

            if (from != null)
            {
                sConversion = ConversionEngine.Convert(sConversion, from);
            }

            if (to != null)
            {
                 sConversion = ConversionEngine.Convert(sConversion, to);
            }


            return sConversion;
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            // TO DO Show Files Tab
            tabOptionsFiles.Focus();
            DisableForm();

            if (InitialiseConverter())
            {
                if (radioFormatText.Checked)
                {
                    // TODO Plain Text
                    // Plain text
                }
                else if (radioFormatXML.Checked)
                {
                    ArrayList tagList = new ArrayList(listTags.Items.Count);

                    foreach (ListViewItem item in listTags.Items)
                    {
                        TagRegex tag;
                        // TO DO Catch Errors
                        tag.Tag = new Regex(item.Text);
                        tag.Attribute = item.SubItems[1].Text;
                        tag.AttributeValueEquals = new Regex(item.SubItems[2].Text);

                        tagList.Add(tag);
                    }

                    progressMain.Value = 0;
                    progressMain.Maximum = listFiles.Items.Count;

                    foreach (ListViewItem item in listFiles.Items)
                    {
                        if (bCancel)
                        {
                            bCancel = false;
                            break;
                        }

                        progressMain.Increment(1);

                        string sFile = "";

                        if (item.SubItems[1].Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
                            sFile = item.SubItems[1].Text + item.Text;
                        else
                            sFile = item.SubItems[1].Text + Path.DirectorySeparatorChar + item.Text;

                        // Read a document
                        XmlDocument xmlDocument;
                        try
                        {
                            xmlDocument = new XmlDocument();
                            xmlDocument.Load(sFile);
                        }
                        catch (Exception ex)
                        {
                            // Error occured parsing XML - Track
                            System.Diagnostics.Debug.Print("Failed: " + sFile + "\n");
                            continue;
                        }

                        Application.DoEvents();

                        //String sDebugXml = "<root><test>brown <b>be</b> test <i>lot</i> people</test></root>";
                        //xmlDocument.LoadXml(sDebugXml);


                        // Grab root node
                        XmlNodeList elements = xmlDocument.GetElementsByTagName("*");
                        for (int i = 0; i < elements.Count; i++)
                        //foreach (XmlNode node in elements)
                        {
                            XmlNode node = elements[i];
                            foreach (TagRegex tagDetails in tagList)
                            {
                                // Start XHTML Hack - This shouldn't apply to bog standard XML files

                                // Anything in <a>, <b>, <i>, <big>, <center>, <strong>, <em> inherits parents attributes

                                // See http://www.web-source.net/html_codes_chart.htm for further expansions

                                // End XHTML Hack (apart from if below)

                                if (tagDetails.Tag.IsMatch(node.Name))
                                {
                                    XmlNode attr = node.Attributes.GetNamedItem(tagDetails.Attribute);

                                    if ((attr == null && tagDetails.AttributeValueEquals.ToString() == "." || tagDetails.AttributeValueEquals.ToString() == "") ||
                                        (attr != null && tagDetails.AttributeValueEquals.IsMatch(attr.Value)))
                                    {

                                        // Get next node
                                        string sInnerXml = node.InnerXml;
                                        string sInnerText = node.InnerText;

                                        // Convert up to the next node
                                        if (sInnerXml.Contains("<"))
                                        {

                                            // Split based on <
                                            string[] split = sInnerXml.Split(new char[] { '<' });

                                            string sOutput = "";
                                            string sFindEndTag = "";

                                            for (int j = 0; j < split.Length; j++)
                                            {
                                                // Reinsert the <'s on all but the first item
                                                if (j > 0)
                                                {
                                                    // To get element name search for />, 
                                                    // space or >

                                                    if (sFindEndTag != "")
                                                    {
                                                        if (sFindEndTag == "]]>" && split[j].Contains(sFindEndTag))
                                                        {
                                                            sFindEndTag = "";
                                                            sOutput += split[j].Substring(0, split[j].IndexOf("]]>") + 3) + ConvertText(split[j].Substring(split[j].IndexOf("]]>") + 3));
                                                        }
                                                        else if (split[j].StartsWith(sFindEndTag))
                                                        {
                                                            sFindEndTag = "";
                                                            sOutput += "<" + split[j].Substring(0, split[j].IndexOf(">") + 1) + ConvertText(split[j].Substring(split[j].IndexOf(">") + 1));
                                                        }
                                                        else
                                                        {
                                                            sOutput += "<" + split[j];
                                                        }
                                                    }
                                                    else if (split[j].Contains("/>"))
                                                    {
                                                        sOutput += "<" + split[j].Substring(0, split[j].IndexOf("/>") + 2) + ConvertText(split[j].Substring(split[j].IndexOf("/>") + 2));
                                                    }
                                                    else
                                                    {
                                                        int splitValue = 0;
                                                        int endBracket = split[j].IndexOf(">");

                                                        if (split[j].IndexOf(" ") > endBracket)
                                                            splitValue = endBracket;
                                                        else
                                                            splitValue = split[j].IndexOf(" ");

                                                        if (splitValue > -1)
                                                            sFindEndTag = "/" + split[j].Substring(0, splitValue);
                                                        else if (split[j].StartsWith("![CDATA["))
                                                            sFindEndTag = "]]>";

                                                        sOutput += "<" + split[j];
                                                    }
                                                }
                                                else if (split[j] != "")
                                                {
                                                    sOutput += ConvertText(split[j]);
                                                }
                                            }
                                            node.InnerXml = sOutput;
                                        }
                                        else
                                        {
                                            node.InnerXml = ConvertText(sInnerXml);
                                        }
                                    }
                                }
                            }
                        }
                        //Ask user if they want to replace file
                        string sNewFile = sFile;

                        // A file extension exists if there is . as the second character or more
                        if (checkReplaceExtension.Checked && sNewFile.LastIndexOf('.') > 1)
                        {
                            sNewFile = sNewFile.Substring(0, sNewFile.LastIndexOf('.')) + textSaveAsSuffix.Text;
                        }
                        else
                        {
                            sNewFile += textSaveAsSuffix.Text;
                        }

                        // Prompt for file replacement
                        if (File.Exists(sNewFile))
                        {
                            if (checkReplaceExistingFiles.Checked)
                            {
                                xmlDocument.Save(sNewFile);
                            }
                            else
                            {
                                DialogResult result = MessageBox.Show("Do you wish to replace the file '" + sNewFile + "'?", "Replace file?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                    xmlDocument.Save(sNewFile);
                                else if (result == DialogResult.Cancel)
                                    break;
                            }
                        }
                        else
                        {
                            xmlDocument.Save(sNewFile);
                        }                    
                    }
                }
            }
            progressMain.Value = 0;
            EnableForm();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {           
            if (buttonConvert.Enabled)
            {
                this.Close();
            }
            else
            {
                bCancel = true;
            }
        }

        private void buttonFilesBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.ShowNewFolderButton = true;

            fbd.ShowDialog();

            if (fbd.SelectedPath.Length > 0)
                textFilesPath.Text = fbd.SelectedPath;
        }

        private void listOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.LoadOptionsList(listOutputFormat, listOutputOptions);
        }
    }
}