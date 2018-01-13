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
using System.Linq;
using Gdk;
using Gtk;
using Zyrenth.Zora;

namespace Zyrenth.ZoraGen.GtkUI
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

		public void SetSecret(Secret secret)
		{
			SetSecret(secret.ToBytes(), secret.Region);
		}

		public void SetSecret(byte[] secret, GameRegion region)
		{
			Reset();
			sym01.SetSecret(secret.Take(5).ToArray(), region);
			sym02.SetSecret(secret.Skip(5).Take(5).ToArray(), region);
			sym03.SetSecret(secret.Skip(10).Take(5).ToArray(), region);
			sym04.SetSecret(secret.Skip(15).Take(5).ToArray(), region);
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

