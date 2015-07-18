/*
 * Copyright © 2013-2015, Andrew Nagle.
 * All rights reserved.
 * 
 * This file is part of Oracle of Secrets.
 *
 * Oracle of Secrets is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Oracle of Secrets is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Oracle of Secrets.  If not, see <http://www.gnu.org/licenses/>.
 */

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

