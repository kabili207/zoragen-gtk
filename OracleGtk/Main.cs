using System;
using Gtk;

namespace Zyrenth.OracleHack.GtkUI
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
