using System;
using Gtk;

namespace Zyrenth.OracleGtk
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init();
			SaveEditor win = new SaveEditor();
			win.Show();
			Application.Run();
		}
	}
}
