/*
 * Copyright © 2013-2015, Andrew Nagle.
 * All rights reserved.
 * 
 * This file is part of Oracle of Secrets.
 *
 * ZoraGen GTK is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ZoraGen GTK is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with ZoraGen GTK.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Linq;
using Zyrenth.Zora;

namespace Zyrenth.ZoraGen.GtkUI
{
	[Gtk.TreeNode(ListOnly = true)]
	public class RingTreeNode : Gtk.TreeNode
	{
		const string ImagePattern = "Zyrenth.ZoraGen.GtkUI.Images.Rings.{0}.gif";

		Rings _ringValue;
		string _name;
		string _description;

		[Gtk.TreeNodeValue(Column = 0)]
		public bool IsChecked { get; set; }

		[Gtk.TreeNodeValue(Column = 2)]
		public string Name { get { return _name; } }


		[Gtk.TreeNodeValue(Column = 1)]
		public Gdk.Pixbuf Image
		{
			get
			{
				return Gdk.Pixbuf.LoadFromResource(string.Format(ImagePattern, _ringValue));
			}
		}

		public Rings RingValue
		{
			get { return _ringValue; }
		}

		public RingTreeNode(Rings ringValue)
		{
			_ringValue = ringValue;
			Type ringType = typeof(Rings);
			Type infoType = typeof(RingInfoAttribute);

			RingInfoAttribute attr = ringType.GetMember(ringValue.ToString())[0].GetCustomAttributes(infoType, false)
					.Cast<RingInfoAttribute>().SingleOrDefault();

			_name = attr.Name;
			_description = attr.Description;
		}
	}
}

