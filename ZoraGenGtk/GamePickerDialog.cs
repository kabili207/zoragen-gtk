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
using System.Collections.Generic;
using Gtk;
using Zyrenth.Zora;

namespace Zyrenth.ZoraGen.GtkUI
{
	public partial class GamePickerDialog : Gtk.Dialog
	{
		private enum Columns
		{
			Hero,
			GameID,
			Game
		}

		private IEnumerable<GameInfo> _gameData;

		private IEnumerable<GameInfo> GameData
		{
			get { return _gameData; }
			set
			{
				_gameData = value;
				nvInfos.NodeStore = CreateModel();
				if(_gameData.Count() > 0)
					nvInfos.NodeSelection.SelectPath(new TreePath("0"));
			}
		}

		public GameInfo SelectedGameInfo
		{
			get;
			private set;
		}

		public GamePickerDialog()
		{
			this.Build();
			CreateTreeViewColumns();
			nvInfos.NodeSelection.Changed += NvInfos_NodeSelection_Changed;
		}

		public GamePickerDialog(IEnumerable<GameInfo> infos) : this()
		{
			GameData = infos;
		}

		private void CreateTreeViewColumns()
		{
			CellRendererText rendererText = new CellRendererText();
			TreeViewColumn column = new TreeViewColumn("Hero", rendererText, "text", (int)Columns.Hero);
			column.SortColumnId = (int)Columns.Hero;
			nvInfos.AppendColumn(column);

			rendererText = new CellRendererText();
			column = new TreeViewColumn("Game ID", rendererText, "text", (int)Columns.GameID);
			column.SortColumnId = (int)Columns.GameID;
			nvInfos.AppendColumn(column);

			rendererText = new CellRendererText();
			column = new TreeViewColumn("Game", rendererText, "text", (int)Columns.Game);
			column.SortColumnId = (int)Columns.GameID;
			nvInfos.AppendColumn(column);
		}

		private NodeStore CreateModel()
		{
			NodeStore store = new NodeStore(typeof(GameInfoNode));
			foreach (GameInfo info in GameData)
			{
				store.AddNode(new GameInfoNode(info));
			}

			return store;
		}

		protected void OnNvInfosRowActivated(object sender, RowActivatedArgs e)
		{
			GameInfoNode node = nvInfos.NodeStore.GetNode(e.Path) as GameInfoNode;
			if (node != null)
			{
				SelectedGameInfo = node.GameInfo;
				previewWidget.GameInfo = SelectedGameInfo;
			}
		}

		void NvInfos_NodeSelection_Changed (object sender, EventArgs e)
		{
			Gtk.NodeSelection selection = (Gtk.NodeSelection) sender;
			GameInfoNode node = selection.SelectedNode as GameInfoNode;
			if (node != null)
			{
				SelectedGameInfo = node.GameInfo;
				previewWidget.GameInfo = SelectedGameInfo;
			}
		}

	}
}

