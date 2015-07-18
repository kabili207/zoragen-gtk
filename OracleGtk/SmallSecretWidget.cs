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

using System;
using System.Linq;
using Gdk;
using Gtk;

namespace Zyrenth.OracleHack.GtkUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public class SmallSecretWidget : Gtk.Bin
	{
		private Fixed fixed1;

		private Gtk.Image img01;
		private Gtk.Image img02;
		private Gtk.Image img03;
		private Gtk.Image img04;
		private Gtk.Image img05;

		private Gtk.Image[] pics;

		public SmallSecretWidget()
		{
			this.Build();

			pics = new [] {
				img01, img02, img03, img04, img05
			};
		}

		public void SetSecret(Secret secret)
		{
			SetSecret(secret.ToBytes());
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
			//SetImageVisibility();
		}

		public void Reset()
		{
			foreach (Gtk.Image pic in pics)
			{
				pic.Pixbuf = null;
			}
		}

		/*private void SetImageVisibility()
		{
			foreach (var pic in pics.Skip(5))
			{
				pic.NoShowAll = _largeDisplay;
				pic.Visible = _largeDisplay;
				if (_largeDisplay)
				{
					if (!fixed1.Children.Contains(pic))
					{
						fixed1.Add(pic);
						pic.Show();
					}
				}
				else
				{
					if (fixed1.Children.Contains(pic))
					{
						pic.Hide();
						fixed1.Remove(pic);
					}
				}
			}
		}*/

		private Size getMininumSize()
		{
			int width = 172, height = 52;
			
			width = 82;
			height = 22;

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

		private void BuildSymbol(ref Gtk.Image img, int x = 0, int y = 0)
		{
			img = new Gtk.Image();
			img.WidthRequest = 16;
			img.HeightRequest = 20;
			fixed1.Add(img);
			Fixed.FixedChild w = ((Fixed.FixedChild)(fixed1[img]));
			w.X = x;
			w.Y = y;
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

			BuildSymbol(ref img01, 0, 0);
			BuildSymbol(ref img02, 16, 0);
			BuildSymbol(ref img03, 32, 0);
			BuildSymbol(ref img04, 48, 0);
			BuildSymbol(ref img05, 64, 0);


			this.Add(this.fixed1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}

			this.Hide();
		}
	}
}

