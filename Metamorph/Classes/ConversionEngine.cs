//
// Metamorph
//
// Copyright © 2004-2006 Sukhjinder Sidhu
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
// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// |                                                                   |
// | This conversion algorithm and source code is released under the   |
// | GNU General Public Licence.  Commercial applications that do not  |
// | adhear to the GNU GPL are not permitted to use any part of this   |
// | software.                                                         |
// |                                                                   |
// | Linking via non-GPL'd software is also NOT permitted.  This       |
// | software is NOT covered by the GNU Lesser General Public Licence. |
// |                                                                   |
// | Organisations wishing to licence this software for non-GPL uses   |
// | should contact the Punjabi Computing Resource Centre:             |
// |                                                                   |
// | http://guca.sourceforge.net/                                      |
// | sukhuk@users.sourceforge.net                                      |
// |                                                                   |
// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//

using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Windows.Forms;

namespace Metamorph.Classes
{
	/// <summary>
	/// The ConversionEngine is a redistributable, self-contained class
	/// designed to convert ASCII based Gurmukhi text into Unicode.
	///
	/// You may freely use this class in your program provided the 
	/// GNU GPL licensing terms are complied with.
	///
	/// Copyright © 2004-2006 Sukhjinder Sidhu.
	/// Released under the GNU General Public Licence.
	///
	/// For further information on XML comment tags, visit MSDN:
	/// /csref/html/vclrfTagsForDocumentationComments.htm
	/// </summary>
	public class ConversionEngine
	{
		
		#region Fields & Variables

        public enum CharType
        {
            Unknown,
            Consonant,
            IndependentVowel,
            VowelSign,
            NasalSign,

            Halant,
            PairinBindi,
            Adhak,
            Udaat,
            Visarg,
            Yakash
        }

        public enum ControlCharType
        {
            Halfform = '\uF15D',
            Postbase = '\uF15E',
            Subjoined = '\uF15F'
        }

        public enum Position
        {
            Left, Top, Bottom, Right, Unknown
        }

		private const string m_sVersion = "3.0";

		private static bool m_bProcessMessages = true;
        private static bool m_bCancel = false;
        private static bool m_bErrorCorrection = true;
        private static bool m_bBindiTippiCorrection = true;
        private static bool m_bConvertNumbers;

        private static System.Windows.Forms.ProgressBar m_progressBar;

		#endregion

		#region Properties

