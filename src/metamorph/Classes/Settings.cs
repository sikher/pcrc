using System;
using System.Xml;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace Metamorph.Classes
{
	/// <summary>
	/// Summary description for Settings.
	/// </summary>
	public class Settings
	{
		public enum LocaleType
		{
			Indian,
			Pakistani,
			Generic,
			Other
		}

        public enum NumberConversionType
        {
            Latin,
            Gurmukhi,
            Keep
        }

		static Settings()
		{
			ApplicationDirectory = "";

			InputFont = "AnmolLipi";
			InputSize = 9.75F;
			InputBold = false;
			InputItalic = false;

			OutputFont = "Saab";
			OutputSize = 9.75F;
			OutputBold = false;
			OutputItalic = false;

			DefaultLocale = LocaleType.Indian;
			OtherLocale = "";

			ErrorCorrection = true;
            BindiTippiCorrection = false;

			XHTML11 = false;
			XMLDeclaration = false;

			OutputUTF16 = false;

            NumberConversion = NumberConversionType.Keep;
		}

		private static string sFileName = "settings.xml";
		private static string sRootNode = "Metamorph-Settings";
		private static string sApplicationDirectory = "";

		private static string sInputFont;
		private static float fInputSize;
		private static bool bInputBold;
		private static bool bInputItalic;

		private static string sOutputFont;
		private static float fOutputSize;
		private static bool bOutputBold;
		private static bool bOutputItalic;

		private static LocaleType iDefaultLocale;
		private static string sOtherLocale;

		private static bool bErrorCorrection;
        private static bool bBindiTippiCorrection;

		private static bool bXHTML11;
		private static bool bXMLDeclaration;

		private static bool bOutputUTF16;

        private static NumberConversionType iNumberConversion;

		// ----------------------------------

		private static string sMappingDirectory;
        public static List<MappingDetails> MappingList = new List<MappingDetails>(32);
		
		public static string ApplicationDirectory
		{
			get {return sApplicationDirectory;}
			set {sApplicationDirectory = value;}
		}

		public static string InputFont
		{
			get {return sInputFont;}
			set {sInputFont = value;}
		}

		public static string OutputFont
		{
			get {return sOutputFont;}
			set {sOutputFont = value;}
		}

		public static float InputSize
		{
			get {return fInputSize;}
			set {fInputSize = value;}
		}

		public static float OutputSize
		{
			get {return fOutputSize;}
			set {fOutputSize = value;}
		}

		public static bool InputBold
		{
			get {return bInputBold;}
			set {bInputBold = value;}
		}

		public static bool OutputBold
		{
			get {return bOutputBold;}
			set {bOutputBold = value;}
		}

		public static bool InputItalic
		{
			get {return bInputItalic;}
			set {bInputItalic = value;}
		}

		public static bool OutputItalic
		{
			get {return bOutputItalic;}
			set {bOutputItalic = value;}
		}

		public static LocaleType DefaultLocale
		{
			get {return iDefaultLocale;}
			set {iDefaultLocale = value;}
		}
		
		public static string OtherLocale
		{
			get {return sOtherLocale;}
			set {sOtherLocale = value;}
		}

		public static bool ErrorCorrection
		{
			get {return bErrorCorrection;}
			set {bErrorCorrection = value;}
		}

        public static bool BindiTippiCorrection
        {
            get { return bBindiTippiCorrection; }
            set { bBindiTippiCorrection = value; }
        }

		public static bool XHTML11
		{
			get {return bXHTML11;}
			set {bXHTML11 = value;}
		}

		public static bool XMLDeclaration
		{
			get {return bXMLDeclaration;}
			set {bXMLDeclaration = value;}
		}

		public static bool OutputUTF16
		{
			get {return bOutputUTF16;}
			set {bOutputUTF16 = value;}
		}

		public static string MappingDirectory
		{
			get {return sMappingDirectory;}
			set {sMappingDirectory = value;}
		}

        public static NumberConversionType NumberConversion
        {
            get { return iNumberConversion; }
            set { iNumberConversion = value; }
        }

		public static void SaveSettings()
		{
			IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForDomain();
			IsolatedStorageFileStream streamWriter = new IsolatedStorageFileStream (sFileName,
				FileMode.Create, isolatedStorage);

			XmlTextWriter xmlWriter = new XmlTextWriter(streamWriter, Encoding.UTF8);

			xmlWriter.Formatting = Formatting.Indented;
			
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement(sRootNode);

			xmlWriter.WriteStartElement("InputFont");
			xmlWriter.WriteString(InputFont);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("InputSize");
			xmlWriter.WriteString(InputSize.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("InputBold");
			xmlWriter.WriteString(InputBold.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("InputItalic");
			xmlWriter.WriteString(InputItalic.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("OutputFont");
			xmlWriter.WriteString(OutputFont);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("OutputSize");
			xmlWriter.WriteString(OutputSize.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("OutputBold");
			xmlWriter.WriteString(OutputBold.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("OutputItalic");
			xmlWriter.WriteString(OutputItalic.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("DefaultLocale");
			xmlWriter.WriteString(DefaultLocale.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("OtherLocale");
			xmlWriter.WriteString(OtherLocale);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ErrorCorrection");
			xmlWriter.WriteString(ErrorCorrection.ToString());
			xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("BindiTippiCorrection");
            xmlWriter.WriteString(BindiTippiCorrection.ToString());
            xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("XHTML11");
			xmlWriter.WriteString(XHTML11.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("XMLDeclaration");
			xmlWriter.WriteString(XMLDeclaration.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("OutputUTF16");
			xmlWriter.WriteString(OutputUTF16.ToString());
			xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("NumberConversion");
            xmlWriter.WriteString(NumberConversion.ToString());
            xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();

			xmlWriter.Flush();
			xmlWriter.Close();

			streamWriter.Close();
			isolatedStorage.Close();
		}

		public static void LoadSettings()
		{
			if (Application.StartupPath[Application.StartupPath.Length - 1] == Path.DirectorySeparatorChar)
				ApplicationDirectory = Application.StartupPath;
			else
				ApplicationDirectory = Application.StartupPath + Path.DirectorySeparatorChar;

			IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForDomain();

			string [] sFiles = isolatedStorage.GetFileNames(sFileName);

            if (sFiles != null)
            {

                foreach (string sCurrentFile in sFiles)
                {
                    // If a file is not found, the default settings are used
                    if (sCurrentFile != sFileName)
                        continue;

                    StreamReader streamReader = new StreamReader(new IsolatedStorageFileStream(sFileName,
                        FileMode.Open, isolatedStorage));

                    XmlTextReader xmlReader = new XmlTextReader(streamReader);

                    while (xmlReader.Read())
                    {
                        if (xmlReader.Depth == 0 && xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name != sRootNode)
                            break;

                        switch (xmlReader.Name)
                        {
                            case "InputFont":
                                InputFont = xmlReader.ReadString();
                                break;

                            case "InputSize":
                                InputSize = float.Parse(xmlReader.ReadString());
                                break;

                            case "InputBold":
                                InputBold = bool.Parse(xmlReader.ReadString());
                                break;

                            case "InputItalic":
                                InputItalic = bool.Parse(xmlReader.ReadString());
                                break;

                            case "OutputFont":
                                OutputFont = xmlReader.ReadString();
                                break;

                            case "OutputSize":
                                OutputSize = float.Parse(xmlReader.ReadString());
                                break;

                            case "OutputBold":
                                OutputBold = bool.Parse(xmlReader.ReadString());
                                break;

                            case "OutputItalic":
                                OutputItalic = bool.Parse(xmlReader.ReadString());
                                break;

                            case "DefaultLocale":
                                DefaultLocale = (LocaleType)StringToEnum(typeof(LocaleType), xmlReader.ReadString());
                                break;

                            case "OtherLocale":
                                OtherLocale = xmlReader.ReadString();
                                break;

                            case "ErrorCorrection":
                                ErrorCorrection = bool.Parse(xmlReader.ReadString());
                                break;

                            case "BindiTippiCorrection":
                                BindiTippiCorrection = bool.Parse(xmlReader.ReadString());
                                break;

                            case "XHTML11":
                                XHTML11 = bool.Parse(xmlReader.ReadString());
                                break;

                            case "XMLDeclaration":
                                XMLDeclaration = bool.Parse(xmlReader.ReadString());
                                break;

                            case "OutputUTF16":
                                OutputUTF16 = bool.Parse(xmlReader.ReadString());
                                break;

                            case "NumberConversion":
                                NumberConversion = (NumberConversionType)StringToEnum(typeof(NumberConversionType), xmlReader.ReadString());
                                break;
                        }
                    }

                    xmlReader.Close();

                    streamReader.Close();
                }
            }
            isolatedStorage.Close();
		}

		public static void LoadFontStyles (TextBox input, TextBox output)
		{
			try
			{
				FontStyle inputStyle;
				FontStyle outputStyle;

				if (InputBold)
				{
					if (InputItalic)
						inputStyle = FontStyle.Bold | FontStyle.Italic;
					else
						inputStyle = FontStyle.Bold;
				}
				else if (InputItalic)
					inputStyle = FontStyle.Italic;
				else
					inputStyle = FontStyle.Regular;

				if (OutputBold)
				{
					if (OutputItalic)
						outputStyle = FontStyle.Bold | FontStyle.Italic;
					else
						outputStyle = FontStyle.Bold;
				}
				else if (OutputItalic)
					outputStyle = FontStyle.Italic;
				else
					outputStyle = FontStyle.Regular;

                input.Font = new Font(InputFont, InputSize, inputStyle); 
				output.Font = new Font(OutputFont, OutputSize, outputStyle);
			}		
			catch (Exception ex)
			{
				// Fixes problems with DrChatrikWeb font
				// TODO: Separate out for ouput/input
				try
				{
					input.Font = new Font(InputFont, InputSize, FontStyle.Bold);
                    input.Font = new Font(OutputFont, OutputSize, FontStyle.Bold);
				}
				catch (Exception ex2)
				{}		
			}
		}


        public static void LoadMappings()
        {
            MappingList.Clear();

            string[] sMappings = ConversionEngine.ListMappings(Settings.MappingDirectory);

            if (sMappings != null)
            {
                foreach (string sCurrent in sMappings)
                {
                    MappingDetails Current = ConversionEngine.LoadMapping(sCurrent);

                    if (Current != null)
                    {
                        MappingList.Add(Current);
                    }
                }
            }

            LoadInternalMappings();
        }

        private static void LoadInternalMappings()
        {
            MappingDetails Current = new MappingDetails();
            Current.sFrom = "__gurmukhi__";
            Current.sTo = "Unicode";
            Current.bInternal = true;
            MappingList.Add(Current);

            Current = new MappingDetails();
            Current.sFrom = "Gurmukhi (Unicode)";
            Current.sTo = "__gurmukhiunicode__";
            Current.bInternal = true;
            MappingList.Add(Current);

            Current = new MappingDetails();
            Current.sFrom = "__gurmukhiunicode__";
            Current.sTo = "WX Notation";
            Current.bInternal = true;
            MappingList.Add(Current);

            Current = new MappingDetails();
            Current.sFrom = "__gurmukhiunicode__";
            Current.sTo = "Stemmed";
            Current.bInternal = true;
            MappingList.Add(Current);
        }

        public static void LoadInputList(ListBox listInput, ListBox listOutput)
        {
            // Load mapping list

            listInput.Items.Clear();
            listOutput.Items.Clear();

            foreach (MappingDetails Current in MappingList)
            {
                if (Current.sFrom != "" && !(Current.sFrom.StartsWith("__") && Current.sFrom.EndsWith("__")))
                    listInput.Items.Add(Current);
            }

            listInput.Sorted = true;
        }

        public static void LoadOutputList(ListBox listInput, CheckedListBox listInputOptions, ListBox listOutput, CheckedListBox listOutputOptions)
        {
            if (listInput.SelectedItem == null)
                return;

            listOutput.Items.Clear();
            listInputOptions.Items.Clear();
            listOutputOptions.Items.Clear();

            MappingDetails MapFrom = (MappingDetails)listInput.SelectedItem;

            LoadOptionsList(listInput, listInputOptions);

            foreach (MappingDetails MapTo in MappingList)
            {
                if (MapFrom.sTo == MapTo.sFrom)
                    listOutput.Items.Add(MapTo);

                listOutput.SelectedIndex = listOutput.Items.Count - 1;
            }
        }

        public static void LoadOptionsList(ListBox listMappings, CheckedListBox listOptions)
        {
            MappingDetails Map = (MappingDetails)listMappings.SelectedItem;

            IDictionaryEnumerator it = Map.OptionListDescriptions().GetEnumerator();

            while (it.MoveNext())
            {
                listOptions.Items.Add(new Pair(it.Key, it.Value));

                if (Map.OptionValue((string)it.Key) == true)
                    listOptions.SetItemChecked(listOptions.Items.Count - 1, true);
            }
        }

		private static object StringToEnum(Type t, string Value)
		{
			foreach ( FieldInfo fi in t.GetFields() )
				if ( fi.Name == Value )
					return fi.GetValue( null );    // We use null because
			// enumeration values
			// are static

			throw new Exception( string.Format("Can't convert {0} to {1}", Value,  t.ToString()) );
		}

		public static bool InitMappingDirectory()
		{
			string sDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
				Path.DirectorySeparatorChar + "Metamorph" + Path.DirectorySeparatorChar + "Mappings";

			MappingDirectory = sDirectory;

			if (Directory.Exists(sDirectory))
				return true;

			try
			{
				Directory.CreateDirectory(sDirectory);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
