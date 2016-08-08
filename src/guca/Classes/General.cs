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
using System.IO;
using System.Windows.Forms;

namespace Unicode.Gurmukhi
{
	public class ProgramResources
	{
		public static ConversionEngine Convert;
		public static string sFileName = "";
		public static string sConvertString = "";
		public static string sApplicationDirectory = "";

		public static void InitEngine()
		{
			CSettings Settings = new CSettings(true);
			Convert = new ConversionEngine();
			String sProgram = Application.ProductName.ToLower();

			Convert.ConvertNumbers = Settings.GetSetting(sProgram, "conversion", "convert_numbers", false);
			Convert.ErrorCorrection = Settings.GetSetting(sProgram, "conversion", "error_correction", true);		
			Convert.RepairISCIIProposals = Settings.GetSetting(sProgram, "repair", "iscii91", true);
			Convert.RepositionI = Settings.GetSetting(sProgram, "repair", "repositioni", false);
			Convert.NormaliseText = Settings.GetSetting(sProgram, "repair", "normalisetext", true);
			Convert.Unicode4 = Settings.GetSetting(sProgram, "unicode", "unicode4", true);

			if (Application.StartupPath[Application.StartupPath.Length - 1] == Path.DirectorySeparatorChar)
				sApplicationDirectory = Application.StartupPath;
			else
				sApplicationDirectory = Application.StartupPath + Path.DirectorySeparatorChar;
		}
	}
}

namespace Unicode.Gurmukhi.Forms
{
	public class TaggedMenuItem : MenuItem
	{
		private object _tag;

		public TaggedMenuItem() : base()
		{
		}

		public TaggedMenuItem(string text) : base(text)
		{
		}

		public object Tag
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag = value;
			}
		}
	}
}