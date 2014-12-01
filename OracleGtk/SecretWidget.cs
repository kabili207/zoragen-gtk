using System;

namespace Zyrenth.OracleHack.GtkUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SecretWidget : Gtk.Bin
	{
		private Gtk.Image[] pics;

		public SecretWidget()
		{
			this.Build();
			pics = new []
			{
				img1, img2, img3, img4, img5, img6, img7, img8, img9, img10,
				img11, img12, img13, img14, img15, img16, img17, img18, img19, img20
			};
		}

		public void SetSecret(byte[] secret)
		{
			Reset();
			for (int i = 0; i < secret.Length && i < pics.Length; i++)
			{
				if (secret[i] > 63)
				{
					pics[i].Pixbuf = null;
				}
				else
				{
					string imgUri = string.Format("Zyrenth.OracleHack.GtkUI.Images.Symbols.{0:00}.png", secret[i]);
					pics[i].Pixbuf = Gdk.Pixbuf.LoadFromResource(imgUri);

				}
			}
		}
		
		public void Reset()
		{
			foreach (Gtk.Image pic in pics)
			{
				pic.Pixbuf = null;
			}
		}
	}
}

