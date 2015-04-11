using System;

namespace Zyrenth.OracleHack.GtkUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class FilePreviewWidget : Gtk.Bin
	{
		private GameInfo _info;

		public GameInfo GameInfo
		{
			get { return _info; }
			set
			{
				_info = value;
				SetControls();
			}
		}

		public FilePreviewWidget()
		{
			this.Build();
		}

		public FilePreviewWidget(GameInfo info)
			: this()
		{
			GameInfo = info;
		}

		private void SetControls()
		{
			lblHero.Text = _info.Hero;
			lblID.Text = _info.GameID.ToString();
			lblGame.Text = _info.Game.ToString();
			lblChild.Text = _info.Child;
			lblAnimal.Text = _info.Animal.ToString();
			lblBehavior.Text = _info.Behavior.ToString();
		}
	}
}

