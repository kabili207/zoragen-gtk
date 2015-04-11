using System;
using Gtk;
using System.Diagnostics;
using System.Reflection;

namespace Zyrenth.OracleHack.GtkUI
{
	public partial class MainWindow : Gtk.Window
	{
		GameInfo _info = new GameInfo();
		string _currentFile = null;

		public MainWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();

			foreach (var val in Enum.GetNames(typeof(ChildBehavior)))
			{
				cmbBehavior.AppendText(val);
			}
			cmbBehavior.Active = 0;
			OnCmbAnimalChanged(this, EventArgs.Empty);
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

		protected void OnBtnRingsClicked(object sender, System.EventArgs e)
		{

		}

		protected void OnBtnEncodeClicked(object sender, System.EventArgs e)
		{

		}

		protected void OnNew(object sender, EventArgs e)
		{

		}

		protected void OnOpen(object sender, EventArgs e)
		{
			Gtk.FileChooserDialog fc =
				new Gtk.FileChooserDialog("Choose the file to open",
					this,
					FileChooserAction.Open,
					"Cancel", ResponseType.Cancel,
					"Open", ResponseType.Accept);
			var filter = new FileFilter();
			filter.Name = "Zora Files";
			filter.AddPattern("*.zora");
			fc.AddFilter(filter);

			if (fc.Run() == (int)ResponseType.Accept)
			{
				using (System.IO.FileStream file = System.IO.File.OpenRead(fc.Filename))
				{
					_info = GameInfo.Load(file);
					_currentFile = fc.Filename;
					SetControlValues();
				}
			}
			//Don't forget to call Destroy() or the FileChooserDialog window won't get closed.
			fc.Destroy();
		}

		protected void OnSave(object sender, EventArgs e)
		{

		}

		protected void OnSaveAs(object sender, EventArgs e)
		{

		}

		protected void OnQuit(object sender, EventArgs e)
		{
			ProcessEvent(Gdk.EventHelper.New(Gdk.EventType.Delete));
		}

		protected void OnLoadGameSecret(object sender, EventArgs e)
		{
			var dialog = new DecoderForm(DecoderForm.SecretType.Game);
			dialog.GameInfo = _info;
			dialog.Modal = true;
			dialog.Show();
			_info = dialog.GameInfo;
		}

		protected void OnLoadRingSecret(object sender, EventArgs e)
		{
			var dialog = new DecoderForm(DecoderForm.SecretType.Ring);
			dialog.GameInfo = _info;
			dialog.Modal = true;
			dialog.Show();
		}

		protected void OnGenerateSecrets(object sender, EventArgs e)
		{
			GetControlValues();
			if (_info.GameID == 0)
			{
				Random rnd = new Random();
				_info.GameID = (short)rnd.Next(1, short.MaxValue);
				spinID.Value = _info.GameID;
			}
			var dialog = new ViewSecretsDialog(_info);
			dialog.Run();
			dialog.Destroy();
		}

		protected void OnAbout(object sender, EventArgs e)
		{
			AboutDialog dialog = new AboutDialog();
			Assembly asmCurrent = Assembly.GetExecutingAssembly();

			AssemblyDetail details = new AssemblyDetail(asmCurrent);

			dialog.ProgramName = details.Product;
			dialog.Version = details.ProductVersion;
			dialog.Comments = "The Legend of Zelda is a trademark of Nintendo of America, Inc.\n" +
			"Images used in this program are copyright their respective owners.";
			dialog.Authors = new string [] { "Andrew Nagle" };
			dialog.Website = "https://github.com/kabili207/oracle-hack-gtk";
			dialog.Copyright = details.Copyright;
			dialog.Logo = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleHack.GtkUI.Farore.ico");
			dialog.Icon = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleHack.GtkUI.Farore.ico");
			dialog.Run();
			dialog.Destroy();
		}

		private void SetControlValues()
		{
			txtHero.Text = _info.Hero;
			txtChild.Text = _info.Child;
			spinID.Value = _info.GameID;
			chkLinked.Active = _info.IsLinkedGame;
			chkHeros.Active = _info.IsHeroQuest;
			cmbAnimal.SetActiveText(_info.Animal.ToString());
			cmbBehavior.SetActiveText(_info.Behavior.ToString());

			if (_info.Game == Game.Ages)
				rdoAges.Active = true;
			else
				rdoSeasons.Active = true;

			// TODO: Set rings
		}

		private void GetControlValues()
		{
			_info.Hero = txtHero.Text;
			_info.Child = txtChild.Text;
			_info.GameID = (short)spinID.ValueAsInt;
			_info.IsLinkedGame = chkLinked.Active;
			_info.IsHeroQuest = chkHeros.Active;

			_info.Game = rdoAges.Active ? Game.Ages : Game.Seasons;

			ChildBehavior behavior;
			if (!Enum.TryParse<ChildBehavior>(cmbBehavior.ActiveText, out behavior))
			{
				_info.Behavior = ChildBehavior.Infant;
			}
			else
			{
				_info.Behavior = behavior;
			}

			Animal animal;
			if (!Enum.TryParse<Animal>(cmbAnimal.ActiveText, out animal))
			{
				imgAnimal.Pixbuf = null;
			}
			else
			{
				_info.Animal = animal;
			}

			// TODO: Set rings
		}

		protected void OnTxtHeroChanged(object sender, EventArgs e)
		{
			_info.Hero = txtHero.Text;
		}

		protected void OnTxtChildChanged(object sender, EventArgs e)
		{
			_info.Child = txtChild.Text;
		}

		protected void OnSpinIDChanged(object sender, EventArgs e)
		{
			_info.GameID = (short)spinID.ValueAsInt;
		}

		protected void OnChkLinkedToggled(object sender, EventArgs e)
		{
			_info.IsLinkedGame = chkLinked.Active;
		}

		protected void OnChkHerosToggled(object sender, EventArgs e)
		{
			_info.IsHeroQuest = chkHeros.Active;
		}

		protected void OnCmbBehaviorChanged(object sender, EventArgs e)
		{
			ChildBehavior behavior;
			if (!Enum.TryParse<ChildBehavior>(cmbBehavior.ActiveText, out behavior))
			{
				_info.Behavior = ChildBehavior.Infant;
			}
			else
			{
				_info.Behavior = behavior;
			}
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
				_info.Animal = animal;
				switch (animal)
				{
					default:
					case Animal.Ricky:
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleHack.GtkUI.Images.Characters.Ricky.gif");
						break;
					case Animal.Dimitri:
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleHack.GtkUI.Images.Characters.Dimitri.gif");
						break;
					case Animal.Moosh:
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.OracleHack.GtkUI.Images.Characters.Moosh.gif");
						break;
				}
			}
		}
	}
}

