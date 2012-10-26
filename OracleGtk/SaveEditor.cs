using System;
using Gtk;

namespace Zyrenth.OracleGtk
{
	public partial class SaveEditor : Gtk.Window
	{
		public SaveEditor() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();

		}
		
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}
	}
}

