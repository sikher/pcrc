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

#pragma once

#ifndef __CONVERSIONENGINE_H__
#define __CONVERSIONENGINE_H__

#include <string>

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
/// </summary>
class ConversionEngine
{
	// Member variables
	private: const static bool m_bProprietary = false;
	private: wchar_t * m_sVersion; // Update in constructor
	private: bool m_bCancel;
	private: bool m_bErrorCorrection;
	private: bool m_bConvertNumbers;
	private: int m_iPercentComplete;
	private: bool m_bRepositionI;
	private: bool m_bRepairISCIIProposals;
	private: bool m_bNormaliseText;
	private: bool m_bUnicode4;

	// Properties
	public: bool get_ErrorCorrection();
	public: void set_ErrorCorrection(bool value);
	public: bool get_ConvertNumbers() ;
	public: void set_ConvertNumbers(bool value);
	public: bool get_RepositionI();
	public: void set_RepositionI(bool value);
	public: bool get_RepairISCIIProposals();
	public: void set_RepairISCIIProposals(bool value);
	public: bool get_NormaliseText();
	public: void set_NormaliseText(bool value);
	public: bool get_Unicode4();
	public: void set_Unicode4(bool value);
	public: bool get_Proprietary();
	public: std::wstring get_Version();

	// Constructors & Destructor
	public: ConversionEngine();
	public: ConversionEngine(bool bConvertNumbers, bool bErrorCorrection);
	public: ~ConversionEngine();

	// Methods
	public: void Cancel();
	public: bool IsVowel(wchar_t cCharacter);
	public: bool IsSign(wchar_t cCharacter);
	public: bool IsConjunct(wchar_t cCharA, wchar_t cCharB);
	public: std::wstring Repair(std::wstring sInput);
	public: std::wstring Convert(std::wstring sInput);
	public: void Progress(int iPercentComplete);

	private: bool AfterVowel(wchar_t cCharacter);
	private: bool BeforeVowel(wchar_t cCharacter);

};
#endif
