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
using Zyrenth.Zora;

namespace Zyrenth.ZoraGen.GtkUI
{
	public partial class ViewSecretsDialog : Gtk.Dialog
	{
		GameInfo _info = null;

		public ViewSecretsDialog()
		{
			this.Build();
			this.QueueResize();
		}
		public ViewSecretsDialog(GameInfo info) : this()
		{
			if(info == null)
				throw new ArgumentNullException("info", "Game info cannot be null");
			_info = info;
			SetSecrets();

			if (_info.Game == Game.Seasons) {
				label3.Text = "Memories\n(for Seasons)";
				label5.Text = "Secrets\n(for Ages)";
			} else {
				label3.Text = "Memories\n(for Ages)";
				label5.Text = "Secrets\n(for Seasons)";
			}
		}
		
		private void SetSecrets()
		{
			swGame.SetSecret(new GameSecret(_info));
			swRings.SetSecret(new RingSecret(_info));
			
			if (_info.IsLinkedGame)
			{
				// Return secrets
				bool returnSecret = true;
				swMem1.SetSecret(new MemorySecret(_info, Memory.ClockShopKingZora, returnSecret));
				swMem2.SetSecret(new MemorySecret(_info, Memory.GraveyardFairy, returnSecret));
				swMem3.SetSecret(new MemorySecret(_info, Memory.SubrosianTroy, returnSecret));
				swMem4.SetSecret(new MemorySecret(_info, Memory.DiverPlen, returnSecret));
				swMem5.SetSecret(new MemorySecret(_info, Memory.SmithLibrary, returnSecret));
				swMem6.SetSecret(new MemorySecret(_info, Memory.PirateTokay, returnSecret));
				swMem7.SetSecret(new MemorySecret(_info, Memory.TempleMamamu, returnSecret));
				swMem8.SetSecret(new MemorySecret(_info, Memory.DekuTingle, returnSecret));
				swMem9.SetSecret(new MemorySecret(_info, Memory.BiggoronElder, returnSecret));
				swMem10.SetSecret(new MemorySecret(_info, Memory.RuulSymmetry, returnSecret));

				// Other-game secrets
				returnSecret = false;

				// swap the game for this secret
				GameInfo info2 = new GameInfo ();
				info2.GameID = _info.GameID;
				info2.Region = _info.Region;
				if (_info.Game == Game.Ages)
					info2.Game = Game.Seasons;
				else
					info2.Game = Game.Ages;

				swSec1.SetSecret (new MemorySecret (info2, Memory.ClockShopKingZora, returnSecret));
				swSec2.SetSecret (new MemorySecret (info2, Memory.GraveyardFairy, returnSecret));
				swSec3.SetSecret (new MemorySecret (info2, Memory.SubrosianTroy, returnSecret));
				swSec4.SetSecret (new MemorySecret (info2, Memory.DiverPlen, returnSecret));
				swSec5.SetSecret (new MemorySecret (info2, Memory.SmithLibrary, returnSecret));
				swSec6.SetSecret (new MemorySecret (info2, Memory.PirateTokay, returnSecret));
				swSec7.SetSecret (new MemorySecret (info2, Memory.TempleMamamu, returnSecret));
				swSec8.SetSecret (new MemorySecret (info2, Memory.DekuTingle, returnSecret));
				swSec9.SetSecret (new MemorySecret (info2, Memory.BiggoronElder, returnSecret));
				swSec10.SetSecret (new MemorySecret (info2, Memory.RuulSymmetry, returnSecret));
			}
			
			if (_info.Game == Game.Ages)
			{
				lblMem1.Text = "Clock Shop";
				lblMem2.Text = "Graveyard";
				lblMem3.Text = "Subrosian";
				lblMem4.Text = "Diver";
				lblMem5.Text = "Smith";
				lblMem6.Text = "Pirate";
				lblMem7.Text = "Temple";
				lblMem8.Text = "Deku";
				lblMem9.Text = "Biggoron";
				lblMem10.Text = "Ruul";
			}
			else
			{
				lblMem1.Text = "King Zora";
				lblMem2.Text = "Fairy";
				lblMem3.Text = "Troy";
				lblMem4.Text = "Plen";
				lblMem5.Text = "Library";
				lblMem6.Text = "Tokay";
				lblMem7.Text = "Mamamu";
				lblMem8.Text = "Tingle";
				lblMem9.Text = "Elder";
				lblMem10.Text = "Symmetry";
			}
		}

		protected void OnButtonOkPressed(object sender, EventArgs e)
		{
			this.Respond(Gtk.ResponseType.Ok);
		}
	}
}

