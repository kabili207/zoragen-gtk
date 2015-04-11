using System;
using Gtk;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zyrenth.OracleHack.GtkUI
{
	public partial class DecoderForm : Gtk.Dialog
	{
		private byte[] data;
		private int currentPic;
		private int _secretLength;
		
		public enum SecretType
		{
			Game,
			Ring,
			Memory
		}
		
		public SecretType Mode = SecretType.Game;
		
		public GameInfo GameInfo { get; set; }
		
		public bool DebugMode { get; set; }
		
		public DecoderForm() : 
			this(SecretType.Game)
		{
		}
		
		public DecoderForm(SecretType mode)
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
			data = new byte[_secretLength];
			Mode = mode;
			chkAppendRings.Visible = Mode == SecretType.Ring;
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
					secretwidget1.SetSecret(data);
				}
				else
				{
					data[currentPic] = id;
					currentPic++;
					secretwidget1.SetSecret(data.Take(currentPic).ToArray());
				}

				txtSymbols.Text = GameInfo.ByteArrayToSecretString(data.Take(currentPic).ToArray());
			}
		}

		protected void OnBtnResetClicked(object sender, EventArgs e)
		{
			secretwidget1.Reset();
			currentPic = 0;
			txtSymbols.Text = GameInfo.ByteArrayToSecretString(data.Take(currentPic).ToArray());
		}

		protected void OnBtnBackClicked(object sender, EventArgs e)
		{
			if (currentPic > 0)
				currentPic--;
			secretwidget1.SetSecret(data.Take(currentPic).ToArray());
			txtSymbols.Text = GameInfo.ByteArrayToSecretString(data.Take(currentPic).ToArray());
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
						GameInfo.LoadGameData(trimmedData);
						break;
					case SecretType.Ring:
						GameInfo.LoadRings(trimmedData, chkAppendRings.Active);
						break;
					case SecretType.Memory:
						GameInfo.ReadMemorySecret(trimmedData);
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
				byte[] parsedSecret = GameInfo.SecretStringToByteArray(txtSymbols.Text);
				byte[] trimmedData = parsedSecret.Take(parsedSecret.Length.Clamp(0, _secretLength)).ToArray();

				secretwidget1.SetSecret(trimmedData);

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
			txtSymbols.Text = GameInfo.ByteArrayToSecretString(data.Take(currentPic).ToArray());
		}

	}
}

