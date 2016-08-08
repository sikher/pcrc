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

//
// Transliterates from Gurmukhi Punjabi to Romanised Punjabi.
//
// This is designed only to be a very basic and crude technique.
// 
// Plans to implement a vastly superior transliteration scheme
// using ICU's InterIndic technique are underway.  In the
// meantime, this version should be adequate.
//
// Anyone wishing to donate their time to improve this is more
// than welcome to contact me: sukhuk@users.sourceforge.net
//

using System;

namespace Unicode.Gurmukhi
{
	/// <summary>
	/// Summary description for Transliterator.
	/// </summary>
	public class Transliterator
	{
		public Transliterator()
		{
			//
			// TODO: Add constructor logic here
			//
		}

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

		// Transliterating vowels:

		// NO VOWEL SIGN - a
		// U+0A3E - 'ਾ' - aa
		// U+0A3F - 'ਿ' - i
		// U+0A40 - 'ੀ' - ee
		// U+0A41 - 'ੁ' - u
		// U+0A42 - 'ੂ' - oo
		// U+0A47 - 'ੇ' - ay
		// U+0A48 - 'ੈ' - ai
		// U+0A4B - 'ੋ' - o
		// U+0A4C - 'ੌ' - au

		public string ToLatin(string sInput)
		{
			int iInputLength = sInput.Length;
			System.Text.StringBuilder sOutput = new System.Text.StringBuilder();

			sOutput.EnsureCapacity(iInputLength);

			for (int iCounter = 0; iCounter < iInputLength; iCounter++)
			{
				bool bPlaceVowel = true;
				char cChar = sInput[iCounter];
				char cNext = ' ';

				if (iCounter + 1 < iInputLength)
					cNext = sInput[iCounter + 1];

				if (cNext == '\u0A4D')
					bPlaceVowel = false;

				switch (cChar)
				{
					// *** VOWEL SIGNS ***

					//U+0A3E - 'ਾ' - aa
					case '\u0A3E':
						sOutput.Append("aa");
						break;
					//U+0A3F - 'ਿ' - i
					case '\u0A3F':
						sOutput.Append("i");
						break;
					// U+0A40 - 'ੀ' - ee
					case '\u0A40':
						sOutput.Append("ee");
						break;
					//U+0A41 - 'ੁ' - u
					case '\u0A41':
						sOutput.Append("u");
						break;
					//U+0A42 - 'ੂ' - oo
					case '\u0A42':
						sOutput.Append("oo");
						break;
					//U+0A47 - 'ੇ' - ay
					case '\u0A47':
						sOutput.Append("ay");
						break;
					//U+0A48 - 'ੈ' - ai
					case '\u0A48':
						sOutput.Append("ai");
						break;
					//U+0A4B - 'ੋ' - o
					case '\u0A4B':
						sOutput.Append("o");
						break;
					//U+0A4C - 'ੌ' - au
					case '\u0A4C':
						sOutput.Append("au");
						break;

					// *** VOWEL CHARACTERS ***

					//U+0A05 - ਅ - a
					case '\u0A05':
						sOutput.Append("a");
						bPlaceVowel = false;
						break;

					//U+0A06 - ਆ - aa
					case '\u0A06':
						sOutput.Append("aa");
						bPlaceVowel = false;
						break;

					//U+0A07 - ਇ - i
					case '\u0A07':
						sOutput.Append("i");
						bPlaceVowel = false;
						break;

					//U+0A08 - ਈ - ee
					case '\u0A08':
						sOutput.Append("ee");
						bPlaceVowel = false;
						break;

					//U+0A09 - ਉ - u
					case '\u0A09':
						sOutput.Append("u");
						bPlaceVowel = false;
						break;

					//U+0A0A - ਊ - oo
					case '\u0A0A':
						sOutput.Append("oo");
						bPlaceVowel = false;
						break;

					//U+0A0F - ਏ - ay
					case '\u0A0F':
						sOutput.Append("ay");
						bPlaceVowel = false;
						break;

					//U+0A10 - ਐ - ai
					case '\u0A10':
						sOutput.Append("ai");
						bPlaceVowel = false;
						break;

					//U+0A13 - ਓ - Ao
					case '\u0A13':
						sOutput.Append("ao");
						bPlaceVowel = false;
						break;

					//U+0A14 - ਔ - au
					case '\u0A14':
						sOutput.Append("au");
						bPlaceVowel = false;
						break;

					//U+0A72 - ੲ - 
					case '\u0A72':
						sOutput.Append("e");
						bPlaceVowel = false;
						break;

					//U+0A73 - ੳ - 
					case '\u0A73':
						sOutput.Append("a");
						bPlaceVowel = false;
						break;

					// *** CONSONANTS ***
					// If no vowel sign follows consonant, use 'a'.

					//U+0A15 - ਕ - k
					case '\u0A15':
						sOutput.Append("k");
						break;
					//U+0A16 - ਖ - kh
					case '\u0A16':
						sOutput.Append("kh");
						break;
					//U+0A17 - ਗ - g
					case '\u0A17':
						sOutput.Append("g");
						break;
					//U+0A18 - ਘ - gh
					case '\u0A18':
						sOutput.Append("gh");
						break;		
					//U+0A19 - ਙ - n
					case '\u0A19':
						sOutput.Append("n");
						break;	
					
					//U+0A1A - ਚ - ch 
					case '\u0A1A':
						sOutput.Append("ch");
						break;
					//U+0A1B - ਛ - chh
					case '\u0A1B':
						sOutput.Append("chh");
						break;	
					//U+0A1C - ਜ - j
					case '\u0A1C':
						sOutput.Append("j");
						break;	
					//U+0A1D - ਝ - jh
					case '\u0A1D':
						sOutput.Append("jh");
						break;	
					//U+0A1E - ਞ - n
					case '\u0A1E':
						sOutput.Append("n");
						break;	
					//U+0A1F - ਟ - t
					case '\u0A1F':
						sOutput.Append("t");
						break;	
					//U+0A20 - ਠ - tth
					case '\u0A20':
						sOutput.Append("tth");
						break;	
					//U+0A21 - ਡ - d
					case '\u0A21':
						sOutput.Append("d");
						break;	
					//U+0A22 - ਢ - ddh
					case '\u0A22':
						sOutput.Append("ddh");
						break;	
					//U+0A23 - ਣ - n
					case '\u0A23':
						sOutput.Append("n");
						break;	
					//U+0A24 - ਤ - t
					case '\u0A24':
						sOutput.Append("t");
						break;
					//U+0A25 - ਥ - th
					case '\u0A25':
						sOutput.Append("th");
						break;
					//U+0A26 - ਦ - th
					case '\u0A26':
						sOutput.Append("th");
						break;
					//U+0A27 - ਧ - thh
					case '\u0A27':
						sOutput.Append("thh");
						break;
					//U+0A28 - ਨ - n
					case '\u0A28':
						sOutput.Append("n");
						break;
					//U+0A2A - ਪ - p
					case '\u0A2A':
						sOutput.Append("p");
						break;
					//U+0A2B - ਫ - dh
					case '\u0A2B':
						sOutput.Append("dh");
						break;
					//U+0A2C - ਬ - b
					case '\u0A2C':
						sOutput.Append("b");
						break;
					//U+0A2D - ਭ - bh
					case '\u0A2D':
						sOutput.Append("bh");
						break;
					//U+0A2E - ਮ - m
					case '\u0A2E':
						sOutput.Append("m");
						break;
					//U+0A2F - ਯ - y
					case '\u0A2F':
						sOutput.Append("y");
						break;
					//U+0A30 - ਰ - r
					case '\u0A30':
						sOutput.Append("r");
						break;
					//U+0A32 - ਲ - l
					case '\u0A32':
						sOutput.Append("l");
						break;
					//U+0A35 - ਵ - v
					case '\u0A35':
						sOutput.Append("v");
						break;
					//U+0A38 - ਸ - s
					case '\u0A38':
						sOutput.Append("s");
						break;
					//U+0A39 - ਹ - h
					case '\u0A39':
						sOutput.Append("h");
						break;

					//*U+0A33 - ਲ਼ - ll
					case '\u0A33':
						sOutput.Append("ll");
						break;
					//U+0A36 - ਸ਼ - sh
					case '\u0A36':
						sOutput.Append("sh");
						break;
					//U+0A59 - ਖ਼ - kh
					case '\u0A59':
						sOutput.Append("kh");
						break;
					//U+0A5A - ਗ਼ - gh
					case '\u0A5A':
						sOutput.Append("gh");
						break;
					//U+0A5B - ਜ਼ - z
					case '\u0A5B':
						sOutput.Append("z");
						break;
					//U+0A5C - ੜ - rh
					case '\u0A5C':
						sOutput.Append("rh");
						break;
					//U+0A5E - ਫ਼ - f
					case '\u0A5E':
						sOutput.Append("f");
						break;

					// *** OTHER SIGNS ***
					// If no vowel sign follows sign, use 'a'.

					//U+0A02 - ਂ - Indicates that a preceding vowel or diphthong is pronounced
					//			  nasal passages open, as in French un bon vln blanc. [N]
					case '\u0A02':
						sOutput.Append("n");
						bPlaceVowel = false;
						break;
						
					//U+0A70 - ੰ - Indicates that a preceding vowel or diphthong is pronounced
					//			  nasal passages open, as in French un bon vln blanc. [N or M]
					case '\u0A70':
						sOutput.Append("n");
						bPlaceVowel = false;
						break;

					//U+0A71 - ੱ - Double sound without nasal affect
					case '\u0A71':
						//sOutput.Append("");
						bPlaceVowel = false;
						break;

					//U+0A3C - ਼ - Paireen Bindi
					case '\u0A3C':
						//sOutput.Append("");
						break;

					//U+0A4D - ੍ - Virama
					//			  Just take the next consonant and don't place vowel.
					case '\u0A4D':
						//sOutput.Append("");
						bPlaceVowel = false;
						break;



					/*//U+0A -  - 
					case '\u0A':
						sOutput.Append("");
						break;*/	

					default:
						sOutput.Append(cChar);
						bPlaceVowel = false;
						break;
				}

				//TODO CHECK IT IS NOT WHITESPACE EITHER
				if (!IsVowel(cNext) && !IsVowel(cChar) && cChar != ' ' && cNext != ' ' && bPlaceVowel == true)
					sOutput.Append("a");
			}

			return sOutput.ToString();
		}
	}
}
