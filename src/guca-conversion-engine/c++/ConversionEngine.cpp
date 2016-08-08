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
#include "ConversionEngine.h"

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
/// 
/// This is the C++ port of the C# source code.  The class is 
/// platform independent.
///
/// </summary>

/// <summary>
/// Automatic error correction.
/// </summary>
bool ConversionEngine::get_ErrorCorrection() 
{
	return m_bErrorCorrection;
}
void ConversionEngine::set_ErrorCorrection(bool value)
{
	m_bErrorCorrection = value;
}


/// <summary>
/// Convert numbers.
/// </summary>
bool ConversionEngine::get_ConvertNumbers() 
{
	return m_bConvertNumbers;
}
void ConversionEngine::set_ConvertNumbers(bool value)
{
	m_bConvertNumbers = value;
}

/// <summary>
/// When repairing, set this option to reposition
/// the vowel sign I (U+0A3F) to the left.
/// </summary>
bool ConversionEngine::get_RepositionI() 
{
	return m_bRepositionI;
}
void ConversionEngine::set_RepositionI(bool value)
{
	m_bRepositionI = value;
}

/// <summary>
/// Repairs any text that was created using ISCII (1991) 
/// proposed extensions which were not implemented into 
/// the Unicode 4.0 standard.  This is not normally 
/// required as VERY few Gurmukhi Unicode fonts have 
/// these additions.
/// </summary>
bool ConversionEngine::get_RepairISCIIProposals() 
{
	return m_bRepairISCIIProposals;
}
void ConversionEngine::set_RepairISCIIProposals(bool value)
{
	m_bRepairISCIIProposals = value;
}

/// <summary>
/// Normalises text when being repaired.
/// </summary>
bool ConversionEngine::get_NormaliseText() 
{
	return m_bNormaliseText;
}
void ConversionEngine::set_NormaliseText(bool value)
{
	m_bNormaliseText = value;
}

/// <summary>
/// Specifies whether to use Unicode 4 characters.
/// </summary>
bool ConversionEngine::get_Unicode4() 
{
	return m_bUnicode4;
}
void ConversionEngine::set_Unicode4(bool value)
{
	m_bUnicode4 = value;
}

/// <summary>
/// Retrieve ConversionEngine version (Read only).
/// </summary>
std::wstring ConversionEngine::get_Version()
{
	return m_sVersion;
}

/// <summary>
/// Returns 'true' is this is a proprietary class (i.e. it
/// has been changed/updated 'unofficially' from an official
/// release). 
/// 
/// If you've changed the class, you should set this value
/// to 'true' by updating the m_bProprietary constant.
/// </summary>
bool ConversionEngine::get_Proprietary()
{
	return m_bProprietary;
}
//#endregion

//#region Constructors & Destructor

/// <summary>
/// Constructor
/// </summary>
ConversionEngine::ConversionEngine()
{
	ConversionEngine(false, false);	
}

/// <summary>
/// Constructor
/// </summary>
/// <param name="bConvertNumbers">Convert numbers.</param>
/// <param name="bErrorCorrection">Automatic error correction.</param>
ConversionEngine::ConversionEngine(bool bConvertNumbers, bool bErrorCorrection)
{
	m_bCancel = false;
	m_sVersion = L"1.1.0 (Native Win32 Implementation [C++])";
	set_ConvertNumbers(bConvertNumbers);
	set_ErrorCorrection(bErrorCorrection);
	set_RepositionI(false);
	set_RepairISCIIProposals(false);
	set_NormaliseText(true);
	set_Unicode4(true);
}

/// <summary>
/// Destructor
/// </summary>
ConversionEngine::~ConversionEngine()
{
	delete m_sVersion;
}

//#endregion

//#region Methods

