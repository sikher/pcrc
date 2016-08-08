// Source: http://www.knowdotnet.com/articles/cfcsetting.html

using System;
using System.Reflection;
using System.Data;
namespace Unicode.Gurmukhi
{
	/// <summary>
	/// Summary description for CSettings.
	/// </summary>
	public class CSettings
	{
		#region " Class Variables "
		private DataSet ds;
		private string xmlFile  = String.Empty;
		private bool m_AllUsers; 
		const string XML = ".config.xml";
		private string m_AlternatePath   = String.Empty;
		#endregion

		#region " SaveSetting Methods "
		public void SaveSetting(string AppTitle,
			string Settings, string Key, bool  Value)
		{
			SaveSetting(AppTitle, Settings, Key, Value.ToString().ToLower());
		}
		public void SaveSetting(string AppTitle,
			string Settings, string Key, int Value)
		{
			SaveSetting(AppTitle, Settings, Key, Value.ToString());
		}
		public void SaveSetting(string AppTitle,
			string Settings, string Key, string Value)
		{
			if (xmlFile.Length==0)
				SetupXMLFileName(AppTitle);
			if (ds == null)
			{
				ds = new DataSet("gucaconfig");
				DataTable dt = CreateDT(Settings,Key,Value);
				ds.Tables.Add(dt);
			}
			else
			{
				DataTable dt = ds.Tables[Settings];
				if (dt == null)
				{
					// create new datatable 
					dt = CreateDT(Settings,Key,Value);
					ds.Tables.Add(dt);
				}
				else
				{
					bool b=false;
					for (int i = 0;  i < (int) dt.Rows.Count;i++)
					{
						if((string)dt.Rows[i].ItemArray[0] == Key)
						{
							dt.Rows[i].ItemArray[1] =  Value;
							b = true;
							break;
						}
					}
					if (b != true)
						AddRow(ref dt, Key, Value);
				}
			}
			ds.WriteXml(xmlFile);
		}
		#endregion

		#region " GetSetting Methods "
		public int GetSetting(string AppTitle, string Settings,
			string Key, int KeyValue)
		{
			string o = GetSetting(AppTitle,Settings,Key,KeyValue.ToString().ToLower());
			if (o == null)
				return KeyValue;
			else
				return int.Parse(o);
		}

		public bool GetSetting(string AppTitle, string Settings,
			string Key, bool KeyValue)
		{
			string o = GetSetting(AppTitle,Settings,Key,KeyValue.ToString().ToLower());
			if (o == null)
				return KeyValue;
			else
				return bool.Parse(o);
		}


		public string GetSetting(string AppTitle, string Settings,
			string Key, string KeyValue)
		{
			DataRow dr;
			DataTable dt;

			if (xmlFile.Length == 0)
				SetupXMLFileName(AppTitle);

			if (ds == null)
			{
				dt = GetXml(Settings);
				if (dt == null)
					return KeyValue;
			}
			else
				dt = ds.Tables[Settings];

			// Fixes problem if ds.Tables[Settings] = null
			if (dt == null)
				return KeyValue;

			for (int i = 0; i < dt.Rows.Count; i++)         
			{
				dr = dt.Rows[i];
				if ((string) dr["key"] == Key)
					return (string) dr["value"];
			}
			return KeyValue;
		}
		#endregion

		#region " Private Methods "
		private DataTable CreateDT(string Settings,string Key,string Value)
		{
			DataTable dt;
			dt = new DataTable(Settings);
			dt.Columns.Add("key",Type.GetType("System.String"));
			dt.Columns.Add("value",Type.GetType("System.String"));
			AddRow(ref dt,Key,Value);
			return dt;
		}
		private void AddRow(ref DataTable dt,
			string Key, object Value)
		{
			DataRow newRow = dt.NewRow();
			newRow[0] = Key;
			newRow[1] = Value;
			dt.Rows.Add(newRow);
		}
		private DataTable GetXml(string tablename)
		{
			if  (!System.IO.File.Exists(xmlFile))
				return null;

			ds = new DataSet("gucaconfig");
			ds.ReadXml(xmlFile);
			DataTable dt = ds.Tables[tablename];
			return dt;
		}
		/* Returns filename for xmlfile, generated by using
		   AppTitle suppliied to the two public methods and then
		   boolean supplied to the constructor.
		   install directory may be locked so check to see if
		   caller supplied an alternate directory.
		*/
		private void SetupXMLFileName(string fn)
		{
			string s;
			if (m_AlternatePath.Length == 0)
				s = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.
					GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
			else
				s = System.IO.Path.GetDirectoryName(m_AlternatePath);
			// compact framework not supported
			if (m_AllUsers==true)
				xmlFile = s + System.IO.Path.DirectorySeparatorChar + fn + XML;
			else
				xmlFile = s + System.IO.Path.DirectorySeparatorChar + fn + "_" + Environment.UserName + XML;
		}
		#endregion

		#region " Constructor "
		public CSettings(bool AllUsers)
		{
			m_AllUsers = AllUsers;
		}
		#endregion

		#region " Public Properties "
		public bool AllUsers 
		{
			get 
			{
				return (bool) m_AllUsers;
			}
			set 
			{
				bool m_AllUsers= value;
			}
		}
		public string AlternatePath 
		{
			get 
			{
				return   m_AlternatePath;
			}
			set 
			{
				m_AlternatePath = value;
			}
		}
		#endregion
	}
}