		/// <summary>
		/// Convert numbers.
		/// </summary>
        public static bool ConvertNumbers 
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
        public static bool ProcessMessages 
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
        public static System.Windows.Forms.ProgressBar ProgressBar 
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
		/// Enables error correction when converting.  Error correction does the following:
        /// 
        /// * Attempts to guess the correct combination if a vowel sign is used on the
        ///   wrong independent vowel.
        /// * Selects the most visible vowel sign if two vowel signs are in the same
        ///   position.
        /// 
        /// The conversion engine always removes duplicated vowel signs even if 
        /// error correction is disabled.
        /// 
		/// </summary>
        public static bool ErrorCorrection
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
        /// Automatically ensures that Bindi and Tippi are used with the
        /// right characters:
        /// 
        /// Tippi - Mukta + ਅ ਇ ਿੁੂ
        /// Bindi - ਉਊਓ ਆਐਔਈਏ ਾੀੇੈੋੌ
        /// 
        /// Tippi is used in all cases but Bindi.
        /// </summary>
        public static bool BindiTippiCorrection
        {
            get
            {
                return m_bBindiTippiCorrection;
            }
            set
            {
                m_bBindiTippiCorrection = value;
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
	 
		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
        public ConversionEngine()
		{
			ConvertNumbers = false;
			ProgressBar = new System.Windows.Forms.ProgressBar(); // Dummy
			ResetProgressBar();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Initialises a ProgressBar.
		/// </summary>
        private static void ResetProgressBar()
		{
			ProgressBar.Value = 0;
			ProgressBar.Maximum = 100;
			ProgressBar.Minimum = 0;
		}

		/// <summary>
		/// Cancels the current operation.
		/// </summary>
        public static void Cancel()
		{
			m_bCancel = true;
		}

		/// <summary>
		/// Lists all the mapping files found in a particular directory.
		/// </summary>	
		/// <param name="sDirectory">Directory to check.</param>
		/// <returns>An array of mapping files.</returns>
        public static string[] ListMappings(string sDirectory)
		{
			if (Directory.Exists(sDirectory) == false)
				return null;

			string[] sFiles = Directory.GetFiles(sDirectory, "*.mmf");

			if (sFiles.Length < 1)
				return null;
			else
				return sFiles;
		}

		/// <summary>
		/// Loads the selected file into and returns mapping details.
		/// </summary>	
		/// <param name="sFile">File to load.</param>
        public static MappingDetails LoadMapping(string sFile)
		{
			XmlTextReader reader = null;

			MappingDetails Details = new MappingDetails();
			Details.sFileName = sFile;

            try 
            {
                // Load the reader with the data file and ignore all white space nodes.         
                reader = new XmlTextReader(sFile);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.
                while (reader.Read()) 
                {
                    // Wrong root node
                    if (reader.Depth == 0 && reader.NodeType == XmlNodeType.Element)
                    {
                        if(reader.Name != "metamorph-mapping")
                            return null;
                        else
                        {
                            if (reader.GetAttribute("version") != "1.0")
                            {
                                MessageBox.Show("The mapping file that is being loaded is not supported.  Please obtain an appropriate version or delete the existing file.\n\n" + sFile, "Invalid Mapping File", MessageBoxButtons.OK,  MessageBoxIcon.Error);
                                return null;
                            }
                        }
                    }

                    if (reader.Depth == 1 && reader.NodeType == XmlNodeType.Element && reader.Name == "information")
                    {
                        while (reader.Read() && reader.Depth >= 2) 
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                if (reader.Name == "from")
                                    Details.sFrom = reader.ReadString();
                                else if (reader.Name == "to")
                                    Details.sTo = reader.ReadString();
                                else if (reader.Name == "author")
                                    Details.sAuthor = reader.ReadString();
                                else if (reader.Name == "version")
                                    Details.sVersion = reader.ReadString();
                                else if (reader.Name == "description")
                                    Details.sDescription = reader.ReadString();
                                else if (reader.Name == "inputfont")
                                    Details.sInputFont = reader.ReadString();
                                else if (reader.Name == "outputfont")
                                    Details.sOutputFont = reader.ReadString();
                            }
                        }
                    } 

                    if (reader.Depth == 1 && reader.NodeType == XmlNodeType.Element && reader.Name == "prescript")
                    {
                        Details.sPreScript = reader.ReadString();
                    }

                    if (reader.Depth == 1 && reader.NodeType == XmlNodeType.Element && reader.Name == "postscript")
                    {
                        Details.sPostScript = reader.ReadString();
                    }

                    if (reader.Depth == 1 && reader.NodeType == XmlNodeType.Element && reader.Name == "optionlist")
                    {
                        while (reader.Read() && reader.Depth > 1)
                        {
                            if (reader.Depth == 2 && reader.NodeType == XmlNodeType.Element && reader.Name == "option")
                            {
                                string sName = reader.GetAttribute("name");

                                string sDescription = reader.GetAttribute("description");

                                if (sName == "" || sDescription == "")
                                    continue;

                                bool bValue = false;

                                if (reader.GetAttribute("value") == "true")
                                    bValue = true;

                                Details.AddOption(sName, sDescription, bValue);
                            }
                        }
                    }

                    if (reader.Depth == 1 && reader.NodeType == XmlNodeType.Element && reader.Name == "mapping")
                    {
                        Mapping CurrentMapping = new Mapping();

                        while (reader.Read() && reader.Depth > 1) 
                        {
                            if (reader.Depth == 2 && reader.NodeType == XmlNodeType.Element && reader.Name == "convert")
                            {
                                string[] sSplit = reader.GetAttribute("from").Split((" ").ToCharArray(), 7);
								
                                int iSize = sSplit.GetUpperBound(0) + 1;

                                if (iSize > 12)
                                    iSize = 12;

                                for (int i = 0; i < iSize; i++)
                                {
                                    try 
                                    {
									
                                        if (sSplit[i] != "")
                                            CurrentMapping.cConvertFrom[i] = (char)Int32.Parse(sSplit[i], System.Globalization.NumberStyles.HexNumber);
                                    }
                                    catch (Exception ex)
                                    {}
                                }
                                sSplit = reader.GetAttribute("to").Split((" ").ToCharArray(), 13);
								
                                iSize = sSplit.GetUpperBound(0) + 1;

                                if (iSize > 12)
                                    iSize = 12;

                                for (int i = 0; i < iSize; i++)
                                {
                                    try 
                                    {
                                        if (sSplit[i] != "")
                                            CurrentMapping.cConvertTo[i] = (char)Int32.Parse(sSplit[i], System.Globalization.NumberStyles.HexNumber);
									
                                    }
                                    catch (Exception ex)
                                    {}
                                }

                                CurrentMapping.sOption = reader.GetAttribute("option");
                            }
                        }
                        Details.Mappings.Add(CurrentMapping);
                    }       
                }           
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An unexpected error occured while loading the specified mapping file: \n" + ex.Message, "Metamorph", MessageBoxButtons.OK, MessageBoxIcon.Error);
				
                if (reader!=null)
                    reader.Close();

                return null;
            }

            if (reader!=null)
				reader.Close();

            return Details;
		}     


        // Returns the positioning of the vowel
        private static Position VowelPosition(char cChar)
        {
            int iCharInt = cChar;
            switch (iCharInt)
            {
                case '\u0A3F': // ਿ U+0A3F
                    return Position.Left;

                case '\u0A47': // ੇ U+0A47
                    return Position.Top;

                case '\u0A48': // ੈ U+0A48
                    return Position.Top;

                case '\u0A4B': // ੋ U+0A4B
                    return Position.Top;

                case '\u0A4C': // ੌ U+0A4C
                    return Position.Top;

                case '\u0A41': // ੁ U+0A41
                    return Position.Bottom;

                case '\u0A42': // ੂ U+0A42
                    return Position.Bottom;

                case '\u0A40': // ੀ U+0A40
                    return Position.Right;

                default:
                    return Position.Unknown;
            }
        }

		// Returns the type of character behaviour wise
        private static CharType CharacterType(char cChar)
		{
			int iCharInt = cChar;

			// If outside of Gurmukhi range, return undefined.
			if (iCharInt < '\u0A00' || iCharInt > '\u0A7F' )
                return CharType.Unknown;

            // Independent vowel
            if ((iCharInt >= '\u0A05' && iCharInt <= '\u0A14'))
                return CharType.IndependentVowel;

			// Consonants (Based on the Devanagari range so that
            // new charaters added in corresponding positions will
            // be recognised.)
            if ((iCharInt >= '\u0A15' && iCharInt <= '\u0A39') || 
				(iCharInt >= '\u0A58' && iCharInt <= '\u0A5F') )
				return CharType.Consonant;

            // These are classed as consonants even though in
            // reality they are not.  
            if ((iCharInt >= '\u0A72' && iCharInt <= '\u0A74'))
				return CharType.Consonant;

			// Vowel Sign
			if (iCharInt >= '\u0A3E' && iCharInt <= '\u0A4C')
				return CharType.VowelSign;

			switch (iCharInt)
			{
				case '\u0A01': // Adhak Bindi
					return CharType.NasalSign;

				case '\u0A02': // Bindi
					return CharType.NasalSign;

				case '\u0A03': // Visarg
                    return CharType.Visarg;

				case '\u0A3C': // Pairin Bindi [Nukta]
					return CharType.PairinBindi;

				case '\u0A4D': // Halant [Virama]
					return CharType.Halant;

                case '\u0A51': // Udaat (Should be in Unicode 5.1)
                    return CharType.Udaat;

				case '\u0A70': // Tippi
					return CharType.NasalSign;

                case '\u0A71': // Adhak
                    return CharType.Adhak;

                case '\u0A75': // Yakash (Should be in Unicode 5.1)
                    return CharType.Yakash;

				default:
					return CharType.Unknown;
			}
		}

        // Returns true if the current string contains a consonant
        private static bool ContainsConsonant(string sString)
        {
            foreach (char cChar in sString)
            {
                if (cChar >= '\uF110' && cChar <= '\uF132')
                    return true;
            }

            return false;
        }

        // Returns true if the current char is a consonant
        private static bool ContainsConsonant(char cChar)
        {
            return IsConsonant(cChar);
        }

        private static bool IsConsonant(char cChar)
        {
            if (cChar >= '\uF110' && cChar <= '\uF132')
                return true;
            else
                return false;
        }

        /// <summary>
		/// Removes endings from words to get the lexeme or root.
		/// </summary>	
		/// <param name="sInput">String to be processed.</param>
		/// <returns>Returns a processed string.</returns>

        public static string Stem(string sInput)
        {
            //TODO, doesn't work with the last word on new line
            //Need to split based on non-Gurmukhi characters
            string[] words = sInput.Split(new char[]{' '});

            string sOutput = "";

            foreach (string word in words)
            {
                if (word.Length == 0)
                {
                    sOutput += " ";
                    continue;
                }

                //TODO - Remove Pairin Bindi based on option
                word.Replace("਼", "");
                word.Replace("ਲ਼", "ਲ");
                word.Replace("ਸ਼", "ਸ");
                word.Replace("ਖ਼", "ਖ");
                word.Replace("ਗ਼", "ਗ");
                word.Replace("ਜ਼", "ਜ");
                word.Replace("ਫ਼", "ਫ");
                
                //Remove endings
                if (word.EndsWith("ੀਆਂ") || word.EndsWith("ਿਆਂ"))
                    sOutput += word.Substring(0, word.Length - 3);
                else if (word.EndsWith("ਾਂ") || word.EndsWith("ਆਂ") || word.EndsWith("ੀਏ")
                    || word.EndsWith("ੀਆ") || word.EndsWith("ੀਅ"))
                    sOutput += word.Substring(0, word.Length - 2);
                else if (word.EndsWith("ਾ") || word.EndsWith("ੇ") || word.EndsWith("ੀ")
                    || word.EndsWith("ਆਂ") || word.EndsWith("ਆ") || word.EndsWith("ਅ")
                    || word.EndsWith("ਏ"))
                    sOutput += word.Substring(0, word.Length - 1);
                else
                    sOutput += word;

                sOutput += " ";
            }

            return sOutput;
        }

        /// <summary>
		/// Converts a Unicode Gurmukhi string to WX notation.
		/// </summary>	
		/// <param name="sInput">String to be converted.</param>
		/// <returns>Returns a converted string.</returns>

        public static string ConvertToWX(string sInput)
        {
            // Based on the algorithm listed: http://codeconverters.sarovar.org/Algorithm 
            // Modified for Gurmukhi

            bool bConsFlag = false;
            bool bAdhak = false;

            string sOutput = "";

            for (int i = 0; i < sInput.Length; i++)
            {
                if ((sInput[i] > '\u0A00' && sInput[i] < '\u0A80') || sInput[i] == '\u0964' || sInput[i] == '\u0965')
                {
                    // Adhak
                    if (sInput[i] == '\u0A71')
                    {
                        bAdhak = true;
                    }
                    // Consonant
                    else if ((sInput[i] > '\u0A14' && sInput[i] < '\u0A3C') || (sInput[i] > '\u0A57' && sInput[i] < '\u0A60'))
                    {
                        if (bConsFlag)
                            sOutput += "a";
                        else
                            bConsFlag = true;

                        // Pass ਸ਼, ਲ਼, ੜ੍ਹ as one character
                        string sSingleChar = sInput[i].ToString();

                        // StartWith is not used because it is culture sensitive and causes
                        // problems when comparing Halant based characters

                        if (sInput.Substring(i).Length >= 2 && sInput.Substring(i, 2) == "ਸ਼")
                        {
                            sSingleChar = "ਸ਼";
                            i++;
                        }
                        else if (sInput.Substring(i).Length >= 2 && sInput.Substring(i, 2) == "ਲ਼")
                        {
                            sSingleChar = "ਲ਼";
                            i++;
                        }
                        else if (sInput.Substring(i).Length >= 3 && sInput.Substring(i, 3) == "ੜ੍ਹ")
                        {
                            sSingleChar = "ੜ੍ਹ";
                            i++;
                            i++;
                        }

                        sOutput += ConvertCharToWX(sSingleChar);

                        // Pass Adhak as the next character twice over.
                        if (bAdhak)
                        {
                            sOutput += ConvertCharToWX(sSingleChar);
                            bAdhak = false;
                        }
                    }
                    // Halant [Virama]
                    else if (sInput[i] == '\u0A4D')
                    {
                        bConsFlag = false;
                        bAdhak = false;
                    }
                    // Nasal Sign or Visarg
                    else if ((sInput[i] >= '\u0A01' && sInput[i] <= '\u0A03') || sInput[i] == '\u0A70')
                    {
                        if (bConsFlag)
                            sOutput += "a";

                        bConsFlag = false;
                        bAdhak = false;

                        sOutput += ConvertCharToWX(sInput[i]);
                    }
                    else
                    {
                        bConsFlag = false;
                        bAdhak = false;
                        sOutput += ConvertCharToWX(sInput[i]);
                    }
                }
                else
                {
                    if (bConsFlag)
                    {
                        sOutput += "a";
                        bConsFlag = false;
                        bAdhak = false;
                    }
                    sOutput += sInput[i];
                }
            }

            //Final 'a'
            if (bConsFlag)
                sOutput += "a";

            return sOutput;
        }


        private static string ConvertCharToWX(char cChar)
        {
            return ConvertCharToWX(cChar.ToString());
        }
        /// <summary>
		/// Converts a character from Unicode to WX notation.
		/// </summary>	
		/// <param name="cChar">Char to be converted.</param>
		/// <returns>Returns a converted string.</returns>
        private static string ConvertCharToWX(string cChar)
        {
            switch (cChar)
            {
                case "ਅ":
                    return "a";
                case "ਆ":
                    return "A";
                case "ਾ":
                    return "A";
                case "ਇ":
                    return "i";
                case "ਿ":
                    return "i";
                case "ਈ":
                    return "I";
                case "ੀ":
                    return "I";
                case "ਉ":
                    return "u";
                case "ੁ":
                    return "u";
                case "ਊ":
                    return "U";
                case "ੂ":
                    return "U";
                case "ਏ":
                    return "e";
                case "ੇ":
                    return "e";
                case "ਐ":
                    return "E";
                case "ੈ":
                    return "E";
                case "ਓ":
                    return "o";
                case "ੋ":
                    return "o";
                case "ਔ":
                    return "O";
                case "ੌ":
                    return "O";
                case "ੰ":
                    return "M";
                case "ਂ":
                    return "M";
                case "ਃ":
                    return "H";
                case "ਁ":
                    return "z";
                case "ਕ":
                    return "k";
                case "ਖ":
                    return "K";
                case "ਗ":
                    return "g";
                case "ਘ":
                    return "G";
                case "ਙ":
                    return "f";
                case "ਚ":
                    return "c";
                case "ਛ":
                    return "C";
                case "ਜ":
                    return "j";
                case "ਝ":
                    return "J";
                case "ਞ":
                    return "F";
                case "ਟ":
                    return "t";
                case "ਠ":
                    return "T";
                case "ਡ":
                    return "d";
                case "ਢ":
                    return "D";
                case "ਣ":
                    return "N";
                case "ਤ":
                    return "w";
                case "ਥ":
                    return "W";
                case "ਦ":
                    return "x";
                case "ਧ":
                    return "X";
                case "ਨ":
                    return "n";
                case "ਪ":
                    return "p";
                case "ਫ":
                    return "P";
                case "ਬ":
                    return "b";
                case "ਭ":
                    return "B";
                case "ਮ":
                    return "m";
                case "ਯ":
                    return "y";
                case "ਰ":
                    return "r";
                case "ਲ":
                    return "l";
                case "ਵ":
                    return "v";
                case "ਸ":
                    return "s";
                case "ਹ":
                    return "h";
                case "ੜ":
                    return "dZ";
                case "ੜ੍ਹ":
                    return "DZ";
                case "ਸ਼":
                    return "S";
                case "ਸ਼":
                    return "S";
                case "ਲ਼":
                    return "lY";
                case "ਲ਼":
                    return "lY";
                case "ਖ਼":
                    return "KZ";
                case "ਗ਼":
                    return "gZ";
                case "ਜ਼":
                    return "jZ";
                case "ਫ਼":
                    return "PZ";
                case "਼":
                    return "Z";

                // Not strictly WX, but gets rid of extra characters
                case "।":
                    return "|";
                case "॥":
                    return "||";

                case "੦":
                    return "0";
                case "੧":
                    return "1";
                case "੨":
                    return "2";
                case "੩":
                    return "3";
                case "੪":
                    return "4";
                case "੫":
                    return "5";
                case "੬":
                    return "6";
                case "੭":
                    return "7";
                case "੮":
                    return "8";
                case "੯":
                    return "9";
                
                default:
                    return cChar;
            }
        }

		/// <summary>
		/// Converts a string from Gurmukhi IEF based text to Unicode.
		/// 
		/// This method implements a syllable analysing technique
		/// to determine the Unicode sequence of characters.
		/// </summary>	
		/// <param name="sInput">String to be converted.</param>
		/// <returns>Returns a converted string.</returns>

        public static string ConvertToUnicode(string sInput)
		{
			// Find all syllable blocks and place them in an array for
			// processing.
			//
			// Although not syllables, these are processed as such to
			// maintain punctuation and formatting:
			//
			// * From non-Gurmukhi char to next Gurmukhi char.
			// * From non-Gurmukhi char to the end of text.
			// 
			// A non-Gurmukhi char is defined as none of the consonants,
			// vowels or signs used in Gurmukhi.  This includes Dandi
			// and Ek Onkar.  It does NOT include Visarg.
			//
			int iInputLength = sInput.Length;
			ArrayList sSyllables = new ArrayList(200);

            StringBuilder sCurrentSyllable = new StringBuilder(6);

			m_progressBar.Value = 0;
			m_progressBar.Minimum = 0;
			m_progressBar.Maximum = iInputLength;

            foreach (char cCurrent in sInput)
			{
				m_progressBar.Increment(1);

				if (m_bCancel == true)
					break;

				// Is the current syllable empty?  If so add the current character
				if (sCurrentSyllable.Length == 0)
				{
                    sCurrentSyllable.Append(cCurrent);
				}
				else
				{					
					//If left side vowel sign
                    if (cCurrent == '\uF171')
					{
						sSyllables.Add(sCurrentSyllable);
                        sCurrentSyllable = new System.Text.StringBuilder(6);
					}
					// If non-Gurmukhi character
                    else if (cCurrent < '\uF100' || cCurrent > '\uF1FF' ||
                        (cCurrent >= '\uF10B' && cCurrent <= '\uF10E'))
					{
						sSyllables.Add(sCurrentSyllable);
						sCurrentSyllable = new System.Text.StringBuilder(6);
					}
                    // If consonant and last char not halant [virama] and
                    // (first char of syllable != sihari) 
                    // or (size of current syllable > 1 && first char of syllable == sihari))
                    else if (IsConsonant(cCurrent) &&
                        (sCurrentSyllable[sCurrentSyllable.Length - 1] != (char)ControlCharType.Halfform && sCurrentSyllable[sCurrentSyllable.Length - 1] != (char)ControlCharType.Postbase && sCurrentSyllable[sCurrentSyllable.Length - 1] != (char)ControlCharType.Subjoined) &&
                        (sCurrentSyllable[0] != '\uF171' || (sCurrentSyllable.Length > 1 && sCurrentSyllable[0] == '\uF171')))
					{
						sSyllables.Add(sCurrentSyllable);
						sCurrentSyllable = new System.Text.StringBuilder(6);
					}

                    sCurrentSyllable.Append(cCurrent);
				}
			}

			sSyllables.Add(sCurrentSyllable);

			StringBuilder sReturn = new System.Text.StringBuilder(100);
				
			m_progressBar.Value = 0;
			m_progressBar.Minimum = 0;
			m_progressBar.Maximum = sSyllables.Count;

			for (int iCounter = 0; iCounter < sSyllables.Count; iCounter++)
			{
				m_progressBar.Increment(1);

				if (m_bCancel == true)
					break;

				StringBuilder sCurrent = (StringBuilder)sSyllables[iCounter];
				StringBuilder sUnicode = new StringBuilder();
				StringBuilder sOutput = new StringBuilder();
			
				// Convert everything into Unicode
				for (int i = 0; i < sCurrent.Length; i++)
				{
					String sConvert = ConvertCharToUnicode(sCurrent[i]);

                    if (sUnicode.Length < sConvert.Length ||
                        (sUnicode.ToString().Substring(sUnicode.Length - sConvert.Length) != sConvert))
                    {
                        sUnicode.Append(sConvert);
                    }

				}		
	
				// USE INTELLIGENT REORDERING TO PLACE ALL SIGNS IN CORRECT ORDER

				// Position 0:  Cons [+ Pairin Bindi]
                // Position 1:  Conjunct [+ Pairin Bindi], Conjunct [+ Pairin Bindi] etc...
                // Position 1a: Udaat or Yakash
				// Position 2:  Vowel Signs
                // Position 3:  Bindi, Tippi, Adhak, Visarg, Adhak Bindi or Pairin Bindi

				string sPos0 = "";
				string sPos1 = "";
                char cUdaatYakash = '\0';
				string sPos2 = "";
				char cPos3 = '\0';


				// Step 3.  Re-arrange into correct order.
				for (int i = 0; i < sUnicode.Length; i++)
				{
					char cChar = sUnicode[i];
					CharType iCharType = CharacterType(cChar);

					char cNextChar = i + 1 < sUnicode.Length ? sUnicode[i+1] : '\0';
                    CharType iNextCharType = CharacterType(cNextChar);

					char cLastChar = i + 2 < sUnicode.Length ? sUnicode[i+2] : '\0';
                    CharType iLastCharType = CharacterType(cLastChar);
					
					if (iCharType == CharType.Unknown)
					{
						sOutput.Append(sUnicode[i]);
						continue;
					}

                    if (iCharType == CharType.VowelSign)
						sPos2 += cChar;
                    else if (iCharType == CharType.Consonant || iCharType == CharType.IndependentVowel)
					{
                        if (iNextCharType == CharType.PairinBindi)
						{
							sPos0 += cChar.ToString() + cNextChar.ToString();
							i++;
						}
						else
						{
							sPos0 += cChar.ToString();
						}
					}
                    else if (iCharType == CharType.Halant)
					{
                        if (iNextCharType == CharType.Consonant /*|| iNextCharType == CharType.IndependentVowel*/)
						{
                            // TODO May not always be desirable, so separate into another option?
                            // Remove repeated conjuncts
                            if (sPos1.IndexOf(cChar.ToString() + cNextChar.ToString()) > -1 && ErrorCorrection)
                            {
                                i++;
                            }
                            else if (iLastCharType == CharType.PairinBindi)
							{
								sPos1 += cChar.ToString() + cNextChar.ToString() + cLastChar.ToString();
								i++;
								i++;
							}
							else
							{
								sPos1 += cChar.ToString() + cNextChar.ToString();
								i++;
							}
						}
						else
						{
							sPos1 += cChar.ToString();
						}
					}
                    else if (iCharType == CharType.Udaat || iCharType == CharType.Yakash)
                    {
                        cUdaatYakash = cChar;
                    }
                    else if (iCharType == CharType.PairinBindi && ErrorCorrection)
                    {
                        sPos1 += cChar.ToString();
                    }
                    else
                    {
                        cPos3 = cChar;
                    }

				}

				// Convert sPos0[0] + sPos2 into appropriate independent vowels

                // TODO - Lots of code repetition here, may wish to create a function

				// Ura ੳ
				if (sPos0 == "\u0A73")
				{
                    // Ordered for visiblity purposes
					// ਓ
					if (sPos2.IndexOf("\u0A4B") != -1)
					{
						sPos0 = "\u0A13";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A4B", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A4B")) + sPos2.Substring(sPos2.IndexOf("\u0A4B") + 1);
					}
					// ਊ
					else if (sPos2.IndexOf("\u0A42") != -1)
					{
						sPos0 = "\u0A0A";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A42", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A42")) +  sPos2.Substring(sPos2.IndexOf("\u0A42") + 1);
					}
                    // ਉ
					else if (sPos2.IndexOf("\u0A41") != -1)
					{
						sPos0 = "\u0A09";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A41", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A41")) + sPos2.Substring(sPos2.IndexOf("\u0A41") + 1);
					}
				}
				// Aira ਅ
				else if (sPos0 == "\u0A05")
				{
					// ਆ
					if (sPos2.IndexOf("\u0A3E") != -1)
					{
						sPos0 = "\u0A06";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A3E", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A3E")) + sPos2.Substring(sPos2.IndexOf("\u0A3E") + 1);
					}
					// ਐ
					else if (sPos2.IndexOf("\u0A48") != -1)
					{
						sPos0 = "\u0A10";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A48", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A48")) + sPos2.Substring(sPos2.IndexOf("\u0A48") + 1);
					}
					// ਔ
					else if (sPos2.IndexOf("\u0A4C") != -1)
					{
						sPos0 = "\u0A14";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A4C", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A4C")) + sPos2.Substring(sPos2.IndexOf("\u0A4C") + 1);
					}
                    // ਅੇ -> ਐ [If error correction is enabled]
                    else if (sPos2.IndexOf("\u0A47") != -1 && ErrorCorrection)
                    {
                        sPos0 = "\u0A10";
                        sPos2 = sPos2.Replace("\u0A47", "");
                    }
				}
				// Iri ੲ
				else if (sPos0 == "\u0A72")
				{
					// ਇ
					if (sPos2.IndexOf("\u0A3F") != -1)
					{
						sPos0 = "\u0A07";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A3F", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A3F")) + sPos2.Substring(sPos2.IndexOf("\u0A3F") + 1);
					}
					// ਈ
					else if (sPos2.IndexOf("\u0A40") != -1)
					{
						sPos0 = "\u0A08";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A40", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A40")) + sPos2.Substring(sPos2.IndexOf("\u0A40") + 1);
					}
					// ਏ
					else if (sPos2.IndexOf("\u0A47") != -1)
					{
						sPos0 = "\u0A0F";
                        if (ErrorCorrection)
                            sPos2 = sPos2.Replace("\u0A47", "");
                        else
                            sPos2 = sPos2.Substring(0, sPos2.IndexOf("\u0A47")) + sPos2.Substring(sPos2.IndexOf("\u0A47") + 1);
					}

                    // ੲੈ -> ਏ [If error correction is enabled]
                    else if (sPos2.IndexOf("\u0A48") != -1 && ErrorCorrection)
                    {
                        sPos0 = "\u0A0F";
                        sPos2 = sPos2.Replace("\u0A48", "");
                    }
				}

				sOutput.Append(sPos0);
				sOutput.Append(sPos1);

                // Udaat or Yakash come after consonants and conjuncts, but before vowels.
                if (cUdaatYakash != '\0')
                    sOutput.Append(cUdaatYakash);
				
                // This section sorts the vowel signs
                // Then orders them based on their position
				if (sPos2 != "")
				{
                    bool bLeft = false;
                    bool bTop = false;
                    bool bBottom = false;
                    bool bRight = false;
                    
                    string sUnknown = "";
                    char cLeft = '\0';
                    char cTop = '\0';
                    char cBottom = '\0';
                    char cRight = '\0';
                    
                    char [] cRepositioned = sPos2.ToCharArray();
                    Array.Sort(cRepositioned);
                    sPos2 = new string(cRepositioned);

                    // Order the vowels

                    // First come, first served apart from in the
                    // following cases if error correction is enabled:

                    // ੌ over ੋ
                    // ੈ over ੇ
                    // ੂ over ੁ

                    for (int i = 0; i < sPos2.Length; i++)
                    {
                        Position iPosition = VowelPosition(sPos2[i]);
                        if (iPosition == Position.Left && bLeft == false)
                        {
                            bLeft = true;
                            cLeft = sPos2[i];
                        }
                        else if (iPosition == Position.Top /*&& bTop == false*/)
                        {
                            if ((sPos2[i] == 'ੌ' && cTop == 'ੋ' && ErrorCorrection) ||
                                (sPos2[i] == 'ੈ' && cTop == 'ੇ' && ErrorCorrection) ||
                                bTop == false)
                            {
                                bTop = true;
                                cTop = sPos2[i];
                            }
                        }
                        else if (iPosition == Position.Bottom /*&& bBottom == false*/)
                        {
                            if ((sPos2[i] == 'ੂ' && cBottom == 'ੁ' && ErrorCorrection) ||
                                bBottom == false)
                            {
                                bBottom = true;
                                cBottom = sPos2[i];
                            }
                        }
                        else if (iPosition == Position.Right && bRight == false)
                        {
                            bRight = true;
                            cRight = sPos2[i];
                        }
                        else if (iPosition == Position.Unknown)
                        {
                            sUnknown += sPos2[i];
                        }
                    }
	
                    if (ErrorCorrection)
                    {
                        if (sPos0.Contains("ਏ") || sPos0.Contains("ਈ") ||
                            sPos0.Contains("ਔ") || sPos0.Contains("ਐ") ||
                            sPos0.Contains("ਓ"))
                        {
                            bTop = false;
                        }

                        if (sPos0.Contains("ਊ") || sPos0.Contains("ਉ"))
                        {
                            bTop = false;
                            bBottom = false;
                        }
                    }

                    if (bLeft)
					    sOutput.Append(cLeft);

                    if (bTop)
                        sOutput.Append(cTop);
                    
                    if (bBottom)
                        sOutput.Append(cBottom);

                    if (bRight)
                        sOutput.Append(cRight);

                    sOutput.Append(sUnknown);
				}

                if (cPos3 != '\0')
                {
                    if (BindiTippiCorrection && (cPos3 == '\u0A02' || cPos3 == '\u0A70'))
                    {
                        // Tippi - Mukta + ਅ ਇ ਿੁੂ
                        // Bindi - ਉਊਓ ਆਐਔਈਏ ਾੀੇੈੋੌ
                        //
                        // Use Tippi in all cases but Bindi
                        // This may seem long winded (i.e. the other way seems faster)
                        // but this is necessary due to issues with double vowel signs
                        if (sPos0.Contains("ੳ") || sPos0.Contains("ਉ") || sPos0.Contains("ਊ") ||
                            sPos0.Contains("ਓ") || sPos0.Contains("ਆ") ||
                            sPos0.Contains("ਐ") || sPos0.Contains("ਔ") ||
                            sPos0.Contains("ਈ") || sPos0.Contains("ਈ") ||
                            sPos0.Contains("ਏ") || sPos2.Contains("ਾ") ||
                            sPos2.Contains("ਾ") || sPos2.Contains("ੀ") ||
                            sPos2.Contains("ੇ") || sPos2.Contains("ੈ") ||
                            sPos2.Contains("ੋ") || sPos2.Contains("ੌ"))
                        {
                            sOutput.Append('\u0A02');
                        }
                        else if (sPos0.Length > 0)
                        {
                            sOutput.Append('\u0A70');
                        }
                        else
                        {
                            sOutput.Append(cPos3);
                        }
                    }
                    else
                    {
                        sOutput.Append(cPos3);
                    }
                }

				sReturn.Append(sOutput);
			}

			m_progressBar.Value = 0;

			return sReturn.ToString();
		}

		/// <summary>
		/// Converts a character from the Gurmukhi IEF to Unicode.
		/// </summary>	
		/// <param name="cChar">Char to be converted.</param>
		/// <returns>Returns a converted string.</returns>
        private static string ConvertCharToUnicode(char cChar)
		{
            // Convert numbers
            if (cChar >= '\uF100' && cChar <= '\uF109')
            {
                if (Settings.NumberConversion == Settings.NumberConversionType.Latin)
                    return ((char)(cChar - '\uF0D0')).ToString();
                else
                    return ((char)(cChar - '\uE69A')).ToString();
            }
            else if (cChar >= '\u0030' && cChar <= '\u0039')
            {
                if (Settings.NumberConversion == Settings.NumberConversionType.Gurmukhi)
                    return ((char)(cChar + '\u0A36')).ToString();                    
            }

			// Return characters outside of the IEF range
            if (cChar < '\uF100' || cChar > '\uF1FF')
				return cChar.ToString();

            switch (cChar)
			{
				case '\uF10B':
					return "ੴ";

				case '\uF10C':
					return "☬";

				case '\uF10D':
					return "।";

				case '\uF10E':
					return "॥";

				case '\uF110':
					return "ੳ";

				case '\uF111':
					return "ਅ";

				case '\uF112':
					return "ੲ";

				case '\uF113':
					return "ਸ";

				case '\uF114':
					return "ਹ";

				case '\uF115':
					return "ਕ";

				case '\uF116':
					return "ਖ";

				case '\uF117':
					return "ਗ";

				case '\uF118':
					return "ਘ";

				case '\uF119':
					return "ਙ";

				case '\uF11A':
					return "ਚ";

				case '\uF11B':
					return "ਛ";

				case '\uF11C':
					return "ਜ";

				case '\uF11D':
					return "ਝ";

				case '\uF11E':
					return "ਞ";

				case '\uF11F':
					return "ਟ";

				case '\uF120':
					return "ਠ";

				case '\uF121':
					return "ਡ";

				case '\uF122':
					return "ਢ";

				case '\uF123':
					return "ਣ";

				case '\uF124':
					return "ਤ";

				case '\uF125':
					return "ਥ";

				case '\uF126':
					return "ਦ";

				case '\uF127':
					return "ਧ";

				case '\uF128':
					return "ਨ";

				case '\uF129':
					return "ਪ";

				case '\uF12A':
					return "ਫ";

				case '\uF12B':
					return "ਬ";

				case '\uF12C':
					return "ਭ";

				case '\uF12D':
					return "ਮ";

				case '\uF12E':
					return "ਯ";

				case '\uF12F':
					return "ਰ";

				case '\uF130':
					return "ਲ";

				case '\uF131':
					return "ਵ";

				case '\uF132':
					return "ੜ";
				
                // Control characters for conjunct formation

                // Unicode includes no way of specifically distinguishing
                // between post-base and subjoined forms of a consonant.

                case '\uF15D':  // C1
                    return "੍\u200D"; // Virama + ZWJ

                case '\uF15E':  // C2 
                    return "੍";

                case '\uF15F':  // SUB
                    return "੍";

                // Special cases

				case '\uF161':  // Yakash
					return "\u0A75";

                case '\uF162':  // Udaat
                    return "\u0A51";
                
                // TODO 
                // Reph Rara requires special repositioning behaviour
                // It is currently not implemented correctly
                //
                // It is an extremely rare and archaic form,
                // character so it should not pose an issue for most
                // uses
                case '\uF163':  // Reph Rara
                    return "ਰ੍\u200D"; // Ra + Virama + ZWJ

				// Vowels and other signs

				case '\uF170':
					return "ਾ";

				case '\uF171':
					return "ਿ";

				case '\uF172':
					return "ੀ";

				case '\uF173':
					return "ੁ";

				case '\uF174':
					return "ੂ";

				case '\uF175':
					return "ੇ";

				case '\uF176':
					return "ੈ";

				case '\uF177':
					return "ੋ";

				case '\uF178':
					return "ੌ";

				case '\uF179': // Halant [Virama]
                    return "੍\u200C"; // Virama + ZWNJ

				case '\uF17A':
					return "਼";

				case '\uF17B':
					return "ਂ";

				case '\uF17C':
					return "ੰ";

				case '\uF17D':
					return "ੱ";

				case '\uF17E':
					return "ਃ";

				default: 
					return "";
			}	
		}

		/// <summary>
		/// Converts text based on the mapping file currently
		/// in memory.
		/// </summary>	
		/// <param name="sInput">String to be converted.</param>
		/// <returns>Returns the converted string.</returns>
        public static string Convert(string sInput, MappingDetails mappingDetails)
		{
            if (mappingDetails.bInternal)
            {
                if (mappingDetails.sFrom == "__gurmukhi__" && mappingDetails.sTo == "Unicode")
                {
                    return ConvertToUnicode(sInput);
                }
                else if (mappingDetails.sFrom == "__gurmukhiunicode__" && mappingDetails.sTo == "WX Notation")
                {
                    return ConvertToWX(sInput);
                }
                else if (mappingDetails.sFrom == "__gurmukhiunicode__" && mappingDetails.sTo == "Stemmed")
                {
                    return Stem(sInput);
                }
                else
                {
                    return sInput;
                }
            }

			m_bCancel = false;
			
			Scripter preScripter;
			Scripter postScripter;

            if (mappingDetails.sPreScript.Length > 0)
			{
                preScripter = new Scripter(mappingDetails.sPreScript, sInput);
				sInput = preScripter.Text.ToString();
			}

			int iInputLength = sInput.Length;
			System.Text.StringBuilder sOutput = new System.Text.StringBuilder(iInputLength);

            IEnumerator Iter = mappingDetails.Mappings.GetEnumerator();

			
			for (int iCounter = 0; iCounter < iInputLength; iCounter++)
			{
				if (m_bCancel == true)
					break;

				//Progress(m_iPercentComplete);
				//m_iPercentComplete = (int)(((decimal)iCounter / (decimal)iInputLength) * 100);

				Iter.Reset();
				bool bMatches = true;
				Mapping CurrentMapping = new Mapping();
				String sAppend = "";

				while(Iter.MoveNext())
				{					
					CurrentMapping = (Mapping)Iter.Current;

					bMatches = true;
					int iCycle = 0;

					for (int iMap = 0; iMap < 12; iMap++)
					{
						if (CurrentMapping.cConvertFrom[iMap] == '\0' && iMap == 0)
						{
							bMatches = false;
							break;
						}

						if (CurrentMapping.cConvertFrom[iMap] == '\0')
							break;

						if (iCounter + iMap < iInputLength)
						{
							if(CurrentMapping.cConvertFrom[iMap] !=  sInput[iCounter + iMap])
							{
								bMatches = false;
								break;
							}
						}
						else
						{
							bMatches = false;
							break;
						}

						iCycle++;
					}

					if (bMatches == true)
					{
						for (int iMap = 0; iMap < 12; iMap++)
						{
							if (CurrentMapping.cConvertTo[iMap] == '\0')
								break;

							sAppend += Char.ToString(CurrentMapping.cConvertTo[iMap]);
						}

						if (iCycle > 1)
							iCounter += iCycle - 1;

						break;
					}	
				}

				if (bMatches == false)
				{
					sOutput.Append(sInput[iCounter]);
				}
				else
				{
					sOutput.Append(sAppend);
				}

			}


            if (mappingDetails.sPostScript.Length > 0)
			{
                postScripter = new Scripter(mappingDetails.sPostScript, sOutput.ToString());
				return postScripter.Text.ToString();
			}
			else
			{
				return sOutput.ToString();
			}
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
        public static void Progress(int iPercentComplete)
		{
			ProgressBar.Value = iPercentComplete;

			if (ProcessMessages == true && iPercentComplete % 20 == 0)
				System.Windows.Forms.Application.DoEvents();
		}

		
		#endregion
	}
}