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
			AnimalType animal = AnimalType.None;
			Enum.TryParse<AnimalType>(cmbAnimal.ActiveText, out animal);
			switch(animal)
			{
				case AnimalType.Ricky:
					imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource ("Zyrenth.OracleGtk.Resources.Ricky.gif");
					break;
				case AnimalType.Dimitri:
					imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource ("Zyrenth.OracleGtk.Resources.Dimitri.gif");
					break;
				case AnimalType.Moosh:
					imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource ("Zyrenth.OracleGtk.Resources.Moosh.gif");
					break;
				default:
					imgAnimal.Pixbuf = null;
					break;
			}
		}
	}
}

