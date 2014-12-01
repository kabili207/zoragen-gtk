using System;
using Gtk;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zyrenth.OracleHack.GtkUI
{
	public partial class DecoderForm : Gtk.Window
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
		
		public DecoderForm(SecretType mode) : 
			base(Gtk.WindowType.Toplevel)
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
			//chkAppendRings.Visibility = Mode == SecretType.Ring ? Visibility.Visible : Visibility.Collapsed;
		}

		protected void OnSymbolClicked(object sender, EventArgs e)
		{
			Widget ctl = sender as Widget;
			if (ctl != null)
			{
				string num = Regex.Replace(ctl.Name, @"\D", "");
				byte id = byte.Parse(num);
				
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
			}
		}

		protected void OnBtnResetClicked(object sender, EventArgs e)
		{
			secretwidget1.Reset();
			currentPic = 0;
		}

		protected void OnBtnBackClicked(object sender, EventArgs e)
		{
			if (currentPic > 0)
				currentPic--;
			secretwidget1.SetSecret(data.Take(currentPic).ToArray());
		}

		protected void OnBtnDoneClicked(object sender, EventArgs e)
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
				
				//this.Close();
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

	}
}

