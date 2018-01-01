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
using Gtk;
using System.Linq;
using System.Text.RegularExpressions;
using Zyrenth.Zora;

namespace Zyrenth.ZoraGen.GtkUI
{
	public partial class DecoderForm : Gtk.Dialog
	{
		private byte[] data;
		private int currentPic;
		private int _secretLength;
		private GameRegion _region;
		
		public enum SecretType
		{
			Game,
			Ring,
			Memory
		}
		
		public SecretType Mode = SecretType.Game;
		
		public GameInfo GameInfo { get; set; }
		
		public bool DebugMode { get; set; }
		
		public DecoderForm(GameRegion region) :
			this(SecretType.Game, region)
		{
		}
		
		public DecoderForm(SecretType mode, GameRegion region)
		{
			this.Build();
			switch (mode)
			{
				case SecretType.Game:
					_secretLength = 20;
					break;
				case SecretType.Ring:
					_secretLength = 15;
					break;
				case SecretType.Memory:
					_secretLength = 5;
					break;
			}
			_region = region;
			data = new byte[_secretLength];
			Mode = mode;
			chkAppendRings.Visible = Mode == SecretType.Ring;

			if (region != GameRegion.US) {
				notebook1.CurrentPage = 1;
				notebook1.ShowTabs = false;
				label7.Text = "Enter a secret (japanese characters).";
				label8.Text = "";
			}
		}

		protected void OnSymbolClicked(object sender, EventArgs e)
		{
			Widget ctl = sender as Widget;
			if (ctl != null)
			{
				string num = Regex.Replace(ctl.Name, @"\D", "");
				byte id = byte.Parse(num);
				id--;
				
				if (currentPic >= _secretLength)
				{
					data[_secretLength - 1] = id;
					secretwidget1.SetSecret(data, _region);
				}
				else
				{
					data[currentPic] = id;
					currentPic++;
					secretwidget1.SetSecret(data.Take(currentPic).ToArray(), _region);
				}

				txtSymbols.Text = SecretParser.CreateString(data.Take(currentPic).ToArray(), _region);
			}
		}

		protected void OnBtnResetClicked(object sender, EventArgs e)
		{
			secretwidget1.Reset();
			currentPic = 0;
			txtSymbols.Text = SecretParser.CreateString(data.Take(currentPic).ToArray(), _region);
		}

		protected void OnBtnBackClicked(object sender, EventArgs e)
		{
			if (currentPic > 0)
				currentPic--;
			secretwidget1.SetSecret(data.Take(currentPic).ToArray(), _region);
			txtSymbols.Text = SecretParser.CreateString(data.Take(currentPic).ToArray(), _region);
		}

		protected void OnButtonOkPressed(object sender, EventArgs e)
		{
			try
			{
				if (GameInfo == null)
					GameInfo = new GameInfo();
				var trimmedData = data.Take(currentPic.Clamp(0, _secretLength)).ToArray();

				switch (Mode)
				{
					case SecretType.Game:
						GameSecret gs = new GameSecret(_region);
						gs.Load(trimmedData);
						gs.UpdateGameInfo(GameInfo);
						break;
					case SecretType.Ring:
						RingSecret rs = new RingSecret(_region);
						rs.Load(trimmedData);
						rs.UpdateGameInfo(GameInfo, chkAppendRings.Active);
						break;
					case SecretType.Memory:
						MemorySecret ms = new MemorySecret(_region);
						ms.Load(trimmedData);
						// Now what?
						break;
				}

				this.Respond(ResponseType.Ok);
			}
			catch (InvalidSecretException ex)
			{
				MessageBox.Show(ex.Message, "Invalid Secret", ButtonsType.Ok, MessageType.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", ButtonsType.Ok, MessageType.Error);
			}
		}

		protected void OnButtonCancelPressed(object sender, EventArgs e)
		{
			this.Respond(ResponseType.Cancel);
		}

		protected void OnTxtSymbolsChanged(object sender, EventArgs e)
		{
			if(notebook1.CurrentPage != 1)
				return;

			try
			{
				byte[] parsedSecret = SecretParser.ParseSecret(txtSymbols.Text, _region);
				byte[] trimmedData = parsedSecret.Take(parsedSecret.Length.Clamp(0, _secretLength)).ToArray();

				secretwidget1.SetSecret(trimmedData, _region);

				for (int i = 0; i < trimmedData.Length; ++i)
				{
					data[i] = trimmedData[i];
				}

				currentPic = (trimmedData.Length).Clamp(0, _secretLength);

			}
			catch (InvalidSecretException) { }
		}

		protected void OnNotebook1SwitchPage(object o, SwitchPageArgs args)
		{
			txtSymbols.Text = SecretParser.CreateString(data.Take(currentPic).ToArray(), _region);
		}
	}
}

