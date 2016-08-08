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

// Uses System.Windows.Forms

namespace Unicode.Gurmukhi
{
	/// <summary>
	/// The ConversionEngine is a redistributable, self-contained class
	/// designed to convert ASCII based Gurmukhi text into Unicode.
	///
	/// You may freely use this class in your program provided the 
	/// GNU GPL licensing terms are complied with.
	///
	/// Copyright © 2004 Sukhjinder Sidhu.
	/// Released under the GNU General Public Licence.
	///
	/// For further information on XML comment tags, visit MSDN:
	/// /csref/html/vclrfTagsForDocumentationComments.htm
	/// </summary>
	public class ConversionEngine
	{
		
		#region Fields & Variables

		private const string m_sVersion = "1.1.0 (.NET Implementation [C#])";
		private const bool m_bProprietary = false;
		private bool m_bProcessMessages = true;
		private bool m_bCancel = false;
		private bool m_bRepositionI = false;
		private bool m_bRepairISCIIProposals = false;
		private bool m_bNormaliseText = true;
		private bool m_bUnicode4 = true;
		private bool m_bErrorCorrection;
		private bool m_bConvertNumbers;
		private int m_iPercentComplete;
		private System.Windows.Forms.ProgressBar m_progressBar;

		#endregion

		#region Properties

		/// <summary>
		/// Automatic error correction.
		/// </summary>
		public bool ErrorCorrection 
		{
			get
			{ 
				return m_bErrorCorrection;
			}
			set
			{
				m_bErrorCorrection = value;
			}
		}

		/// <summary>
		/// Convert numbers.
		/// </summary>
		public bool ConvertNumbers 
		{
			get
			{ 
				return m_bConvertNumbers;
			}
			set
			{
				m_bConvertNumbers = value;
			}
		}

		/// <summary>
		/// Process window messages.  Increases UI responsiveness
		/// but decreases conversion speed.  If this is set to 
		/// 'false' the user will be unable to manually cancel
		/// the conversion.
		/// </summary>
		public bool ProcessMessages 
		{
			get
			{ 
				return m_bProcessMessages;
			}
			set
			{
				m_bProcessMessages = value;
			}
		}

		/// <summary>
		/// The current progress bar to be used for progress
		/// information.
		/// </summary>
		public System.Windows.Forms.ProgressBar ProgressBar 
		{
			get
			{ 
				return m_progressBar;
			}
			set
			{
				m_progressBar = value;
			}
		}

		/// <summary>
		/// When repairing, set this option to reposition
		/// the vowel sign I (U+0A3F) to the left.
		/// </summary>
		public bool RepositionI
		{
			get
			{ 
				return m_bRepositionI;
			}
			set
			{
				m_bRepositionI = value;
			}
		}

		/// <summary>
		/// Repairs any text that was created using ISCII (1991) 
		/// proposed extensions which were not implemented into 
		/// the Unicode 4.0 standard.  This is not normally 
		/// required as VERY few Gurmukhi Unicode fonts have 
		/// these additions.
		/// </summary>
		public bool RepairISCIIProposals
		{
			get
			{ 
				return m_bRepairISCIIProposals;
			}
			set
			{
				m_bRepairISCIIProposals = value;
			}
		}
		
		/// <summary>
		/// Normalises text when being repaired.
		/// </summary>
		public bool NormaliseText
		{
			get
			{ 
				return m_bNormaliseText;
			}
			set
			{
				m_bNormaliseText = value;
			}
		}

		/// <summary>
		/// Specifies whether to use Unicode 4 characters.
		/// </summary>
		public bool Unicode4
		{
			get
			{ 
				return m_bUnicode4;
			}
			set
			{
				m_bUnicode4 = value;
			}
		}

		/// <summary>
		/// Retrieve ConversionEngine version (Read only).
		/// </summary>
		public static string Version
		{
			get
			{ 
				return m_sVersion;
			}
		}
	 
