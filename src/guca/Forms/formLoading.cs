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

namespace Unicode.Gurmukhi.Forms
{
	/// <summary>
	/// Summary description for formLoading.
	/// </summary>
	public class formLoading : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureLogo;
		private System.Windows.Forms.Label labelLoading;
		bool bFirstLoad = false;
		private Skybound.VisualStyles.VisualStyleProvider visualStyleProvider;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public formLoading()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(formLoading));
			this.pictureLogo = new System.Windows.Forms.PictureBox();
			this.labelLoading = new System.Windows.Forms.Label();
			this.visualStyleProvider = new Skybound.VisualStyles.VisualStyleProvider();
			this.SuspendLayout();
			// 
			// pictureLogo
			// 
			this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
			this.pictureLogo.Location = new System.Drawing.Point(0, 0);
			this.pictureLogo.Name = "pictureLogo";
			this.pictureLogo.Size = new System.Drawing.Size(328, 104);
			this.pictureLogo.TabIndex = 1;
			this.pictureLogo.TabStop = false;
			this.visualStyleProvider.SetVisualStyleSupport(this.pictureLogo, true);
			// 
			// labelLoading
			// 
			this.labelLoading.Location = new System.Drawing.Point(8, 104);
			this.labelLoading.Name = "labelLoading";
			this.labelLoading.Size = new System.Drawing.Size(288, 16);
			this.labelLoading.TabIndex = 2;
			this.labelLoading.Text = "Loading...";
			this.visualStyleProvider.SetVisualStyleSupport(this.labelLoading, true);
			// 
			// formLoading
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(322, 122);
			this.ControlBox = false;
			this.Controls.Add(this.labelLoading);
			this.Controls.Add(this.pictureLogo);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "formLoading";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.formLoading_Load);
			this.Activated += new System.EventHandler(this.formLoading_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		private void formLoading_Activated(object sender, System.EventArgs e)
		{
			if (this.Visible == true && bFirstLoad == false)
			{
				bFirstLoad = true;

				Application.DoEvents();

				ProgramResources.InitEngine();
			
				CSettings Settings = new CSettings(true);
				string sProgram = Application.ProductName.ToLower();

				string sOriginalFont = Settings.GetSetting(sProgram, "originalfont", "name", "AnmolLipi");
				float fOriginalSize = float.Parse(Settings.GetSetting(sProgram, "originalfont", "size", "14"));
				Color colourOriginal = Color.FromArgb(Settings.GetSetting(sProgram, "originalfont", "colour", SystemColors.WindowText.ToArgb()));
			
				string sConvertedFont = Settings.GetSetting(sProgram, "convertedfont", "name", "Saab");
				float fConvertedSize = float.Parse(Settings.GetSetting(sProgram, "convertedfont", "size", "14"));
				Color colourConverted = Color.FromArgb(Settings.GetSetting(sProgram, "convertedfont", "colour", SystemColors.WindowText.ToArgb()));

				formMain formCurrent = ((formMain)this.Owner);

				try
				{
					// TODO - Fix error
					formCurrent.textOriginalText.Font = new Font(sOriginalFont, fOriginalSize);
					formCurrent.textConvertedText.Font = new Font(sConvertedFont, fConvertedSize);
				}
				catch (Exception ex)
				{

				}

				formCurrent.textOriginalText.ForeColor = colourOriginal;
				formCurrent.textConvertedText.ForeColor = colourConverted;

				string[] sMappings = ProgramResources.Convert.ListMappings(Settings.GetSetting(sProgram, "mappings", "directory", ProgramResources.sApplicationDirectory));
				string sDefaultPath = Settings.GetSetting(sProgram, "mappings", "defaultpath", "");

				IEnumerator Iter = sMappings.GetEnumerator();
			
				while(Iter.MoveNext())
				{
					MappingDetails Current =  ProgramResources.Convert.GetDetails((string)Iter.Current);
					TaggedMenuItem Item = new TaggedMenuItem(Current.sFrom + " > " + Current.sTo);
					Item.Tag = Current.sFileName;
					Item.RadioCheck = true;
					Item.Click += new EventHandler(formCurrent.menuCustomConversion_Click);

					formCurrent.menuToolsConvert.MenuItems.Add(Item);
				}

				Iter = formCurrent.menuToolsConvert.MenuItems.GetEnumerator();

				int iCounter = 0;

				while(Iter.MoveNext())
				{
					// Prevents invalid cast on first & second menu item
					iCounter++;

					if (iCounter <= 2)
						continue;

					TaggedMenuItem Item = (TaggedMenuItem)Iter.Current;

					if ((string)Item.Tag == sDefaultPath)
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

				this.Close();
			}
		}

		private void formLoading_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
