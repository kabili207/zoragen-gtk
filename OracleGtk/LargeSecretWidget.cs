using System;
using System.Linq;
using Gdk;
using Gtk;

namespace Zyrenth.OracleHack.GtkUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public class LargeSecretWidget : Gtk.Bin
	{
		private Fixed fixed1;

		private SmallSecretWidget sym01;
		private SmallSecretWidget sym02;
		private SmallSecretWidget sym03;
		private SmallSecretWidget sym04;

		public LargeSecretWidget()
		{
			this.Build();
		}

		public void SetSecret(byte[] secret)
		{
			Reset();
			sym01.SetSecret(secret.Take(5).ToArray());
			sym02.SetSecret(secret.Skip(5).Take(5).ToArray());
			sym03.SetSecret(secret.Skip(10).Take(5).ToArray());
			sym04.SetSecret(secret.Skip(15).Take(5).ToArray());
		}

		public void Reset()
		{
			sym01.Reset();
			sym02.Reset();
			sym03.Reset();
			sym04.Reset();
		}

		private void BuildSmallWidget(ref SmallSecretWidget widg, int x = 0, int y = 0)
		{
			widg = new SmallSecretWidget();
			//img.WidthRequest = 16;
			//img.HeightRequest = 20;
			fixed1.Add(widg);
			Fixed.FixedChild w = ((Fixed.FixedChild)(fixed1[widg]));
			w.X = x;
			w.Y = y;
		}

		private Size getMininumSize()
		{
			int width = 172, height = 52;

			return new Size(width, height);
		}

		protected override void OnSizeRequested(ref Requisition requisition)
		{
			//set minimum size
			Size size = getMininumSize();
			requisition.Width = size.Width;
			requisition.Height = size.Height;
			//
			base.OnSizeRequested(ref requisition);
		}

		protected virtual void Build()
		{
			BinContainer.Attach(this);

			fixed1 = new Gtk.Fixed();
			fixed1.Name = "fixed1";
			fixed1.HasWindow = true;
			Color color = new Color();
			Color.Parse("white", ref color);
			fixed1.ModifyBg(StateType.Normal, color);

			BuildSmallWidget(ref sym01, 0, 0);
			BuildSmallWidget(ref sym02, 90, 0);
			BuildSmallWidget(ref sym03, 0, 30);
			BuildSmallWidget(ref sym04, 90, 30);


			this.Add(this.fixed1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}

			this.Hide();
		}
	}
}

