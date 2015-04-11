using System;

namespace Zyrenth.OracleHack.GtkUI
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
		}
		
		private void SetSecrets()
		{
			swGame.SetSecret(_info.CreateGameSecret());
			swRings.SetSecret(_info.CreateRingSecret());
			
			if (_info.IsLinkedGame)
			{
				bool returnSecret = true;
				swMem1.SetSecret(_info.CreateMemorySecret(Memory.ClockShopKingZora, returnSecret));
				swMem2.SetSecret(_info.CreateMemorySecret(Memory.GraveyardFairy, returnSecret));
				swMem3.SetSecret(_info.CreateMemorySecret(Memory.SubrosianTroy, returnSecret));
				swMem4.SetSecret(_info.CreateMemorySecret(Memory.DiverPlen, returnSecret));
				swMem5.SetSecret(_info.CreateMemorySecret(Memory.SmithLibrary, returnSecret));
				swMem6.SetSecret(_info.CreateMemorySecret(Memory.PirateTokay, returnSecret));
				swMem7.SetSecret(_info.CreateMemorySecret(Memory.TempleMamamu, returnSecret));
				swMem8.SetSecret(_info.CreateMemorySecret(Memory.DekuTingle, returnSecret));
				swMem9.SetSecret(_info.CreateMemorySecret(Memory.BiggoronElder, returnSecret));
				swMem10.SetSecret(_info.CreateMemorySecret(Memory.RuulSymmetry, returnSecret));
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

