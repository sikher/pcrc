using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Metamorph.Classes;

namespace Metamorph.Forms
{

	/// <summary>
	/// Summary description for Loading.
	/// </summary>
	public class Loading : System.Windows.Forms.Form
	{
		private bool bFirstLoad = false;
		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.ProgressBar prgLoading;
        private System.Windows.Forms.Label lblIntro;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Loading()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.prgLoading = new System.Windows.Forms.ProgressBar();
            this.lblIntro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(16, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(304, 152);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // prgLoading
            // 
            this.prgLoading.Location = new System.Drawing.Point(8, 176);
            this.prgLoading.Name = "prgLoading";
            this.prgLoading.Size = new System.Drawing.Size(320, 16);
            this.prgLoading.TabIndex = 1;
            // 
            // lblIntro
            // 
            this.lblIntro.Location = new System.Drawing.Point(8, 152);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(320, 16);
            this.lblIntro.TabIndex = 2;
            this.lblIntro.Text = "Loading...";
            this.lblIntro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIntro.Click += new System.EventHandler(this.lblIntro_Click);
            // 
            // Loading
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(336, 198);
            this.ControlBox = false;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.prgLoading);
            this.Controls.Add(this.picLogo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Loading";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Loading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Loading_Load(object sender, System.EventArgs e)
		{	
			this.Show();
			Application.DoEvents();

			if (this.Visible == true && bFirstLoad == false)
			{
				bFirstLoad = true;

				MainForm form = ((MainForm)this.Owner);

				if (!Settings.InitMappingDirectory())
				{
					MessageBox.Show(this, "Fatal error: Unable to create or access mappings directory.", "Metamorph", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				Settings.LoadSettings();
				Settings.LoadFontStyles(form.textInputText, form.textOutputText);

                Settings.LoadMappings();
                Settings.LoadInputList(form.listInputFormat, form.listOutputFormat);
                
				this.Close();
			}
		}

		private void lblIntro_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
