using System;

namespace Metamorph.Classes
{
	/// <summary>
	/// Summary description for Mapping.
	/// </summary>
	public class Mapping
	{
		// <convert>
		public char [] cConvertFrom;
		public char [] cConvertTo;
        public string sOption;

		public Mapping()
		{
			cConvertFrom = new char[12] {'\0', '\0', '\0', '\0', '\0', '\0',
											'\0', '\0', '\0', '\0', '\0', '\0'};
			cConvertTo = new char[12] {'\0', '\0', '\0', '\0', '\0', '\0',
										 '\0', '\0', '\0', '\0', '\0', '\0'};
		}
	}
}
