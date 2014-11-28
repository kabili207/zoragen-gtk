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
			VbaAnimalType animal = VbaAnimalType.None;
			Enum.TryParse<VbaAnimalType>(cmbAnimal.ActiveText, out animal);
			switch (animal)
			{
				case VbaAnimalType.Ricky:
					imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleGtk.Images.Characters.Ricky.gif");
					break;
				case VbaAnimalType.Dimitri:
					imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleGtk.Images.Characters.Dimitri.gif");
					break;
				case VbaAnimalType.Moosh:
					imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleGtk.Images.Characters.Moosh.gif");
					break;
				default:
					imgAnimal.Pixbuf = null;
					break;
			}
		}
	}
}

