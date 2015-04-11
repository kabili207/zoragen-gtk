using Gtk;
using System;

namespace Zyrenth.OracleHack.GtkUI
{
	public static class Extensions
	{
		public static void SetActiveText(this ComboBox comboBox, string str)
		{
			var store = (ListStore) comboBox.Model;
			int index = 0;

			foreach (object[] row in store)
			{
				// Check for match
				if (str == row[0].ToString())
				{
					comboBox.Active = index;
					break;
				}

				// Increment the index so we can reference it for the active.
				index++;
			}
		}
	}
}

