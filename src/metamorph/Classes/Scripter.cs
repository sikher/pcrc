using System;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Vsa;

namespace Metamorph.Classes
{
	/// <summary>
	/// Processes JS code for mappings which require complex analysis
	/// </summary>
	public class Scripter : IVsaSite, IDisposable
	{
		private static int  _scripterCount = 0;
		private StringBuilder _sText = new StringBuilder();
		private IVsaEngine  _engine;

		public StringBuilder Text 
		{
			get
			{ 
				return _sText;
			}
			set
			{
				_sText = value;
			}
		}

		public Scripter(string sScript, string sMappingText)
		{
			_scripterCount++;
			_sText = new StringBuilder(sMappingText);

			_engine = new Microsoft.JScript.Vsa.VsaEngine();

			_engine.RootMoniker = "metamorph://mappings/" + _scripterCount;
			_engine.Site = this;
			_engine.InitNew();
			_engine.RootNamespace = "Metamorph.Classes";

			// Turn on debugging
			_engine.GenerateDebugInfo = true;

			// Load the core support assemblies
			IVsaItems    items = _engine.Items;
			IVsaReferenceItem   refItem;

			// system.dll
			refItem = (IVsaReferenceItem)items.CreateItem("system.dll", VsaItemType.Reference, VsaItemFlag.None);
			refItem.AssemblyName = "system.dll";

			// system.windows.forms.dll
			refItem = (IVsaReferenceItem)items.CreateItem("system.windows.forms.dll", VsaItemType.Reference, VsaItemFlag.None);
			refItem.AssemblyName = "system.windows.forms.dll";

			// mscorlib.dll
			refItem = (IVsaReferenceItem)items.CreateItem("mscorlib.dll", VsaItemType.Reference, VsaItemFlag.None);
			refItem.AssemblyName = "mscorlib.dll";

			// this assembly
			string  assemName = Assembly.GetExecutingAssembly().Location;
			refItem = (IVsaReferenceItem)items.CreateItem(assemName,
				VsaItemType.Reference,
				VsaItemFlag.None);
			refItem.AssemblyName = assemName;

			//Add the global "Core" item
			IVsaGlobalItem  mainItem = (IVsaGlobalItem)items.CreateItem("Core",
				VsaItemType.AppGlobal,
				VsaItemFlag.None);

			mainItem.TypeString = "Metamorph.Classes.Scripter";

			IVsaCodeItem codeItem = (IVsaCodeItem)items.CreateItem("Script",
				VsaItemType.Code,
				VsaItemFlag.None);
			codeItem.SourceText = sScript;

			// Run the script
			_engine.Compile();
			_engine.Run();

			//TODO Catch errors
         }

		// IVsaSite
		void IVsaSite.GetCompiledState(out Byte[] pe, out Byte[] debugInfo)
		{
			Trace.WriteLine("IVsaSite.GetCompiledState()");
			pe = debugInfo = null;
		}

		object IVsaSite.GetEventSourceInstance(string itemName, string eventSourceName)
		{
			Trace.WriteLine(string.Format("IVsaSite.GetEventSourceInstance('{0}', '{1}')", itemName, eventSourceName));
			switch( eventSourceName )
			{
				case "Core":
					return this;
				//case "Clock": return this;
				//	// TODO: Throw VsaError.EventSourceInvalid instead
				default: return null;
			}
		}

		object IVsaSite.GetGlobalInstance(string name)
		{
			Trace.WriteLine("IVsaSite.GetGlobalInstance('" + name + "')");
			switch( name )
			{
				case "Core":
					return this;
				//case "Clock": return this;
				//	// TODO: Thrown VsaError.GlobalInstanceInvalid instead
				default: return null;
			}
		}

		void IVsaSite.Notify(string notify, object info)
		{
		}

		bool IVsaSite.OnCompilerError(IVsaError e)
		{
			MessageBox.Show(String.Format("The scripting engine has detected an error in the mapping you are attempting to use.\n  Error of severity {0} on line {1}: {2}", e.Severity, e.Line, e.Description), "Scripting Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return true; // Continue to report errors
		}

		// IDisposable
		void IDisposable.Dispose()
		{
			// Close the engine
			if( _engine != null )
				_engine.Close();
		}
	}
}
