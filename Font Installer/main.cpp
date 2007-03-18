//
// The Font Installer
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

// Version: 0.5 - Last updated: 2004-XX-XX
// Visit http://guca.sourceforge.net/

/* TO DO 
 *
 * C:\Program Files\Resource Kit\InUse.exe - use to replace usp10.dll on Windows 2000 
 *
 * Replacing existing files is faulty.
 */

// Planned for version 0.5:
// Make error messages more informative - i.e. state font involved.
// Allow usp10.dll upgrade facility

//
// This program is designed to be a simple, light-weight font
// installation utility that can be included within a self-extracting
// archive.
//

//
// Just add the file names of the fonts you wish to install to fonts.dat
// making sure they are seperated by a new line.  Then create a 
// self-extracting file using a package of your choice.  Bingo!
//

#include <windows.h>
#include <stdio.h>
#include <string>
#include <vector>
#include <commctrl.h>
#include "main.h"
#include "resource.h"

const char cFontFile[MAX_PATH] = "fonts.dat";
const char * cAppName = "Font Installer";
const char cPathSeperator = '\\';
bool bDeselect = false;
std::vector<std::string> v_sFonts;

BOOL CALLBACK DlgProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
    switch(msg)
    {
        case WM_INITDIALOG:
			{
				CHAR cCurrentDirectory[MAX_PATH];

				if (!::GetModuleFileName(NULL, cCurrentDirectory, MAX_PATH))
				{
					::MessageBox(NULL, "Unable to obtain current application directory.  Installation aborted!", cAppName, MB_OK|MB_ICONERROR);
					return 0;
				}

				// Remove module name from char string
				char *pStr = strrchr(cCurrentDirectory, '\\');
				if (cCurrentDirectory != NULL)
					*(++pStr)='\0';

				std::string sCurrentDirectory = cCurrentDirectory;

				if (sCurrentDirectory[sCurrentDirectory.length() - 1] != cPathSeperator)
					sCurrentDirectory += cPathSeperator;

				std::string sLicenceFile = sCurrentDirectory + std::string("licence.txt");

#ifdef _DEBUG
		::MessageBox(NULL, cCurrentDirectory, "Font Installer Debug - Current Directory", MB_OK);
#endif

				FILE * fFile = fopen(sLicenceFile.c_str(), "rb");

				if (fFile == NULL)
				{
					::SetWindowText(GetDlgItem(hwnd, IDC_LICENCE), "Unable to find licence!");
				}
				else
				{
					CHAR cBuffer[1000];
					std::string sLicence = "";

					while(fgets(cBuffer, 1000, fFile) != NULL)
						sLicence += cBuffer;

					::SetWindowText(GetDlgItem(hwnd, IDC_LICENCE), sLicence.c_str());
				}
				::SendMessage(GetDlgItem(hwnd, IDC_LICENCE), EM_SETSEL, -1, 0);

				GetFontList(sCurrentDirectory + cFontFile);

				if (v_sFonts.size() < 1)
				{
					::EndDialog(hwnd, IDCANCEL);
					return TRUE;
				}

				::SetFocus(GetDlgItem(hwnd, IDOK));
			}
		break;
		case WM_CTLCOLORDLG:
			{
				if (!bDeselect)
				{
					::SendMessage(GetDlgItem(hwnd, IDC_LICENCE), EM_SETSEL, -1, 0);
					bDeselect = true;
				}
			}
		break;
        case WM_COMMAND:
            switch(LOWORD(wParam))
            {
				case IDABOUT:
					::MessageBox(hwnd, "The Font Installer is a free utility designed to quickly and easily install fonts.\nThis software is released under the GNU General Public Licence.\nFor further details, visit http://guca.sourceforge.net/.\n\nVersion: 0.5\n\nCopyright © 2004 Sukhjinder Sidhu.  All rights reserved.", cAppName, MB_OK|MB_ICONINFORMATION);
					break;
                case IDOK:
                    ::EndDialog(hwnd, IDOK);
					break;
                case IDCANCEL:
					if (::MessageBox(hwnd, "Are you sure you wish to abort the installation?" , cAppName, MB_YESNO|MB_ICONQUESTION) == IDYES)
					{
						::MessageBox(hwnd, "Font installation aborted!" , cAppName, MB_OK|MB_ICONEXCLAMATION);
						::EndDialog(hwnd, IDCANCEL);
					}
					break;
            }
        break;
        default:
            return FALSE;
    }
    return TRUE;
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	// Under Windows XP this enables visual styles if a manfest is included.
	::InitCommonControls();

	INT_PTR res = ::DialogBox(GetModuleHandle(NULL), MAKEINTRESOURCE(IDD_INSTALL), NULL, DlgProc);

    if(res < 1)
    {
        ::MessageBox(NULL, "Dialog Creation Failed!", "Error!", MB_ICONEXCLAMATION | MB_OK);
        return 0;
    }

	if(res == IDOK)
	{
#ifdef _DEBUG
		::MessageBox(NULL, lpCmdLine, "Font Installer Debug - Command Line Parameters", MB_OK);
#endif
		CHAR cWindowsFont[MAX_PATH];
		CHAR cCurrentDirectory[MAX_PATH];

		// Should use SHGetFolderPath but this is dependant on
		// Internet Explorer 5.0 which not all systems will have.
		if (!::GetWindowsDirectory(cWindowsFont, MAX_PATH))
		{
			::MessageBox(NULL, "Unable to obtain Windows directory.  Installation aborted!", cAppName, MB_OK|MB_ICONERROR);
			return 0;
		}
		if (!::GetModuleFileName(NULL, cCurrentDirectory, MAX_PATH))
		{
			::MessageBox(NULL, "Unable to obtain current application directory.  Installation aborted!", cAppName, MB_OK|MB_ICONERROR);
			return 0;
		}

		// Remove module name from char string
		char *pStr = strrchr(cCurrentDirectory, '\\');
		if (cCurrentDirectory != NULL)
			*(++pStr)='\0';

#ifdef _DEBUG
		::MessageBox(NULL, cWindowsFont, "Font Installer Debug - Windows Directory", MB_OK);
		::MessageBox(NULL, cCurrentDirectory, "Font Installer Debug - Current Directory", MB_OK);
#endif

		std::string sFontDirectory = cWindowsFont;
		std::string sCurrentDirectory = cCurrentDirectory;

		if (sFontDirectory[sFontDirectory.length() - 1] != cPathSeperator)
			sFontDirectory += cPathSeperator;

		if (sCurrentDirectory[sCurrentDirectory.length() - 1] != cPathSeperator)
			sCurrentDirectory += cPathSeperator;

		sFontDirectory += std::string("Fonts") + cPathSeperator;

#ifdef _DEBUG
		::MessageBox(NULL, sFontDirectory.c_str(), "Font Installer Debug - Font Path", MB_OK);
#endif

		bool bError = false;
		std::vector<std::string>::iterator Iter	= v_sFonts.begin();

		while( Iter != v_sFonts.end()) 
		{
			std::string sCurrentFont = (std::string)*Iter;

			std::string sFontFileTo = sFontDirectory + sCurrentFont;
			std::string sFontFileFrom = sCurrentDirectory + sCurrentFont;

#ifdef _DEBUG
			::MessageBox(NULL, sFontFileTo.c_str(), "Font Installer Debug - Font Destination", MB_OK);
			::MessageBox(NULL, sFontFileFrom.c_str(), "Font Installer Debug - Font Source", MB_OK);
#endif

			BOOL bReplaceFile = FALSE;

			if (FileExists(sFontFileTo))
			{
				if (::MessageBox(NULL, "The font you are trying to install already exists on your system.  Do you wish to replace it?", cAppName, MB_YESNO|MB_ICONQUESTION) == IDYES)
				{
					::DeleteFile(sFontFileTo.c_str());
					bReplaceFile = TRUE;
				}
				else
				{
					Iter++;
					continue;
				}
			}
			
			if(!::CopyFile(sFontFileFrom.c_str(), sFontFileTo.c_str(), bReplaceFile))
			{
				::MessageBox(NULL, "Unable to copy font file into your font directory.  Ensure that all programs are closed and try and run the installer again.", cAppName, MB_OK|MB_ICONERROR);
				Iter++;
				bError = true;
				continue;
			}

			if (!::AddFontResource(sFontFileTo.c_str()))
			{
				::MessageBox(NULL, "Although the font file was copied to your font directory it was not correctly installed.  This may be due to a corrupt font file.", cAppName, MB_OK|MB_ICONERROR);
				Iter++;
				bError = true;
				continue;
			}

			Iter++;
		}

		::ShellExecute(NULL, "explore", sFontDirectory.c_str(), NULL, NULL, SW_SHOWNORMAL);
		::SendMessage(HWND_BROADCAST, WM_FONTCHANGE, NULL, NULL);

		if (bError)
			::MessageBox(NULL, "One or more errors occured during the installation.  You may not be able to use your fonts." , cAppName, MB_OK|MB_ICONINFORMATION);
		else
			::MessageBox(NULL, "Font installed!  If you are unable to view the font, please restart the computer." , cAppName, MB_OK|MB_ICONINFORMATION);
	}

	return 0;
}

