using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Metamorph.Forms
{
	/// <summary>
	/// Summary description for CharacterViewer.
	/// </summary>
	public class CharacterViewer : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupCharProperties;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupCharacter;
		private System.Windows.Forms.TextBox textChar;
		private System.Windows.Forms.GroupBox groupHTMLEntityGenerator;
		private System.Windows.Forms.TextBox textNormalText;
		private System.Windows.Forms.TextBox textHTMLEntities;
		private System.Windows.Forms.Button buttonToEntity;
		private System.Windows.Forms.Button buttonToNormalText;
		private System.Windows.Forms.TextBox textInfo;
		private System.Windows.Forms.Button buttonToCodepoints;

		
		private System.Collections.Hashtable hashTable;

		public CharacterViewer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			hashTable = new System.Collections.Hashtable();

			//Eventually plan to store *all* Unicode details using their data files

            hashTable.Add(0x0A01, "GURMUKHI SIGN ADAK BINDI");
            hashTable.Add(0x0A02, "GURMUKHI SIGN BINDI");
            hashTable.Add(0x0A03, "GURMUKHI SIGN VISARGA");
            hashTable.Add(0x0A05, "GURMUKHI LETTER A");
            hashTable.Add(0x0A06, "GURMUKHI LETTER AA");
            hashTable.Add(0x0A07, "GURMUKHI LETTER I");
            hashTable.Add(0x0A08, "GURMUKHI LETTER II");
            hashTable.Add(0x0A09, "GURMUKHI LETTER U");
            hashTable.Add(0x0A0A, "GURMUKHI LETTER UU");
            hashTable.Add(0x0A0F, "GURMUKHI LETTER EE");
            hashTable.Add(0x0A10, "GURMUKHI LETTER AI");
            hashTable.Add(0x0A13, "GURMUKHI LETTER OO");
            hashTable.Add(0x0A14, "GURMUKHI LETTER AU");
            hashTable.Add(0x0A15, "GURMUKHI LETTER KA");
            hashTable.Add(0x0A16, "GURMUKHI LETTER KHA");
            hashTable.Add(0x0A17, "GURMUKHI LETTER GA");
            hashTable.Add(0x0A18, "GURMUKHI LETTER GHA");
            hashTable.Add(0x0A19, "GURMUKHI LETTER NGA");
            hashTable.Add(0x0A1A, "GURMUKHI LETTER CA");
            hashTable.Add(0x0A1B, "GURMUKHI LETTER CHA");
            hashTable.Add(0x0A1C, "GURMUKHI LETTER JA");
            hashTable.Add(0x0A1D, "GURMUKHI LETTER JHA");
            hashTable.Add(0x0A1E, "GURMUKHI LETTER NYA");
            hashTable.Add(0x0A1F, "GURMUKHI LETTER TTA");
            hashTable.Add(0x0A20, "GURMUKHI LETTER TTHA");
            hashTable.Add(0x0A21, "GURMUKHI LETTER DDA");
            hashTable.Add(0x0A22, "GURMUKHI LETTER DDHA");
            hashTable.Add(0x0A23, "GURMUKHI LETTER NNA");
            hashTable.Add(0x0A24, "GURMUKHI LETTER TA");
            hashTable.Add(0x0A25, "GURMUKHI LETTER THA");
            hashTable.Add(0x0A26, "GURMUKHI LETTER DA");
            hashTable.Add(0x0A27, "GURMUKHI LETTER DHA");
            hashTable.Add(0x0A28, "GURMUKHI LETTER NA");
            hashTable.Add(0x0A2A, "GURMUKHI LETTER PA");
            hashTable.Add(0x0A2B, "GURMUKHI LETTER PHA");
            hashTable.Add(0x0A2C, "GURMUKHI LETTER BA");
            hashTable.Add(0x0A2D, "GURMUKHI LETTER BHA");
            hashTable.Add(0x0A2E, "GURMUKHI LETTER MA");
            hashTable.Add(0x0A2F, "GURMUKHI LETTER YA");
            hashTable.Add(0x0A30, "GURMUKHI LETTER RA");
            hashTable.Add(0x0A32, "GURMUKHI LETTER LA");
            hashTable.Add(0x0A33, "GURMUKHI LETTER LLA");
            hashTable.Add(0x0A35, "GURMUKHI LETTER VA");
            hashTable.Add(0x0A36, "GURMUKHI LETTER SHA");
            hashTable.Add(0x0A38, "GURMUKHI LETTER SA");
            hashTable.Add(0x0A39, "GURMUKHI LETTER HA");
            hashTable.Add(0x0A3C, "GURMUKHI SIGN NUKTA\r\n\r\n\t* for extending the alphabet to new letters");
            hashTable.Add(0x0A3E, "GURMUKHI VOWEL SIGN AA");
            hashTable.Add(0x0A3F, "GURMUKHI VOWEL SIGN I\r\n\r\n\t* stands to the left of the consonant");
            hashTable.Add(0x0A40, "GURMUKHI VOWEL SIGN II");
            hashTable.Add(0x0A41, "GURMUKHI VOWEL SIGN U");
            hashTable.Add(0x0A42, "GURMUKHI VOWEL SIGN UU");
            hashTable.Add(0x0A47, "GURMUKHI VOWEL SIGN EE");
            hashTable.Add(0x0A48, "GURMUKHI VOWEL SIGN AI");
            hashTable.Add(0x0A4B, "GURMUKHI VOWEL SIGN OO");
            hashTable.Add(0x0A4C, "GURMUKHI VOWEL SIGN AU");
            hashTable.Add(0x0A4D, "GURMUKHI SIGN VIRAMA");
            hashTable.Add(0x0A59, "GURMUKHI LETTER KHHA");
            hashTable.Add(0x0A5A, "GURMUKHI LETTER GHHA");
            hashTable.Add(0x0A5B, "GURMUKHI LETTER ZA");
            hashTable.Add(0x0A5C, "GURMUKHI LETTER RRA");
            hashTable.Add(0x0A5E, "GURMUKHI LETTER FA");
            hashTable.Add(0x0A66, "GURMUKHI DIGIT ZERO");
            hashTable.Add(0x0A67, "GURMUKHI DIGIT ONE");
            hashTable.Add(0x0A68, "GURMUKHI DIGIT TWO");
            hashTable.Add(0x0A69, "GURMUKHI DIGIT THREE");
            hashTable.Add(0x0A6A, "GURMUKHI DIGIT FOUR");
            hashTable.Add(0x0A6B, "GURMUKHI DIGIT FIVE");
            hashTable.Add(0x0A6C, "GURMUKHI DIGIT SIX");
            hashTable.Add(0x0A6D, "GURMUKHI DIGIT SEVEN");
            hashTable.Add(0x0A6E, "GURMUKHI DIGIT EIGHT");
            hashTable.Add(0x0A6F, "GURMUKHI DIGIT NINE");
            hashTable.Add(0x0A70, "GURMUKHI TIPPI\r\n\r\n\t* nasalization");
            hashTable.Add(0x0A71, "GURMUKHI ADDAK\r\n\r\n\t* doubles following consonant");
            hashTable.Add(0x0A72, "GURMUKHI IRI\r\n\r\n\t* base for vowels");
            hashTable.Add(0x0A73, "GURMUKHI URA\r\n\r\n\t* base for vowels");
            hashTable.Add(0x0A74, "GURMUKHI EK ONKAR\r\n\r\n\t* God is One");

            hashTable.Add(0x0964, "DEVANAGARI DANDA");
            hashTable.Add(0x0965, "DEVANAGARI DOUBLE DANDA");

            hashTable.Add(0x262C, "ADI SHAKTI\r\n\t= Gurmukhi Khanda");
            hashTable.Add(0x200B, "ZERO WIDTH SPACE\r\n\t= ZWSP\r\n\t* nominally zero width, but may expand in justification");
            hashTable.Add(0x200C, "ZERO WIDTH NON-JOINER\r\n\t= ZWNJ");
            hashTable.Add(0x200D, "ZERO WIDTH JOINER\r\n\t= ZWJ");

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
            this.groupCharProperties = new System.Windows.Forms.GroupBox();
            this.textInfo = new System.Windows.Forms.TextBox();
            this.groupCharacter = new System.Windows.Forms.GroupBox();
            this.textChar = new System.Windows.Forms.TextBox();
            this.groupHTMLEntityGenerator = new System.Windows.Forms.GroupBox();
            this.buttonToCodepoints = new System.Windows.Forms.Button();
            this.buttonToNormalText = new System.Windows.Forms.Button();
            this.buttonToEntity = new System.Windows.Forms.Button();
            this.textHTMLEntities = new System.Windows.Forms.TextBox();
            this.textNormalText = new System.Windows.Forms.TextBox();
            this.groupCharProperties.SuspendLayout();
            this.groupCharacter.SuspendLayout();
            this.groupHTMLEntityGenerator.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCharProperties
            // 
            this.groupCharProperties.Controls.Add(this.textInfo);
            this.groupCharProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupCharProperties.Location = new System.Drawing.Point(88, 8);
            this.groupCharProperties.Name = "groupCharProperties";
            this.groupCharProperties.Size = new System.Drawing.Size(312, 80);
            this.groupCharProperties.TabIndex = 3;
            this.groupCharProperties.TabStop = false;
            this.groupCharProperties.Text = "Character Properties";
            // 
            // textInfo
            // 
            this.textInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textInfo.Location = new System.Drawing.Point(8, 16);
            this.textInfo.Multiline = true;
            this.textInfo.Name = "textInfo";
            this.textInfo.ReadOnly = true;
            this.textInfo.Size = new System.Drawing.Size(296, 56);
            this.textInfo.TabIndex = 0;
            // 
            // groupCharacter
            // 
            this.groupCharacter.Controls.Add(this.textChar);
            this.groupCharacter.Location = new System.Drawing.Point(8, 8);
            this.groupCharacter.Name = "groupCharacter";
            this.groupCharacter.Size = new System.Drawing.Size(72, 80);
            this.groupCharacter.TabIndex = 4;
            this.groupCharacter.TabStop = false;
            this.groupCharacter.Text = "Character";
            // 
            // textChar
            // 
            this.textChar.Font = new System.Drawing.Font("Saab", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChar.Location = new System.Drawing.Point(8, 16);
            this.textChar.MaxLength = 1;
            this.textChar.Name = "textChar";
            this.textChar.Size = new System.Drawing.Size(56, 56);
            this.textChar.TabIndex = 0;
            this.textChar.Text = "ੴ";
            this.textChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textChar.TextChanged += new System.EventHandler(this.textChar_TextChanged);
            // 
            // groupHTMLEntityGenerator
            // 
            this.groupHTMLEntityGenerator.Controls.Add(this.buttonToCodepoints);
            this.groupHTMLEntityGenerator.Controls.Add(this.buttonToNormalText);
            this.groupHTMLEntityGenerator.Controls.Add(this.buttonToEntity);
            this.groupHTMLEntityGenerator.Controls.Add(this.textHTMLEntities);
            this.groupHTMLEntityGenerator.Controls.Add(this.textNormalText);
            this.groupHTMLEntityGenerator.Location = new System.Drawing.Point(8, 96);
            this.groupHTMLEntityGenerator.Name = "groupHTMLEntityGenerator";
            this.groupHTMLEntityGenerator.Size = new System.Drawing.Size(392, 112);
            this.groupHTMLEntityGenerator.TabIndex = 5;
            this.groupHTMLEntityGenerator.TabStop = false;
            this.groupHTMLEntityGenerator.Text = "HTML Entity Generator";
            this.groupHTMLEntityGenerator.Enter += new System.EventHandler(this.groupHTMLEntityGenerator_Enter);
            // 
            // buttonToCodepoints
            // 
            this.buttonToCodepoints.Location = new System.Drawing.Point(136, 48);
            this.buttonToCodepoints.Name = "buttonToCodepoints";
            this.buttonToCodepoints.Size = new System.Drawing.Size(120, 24);
            this.buttonToCodepoints.TabIndex = 4;
            this.buttonToCodepoints.Text = "To Codepoints ▼";
            this.buttonToCodepoints.Click += new System.EventHandler(this.buttonToCodepoints_Click);
            // 
            // buttonToNormalText
            // 
            this.buttonToNormalText.Location = new System.Drawing.Point(264, 48);
            this.buttonToNormalText.Name = "buttonToNormalText";
            this.buttonToNormalText.Size = new System.Drawing.Size(120, 24);
            this.buttonToNormalText.TabIndex = 3;
            this.buttonToNormalText.Text = "▲ To Normal Text";
            this.buttonToNormalText.Click += new System.EventHandler(this.buttonToNormalText_Click);
            // 
            // buttonToEntity
            // 
            this.buttonToEntity.Location = new System.Drawing.Point(8, 48);
            this.buttonToEntity.Name = "buttonToEntity";
            this.buttonToEntity.Size = new System.Drawing.Size(120, 24);
            this.buttonToEntity.TabIndex = 2;
            this.buttonToEntity.Text = "To HTML Entities ▼";
            this.buttonToEntity.Click += new System.EventHandler(this.buttonToEntity_Click);
            // 
            // textHTMLEntities
            // 
            this.textHTMLEntities.Location = new System.Drawing.Point(8, 80);
            this.textHTMLEntities.Name = "textHTMLEntities";
            this.textHTMLEntities.Size = new System.Drawing.Size(376, 20);
            this.textHTMLEntities.TabIndex = 1;
            this.textHTMLEntities.Text = "Enter HTML Entities Here";
            this.textHTMLEntities.Enter += new System.EventHandler(this.textHTMLEntities_Enter);
            this.textHTMLEntities.Leave += new System.EventHandler(this.textHTMLEntities_Leave);
            // 
            // textNormalText
            // 
            this.textNormalText.Location = new System.Drawing.Point(8, 20);
            this.textNormalText.Name = "textNormalText";
            this.textNormalText.Size = new System.Drawing.Size(376, 20);
            this.textNormalText.TabIndex = 0;
            this.textNormalText.Text = "Enter Normal Text Here";
            this.textNormalText.Enter += new System.EventHandler(this.textNormalText_Enter);
            this.textNormalText.Leave += new System.EventHandler(this.textNormalText_Leave);
            // 
            // CharacterViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(408, 216);
            this.Controls.Add(this.groupHTMLEntityGenerator);
            this.Controls.Add(this.groupCharacter);
            this.Controls.Add(this.groupCharProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CharacterViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Viewer";
            this.Load += new System.EventHandler(this.CharacterViewer_Load);
            this.groupCharProperties.ResumeLayout(false);
            this.groupCharProperties.PerformLayout();
            this.groupCharacter.ResumeLayout(false);
            this.groupCharacter.PerformLayout();
            this.groupHTMLEntityGenerator.ResumeLayout(false);
            this.groupHTMLEntityGenerator.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void textChar_Validated(object sender, System.EventArgs e)
		{
		
		}

		private void textChar_TextChanged(object sender, System.EventArgs e)
		{
			if (textChar.Text.Length > 0)
			{
				foreach (DictionaryEntry myDE in hashTable)
				{
					if ((int)myDE.Key == (int)textChar.Text[0])
					{
						textInfo.Text = "Code point: U+" + ((int)textChar.Text[0]).ToString("X4") + "\r\n" +
							"Description: " + myDE.Value;
						return;
					}
				}

				textInfo.Text = "Code point: U+" + ((int)textChar.Text[0]).ToString("X4");
			}
		}

		private void CharacterViewer_Load(object sender, System.EventArgs e)
		{
			textChar_TextChanged(sender, e);
			textInfo.SelectionLength = 0;
			textChar.Select();
		}

		private void buttonToEntity_Click(object sender, System.EventArgs e)
		{
			string sOutput = "";
			foreach (char Char in textNormalText.Text)
			{
				sOutput += "&#" + (int)Char + ";";
			}

			textHTMLEntities.Text = sOutput;
		}

		private void buttonToNormalText_Click(object sender, System.EventArgs e)
		{
			string sInput = textHTMLEntities.Text.Trim();

			//char[] sSplit = new char[] {;

			string[] sSplit = sInput.Split(new char[] {';'});

			string sOutput = "";

			foreach (string sCurrent in sSplit)
			{

				if (sCurrent.Length > 2 && sCurrent.Substring(0, 2) == "&#")
				{
					try
					{
						sOutput += (char)int.Parse(sCurrent.Substring(2));
					}
					catch (Exception ex)
					{
						sOutput += sCurrent;
					}
				}
				else
					sOutput += sCurrent;
			}

			textNormalText.Text = sOutput;
		}

		private void groupHTMLEntityGenerator_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void buttonToCodepoints_Click(object sender, System.EventArgs e)
		{
			string sNewText = "";
			for (int i=0; i < textNormalText.Text.Length; i++)
			{
				if (textNormalText.Text[i] != '\r' && textNormalText.Text[i] != '\n')
					sNewText += "U+" + ((int)textNormalText.Text[i]).ToString("X").PadLeft(4, '0') + " ";
				else
					sNewText += textNormalText.Text[i];
			}

			textHTMLEntities.Text = sNewText;
		}

        private void textNormalText_Leave(object sender, EventArgs e)
        {
            if (textNormalText.Text == "")
                textNormalText.Text = "Enter Normal Text Here";
        }

        private void textNormalText_Enter(object sender, EventArgs e)
        {
            if (textNormalText.Text == "Enter Normal Text Here")
                textNormalText.Text = "";
        }

        private void textHTMLEntities_Enter(object sender, EventArgs e)
        {
            if (textHTMLEntities.Text == "Enter HTML Entities Here")
                textHTMLEntities.Text = "";
        }

        private void textHTMLEntities_Leave(object sender, EventArgs e)
        {
            if (textHTMLEntities.Text == "")
                textHTMLEntities.Text = "Enter HTML Entities Here";
        }
	}
}