		/// <summary>
		/// Returns 'true' is this is a proprietary class (i.e. it
		/// has been changed/updated 'unofficially' from an official
		/// release). 
		/// 
		/// If you've changed the class, you should set this value
		/// to 'true' by updating the m_bProprietary constant.
		/// </summary>
		public static bool Proprietary
		{
			get
			{ 
				return m_bProprietary;
			}
		}
		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		public ConversionEngine()
		{
			ConvertNumbers = false;
			ErrorCorrection = false;
			ProgressBar = new System.Windows.Forms.ProgressBar(); // Dummy
			ResetProgressBar();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="progressBar">A ProgressBar that is dynamically
		/// updated as the conversion progresses.</param>
		public ConversionEngine(System.Windows.Forms.ProgressBar progressBar)
		{
			ConvertNumbers = false;
			ErrorCorrection = false;
			ProgressBar = progressBar;
			ResetProgressBar();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="bConvertNumbers">Convert numbers.</param>
		/// <param name="bErrorCorrection">Automatic error correction.</param>
		public ConversionEngine(bool bConvertNumbers, bool bErrorCorrection)
		{
			ConvertNumbers = bConvertNumbers;
			ErrorCorrection = bErrorCorrection;
			ProgressBar = new System.Windows.Forms.ProgressBar(); // Dummy
			ResetProgressBar();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="progressBar">A ProgressBar that is dynamically
		/// updated as the conversion progresses.</param>
		/// <param name="bConvertNumbers">Convert numbers.</param>
		/// <param name="bErrorCorrection">Automatic error correction.</param>
		public ConversionEngine(System.Windows.Forms.ProgressBar progressBar, bool bConvertNumbers, bool bErrorCorrection)
		{
			ConvertNumbers = bConvertNumbers;
			ErrorCorrection = bErrorCorrection;
			ProgressBar = progressBar;
			ResetProgressBar();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Initialises a ProgressBar.
		/// </summary>
		private void ResetProgressBar()
		{
			ProgressBar.Value = 0;
			ProgressBar.Maximum = 100;
			ProgressBar.Minimum = 0;
		}

		/// <summary>
		/// Returns whether the current character should be
		/// placed after a vowel.
		/// </summary>	
		/// <param name="cCharacter">Character to be checked.</param>
		/// <returns>Returns 'true' if the character should be placed after vowel.</returns>
		private bool AfterVowel(char cCharacter)
		{
			// Bindi, Tippi, Addak
			// U+0A02, U+0A70, U+0A71

			if (cCharacter == '\u0A02' ||
				cCharacter == '\u0A70' ||
				cCharacter == '\u0A71')
				return true;
			else
				return false;
		}

		/// <summary>
		/// Returns whether the current character should be
		/// placed before a vowel.
		/// </summary>	
		/// <param name="cCharacter">Character to be checked.</param>
		/// <returns>Returns 'true' if the character should be placed before a vowel.</returns>
		private bool BeforeVowel(char cCharacter)
		{
			// Nukta
			// U+0A3C

			if (cCharacter == '\u0A3C')
				return true;
			else
				return false;
		}

		/// <summary>
		/// Cancels the current operation.
		/// </summary>
		public void Cancel()
		{
			m_bCancel = true;
		}

		/// <summary>
		/// Checks for a vowel in a character.
		/// </summary>	
		/// <remarks>
		/// This method only checks for one character vowels.  See overloaded
		/// method for more general purpose usage.
		/// </remarks>
		/// <param name="cCharacter">Character to be checked for a vowel.</param>
		/// <returns>Returns 'true' if a vowel is found.</returns>
		public bool IsVowel(char cCharacter)
		{
			if (cCharacter == '\u0A3E' ||
				cCharacter == '\u0A3F' ||
				cCharacter == '\u0A40' ||
				cCharacter == '\u0A41' ||
				cCharacter == '\u0A42' ||
				cCharacter == '\u0A47' ||
				cCharacter == '\u0A48' ||
				cCharacter == '\u0A4B' ||
				cCharacter == '\u0A4C')
				return true;
			else
				return false;
		}

		/// <summary>
		/// Checks to see if current character is a sign.
		/// </summary>	
		/// <param name="cCharacter">Character to be checked for a sign.</param>
		/// <returns>Returns 'true' if a sign is found.</returns>
		public bool IsSign(char cCharacter)
		{
			if (IsVowel(cCharacter) ||
				cCharacter == '\u0A3C' ||
				cCharacter == '\u0A4D' ||
				cCharacter == '\u0A70' ||
				cCharacter == '\u0A71' ||
				cCharacter == '\u0A02')
				return true;
			else
				return false;
		}

		/// <summary>
		/// Checks to see if current two characters form a conjunct.
		/// </summary>	
		/// <param name="cCharA">First character.  Should be Virama.</param>
		/// <param name="cCharB">Second character.</param>
		/// <returns>Returns 'true' if a conjunct is found.</returns>
		public bool IsConjunct(char cCharA, char cCharB)
		{
			if (cCharA != '\u0A4D')
				return false;

			if (cCharB == '\u0A2F' ||
				cCharB == '\u0A30' ||
				cCharB == '\u0A35' ||
				cCharB == '\u0A39')
				return true;
			else
				return false;
		}

		/// <summary>
		/// Repairs Gurmukhi Unicode text.  This is not required on
		/// text created by the Convert() method.
		/// 
		/// It is recommended that all text is repaired to prevent
		/// inconsistencies and incompatiblity with different fonts. 
		/// </summary>	
		/// <param name="sInput">String to be repaired.</param>
		/// <returns>Returns a repaired string.</returns>
		public string Repair(string sInput)
		{
			m_bCancel = false;
			int iInputLength = sInput.Length;
			System.Text.StringBuilder sOutput = new System.Text.StringBuilder();

			sOutput.EnsureCapacity(iInputLength);

			for (int iCounter = 0; iCounter < iInputLength; iCounter++)
			{
				if (m_bCancel == true)
					break;

				Progress(m_iPercentComplete);
				m_iPercentComplete = (int)(((decimal)iCounter / (decimal)iInputLength) * 100);

				char cChar = sInput[iCounter];

				char cNext = ' ';

				if (iCounter + 1 < iInputLength)
					cNext = sInput[iCounter + 1];

				if (!(IsSign(cChar) == true && cNext == cChar))
				{
					switch (cChar)
					{
						// ਖ਼  - U+0A59
						case '\u0A59':
							// Convert ਖ਼ to ਖ + ਼ 
							// U+0A59 to U+0A16 + U+0A3C
							if (NormaliseText == true)
								sOutput.Append("\u0A16\u0A3C");
							else
								sOutput.Append(cChar);
							break;

						// ਗ਼ - U+0A5A
						case '\u0A5A':
							// Convert ਗ਼ to ਗ + ਼
							// U+0A5A to U+0A17 + U+0A3C
							if (NormaliseText == true)
								sOutput.Append("\u0A17\u0A3C");
							else
								sOutput.Append(cChar);
							break;

						// ਜ਼- U+0A5B
						case '\u0A5B':
							// Convert ਜ਼ to ਜ + ਼
							// U+0A5B to U+0A1C + U+0A3C
							if (NormaliseText == true)
								sOutput.Append("\u0A1C\u0A3C");
							else
								sOutput.Append(cChar);
							break;
					
						// ਫ਼ - U+0A5E
						case '\u0A5E':
							// Convert ਫ਼ to ਫ + ਼
							// U+0A5E to U+0A2B + U+0A3C
							if (NormaliseText == true)
								sOutput.Append("\u0A2B\u0A3C");
							else
								sOutput.Append(cChar);
							break;

						// ਲ਼ - U+0A33
						case '\u0A33':
							// Convert ਲ਼ to ਲ + ਼
							// U+0A33 to U+0A32 + U+0A3C
							if (NormaliseText == true)
								sOutput.Append("\u0A32\u0A3C");
							else
								sOutput.Append(cChar);
							break;

						// ਸ਼ - U+0A36
						case '\u0A36':
							// Convert ਸ਼ to ਸ + ਼
							// U+0A36 to U+0A38 + U+0A3C
							if (NormaliseText == true)
								sOutput.Append("\u0A38\u0A3C");
							else
								sOutput.Append(cChar);
							break;

						// ੜ - U+0A5C
						case '\u0A5C':
							// Convert ਡ਼ to ਡ + ਼
							// U+0A5C to 0A21 + U+0A3C
							if (NormaliseText == true)
								sOutput.Append("\u0A21\u0A3C");
							else
								sOutput.Append(cChar);
							break;
					
						// ਅ - U+0A05
						case '\u0A05':
							// Convert ਅ + ਾ  to ਆ
							// U+0A05 + U+0A3E to U+0A06
							if (cNext == '\u0A3E')
							{
								sOutput.Append('\u0A06');
								iCounter++;
							}
							// Convert ਅ + ੈ  to ਐ
							// U+0A05 + U+0A48 to U+0A10
							else if (cNext == '\u0A48')
							{
								sOutput.Append('\u0A10');
								iCounter++;
							}
							// Convert ਅ + ੌ to ਔ
							// U+0A05 + U+0A4C to U+0A14
							else if (cNext == '\u0A4C')
							{
								sOutput.Append('\u0A14');
								iCounter++;
							}
							// ****Proposed ISCII Extensions Repair****
							// Convert to ਆਂ
							// U+0A7E to U+0A06 + U+0A02
							else if (cNext == '\u0A7E' && RepairISCIIProposals == true)
							{
								sOutput.Append("\u0A06\u0A02");
								iCounter++;
							}
							else
							{
								sOutput.Append(cChar);
							}
							break;

						// ੲ - U+0A72
						case '\u0A72':
							// Convert ੲ + ੇ to ਏ
							// U+0A72 + U+0A47 to U+0A0F
							if (cNext == '\u0A47')
							{
								sOutput.Append('\u0A0F');
								iCounter++;
							}
							// Convert ੲ + ੀ  to ਈ
							// U+0A72 + U+0A40 to U+0A08
							if (cNext == '\u0A40')
							{
								sOutput.Append('\u0A08');
								iCounter++;
							}
							// Convert ੲ + ਿ  to ਇ
							// U+0A72 + U+0A3F to U+0A07
							else if (cNext == '\u0A3F')
							{
								sOutput.Append('\u0A07');
								iCounter++;
							}
							else
							{
								sOutput.Append(cChar);
							}
							break;

						// ੳ - U+0A73
						case '\u0A73':
							// Convert ੳ + ੁ  to ਉ
							// U+0A73 + U+0A41 to U+0A09
							if (cNext == '\u0A41')
							{
								sOutput.Append('\u0A09');
								iCounter++;
							}
							// Convert ੳ + ੂ  to ਊ
							// U+0A73 + U+0A42 to U+0A0A
							else if (cNext == '\u0A42')
							{
								sOutput.Append('\u0A0A');
								iCounter++;
							}
							else
							{
								sOutput.Append(cChar);
							}
							break;

						// ਿ - U+0A3F
						case '\u0A3F':
							if (RepositionI == true)
							{
								// Convert ਿ + ੲ   to ਇ
								// U+0A3F + U+0A72 to U+0A07
								if (cNext == '\u0A72')
								{
									sOutput.Append('\u0A07');
									iCounter++;
								}
								else
								{
									sOutput.Append(cNext);
									sOutput.Append(cChar);
									iCounter++;
								}
							}
							else
							{
								sOutput.Append(cChar);
							}
							break;

						// ****Proposed ISCII Extensions****
						//
						// The following characters are designed
						// to convert characters based on proposed
						// ISCII (1991) extensions to Unicode 4.0.
						//
						// Currently the following are not handled:
						//
						// U+0A3A
						// U+0A77
						// U+0A79
						// U+0A7A
						// U+0A7B
						// U+0A7C
						//
						// This is because no adequate conversion is
						// available at present (at least to my knowledge).

						// Convert to ੴ
						// U+0A50 to U+0A74
						case '\u0A50':
							if (RepairISCIIProposals == true)
								sOutput.Append('\u0A74');
							else
								sOutput.Append(cChar);
							break;

						// Convert to ☬
						// U+0A74 to U+262C
						case '\u0A74':
							if (RepairISCIIProposals == true)
								sOutput.Append('\u262C');
							else
								sOutput.Append(cChar);
							break;


						// Convert to ੱ
						// U+0A3B to U+0A71
						case '\u0A3B':
							if (RepairISCIIProposals == true)
								sOutput.Append('\u0A71');
							else
								sOutput.Append(cChar);
							break;

						// Convert to ੍ਹ
						// U+0A4E to U+0A4D + U+0A39
						case '\u0A4E':
							if (RepairISCIIProposals == true)
								sOutput.Append("\u0A4D\u0A39");
							else
								sOutput.Append(cChar);
							break;

						// Convert to ੍ਰ
						// U+0A4F to U+0A4D + U+0A30
						case '\u0A4F':
							if (RepairISCIIProposals == true)
								sOutput.Append("\u0A4D\u0A30");
							else
								sOutput.Append(cChar);
							break;

						// Convert to ।
						// U+0A64 to U+0964
						case '\u0A64':
							if (RepairISCIIProposals == true)
								sOutput.Append('\u0964');
							else
								sOutput.Append(cChar);
							break;

						// Convert to ॥
						// U+0A65 to U+0965
						case '\u0A65':
							if (RepairISCIIProposals == true)
								sOutput.Append('\u0965');
							else
								sOutput.Append(cChar);
							break;

						// Convert to ੍ਵ
						// U+0A76 to U+0A4D + U+0A35
						case '\u0A76':
							if (RepairISCIIProposals == true)
								sOutput.Append("\u0A4D\u0A35");
							else
								sOutput.Append(cChar);
							break;

						// Convert to ੍ਯ
						// U+0A78 to U+0A4D + U+0A2F
						case '\u0A78':
							if (RepairISCIIProposals == true)
								sOutput.Append("\u0A4D\u0A2F");
							else
								sOutput.Append(cChar);
							break;

						// Convert to ੀਂ
						// U+0A7D to U+0A40 + U+0A02
						case '\u0A7D':
							if (RepairISCIIProposals == true)
								sOutput.Append("\u0A40\u0A02");
							else
								sOutput.Append(cChar);
							break;

						// Convert to ਾਂ
						// U+0A7E to U+0A3E + U+0A02
						case '\u0A7E':
							if (RepairISCIIProposals == true)
								sOutput.Append("\u0A3E\u0A02");
							else
								sOutput.Append(cChar);
							break;


						default:
							if ((AfterVowel(cChar) == true &&
								IsVowel(cNext) == true) ||
								(BeforeVowel(cNext) == true &&
								IsVowel(cChar) == true))
							{
								sOutput.Append(cNext);
								sOutput.Append(cChar);
								iCounter++;
							}
							else
							{
								sOutput.Append(cChar);
							}
							break;
					}
				}
			}

			m_iPercentComplete = 100;
			Progress(m_iPercentComplete);
			return sOutput.ToString();
		}

		/// <summary>
		/// Converts a string from ASCII based Gurmukhi text to
		/// Unicode.
		/// </summary>	
		/// <param name="sInput">String to be converted.</param>
		/// <returns>Returns a converted string.</returns>
		public string Convert(string sInput)
		{
			m_bCancel = false;
			int iAddVowelSignI = 0;
			int iInputLength = sInput.Length;
			System.Text.StringBuilder sOutput = new System.Text.StringBuilder();

			sOutput.EnsureCapacity(iInputLength);

			for (int iCounter = 0; iCounter < iInputLength; iCounter++)
			{
				if (m_bCancel == true)
					break;

				Progress(m_iPercentComplete);
				m_iPercentComplete = (int)(((decimal)iCounter / (decimal)iInputLength) * 100);

				char cChar = sInput[iCounter];

				// Fixes problem with converting iq@k
				if (iAddVowelSignI == 3)
					iAddVowelSignI = 2;

				if (iAddVowelSignI == 1 && iCounter + 1 < iInputLength)
				{
					if (sInput[iCounter + 1] != '@')
						iAddVowelSignI++;
					else
						iAddVowelSignI = 3;
				}
				else if (iAddVowelSignI == 1)
				{
					iAddVowelSignI++;
				}

				switch (cChar)
				{
					// Numbers
					case '0':case '1':case '2':case '3':case '4':case '5':case '6':case '7':case '8':case '9':
						if (ConvertNumbers == true)
							sOutput.Append((char)(cChar + '\u0A36'));
						else
							sOutput.Append(cChar);
						break;

					// 1 - 9
					case 'ñ':case 'ò':case 'ó':case 'ô':case 'õ':case 'ö':case '÷':case 'ø':case 'ù':
						if (ConvertNumbers == true)
							sOutput.Append((char)(cChar + '\u0976'));
						else
							sOutput.Append((char)(cChar - '\u00C0'));
						break;
					
					// 0: 
					case 'ú':
						if (ConvertNumbers == true)
							sOutput.Append((char)(cChar + '\u096C'));
						else
							sOutput.Append((char)(cChar - '\u00CA'));
						break;

					// Special characters
					case '<': //<> - ੴ
						sOutput.Append('\u0A74');
						if(iCounter + 1 < sInput.Length && sInput[iCounter + 1] == '>')
							iCounter++;
						break;

					case 'Ç': // - ☬
						sOutput.Append('\u262C');
						break;

					case '—': // - -
						sOutput.Append('\u002D');
						break;

					// Vowel signs & misc.
					// ***When adding support for vowels, update IsVowel()***
					case 'w': //w - ਾ
						sOutput.Append('\u0A3E');
						break;
					case 'W': //W - ਾਂ
						sOutput.Append('\u0A3E');
						sOutput.Append('\u0A02');
						break;
					case 'i': //i - ਿ
						// ***Special Case Applies [ਇ]***
						if(iCounter + 1 < sInput.Length && sInput[iCounter + 1] == 'e')
						{
							sOutput.Append('\u0A07');
							iCounter++;
						}
						else
						{
							// Must be placed next time round
							if (iCounter + 1 < sInput.Length)
								iAddVowelSignI = 1;
							else
								sOutput.Append('\u0A3F');
						}
						break;
					case 'I': //I - ੀ
						sOutput.Append('\u0A40');
						break;
					case 'u': //u - ੁ
						// Error correction - force placement before ੰ or ੱ.
						if (ErrorCorrection == true && sOutput.Length > 0)
						{
							if (sOutput[sOutput.Length - 1] == '\u0A70' || sOutput[sOutput.Length - 1] == '\u0A71')
							{
								// Place before last character
								sOutput.Insert(sOutput.Length - 1, '\u0A41');
								break;
							}
						}
						sOutput.Append('\u0A41');
						break;
					case 'ü': //ü - ੁ (As above)
						goto case 'u';
					case 'U': //U - ੂ
						// Error correction - force placement before ੰ or ੱ.
						if (ErrorCorrection == true && sOutput.Length > 0)
						{
							if (sOutput[sOutput.Length - 1] == '\u0A70' || sOutput[sOutput.Length - 1] == '\u0A71')
							{
								// Place before last character
								sOutput.Insert(sOutput.Length - 1, '\u0A42');
								break;
							}
						}
						sOutput.Append('\u0A42');
						break;
					case '¨': //¨ - ੂ (As above)
						goto case 'U';
					case 'y': //y - ੇ
						sOutput.Append('\u0A47');
						break;
					case 'Y': //Y - ੈ
						sOutput.Append('\u0A48');
						break;
					case 'o': //o - ੋ
						sOutput.Append('\u0A4B');
						break;
					case 'O': //O - ੌ
						sOutput.Append('\u0A4C');
						break;
					case '@': //@ - ੍
						sOutput.Append('\u0A4D');
						break;
					case 'M': //M - ੰ
						sOutput.Append('\u0A70');
						break;
					case 'µ': //µ - ੰ (As above)
						goto case 'M';
					case '`': //` - ੰ
						sOutput.Append('\u0A71');
						break;
					case '~': //~ - ੰ (As above)
						goto case '`';
					case 'é': //é - ਂ
						sOutput.Append('\u0A02');
						break;
					case 'N': //N - ਂ (As above)
						goto case 'é';
					
					case 'æ': //æ - ਼
						sOutput.Append('\u0A3C');
						break;

					case 'Ú': //Ú - ਃ
						if (Unicode4 == true)
						{	
							sOutput.Append('\u0A03');
						}
						else
						{
							sOutput.Append('\u003A');
						}
						break;

					case 'ƒ': //ƒ - ਨੂੰ
						sOutput.Append('\u0A28');
						sOutput.Append('\u0A42');
						sOutput.Append('\u0A70');
						break;

						// Devangari | & ||
					case '[': //[ - ।
						sOutput.Append('\u0964');
						break;
					case ']': //] - ॥
						sOutput.Append('\u0965');
						break;

					// Conjuncts
					// These require re-jigging
					// certain characters because they
					// need to be placed before vowels

					case 'H': //H - ੍ਹ
						if(sOutput.Length - 1 > 0 && sOutput[sOutput.Length - 2] == '\u0A3E' && sOutput[sOutput.Length - 1] == '\u0A02')
						{
							// Place before last TWO characters
							sOutput.Insert(sOutput.Length - 2, "\u0A4D\u0A39");
						}
						else if (sOutput.Length > 0 && IsVowel(sOutput[sOutput.Length - 1]) == true)
						{
							// Place before last character
							sOutput.Insert(sOutput.Length - 1, "\u0A4D\u0A39");
						}
						else
						{
							sOutput.Append("\u0A4D\u0A39");
						}
						break;
					case '´': //´ - ੍ਹ (As above)
						goto case 'H';
					case 'R': //R - ੍ਰ
						if(sOutput.Length - 1 > 0 && sOutput[sOutput.Length - 2] == '\u0A3E' && sOutput[sOutput.Length - 1] == '\u0A02')
						{
							// Place before last TWO characters
							sOutput.Insert(sOutput.Length - 2, "\u0A4D\u0A30");
						}
						else if (sOutput.Length > 0 && IsVowel(sOutput[sOutput.Length - 1]) == true)
						{
							// Place before last character
							sOutput.Insert(sOutput.Length - 1, "\u0A4D\u0A30");
						}
						else
						{
							sOutput.Append("\u0A4D\u0A30");
						}
						break;
					case '®': //® - ੍ਰ (As above)
						goto case 'R';
					case 'Í': //Í - ੍ਵ
						if(sOutput.Length - 1 > 0 && sOutput[sOutput.Length - 2] == '\u0A3E' && sOutput[sOutput.Length - 1] == '\u0A02')
						{
							// Place before last TWO characters
							sOutput.Insert(sOutput.Length - 2, "\u0A4D\u0A35");
						}
						else if (sOutput.Length > 0 && IsVowel(sOutput[sOutput.Length - 1]) == true)
						{
							// Place before last character
							sOutput.Insert(sOutput.Length - 1, "\u0A4D\u0A35");
						}
						else
						{
							sOutput.Append("\u0A4D\u0A35");
						}
						break;
					case 'Î': //Î - ੍ਯ
						if(sOutput.Length - 1 > 0 && sOutput[sOutput.Length - 2] == '\u0A3E' && sOutput[sOutput.Length - 1] == '\u0A02')
						{
							// Place before last TWO characters
							sOutput.Insert(sOutput.Length - 2, "\u0A4D\u0A2F");
						}
						else if (sOutput.Length > 0 && IsVowel(sOutput[sOutput.Length - 1]) == true)
						{
							// Place before last character
							sOutput.Insert(sOutput.Length - 1, "\u0A4D\u0A2F");
						}
						else
						{
							sOutput.Append("\u0A4D\u0A2F");
						}
						break;

					// Normal characters
					case 'a': //a - ੳ
						// ***Special Case Applies [ਉ]***
						if(iCounter + 1 < sInput.Length && sInput[iCounter + 1] == 'u')
						{
							sOutput.Append('\u0A09');
							iCounter++;
						}
							// ***Special Case Applies [ਊ]***
						else if(iCounter + 1 < sInput.Length && sInput[iCounter + 1] == 'U')
						{
							sOutput.Append('\u0A0A');
							iCounter++;
						}
						else
						{
							sOutput.Append('\u0A73');
						}
						break;
					case 'A': //A - ਅ

						char cNextChar = '\0';

						if (iCounter + 1 < sInput.Length)
							cNextChar = sInput[iCounter + 1];

						// ***Special Case Applies [ਆਂ]***
						if(iCounter + 2 < sInput.Length && cNextChar == 'w' && sInput[iCounter + 2] == 'N')
						{
							sOutput.Append('\u0A06');
							sOutput.Append('\u0A02');
							iCounter += 2;
						}
						// ***Special Case Applies [ਆਂ]***
						else if(cNextChar == 'W')
						{
							sOutput.Append('\u0A06');
							sOutput.Append('\u0A02');
							iCounter++;
						}
						// ***Special Case Applies [ਆ]***
						else if(cNextChar == 'w')
						{
							sOutput.Append('\u0A06');
							iCounter++;
						}
						// ***Special Case Applies [ਐ]***
						else if(cNextChar == 'Y')
						{
							sOutput.Append('\u0A10');
							iCounter++;
						}
						// ***Special Case Applies [ਔ]***
						else if(cNextChar == 'O')
						{
							sOutput.Append('\u0A14');
							iCounter++;
						}
						// ***Special Case Applies [ਔ]***
						else if(cNextChar == 'o')
						{
							sOutput.Append('\u0A14');
							iCounter++;
						}
						// Error correction to automatically convert
						// text that looks like it should be right.
						else if(ErrorCorrection == true && cNextChar == 'y')
						{
							sOutput.Append('\u0A10');
							iCounter++;
						}
						else
						{
							sOutput.Append('\u0A05');
						}
						break;
					case 'e': //e - ੲ
						// ***Special Case Applies [ਈ]***
						if(iCounter + 1 < sInput.Length && sInput[iCounter + 1] == 'I')
						{
							sOutput.Append('\u0A08');
							iCounter++;
						}
							// ***Special Case Applies [ਏ]***
						else if(iCounter + 1 < sInput.Length && sInput[iCounter + 1] == 'y')
						{
							sOutput.Append('\u0A0F');
							iCounter++;
						}
						else
						{
							sOutput.Append('\u0A72');
						}
						break;
					case 's': //s - ਸ
						sOutput.Append('\u0A38');
						break;
					case 'h': //h - ਹ
						sOutput.Append('\u0A39');
						break;
					case 'k': //k - ਕ
						sOutput.Append('\u0A15');
						break;
					case 'K': //K - ਖ
						sOutput.Append('\u0A16');
						break;
					case 'g': //g - ਗ
						sOutput.Append('\u0A17');
						break;
					case 'G': //G - ਘ
						sOutput.Append('\u0A18');
						break;
					case '|': //| - ਙ
						sOutput.Append('\u0A19');
						break;
					case 'c': //c - ਚ
						sOutput.Append('\u0A1A');
						break;
					case 'C': //C - ਛ
						sOutput.Append('\u0A1B');
						break;
					case 'j': //j - ਜ
						sOutput.Append('\u0A1C');
						break;
					case 'J': //J - ਝ
						sOutput.Append('\u0A1D');
						break;
					case '\\': //\ - ਞ
						sOutput.Append('\u0A1E');
						break;
					case 't': //t - ਟ
						sOutput.Append('\u0A1F');
						break;
					case 'T': //T - ਠ
						sOutput.Append('\u0A20');
						break;
					case 'f': //f - ਡ
						sOutput.Append('\u0A21');
						break;
					case 'F': //F - ਢ
						sOutput.Append('\u0A22');
						break;
					case 'x': //x - ਣ
						sOutput.Append('\u0A23');
						break;
					case 'q': //q - ਤ
						sOutput.Append('\u0A24');
						break;
					case 'Q': //Q - ਥ
						sOutput.Append('\u0A25');
						break;
					case 'd': //d - ਦ
						sOutput.Append('\u0A26');
						break;
					case 'D': //D - ਧ
						sOutput.Append('\u0A27');
						break;
					case 'n': //n - ਨ
						sOutput.Append('\u0A28');
						break;
					case 'p': //p - ਪ
						sOutput.Append('\u0A2A');
						break;
					case 'P': //P - ਫ
						sOutput.Append('\u0A2B');
						break;
					case 'b': //b - ਬ
						sOutput.Append('\u0A2C');
						break;
					case 'B': //B - ਭ
						sOutput.Append('\u0A2D');
						break;
					case 'm': //m - ਮ
						sOutput.Append('\u0A2E');
						break;
					case 'X': //X - ਯ
						sOutput.Append('\u0A2F');
						break;
					case 'r': //r - ਰ
						sOutput.Append('\u0A30');
						break;
					case 'l': //l - ਲ 
						sOutput.Append('\u0A32');
						break;
					case 'v': //v - ਵ
						sOutput.Append('\u0A35');
						break;
					case 'V': //V - ੜ
						sOutput.Append('\u0A5C');
						break;
					case 'S': //S - ਸ਼
						sOutput.Append('\u0A36');
						break;
					case '^': //^ - ਖ਼
						sOutput.Append('\u0A59');
						break;
					case 'Z': //Z - ਗ਼
						sOutput.Append('\u0A5A');
						break;
					case 'z': //z - ਜ਼
						sOutput.Append('\u0A5B');
						break;
					case '&': //& - ਫ਼
						sOutput.Append('\u0A5E');
						break;
					case 'L': //L - ਲ਼
						sOutput.Append('\u0A33');
						break;
					case 'E': //E - ਓ
						sOutput.Append('\u0A13');
						break;
					case '¿': //¿ - ×
						sOutput.Append('\u00D7');
						break;
					case '‹': //‹ - ÷
						sOutput.Append('\u00F7');
						break;
					default:
						sOutput.Append(cChar);
						break;
				}

				//  ਿ Must be placed after constonant
				if (iAddVowelSignI == 2)
				{
					iAddVowelSignI = 0;
					sOutput.Append('\u0A3F');
				}

				if (ErrorCorrection == true)
				{
					// Remove duplicated signs (more than one character long)
					if (sOutput.Length > 3)
					{
						char[] cFirst = new char[2] {sOutput[sOutput.Length - 4], sOutput[sOutput.Length - 3]};
						char[] cSecond = new char[2] {sOutput[sOutput.Length - 2], sOutput[sOutput.Length - 1]};
						
						if (cFirst[0] == '\u0A3E' && cFirst[1] == '\u0A02' && cSecond[0] == '\u0A3E' && cSecond[1] == '\u0A02')
							sOutput.Remove(sOutput.Length - 2, 2);
					}
					
					// Remove duplicated signs (one character long)
					if (sOutput.Length > 1)
					{
						char cFirst = sOutput[sOutput.Length - 2];
						char cSecond = sOutput[sOutput.Length - 1];
						
						if (cFirst == cSecond && IsSign(cFirst))
							sOutput.Remove(sOutput.Length - 1, 1);
					}
				}
			}

			m_iPercentComplete = 100;
			Progress(m_iPercentComplete);
			return sOutput.ToString();
		}


		/// <summary>
		/// Called whenever a new character is processed. 
		/// </summary>
		/// <remarks>
		/// Currently, this method updates an optional ProgressBar 
		/// specified in the constructor.  It also processes all
		/// Window Messages at 20% intervals if ProcessMessages
		/// is set to 'true'.
		/// 
		/// Overload this method if you require more sophisticated
		/// behaviour.
		/// </remarks>
		/// <param name="iPercentComplete">The percentage of the 
		/// conversion that has been completed.</param>
		public void Progress(int iPercentComplete)
		{
			ProgressBar.Value = iPercentComplete;

			if (ProcessMessages == true && iPercentComplete % 20 == 0)
				System.Windows.Forms.Application.DoEvents();
		}

		#endregion

	}
}
