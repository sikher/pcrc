using System;
using System.Collections;

namespace Metamorph.Classes
{
	public class MappingDetails
	{
		public string sFileName = "";
		public string sFrom = "";
		public string sTo = "";
		public string sAuthor = "";
		public string sVersion = "";
		public string sDescription = "";
		public string sInputFont = "";
		public string sOutputFont = "";
		public bool bInternal = false;

		public string sPreScript = "";
		public string sPostScript = "";

        public ArrayList Mappings = new ArrayList(32);
        private Hashtable OptionValues = new Hashtable(32);
        private Hashtable OptionDescriptions = new Hashtable(32);

		// Override the standard 'tostring' function
		public override string ToString()
		{
			if (sTo == "" || (sTo.StartsWith("__") && sTo.EndsWith("__")))
				return sFrom;
			else if (sFrom == "" || (sFrom.StartsWith("__") && sFrom.EndsWith("__")))
				return sTo;
			else
				return sFrom + " -> " + sTo;
		}

        public void AddOption(string optionName, string optionDescription, bool optionValue)
        {
            OptionValues.Add(optionName, optionValue);
            OptionDescriptions.Add(optionName, optionDescription);
        }

        // Return option value
        // False is default if that particular option does not exist
        public bool OptionValue(string optionName)
        {
            if (!OptionValues.ContainsKey(optionName))
               return false;

           return (bool)OptionValues[optionName];
        }

        // Return option description
        public string OptionDescription(string optionName)
        {
            return (string)OptionDescriptions[optionName];
        }

        // Get list of options with Values
        public Hashtable OptionListValues()
        {
            return OptionValues;
        }

        // Get list of options with Descriptions
        public Hashtable OptionListDescriptions()
        {
            return OptionDescriptions;
        }
	}
}
