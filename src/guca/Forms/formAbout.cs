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
	/// Summary description for formAbout.
	/// </summary>
	public class formAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureLogo;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.GroupBox groupGUCA;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.LinkLabel linkGUCA;
		private System.Windows.Forms.LinkLabel linkEmail;
		private System.Windows.Forms.GroupBox groupGNUGPL;
		private System.Windows.Forms.TextBox textLicence;
		private System.Windows.Forms.Label labelSystemDetails;
		private System.Windows.Forms.Label labelActualDetails;
		private System.Windows.Forms.LinkLabel linkGNUGPL;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public formAbout()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(formAbout));
			this.pictureLogo = new System.Windows.Forms.PictureBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.groupGUCA = new System.Windows.Forms.GroupBox();
			this.linkGNUGPL = new System.Windows.Forms.LinkLabel();
			this.labelActualDetails = new System.Windows.Forms.Label();
			this.labelSystemDetails = new System.Windows.Forms.Label();
			this.linkEmail = new System.Windows.Forms.LinkLabel();
			this.linkGUCA = new System.Windows.Forms.LinkLabel();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.groupGNUGPL = new System.Windows.Forms.GroupBox();
			this.textLicence = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupGUCA.SuspendLayout();
			this.groupGNUGPL.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureLogo
			// 
			this.pictureLogo.BackColor = System.Drawing.Color.Black;
			this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
			this.pictureLogo.Location = new System.Drawing.Point(4, 8);
			this.pictureLogo.Name = "pictureLogo";
			this.pictureLogo.Size = new System.Drawing.Size(328, 96);
			this.pictureLogo.TabIndex = 0;
			this.pictureLogo.TabStop = false;
			// 
			// buttonOK
			// 
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(240, 296);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 24);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "&OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// groupGUCA
			// 
			this.groupGUCA.Controls.Add(this.linkGNUGPL);
			this.groupGUCA.Controls.Add(this.labelActualDetails);
			this.groupGUCA.Controls.Add(this.labelSystemDetails);
			this.groupGUCA.Controls.Add(this.linkEmail);
			this.groupGUCA.Controls.Add(this.linkGUCA);
			this.groupGUCA.Controls.Add(this.labelCopyright);
			this.groupGUCA.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupGUCA.Location = new System.Drawing.Point(8, 112);
			this.groupGUCA.Name = "groupGUCA";
			this.groupGUCA.Size = new System.Drawing.Size(312, 176);
			this.groupGUCA.TabIndex = 2;
			this.groupGUCA.TabStop = false;
			this.groupGUCA.Text = "Version";
			// 
			// linkGNUGPL
			// 
			this.linkGNUGPL.Location = new System.Drawing.Point(24, 72);
			this.linkGNUGPL.Name = "linkGNUGPL";
			this.linkGNUGPL.Size = new System.Drawing.Size(264, 16);
			this.linkGNUGPL.TabIndex = 7;
			this.linkGNUGPL.TabStop = true;
			this.linkGNUGPL.Text = "View the GNU General Public Licence.";
			this.linkGNUGPL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGNUGPL_LinkClicked);
			// 
			// labelActualDetails
			// 
			this.labelActualDetails.Location = new System.Drawing.Point(112, 96);
			this.labelActualDetails.Name = "labelActualDetails";
			this.labelActualDetails.Size = new System.Drawing.Size(192, 72);
			this.labelActualDetails.TabIndex = 6;
			// 
			// labelSystemDetails
			// 
			this.labelSystemDetails.Location = new System.Drawing.Point(8, 96);
			this.labelSystemDetails.Name = "labelSystemDetails";
			this.labelSystemDetails.Size = new System.Drawing.Size(104, 72);
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
			// linkGUCA
			// 
			this.linkGUCA.Location = new System.Drawing.Point(24, 56);
			this.linkGUCA.Name = "linkGUCA";
			this.linkGUCA.Size = new System.Drawing.Size(264, 16);
			this.linkGUCA.TabIndex = 2;
			this.linkGUCA.TabStop = true;
			this.linkGUCA.Text = "Visit the Punjabi Computing Resource Centre.";
			this.linkGUCA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGUCA_LinkClicked);
			// 
			// labelCopyright
			// 
			this.labelCopyright.Location = new System.Drawing.Point(8, 17);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(296, 16);
			this.labelCopyright.TabIndex = 0;
			this.labelCopyright.Text = "Copyright © 2004 Sukhjinder Sidhu.  All rights reserved.";
			// 
			// groupGNUGPL
			// 
			this.groupGNUGPL.Controls.Add(this.textLicence);
			this.groupGNUGPL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupGNUGPL.Location = new System.Drawing.Point(8, 112);
			this.groupGNUGPL.Name = "groupGNUGPL";
			this.groupGNUGPL.Size = new System.Drawing.Size(312, 176);
			this.groupGNUGPL.TabIndex = 6;
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
			this.textLicence.Size = new System.Drawing.Size(296, 152);
			this.textLicence.TabIndex = 0;
			this.textLicence.Text = "";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Location = new System.Drawing.Point(0, -8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(352, 112);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// formAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(330, 328);
			this.Controls.Add(this.groupGUCA);
			this.Controls.Add(this.groupGNUGPL);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.pictureLogo);
			this.Controls.Add(this.pictureBox1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "formAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About GUCA";
			this.Load += new System.EventHandler(this.formAbout_Load);
			this.groupGUCA.ResumeLayout(false);
			this.groupGNUGPL.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

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


		private void linkGUCA_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start("http://guca.sourceforge.net/");
			}
			catch (Exception ex)
			{

			}

		}

		private void linkEmail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("mailto:sukhuk@users.sourceforge.net");
		}

		private void formAbout_Load(object sender, System.EventArgs e)
		{
			groupGUCA.Text = "Program Version: " + Application.ProductVersion;
			labelSystemDetails.Text =	"Conversion Engine: " + "\r\n\r\n" + "Operating System: " +  "\r\n" + "Machine: " + "\r\n" +	"User: ";
			labelActualDetails.Text =	ConversionEngine.Version + "\r\n\r\n" + Environment.OSVersion +  "\r\n" + Environment.MachineName + "\r\n" +	Environment.UserName;
			
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
	}
}
