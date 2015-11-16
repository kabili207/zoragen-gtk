using System;

namespace Zyrenth.OracleHack.GtkUI
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

