/*
 * Copyright © 2013-2018, Amy Nagle.
 * All rights reserved.
 * 
 * This file is part of ZoraGen GTK.
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

namespace Zyrenth.ZoraGen.GtkUI
{
	internal class BinContainer
	{
		private Gtk.Widget child;

		private Gtk.UIManager uimanager;

		public static BinContainer Attach(Gtk.Bin bin)
		{
			BinContainer bc = new BinContainer();
			bin.SizeRequested += new Gtk.SizeRequestedHandler(bc.OnSizeRequested);
			bin.SizeAllocated += new Gtk.SizeAllocatedHandler(bc.OnSizeAllocated);
			bin.Added += new Gtk.AddedHandler(bc.OnAdded);
			return bc;
		}

		private void OnSizeRequested(object sender, Gtk.SizeRequestedArgs args)
		{
			if ((this.child != null))
			{
				args.Requisition = this.child.SizeRequest();
			}
		}

		private void OnSizeAllocated(object sender, Gtk.SizeAllocatedArgs args)
		{
			if ((this.child != null))
			{
				this.child.Allocation = args.Allocation;
			}
		}

		private void OnAdded(object sender, Gtk.AddedArgs args)
		{
			this.child = args.Widget;
		}

		public void SetUiManager(Gtk.UIManager uim)
		{
			this.uimanager = uim;
			this.child.Realized += new System.EventHandler(this.OnRealized);
		}

		private void OnRealized(object sender, System.EventArgs args)
		{
			if ((this.uimanager != null))
			{
				Gtk.Widget w;
				w = this.child.Toplevel;
				if (((w != null) && typeof(Gtk.Window).IsInstanceOfType(w)))
				{
					((Gtk.Window)(w)).AddAccelGroup(this.uimanager.AccelGroup);
					this.uimanager = null;
				}
			}
		}
	}
}

