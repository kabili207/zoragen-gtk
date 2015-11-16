using System;
using System.Linq;
using System.Collections.Generic;
using Gtk;

namespace Zyrenth.OracleHack.GtkUI
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