/// <summary>
/// Returns whether the current character should be
/// placed after a vowel.
/// </summary>	
/// <param name="cCharacter">Character to be checked.</param>
/// <returns>Returns 'true' if the character should be placed after vowel.</returns>
bool ConversionEngine::AfterVowel(wchar_t cCharacter)
{
	// Bindi, Tippi, Addak
	// U+0A02, U+0A70, U+0A71

	if (cCharacter == L'\x0A02' ||
		cCharacter == L'\x0A70' ||
		cCharacter == L'\x0A71')
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
bool ConversionEngine::BeforeVowel(wchar_t cCharacter)
{
	// Nukta
	// U+0A3C

	if (cCharacter == L'\x0A3C')
		return true;
	else
		return false;
}

/// <summary>
/// Cancels the current operation.
/// </summary>
void ConversionEngine::Cancel()
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
bool ConversionEngine::IsVowel(wchar_t cCharacter)
{
	if (cCharacter == L'\x0A3E' ||
		cCharacter == L'\x0A3F' ||
		cCharacter == L'\x0A40' ||
		cCharacter == L'\x0A41' ||
		cCharacter == L'\x0A42' ||
		cCharacter == L'\x0A47' ||
		cCharacter == L'\x0A48' ||
		cCharacter == L'\x0A4B' ||
		cCharacter == L'\x0A4C')
		return true;
	else
		return false;
}

/// <summary>
/// Checks to see if current character is a sign.
/// </summary>	
/// <param name="cCharacter">Character to be checked for a sign.</param>
/// <returns>Returns 'true' if a sign is found.</returns>
bool ConversionEngine::IsSign(wchar_t cCharacter)
{
	if (IsVowel(cCharacter) ||
		cCharacter == L'\x0A3C' ||
		cCharacter == L'\x0A4D' ||
		cCharacter == L'\x0A70' ||
		cCharacter == L'\x0A71' ||
		cCharacter == L'\x0A02')
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
bool ConversionEngine::IsConjunct(wchar_t cCharA, wchar_t cCharB)
{
	if (cCharA != L'\x0A4D')
		return false;

	if (cCharB == L'\x0A2F' ||
		cCharB == L'\x0A30' ||
		cCharB == L'\x0A35' ||
		cCharB == L'\x0A39')
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
std::wstring ConversionEngine::Repair(std::wstring sInput)
{
	m_bCancel = false;
	int iInputLength = sInput.length();
	std::wstring sOutput = L"";

	sOutput.reserve(iInputLength);

	for (int iCounter = 0; iCounter < iInputLength; iCounter++)
	{
		if (m_bCancel == true)
			break;

		Progress(m_iPercentComplete);
		m_iPercentComplete = (int)(((double)iCounter / (double)iInputLength) * 100);

		wchar_t cChar = sInput[iCounter];

		wchar_t cNext = ' ';

		if (iCounter + 1 < iInputLength)
			cNext = sInput[iCounter + 1];

		if (!(IsSign(cChar) == true && cNext == cChar))
		{
			switch (cChar)
			{
				// ਖ਼  - U+0A59
				case L'\x0A59':
					// Convert ਖ਼ to ਖ + ਼ 
					// U+0A59 to U+0A16 + U+0A3C
					if (get_NormaliseText() == true)
						sOutput.append(L"\x0A16\x0A3C");
					else
						sOutput.push_back(cChar);
					break;

				// ਗ਼ - U+0A5A
				case L'\x0A5A':
					// Convert ਗ਼ to ਗ + ਼
					// U+0A5A to U+0A17 + U+0A3C
					if (get_NormaliseText() == true)
						sOutput.append(L"\x0A17\x0A3C");
					else
						sOutput.push_back(cChar);
					break;

				// ਜ਼- U+0A5B
				case L'\x0A5B':
					// Convert ਜ਼ to ਜ + ਼
					// U+0A5B to U+0A1C + U+0A3C
					if (get_NormaliseText() == true)
						sOutput.append(L"\x0A1C\x0A3C");
					else
						sOutput.push_back(cChar);
					break;
			
				// ਫ਼ - U+0A5E
				case L'\x0A5E':
					// Convert ਫ਼ to ਫ + ਼
					// U+0A5E to U+0A2B + U+0A3C
					if (get_NormaliseText() == true)
						sOutput.append(L"\x0A2B\x0A3C");
					else
						sOutput.push_back(cChar);
					break;

				// ਲ਼ - U+0A33
				case L'\x0A33':
					// Convert ਲ਼ to ਲ + ਼
					// U+0A33 to U+0A32 + U+0A3C
					if (get_NormaliseText() == true)
						sOutput.append(L"\x0A32\x0A3C");
					else
						sOutput.push_back(cChar);
					break;

				// ਸ਼ - U+0A36
				case L'\x0A36':
					// Convert ਸ਼ to ਸ + ਼
					// U+0A36 to U+0A38 + U+0A3C
					if (get_NormaliseText() == true)
						sOutput.append(L"\x0A38\x0A3C");
					else
						sOutput.push_back(cChar);
					break;

				// ੜ - U+0A5C
				case L'\x0A5C':
					// Convert ਡ਼ to ਡ + ਼
					// U+0A5C to 0A21 + U+0A3C
					if (get_NormaliseText() == true)
						sOutput.append(L"\x0A21\x0A3C");
					else
						sOutput.push_back(cChar);
					break;
			
				// ਅ - U+0A05
				case L'\x0A05':
					// Convert ਅ + ਾ  to ਆ
					// U+0A05 + U+0A3E to U+0A06
					if (cNext == L'\x0A3E')
					{
						sOutput.push_back(L'\x0A06');
						iCounter++;
					}
					// Convert ਅ + ੈ  to ਐ
					// U+0A05 + U+0A48 to U+0A10
					else if (cNext == L'\x0A48')
					{
						sOutput.push_back(L'\x0A10');
						iCounter++;
					}
					// Convert ਅ + ੌ to ਔ
					// U+0A05 + U+0A4C to U+0A14
					else if (cNext == L'\x0A4C')
					{
						sOutput.push_back(L'\x0A14');
						iCounter++;
					}
					// ****Proposed ISCII Extensions Repair****
					// Convert to ਆਂ
					// U+0A7E to U+0A06 + U+0A02
					else if (cNext == L'\x0A7E' && get_RepairISCIIProposals() == true)
					{
						sOutput.append(L"\x0A06\u0A02");
						iCounter++;
					}
					else
					{
						sOutput.push_back(cChar);
					}
					break;

				// ੲ - U+0A72
				case L'\x0A72':
					// Convert ੲ + ੇ to ਏ
					// U+0A72 + U+0A47 to U+0A0F
					if (cNext == L'\x0A47')
					{
						sOutput.push_back(L'\x0A0F');
						iCounter++;
					}
					// Convert ੲ + ੀ  to ਈ
					// U+0A72 + U+0A40 to U+0A08
					if (cNext == L'\x0A40')
					{
						sOutput.push_back(L'\x0A08');
						iCounter++;
					}
					// Convert ੲ + ਿ  to ਇ
					// U+0A72 + U+0A3F to U+0A07
					else if (cNext == L'\x0A3F')
					{
						sOutput.push_back(L'\x0A07');
						iCounter++;
					}
					else
					{
						sOutput.push_back(cChar);
					}
					break;

				// ੳ - U+0A73
				case L'\x0A73':
					// Convert ੳ + ੁ  to ਉ
					// U+0A73 + U+0A41 to U+0A09
					if (cNext == L'\x0A41')
					{
						sOutput.push_back(L'\x0A09');
						iCounter++;
					}
					// Convert ੳ + ੂ  to ਊ
					// U+0A73 + U+0A42 to U+0A0A
					else if (cNext == L'\x0A42')
					{
						sOutput.push_back(L'\x0A0A');
						iCounter++;
					}
					else
					{
						sOutput.push_back(cChar);
					}
					break;

				// ਿ - U+0A3F
				case L'\x0A3F':
					if (get_RepositionI() == true)
					{
						// Convert ਿ + ੲ   to ਇ
						// U+0A3F + U+0A72 to U+0A07
						if (cNext == L'\x0A72')
						{
							sOutput.push_back(L'\x0A07');
							iCounter++;
						}
						else
						{
							sOutput.push_back(cNext);
							sOutput.push_back(cChar);
							iCounter++;
						}
					}
					else
					{
						sOutput.push_back(cChar);
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
				case L'\x0A50':
					if (get_RepairISCIIProposals() == true)
						sOutput.push_back(L'\x0A74');
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ☬
				// U+0A74 to U+262C
				case L'\x0A74':
					if (get_RepairISCIIProposals() == true)
						sOutput.push_back(L'\x262C');
					else
						sOutput.push_back(cChar);
					break;


				// Convert to ੱ
				// U+0A3B to U+0A71
				case L'\x0A3B':
					if (get_RepairISCIIProposals() == true)
						sOutput.push_back(L'\x0A71');
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ੍ਹ
				// U+0A4E to U+0A4D + U+0A39
				case L'\x0A4E':
					if (get_RepairISCIIProposals() == true)
						sOutput.append(L"\x0A4D\u0A39");
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ੍ਰ
				// U+0A4F to U+0A4D + U+0A30
				case L'\x0A4F':
					if (get_RepairISCIIProposals() == true)
						sOutput.append(L"\x0A4D\u0A30");
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ।
				// U+0A64 to U+0964
				case L'\x0A64':
					if (get_RepairISCIIProposals() == true)
						sOutput.push_back(L'\x0964');
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ॥
				// U+0A65 to U+0965
				case L'\x0A65':
					if (get_RepairISCIIProposals() == true)
						sOutput.push_back(L'\x0965');
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ੍ਵ
				// U+0A76 to U+0A4D + U+0A35
				case L'\x0A76':
					if (get_RepairISCIIProposals() == true)
						sOutput.append(L"\x0A4D\u0A35");
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ੍ਯ
				// U+0A78 to U+0A4D + U+0A2F
				case L'\x0A78':
					if (get_RepairISCIIProposals() == true)
						sOutput.append(L"\x0A4D\u0A2F");
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ੀਂ
				// U+0A7D to U+0A40 + U+0A02
				case L'\x0A7D':
					if (get_RepairISCIIProposals() == true)
						sOutput.append(L"\x0A40\u0A02");
					else
						sOutput.push_back(cChar);
					break;

				// Convert to ਾਂ
				// U+0A7E to U+0A3E + U+0A02
				case L'\x0A7E':
					if (get_RepairISCIIProposals() == true)
						sOutput.append(L"\x0A3E\u0A02");
					else
						sOutput.push_back(cChar);
					break;


				default:
					if ((AfterVowel(cChar) == true &&
						IsVowel(cNext) == true) ||
						(BeforeVowel(cNext) == true &&
						IsVowel(cChar) == true))
					{
						sOutput.push_back(cNext);
						sOutput.push_back(cChar);
						iCounter++;
					}
					else
					{
						sOutput.push_back(cChar);
					}
					break;
			}
		}
	}

	m_iPercentComplete = 100;
	Progress(m_iPercentComplete);
	return sOutput;
}

/// <summary>
/// Converts a string from ASCII based Gurmukhi text to
/// Unicode.
/// </summary>	
/// <param name="sInput">String to be converted.</param>
/// <returns>Returns a converted string.</returns>
std::wstring ConversionEngine::Convert(std::wstring sInput)
{
	m_bCancel = false;
	int iAddVowelSignI = 0;
	int iInputLength = sInput.length();
	std::wstring sOutput;

	sOutput.reserve(iInputLength);

	for (int iCounter = 0; iCounter < iInputLength; iCounter++)
	{
		if (m_bCancel == true)
			break;

		Progress(m_iPercentComplete);
		m_iPercentComplete = (int)(((double)iCounter / (double)iInputLength) * 100);

		wchar_t cChar = sInput[iCounter];

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
				if (get_ConvertNumbers() == true)
					sOutput.push_back((wchar_t)(cChar + L'\x0A36'));
				else
					sOutput.push_back(cChar);
				break;

			// 1 - 9
			case 'ñ':case 'ò':case 'ó':case 'ô':case 'õ':case 'ö':case '÷':case 'ø':case 'ù':
				if (get_ConvertNumbers() == true)
					sOutput.push_back((wchar_t)(cChar + L'\x0976'));
				else
					sOutput.push_back((wchar_t)(cChar - L'\x00C0'));
				break;
			
			// 0: 
			case 'ú':
				if (get_ConvertNumbers() == true)
					sOutput.push_back((wchar_t)(cChar + L'\x096C'));
				else
					sOutput.push_back((wchar_t)(cChar - L'\x00CA'));
				break;

			// Special characters
			case '<': //<> - ੴ
				sOutput.push_back(L'\x0A74');
				if(iCounter + 1 < sInput.length() && sInput[iCounter + 1] == '>')
					iCounter++;
				break;

			case 'Ç': // - ☬
				sOutput.push_back(L'\x262C');
				break;

			case '—': // - -
				sOutput.push_back(L'\x2D');
				break;

			// Vowel signs & misc.
			// ***When adding support for vowels, update IsVowel()***
			case 'w': //w - ਾ
				sOutput.push_back(L'\x0A3E');
				break;
			case 'W': //W - ਾਂ
				sOutput.push_back(L'\x0A3E');
				sOutput.push_back(L'\x0A02');
				break;
			case 'i': //i - ਿ
				// ***Special Case Applies [ਇ]***
				if(iCounter + 1 < sInput.length() && sInput[iCounter + 1] == 'e')
				{
					sOutput.push_back(L'\x0A07');
					iCounter++;
				}
				else
				{
					// Must be placed next time round
					if (iCounter + 1 < sInput.length())
						iAddVowelSignI = 1;
					else
						sOutput.push_back(L'\x0A3F');
				}
				break;
			case 'I': //I - ੀ
				sOutput.push_back(L'\x0A40');
				break;
			case 'u': //u - ੁ 
			case 'ü': //ü - ੁ (As above)
				// Error correction - force placement before ੰ or ੱ.
				if (get_ErrorCorrection() == true && sOutput.length() > 0)
				{
					if (sOutput[sOutput.length() - 1] == L'\x0A70' || sOutput[sOutput.length() - 1] == L'\x0A71')
					{
						// Place before last character
						sOutput.insert(sOutput.length() - 1, 1, L'\x0A41');
						break;
					}
				}
				sOutput.push_back(L'\x0A41');
				break;
			case 'U': //U - ੂ
			case '¨': //¨ - ੂ (As above)
				// Error correction - force placement before ੰ or ੱ.
				if (get_ErrorCorrection() == true && sOutput.length() > 0)
				{
					if (sOutput[sOutput.length() - 1] == L'\x0A70' || sOutput[sOutput.length() - 1] == L'\x0A71')
					{
						// Place before last character
						sOutput.insert(sOutput.length() - 1, 1, L'\x0A42');
						break;
					}
				}
				sOutput.push_back(L'\x0A42');
				break;
			case 'y': //y - ੇ
				sOutput.push_back(L'\x0A47');
				break;
			case 'Y': //Y - ੈ
				sOutput.push_back(L'\x0A48');
				break;
			case 'o': //o - ੋ
				sOutput.push_back(L'\x0A4B');
				break;
			case 'O': //O - ੌ
				sOutput.push_back(L'\x0A4C');
				break;
			case '@': //@ - ੍
				sOutput.push_back(L'\x0A4D');
				break;
			case 'M': //M - ੰ
			case 'µ': //µ - ੰ (As above)
				sOutput.push_back(L'\x0A70');
				break;
			case '`': //` - ੰ
			case '~': //~ - ੰ (As above)
				sOutput.push_back(L'\x0A71');
				break;
			case 'é': //é - ਂ
			case 'N': //N - ਂ (As above)
				sOutput.push_back(L'\x0A02');
				break;
			
			case 'æ': //æ - ਼
				sOutput.push_back(L'\x0A3C');
				break;

			case 'Ú': //Ú - ਃ
				if (get_Unicode4() == true)
				{	
					sOutput.push_back(L'\x0A03');
				}
				else
				{
					sOutput.push_back(L'\x003A');
				}
				break;

			case 'ƒ': //ƒ - ਨੂੰ
				sOutput.push_back(L'\x0A28');
				sOutput.push_back(L'\x0A42');
				sOutput.push_back(L'\x0A70');
				break;

				// Devangari | & ||
			case '[': //[ - ।
				sOutput.push_back(L'\x0964');
				break;
			case ']': //] - ॥
				sOutput.push_back(L'\x0965');
				break;

			// Conjuncts
			// These require re-jigging
			// certain characters because they
			// need to be placed before vowels

			case 'H': //H - ੍ਹ
			case '´': //´ - ੍ਹ (As above)
				if(sOutput.length() - 1 > 0 && sOutput[sOutput.length() - 2] == L'\x0A3E' && sOutput[sOutput.length() - 1] == L'\x0A02')
				{
					// Place before last TWO characters
					sOutput.insert(sOutput.length() - 2, L"\x0A4D\x0A39");
				}
				else if (sOutput.length() > 0 && IsVowel(sOutput[sOutput.length() - 1]) == true)
				{
					// Place before last character
					sOutput.insert(sOutput.length() - 1, L"\x0A4D\x0A39");
				}
				else
				{
					sOutput.append(L"\x0A4D\x0A39");
				}
				break;
			case 'R': //R - ੍ਰ
			case '®': //® - ੍ਰ (As above)
				if(sOutput.length() - 1 > 0 && sOutput[sOutput.length() - 2] == L'\x0A3E' && sOutput[sOutput.length() - 1] == L'\x0A02')
				{
					// Place before last TWO characters
					sOutput.insert(sOutput.length() - 2, L"\x0A4D\x0A30");
				}
				else if (sOutput.length() > 0 && IsVowel(sOutput[sOutput.length() - 1]) == true)
				{
					// Place before last character
					sOutput.insert(sOutput.length() - 1, L"\x0A4D\x0A30");
				}
				else
				{
					sOutput.append(L"\x0A4D\x0A30");
				}
				break;
			case 'Í': //Í - ੍ਵ
				if(sOutput.length() - 1 > 0 && sOutput[sOutput.length() - 2] == L'\x0A3E' && sOutput[sOutput.length() - 1] == L'\x0A02')
				{
					// Place before last TWO characters
					sOutput.insert(sOutput.length() - 2, L"\x0A4D\x0A35");
				}
				else if (sOutput.length() > 0 && IsVowel(sOutput[sOutput.length() - 1]) == true)
				{
					// Place before last character
					sOutput.insert(sOutput.length() - 1, L"\x0A4D\x0A35");
				}
				else
				{
					sOutput.append(L"\x0A4D\x0A35");
				}
				break;
			case 'Î': //Î - ੍ਯ
				if(sOutput.length() - 1 > 0 && sOutput[sOutput.length() - 2] == L'\x0A3E' && sOutput[sOutput.length() - 1] == L'\x0A02')
				{
					// Place before last TWO characters
					sOutput.insert(sOutput.length() - 2, L"\x0A4D\x0A2F");
				}
				else if (sOutput.length() > 0 && IsVowel(sOutput[sOutput.length() - 1]) == true)
				{
					// Place before last character
					sOutput.insert(sOutput.length() - 1, L"\x0A4D\x0A2F");
				}
				else
				{
					sOutput.append(L"\x0A4D\x0A2F");
				}
				break;

			// Normal characters
			case 'a': //a - ੳ
				// ***Special Case Applies [ਉ]***
				if(iCounter + 1 < sInput.length() && sInput[iCounter + 1] == 'u')
				{
					sOutput.push_back(L'\x0A09');
					iCounter++;
				}
					// ***Special Case Applies [ਊ]***
				else if(iCounter + 1 < sInput.length() && sInput[iCounter + 1] == 'U')
				{
					sOutput.push_back(L'\x0A0A');
					iCounter++;
				}
				else
				{
					sOutput.push_back(L'\x0A73');
				}
				break;
			case 'A': //A - ਅ

				wchar_t cNextChar;

				if (iCounter + 1 < sInput.length())
					cNextChar = sInput[iCounter + 1];

				// ***Special Case Applies [ਆਂ]***
				if(iCounter + 2 < sInput.length() && cNextChar == 'w' && sInput[iCounter + 2] == 'N')
				{
					sOutput.push_back(L'\x0A06');
					sOutput.push_back(L'\x0A02');
					iCounter += 2;
				}
				// ***Special Case Applies [ਆਂ]***
				else if(cNextChar == 'W')
				{
					sOutput.push_back(L'\x0A06');
					sOutput.push_back(L'\x0A02');
					iCounter++;
				}
				// ***Special Case Applies [ਆ]***
				else if(cNextChar == 'w')
				{
					sOutput.push_back(L'\x0A06');
					iCounter++;
				}
				// ***Special Case Applies [ਐ]***
				else if(cNextChar == 'Y')
				{
					sOutput.push_back(L'\x0A10');
					iCounter++;
				}
				// ***Special Case Applies [ਔ]***
				else if(cNextChar == 'O')
				{
					sOutput.push_back(L'\x0A14');
					iCounter++;
				}
				// ***Special Case Applies [ਔ]***
				else if(cNextChar == 'o')
				{
					sOutput.push_back(L'\x0A14');
					iCounter++;
				}
				// Error correction to automatically convert
				// text that looks like it should be right.
				else if(get_ErrorCorrection() == true && cNextChar == 'y')
				{
					sOutput.push_back(L'\x0A10');
					iCounter++;
				}
				else
				{
					sOutput.push_back(L'\x0A05');
				}
				break;
			case 'e': //e - ੲ
				// ***Special Case Applies [ਈ]***
				if(iCounter + 1 < sInput.length() && sInput[iCounter + 1] == 'I')
				{
					sOutput.push_back(L'\x0A08');
					iCounter++;
				}
					// ***Special Case Applies [ਏ]***
				else if(iCounter + 1 < sInput.length() && sInput[iCounter + 1] == 'y')
				{
					sOutput.push_back(L'\x0A0F');
					iCounter++;
				}
				else
				{
					sOutput.push_back(L'\x0A72');
				}
				break;
			case 's': //s - ਸ
				sOutput.push_back(L'\x0A38');
				break;
			case 'h': //h - ਹ
				sOutput.push_back(L'\x0A39');
				break;
			case 'k': //k - ਕ
				sOutput.push_back(L'\x0A15');
				break;
			case 'K': //K - ਖ
				sOutput.push_back(L'\x0A16');
				break;
			case 'g': //g - ਗ
				sOutput.push_back(L'\x0A17');
				break;
			case 'G': //G - ਘ
				sOutput.push_back(L'\x0A18');
				break;
			case '|': //| - ਙ
				sOutput.push_back(L'\x0A19');
				break;
			case 'c': //c - ਚ
				sOutput.push_back(L'\x0A1A');
				break;
			case 'C': //C - ਛ
				sOutput.push_back(L'\x0A1B');
				break;
			case 'j': //j - ਜ
				sOutput.push_back(L'\x0A1C');
				break;
			case 'J': //J - ਝ
				sOutput.push_back(L'\x0A1D');
				break;
			case '\\': //\ - ਞ
				sOutput.push_back(L'\x0A1E');
				break;
			case 't': //t - ਟ
				sOutput.push_back(L'\x0A1F');
				break;
			case 'T': //T - ਠ
				sOutput.push_back(L'\x0A20');
				break;
			case 'f': //f - ਡ
				sOutput.push_back(L'\x0A21');
				break;
			case 'F': //F - ਢ
				sOutput.push_back(L'\x0A22');
				break;
			case 'x': //x - ਣ
				sOutput.push_back(L'\x0A23');
				break;
			case 'q': //q - ਤ
				sOutput.push_back(L'\x0A24');
				break;
			case 'Q': //Q - ਥ
				sOutput.push_back(L'\x0A25');
				break;
			case 'd': //d - ਦ
				sOutput.push_back(L'\x0A26');
				break;
			case 'D': //D - ਧ
				sOutput.push_back(L'\x0A27');
				break;
			case 'n': //n - ਨ
				sOutput.push_back(L'\x0A28');
				break;
			case 'p': //p - ਪ
				sOutput.push_back(L'\x0A2A');
				break;
			case 'P': //P - ਫ
				sOutput.push_back(L'\x0A2B');
				break;
			case 'b': //b - ਬ
				sOutput.push_back(L'\x0A2C');
				break;
			case 'B': //B - ਭ
				sOutput.push_back(L'\x0A2D');
				break;
			case 'm': //m - ਮ
				sOutput.push_back(L'\x0A2E');
				break;
			case 'X': //X - ਯ
				sOutput.push_back(L'\x0A2F');
				break;
			case 'r': //r - ਰ
				sOutput.push_back(L'\x0A30');
				break;
			case 'l': //l - ਲ 
				sOutput.push_back(L'\x0A32');
				break;
			case 'v': //v - ਵ
				sOutput.push_back(L'\x0A35');
				break;
			case 'V': //V - ੜ
				sOutput.push_back(L'\x0A5C');
				break;
			case 'S': //S - ਸ਼
				sOutput.push_back(L'\x0A36');
				break;
			case '^': //^ - ਖ਼
				sOutput.push_back(L'\x0A59');
				break;
			case 'Z': //Z - ਗ਼
				sOutput.push_back(L'\x0A5A');
				break;
			case 'z': //z - ਜ਼
				sOutput.push_back(L'\x0A5B');
				break;
			case '&': //& - ਫ਼
				sOutput.push_back(L'\x0A5E');
				break;
			case 'L': //L - ਲ਼
				sOutput.push_back(L'\x0A33');
				break;
			case 'E': //E - ਓ
				sOutput.push_back(L'\x0A13');
				break;
			case '¿': //¿ - ×
				sOutput.push_back(L'\x00D7');
				break;
			case '‹': //‹ - ÷
				sOutput.push_back(L'\x00F7');
				break;
			default:
				sOutput.push_back(cChar);
				break;
		}

		//  ਿ Must be placed after constonant
		if (iAddVowelSignI == 2)
		{
			iAddVowelSignI = 0;
			sOutput.push_back(L'\x0A3F');
		}

		if (get_ErrorCorrection() == true)
		{
			// Remove duplicated vowel signs (more than one character long)
			if (sOutput.length() > 3)
			{
				wchar_t cFirst[2];
				wchar_t cSecond[2];

				cFirst[0] = sOutput[sOutput.length() - 4];
				cFirst[1] = sOutput[sOutput.length() - 3];
				cSecond[0] = sOutput[sOutput.length() - 2];
				cSecond[1] = sOutput[sOutput.length() - 1];
				
				if (cFirst[0] == L'\x0A3E' && cFirst[1] == L'\x0A02' && cSecond[0] == L'\x0A3E' && cSecond[1] == L'\x0A02')
					sOutput.erase(sOutput.length() - 2, 2);
			}
			
			// Remove duplicated vowel signs (one character long)
			if (sOutput.length() > 1)
			{
				wchar_t cFirst = sOutput[sOutput.length() - 2];
				wchar_t cSecond = sOutput[sOutput.length() - 1];
				
				if (cFirst == cSecond && IsSign(cFirst))
					sOutput.erase(sOutput.length() - 1, 1);
			}
		}
	}

	m_iPercentComplete = 100;
	Progress(m_iPercentComplete);
	return sOutput;
}


/// <summary>
/// Called whenever a new character is processed. 
/// </summary>
/// <remarks>
/// Overload this method if you require more sophisticated
/// behaviour.
/// </remarks>
/// <param name="iPercentComplete">The percentage of the 
/// conversion that has been completed.</param>
void ConversionEngine::Progress(int iPercentComplete)
{
}

//#endregion

