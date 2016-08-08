using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Unicode.Gurmukhi.Forms
{
	/// <summary>
	/// Summary description for formCode.
	/// </summary>
	public class formCode : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textChar;
		private System.Windows.Forms.GroupBox groupCharProperties;
		private System.Windows.Forms.Label labelInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Skybound.VisualStyles.VisualStyleProvider visualStyleProvider;

		private System.Collections.Hashtable hashTable;

		public formCode()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			hashTable = new System.Collections.Hashtable();
						
			hashTable.Add(0x0A01	,"GURMUKHI SIGN ADAK BINDI");
			hashTable.Add(0x0A02	,"GURMUKHI SIGN BINDI");
			hashTable.Add(0x0A03	,"GURMUKHI SIGN VISARGA");
			hashTable.Add(0x0A05	,"GURMUKHI LETTER A");
			hashTable.Add(0x0A06	,"GURMUKHI LETTER AA");
			hashTable.Add(0x0A07	,"GURMUKHI LETTER I");
			hashTable.Add(0x0A08	,"GURMUKHI LETTER II");
			hashTable.Add(0x0A09	,"GURMUKHI LETTER U");
			hashTable.Add(0x0A0A	,"GURMUKHI LETTER UU");
			hashTable.Add(0x0A0F	,"GURMUKHI LETTER EE");
			hashTable.Add(0x0A10	,"GURMUKHI LETTER AI");
			hashTable.Add(0x0A13	,"GURMUKHI LETTER OO");
			hashTable.Add(0x0A14	,"GURMUKHI LETTER AU");
			hashTable.Add(0x0A15	,"GURMUKHI LETTER KA");
			hashTable.Add(0x0A16	,"GURMUKHI LETTER KHA");
			hashTable.Add(0x0A17	,"GURMUKHI LETTER GA");
			hashTable.Add(0x0A18	,"GURMUKHI LETTER GHA");
			hashTable.Add(0x0A19	,"GURMUKHI LETTER NGA");
			hashTable.Add(0x0A1A	,"GURMUKHI LETTER CA");
			hashTable.Add(0x0A1B	,"GURMUKHI LETTER CHA");
			hashTable.Add(0x0A1C	,"GURMUKHI LETTER JA");
			hashTable.Add(0x0A1D	,"GURMUKHI LETTER JHA");
			hashTable.Add(0x0A1E	,"GURMUKHI LETTER NYA");
			hashTable.Add(0x0A1F	,"GURMUKHI LETTER TTA");
			hashTable.Add(0x0A20	,"GURMUKHI LETTER TTHA");
			hashTable.Add(0x0A21	,"GURMUKHI LETTER DDA");
			hashTable.Add(0x0A22	,"GURMUKHI LETTER DDHA");
			hashTable.Add(0x0A23	,"GURMUKHI LETTER NNA");
			hashTable.Add(0x0A24	,"GURMUKHI LETTER TA");
			hashTable.Add(0x0A25	,"GURMUKHI LETTER THA");
			hashTable.Add(0x0A26	,"GURMUKHI LETTER DA");
			hashTable.Add(0x0A27	,"GURMUKHI LETTER DHA");
			hashTable.Add(0x0A28	,"GURMUKHI LETTER NA");
			hashTable.Add(0x0A2A	,"GURMUKHI LETTER PA");
			hashTable.Add(0x0A2B	,"GURMUKHI LETTER PHA");
			hashTable.Add(0x0A2C	,"GURMUKHI LETTER BA");
			hashTable.Add(0x0A2D	,"GURMUKHI LETTER BHA");
			hashTable.Add(0x0A2E	,"GURMUKHI LETTER MA");
			hashTable.Add(0x0A2F	,"GURMUKHI LETTER YA");
			hashTable.Add(0x0A30	,"GURMUKHI LETTER RA");
			hashTable.Add(0x0A32	,"GURMUKHI LETTER LA");
			hashTable.Add(0x0A33	,"GURMUKHI LETTER LLA");
			hashTable.Add(0x0A35	,"GURMUKHI LETTER VA");
			hashTable.Add(0x0A36	,"GURMUKHI LETTER SHA");
			hashTable.Add(0x0A38	,"GURMUKHI LETTER SA");
			hashTable.Add(0x0A39	,"GURMUKHI LETTER HA");
			hashTable.Add(0x0A3C	,"GURMUKHI SIGN NUKTA\r\n\r\n\t* for extending the alphabet to new letters");
			hashTable.Add(0x0A3E	,"GURMUKHI VOWEL SIGN AA");
			hashTable.Add(0x0A3F	,"GURMUKHI VOWEL SIGN I\r\n\r\n\t* stands to the left of the consonant");
			hashTable.Add(0x0A40	,"GURMUKHI VOWEL SIGN II");
			hashTable.Add(0x0A41	,"GURMUKHI VOWEL SIGN U");
			hashTable.Add(0x0A42	,"GURMUKHI VOWEL SIGN UU");
			hashTable.Add(0x0A47	,"GURMUKHI VOWEL SIGN EE");
			hashTable.Add(0x0A48	,"GURMUKHI VOWEL SIGN AI");
			hashTable.Add(0x0A4B	,"GURMUKHI VOWEL SIGN OO");
			hashTable.Add(0x0A4C	,"GURMUKHI VOWEL SIGN AU");
			hashTable.Add(0x0A4D	,"GURMUKHI SIGN VIRAMA");
			hashTable.Add(0x0A59	,"GURMUKHI LETTER KHHA");
			hashTable.Add(0x0A5A	,"GURMUKHI LETTER GHHA");
			hashTable.Add(0x0A5B	,"GURMUKHI LETTER ZA");
			hashTable.Add(0x0A5C	,"GURMUKHI LETTER RRA");
			hashTable.Add(0x0A5E	,"GURMUKHI LETTER FA");
			hashTable.Add(0x0A66	,"GURMUKHI DIGIT ZERO");
			hashTable.Add(0x0A67	,"GURMUKHI DIGIT ONE");
			hashTable.Add(0x0A68	,"GURMUKHI DIGIT TWO");
			hashTable.Add(0x0A69	,"GURMUKHI DIGIT THREE");
			hashTable.Add(0x0A6A	,"GURMUKHI DIGIT FOUR");
			hashTable.Add(0x0A6B	,"GURMUKHI DIGIT FIVE");
			hashTable.Add(0x0A6C	,"GURMUKHI DIGIT SIX");
			hashTable.Add(0x0A6D	,"GURMUKHI DIGIT SEVEN");
			hashTable.Add(0x0A6E	,"GURMUKHI DIGIT EIGHT");
			hashTable.Add(0x0A6F	,"GURMUKHI DIGIT NINE");
			hashTable.Add(0x0A70	,"GURMUKHI TIPPI\r\n\r\n\t* nasalization");
			hashTable.Add(0x0A71	,"GURMUKHI ADDAK\r\n\r\n\t* doubles following consonant");
			hashTable.Add(0x0A72	,"GURMUKHI IRI\r\n\r\n\t* base for vowels");
			hashTable.Add(0x0A73	,"GURMUKHI URA\r\n\r\n\t* base for vowels");
			hashTable.Add(0x0A74	,"GURMUKHI EK ONKAR\r\n\r\n\t* God is One");

			hashTable.Add(0x0964	,"DEVANAGARI DANDA");
			hashTable.Add(0x0A65	,"DEVANAGARI DOUBLE DANDA");

			hashTable.Add(0x262C	,"ADI SHAKTI\r\n\r\n\t= Gurmukhi Khanda");
			hashTable.Add(0x200C	,"ZERO WIDTH NON-JOINER\r\n\r\n\t= ZWNJ");
			hashTable.Add(0x200D	,"ZERO WIDTH JOINER\r\n\r\n\t= ZWJ");

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
			this.textChar = new System.Windows.Forms.TextBox();
			this.groupCharProperties = new System.Windows.Forms.GroupBox();
			this.labelInfo = new System.Windows.Forms.Label();
			this.visualStyleProvider = new Skybound.VisualStyles.VisualStyleProvider();
			this.groupCharProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// textChar
			// 
			this.textChar.Font = new System.Drawing.Font("Saab", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textChar.Location = new System.Drawing.Point(8, 16);
			this.textChar.MaxLength = 1;
			this.textChar.Name = "textChar";
			this.textChar.Size = new System.Drawing.Size(48, 65);
			this.textChar.TabIndex = 0;
			this.textChar.Text = "ੴ";
			this.textChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.visualStyleProvider.SetVisualStyleSupport(this.textChar, true);
			this.textChar.TextChanged += new System.EventHandler(this.textChar_TextChanged);
			// 
			// groupCharProperties
			// 
			this.groupCharProperties.Controls.Add(this.labelInfo);
			this.groupCharProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupCharProperties.Location = new System.Drawing.Point(64, 8);
			this.groupCharProperties.Name = "groupCharProperties";
			this.groupCharProperties.Size = new System.Drawing.Size(248, 80);
			this.groupCharProperties.TabIndex = 1;
			this.groupCharProperties.TabStop = false;
			this.groupCharProperties.Text = "Character Properties";
			this.visualStyleProvider.SetVisualStyleSupport(this.groupCharProperties, true);
			// 
			// labelInfo
			// 
			this.labelInfo.Location = new System.Drawing.Point(8, 16);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(232, 56);
			this.labelInfo.TabIndex = 0;
			this.visualStyleProvider.SetVisualStyleSupport(this.labelInfo, true);
			// 
			// formCode
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(322, 96);
			this.Controls.Add(this.groupCharProperties);
			this.Controls.Add(this.textChar);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "formCode";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Character Code Viewer";
			this.Load += new System.EventHandler(this.formCode_Load);
			this.groupCharProperties.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void formCode_Load(object sender, System.EventArgs e)
		{
			textChar_TextChanged(sender, e);
		}

		private void textChar_TextChanged(object sender, System.EventArgs e)
		{
			if (textChar.Text.Length > 0)
			{
				foreach (DictionaryEntry myDE in hashTable)
				{
					if ((int)myDE.Key == (int)textChar.Text[0])
					{
						labelInfo.Text = "Code point: U+" + ((int)textChar.Text[0]).ToString("X4") + "\r\n" +
							"Description: " + myDE.Value;
						return;
					}
				}

				labelInfo.Text = "Code point: U+" + ((int)textChar.Text[0]).ToString("X4");
			}
		}
	}
}