// File exists code that works on all Windows version
// Copied from my MagicInstall project and converted from Unicode to ASCII.
bool FileExists(const std::string sFile)
{
	WIN32_FIND_DATA stFindData;
	HANDLE hFile;
   
	hFile = ::FindFirstFile(sFile.c_str(), &stFindData);
   
	if (hFile == INVALID_HANDLE_VALUE)
		return false;
	else 
	{
		if (stFindData.dwFileAttributes == FILE_ATTRIBUTE_DIRECTORY)
			return false;
		else
			return true;
	}
}


void GetFontList(const std::string sFile)
{
	FILE * fFile = fopen(sFile.c_str(), "r");
	v_sFonts.clear();

	if (fFile == NULL)
	{
		::MessageBox(NULL, "Unable to load font list.  Installation aborted!", cAppName, MB_OK|MB_ICONERROR);
		return;
	}
	else
	{
		CHAR cBuffer[MAX_PATH];

		while(fgets(cBuffer, MAX_PATH, fFile) != NULL)
		{
			std::string sFile = cBuffer;
			size_t iFindNewLine = sFile.rfind('\n');
			
			if (iFindNewLine == sFile.npos)
				v_sFonts.push_back(sFile);
			else
				v_sFonts.push_back(sFile.substr(0, iFindNewLine));
		}
	}
}
