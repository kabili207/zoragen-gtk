using System;
using Gtk;

namespace Zyrenth.OracleHack.GtkUI
{
	public partial class SaveEditor : Gtk.Window
	{
		public SaveEditor() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();

		}
		
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

		protected void OnBtnDecodeClicked(object sender, System.EventArgs e)
		{
			DecoderForm form = new DecoderForm();
			form.Show();
		}

		protected void OnBtnRingsClicked(object sender, System.EventArgs e)
		{

		}

		protected void OnBtnEncodeClicked(object sender, System.EventArgs e)
		{

		}

		protected void OnCmbAnimalChanged(object sender, System.EventArgs e)
		{
			Animal animal;
			if (!Enum.TryParse<Animal>(cmbAnimal.ActiveText, out animal))
			{
				imgAnimal.Pixbuf = null;
			}
			else
			{
				switch (animal)
				{
					case Animal.Ricky:
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleGtk.Images.Characters.Ricky.gif");
						break;
					case Animal.Dimitri:
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleGtk.Images.Characters.Dimitri.gif");
						break;
					case Animal.Moosh:
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleGtk.Images.Characters.Moosh.gif");
						break;
					default:
						imgAnimal.Pixbuf = null;
						break;
				}
			}
		}

		protected void OnNew(object sender, EventArgs e)
		{

		}

		protected void OnOpen(object sender, EventArgs e)
		{

		}

		protected void OnSave(object sender, EventArgs e)
		{

		}

		protected void OnSaveAs(object sender, EventArgs e)
		{

		}

		protected void OnQuit(object sender, EventArgs e)
		{

		}

		protected void OnLoadGameSecret(object sender, EventArgs e)
		{

		}

		protected void OnLoadRingSecret(object sender, EventArgs e)
		{

		}

		protected void OnGenerateSecrets(object sender, EventArgs e)
		{

		}


	}
}

