using System;
using Gtk;

namespace Zyrenth.OracleHack.GtkUI
{
	public static class MessageBox
	{
		public static void Show(Gtk.Window parent_window, DialogFlags flags, MessageType msgtype, ButtonsType btntype, string msg)
		{
			MessageDialog md = new MessageDialog (parent_window, flags, msgtype, btntype, msg);
			md.Run ();
			md.Destroy();
		}
		
		public static void Show(string msg)
		{
			MessageDialog md = new MessageDialog (null, DialogFlags.Modal, MessageType.Other, ButtonsType.Ok, msg);
			md.Run ();
			md.Destroy();
		}
		
		public static void Show(string msg, string title, ButtonsType buttons, MessageType type)
		{
			MessageDialog md = new MessageDialog (null, DialogFlags.Modal, type, buttons, msg);
			md.Title = title;
			md.Run ();
			md.Destroy();
		}
	} 
}

