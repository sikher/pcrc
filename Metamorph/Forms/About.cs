using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Metamorph.Forms
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.LinkLabel linkGNUGPL;
		private System.Windows.Forms.Label labelSystemDetails;
		private System.Windows.Forms.LinkLabel linkEmail;
		private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.GroupBox groupGNUGPL;
		private System.Windows.Forms.TextBox textLicence;
		private System.Windows.Forms.LinkLabel linkPCRC;
		private System.Windows.Forms.GroupBox groupMetamorph;
        private TextBox textActualDetails;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupMetamorph = new System.Windows.Forms.GroupBox();
            this.linkGNUGPL = new System.Windows.Forms.LinkLabel();
            this.labelSystemDetails = new System.Windows.Forms.Label();
            this.linkEmail = new System.Windows.Forms.LinkLabel();
            this.linkPCRC = new System.Windows.Forms.LinkLabel();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.groupGNUGPL = new System.Windows.Forms.GroupBox();
            this.textLicence = new System.Windows.Forms.TextBox();
            this.textActualDetails = new System.Windows.Forms.TextBox();
            this.groupMetamorph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.groupGNUGPL.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(272, 336);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(80, 24);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "&OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupMetamorph
            // 
            this.groupMetamorph.Controls.Add(this.textActualDetails);
            this.groupMetamorph.Controls.Add(this.linkGNUGPL);
            this.groupMetamorph.Controls.Add(this.labelSystemDetails);
            this.groupMetamorph.Controls.Add(this.linkEmail);
            this.groupMetamorph.Controls.Add(this.linkPCRC);
            this.groupMetamorph.Controls.Add(this.labelCopyright);
            this.groupMetamorph.Location = new System.Drawing.Point(8, 168);
            this.groupMetamorph.Name = "groupMetamorph";
            this.groupMetamorph.Size = new System.Drawing.Size(344, 160);
            this.groupMetamorph.TabIndex = 4;
            this.groupMetamorph.TabStop = false;
            this.groupMetamorph.Text = "Version";
            // 
            // linkGNUGPL
            // 
            this.linkGNUGPL.Location = new System.Drawing.Point(24, 88);
            this.linkGNUGPL.Name = "linkGNUGPL";
            this.linkGNUGPL.Size = new System.Drawing.Size(264, 16);
            this.linkGNUGPL.TabIndex = 7;
            this.linkGNUGPL.TabStop = true;
            this.linkGNUGPL.Text = "View the GNU General Public Licence.";
            this.linkGNUGPL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGNUGPL_LinkClicked);
            // 
            // labelSystemDetails
            // 
            this.labelSystemDetails.Location = new System.Drawing.Point(8, 112);
            this.labelSystemDetails.Name = "labelSystemDetails";
            this.labelSystemDetails.Size = new System.Drawing.Size(120, 40);
            this.labelSystemDetails.TabIndex = 5;
            // 
            // linkEmail
            // 
            this.linkEmail.Location = new System.Drawing.Point(24, 40);
            this.linkEmail.Name = "linkEmail";
            this.linkEmail.Size = new System.Drawing.Size(264, 16);
            this.linkEmail.TabIndex = 1;
            this.linkEmail.TabStop = true;
            this.linkEmail.Text = "E-mail Sukhjinder Sidhu (in English).";
            this.linkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEmail_LinkClicked);
            // 
            // linkPCRC
            // 
            this.linkPCRC.Location = new System.Drawing.Point(24, 64);
            this.linkPCRC.Name = "linkPCRC";
            this.linkPCRC.Size = new System.Drawing.Size(264, 16);
            this.linkPCRC.TabIndex = 2;
            this.linkPCRC.TabStop = true;
            this.linkPCRC.Text = "Visit the Punjabi Computing Resource Centre.";
            this.linkPCRC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPCRC_LinkClicked);
            // 
            // labelCopyright
            // 
            this.labelCopyright.Location = new System.Drawing.Point(8, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(328, 16);
            this.labelCopyright.TabIndex = 0;
            this.labelCopyright.Text = "Copyright © 2004-2006 Sukhjinder Sidhu.  All rights reserved.";
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(24, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(312, 152);
            this.picLogo.TabIndex = 5;
            this.picLogo.TabStop = false;
            // 
            // groupGNUGPL
            // 
            this.groupGNUGPL.Controls.Add(this.textLicence);
            this.groupGNUGPL.Location = new System.Drawing.Point(8, 168);
            this.groupGNUGPL.Name = "groupGNUGPL";
            this.groupGNUGPL.Size = new System.Drawing.Size(344, 160);
            this.groupGNUGPL.TabIndex = 7;
            this.groupGNUGPL.TabStop = false;
            this.groupGNUGPL.Text = "GNU General Public Licence";
            this.groupGNUGPL.Visible = false;
            // 
            // textLicence
            // 
            this.textLicence.BackColor = System.Drawing.Color.White;
            this.textLicence.Location = new System.Drawing.Point(8, 16);
            this.textLicence.Multiline = true;
            this.textLicence.Name = "textLicence";
            this.textLicence.ReadOnly = true;
            this.textLicence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLicence.Size = new System.Drawing.Size(328, 136);
            this.textLicence.TabIndex = 0;
            // 
            // textActualDetails
            // 
            this.textActualDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textActualDetails.Location = new System.Drawing.Point(125, 112);
            this.textActualDetails.Multiline = true;
            this.textActualDetails.Name = "textActualDetails";
            this.textActualDetails.Size = new System.Drawing.Size(213, 40);
            this.textActualDetails.TabIndex = 8;
            this.textActualDetails.WordWrap = false;
            // 
            // About
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(362, 368);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupMetamorph);
            this.Controls.Add(this.groupGNUGPL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.groupMetamorph.ResumeLayout(false);
            this.groupMetamorph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.groupGNUGPL.ResumeLayout(false);
            this.groupGNUGPL.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void About_Load(object sender, System.EventArgs e)
		{
			groupMetamorph.Text = "Program Version: " + Application.ProductVersion;
			labelSystemDetails.Text =	"Operating System: " +  "\r\n" + "Machine: " + "\r\n" +	"User: ";
            textActualDetails.Text = Environment.OSVersion + "\r\n" + Environment.MachineName + "\r\n" + Environment.UserName;
			
			textLicence.Text = "";
			try
			{
				TextReader textRead = File.OpenText(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf(Path.DirectorySeparatorChar) + 1) + "licence.txt");

				textLicence.Text = "";

				textLicence.Text = textRead.ReadToEnd();
			}
			catch (Exception exp)
			{
				textLicence.Text = "Unable to load licence.  Please ensure that the appropriate licence.txt file is in the same directory as the current program.";
			}
		}

		private void linkGNUGPL_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			groupGNUGPL.BringToFront();
			groupGNUGPL.Visible = true;
			buttonOK.Text = "&Back";
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			if (buttonOK.Text == "&Back")
			{
				groupGNUGPL.Visible = false;
				buttonOK.Text = "&OK";
			}
			else
				this.Close();
		}

		private void linkPCRC_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start("http://guca.sourceforge.net/");
			}
			catch (Exception ex){}
		}

		private void linkEmail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("mailto:sukhuk@users.sourceforge.net");
		}
	}
}
