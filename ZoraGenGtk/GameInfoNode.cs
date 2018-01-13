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
using Zyrenth.Zora;

namespace Zyrenth.ZoraGen.GtkUI
{
	[Gtk.TreeNode(ListOnly = true)]
	public class GameInfoNode : Gtk.TreeNode
	{
		private GameInfo _info;

		public GameInfo GameInfo
		{
			get { return _info; }
		}

		[Gtk.TreeNodeValue(Column = 0)]
		public string Hero
		{
			get { return GameInfo.Hero; }
		}

		[Gtk.TreeNodeValue(Column = 1)]
		public string GameID
		{
			get { return GameInfo.GameID.ToString(); }
		}

		[Gtk.TreeNodeValue(Column = 2)]
		public string Game
		{
			get { return GameInfo.Game.ToString(); }
		}

		public GameInfoNode(GameInfo info)
		{
			_info = info;
		}
	}
}

