using System;
using Gtk;
using Zyrenth.OracleHack;

namespace Zyrenth.OracleGtk
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
			throw new System.NotImplementedException();
		}

		protected void OnBtnEncodeClicked(object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException();
		}

		protected void OnCmbAnimalChanged(object sender, System.EventArgs e)
		{
			Animal animal;
			if(!Enum.TryParse<Animal>(cmbAnimal.ActiveText, out animal))
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
	}
}

