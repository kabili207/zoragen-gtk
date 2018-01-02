/*
 * Copyright © 2013-2015, Andrew Nagle.
 * All rights reserved.
 * 
 * This file is part of ZoraGen GTK.
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Zyrenth.Zora;

namespace Zyrenth.ZoraGen.GtkUI
{
	public partial class MainWindow : Gtk.Window
	{
		GameInfo _info = new GameInfo();
		string _currentFile = null;

		Gtk.NodeStore _ringStore;

		Gtk.NodeStore RingStore
		{
			get
			{
				if (_ringStore == null)
				{
					_ringStore = new Gtk.NodeStore(typeof(RingTreeNode));

					Type ringType = typeof(Rings);

					Array values = Enum.GetValues(ringType);
					var availableRings = values.OfType<Rings>().Where(x => x != Rings.All && x != Rings.None)
						.OrderBy(x => (ulong)x).ToList();

					foreach (var val in availableRings)
						_ringStore.AddNode(new RingTreeNode(val));
				}
				return _ringStore;
			}
		}

		public MainWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();

			rdoUS.Active = true;

			foreach (var val in Enum.GetNames(typeof(ChildBehavior)))
			{
				cmbBehavior.AppendText(val);
			}
			cmbBehavior.Active = 0;
			OnCmbAnimalChanged(this, EventArgs.Empty);

			InitializeRings();
			CheckForUpdates(true);
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

		protected void OnNew(object sender, EventArgs e)
		{
			_info = new GameInfo();
			_currentFile = null;
			SetControlValues();
		}

		protected void OnOpen(object sender, EventArgs e)
		{
			OpenFile();
		}

		protected void OnSave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(_currentFile))
				SaveAsFile();
			else
				SaveFile();
		}

		protected void OnSaveAs(object sender, EventArgs e)
		{
			SaveAsFile();
		}

		protected void OnQuit(object sender, EventArgs e)
		{
			ProcessEvent(Gdk.EventHelper.New(Gdk.EventType.Delete));
		}

		protected void OnLoadGameSecret(object sender, EventArgs e)
		{
			GetControlValues();

			var dialog = new DecoderForm(DecoderForm.SecretType.Game, _info.Region);
			dialog.GameInfo = _info;
			dialog.Modal = true;

			if (dialog.Run() == (int)Gtk.ResponseType.Ok)
			{
				_info = dialog.GameInfo;
				SetControlValues();
			}
			dialog.Destroy();
		}

		protected void OnLoadRingSecret(object sender, EventArgs e)
		{
			GetControlValues();

			var dialog = new DecoderForm(DecoderForm.SecretType.Ring, _info.Region);
			dialog.GameInfo = _info;
			dialog.Modal = true;

			if (dialog.Run() == (int)Gtk.ResponseType.Ok)
			{
				_info = dialog.GameInfo;
				SetControlValues();
			}

			dialog.Destroy();
		}

		protected void OnGenerateSecrets(object sender, EventArgs e)
		{
			GenerateSecrets();
		}

		protected void OnAbout(object sender, EventArgs e)
		{
			AboutDialog dialog = new AboutDialog();
			Assembly asmCurrent = Assembly.GetExecutingAssembly();

			AssemblyDetail details = new AssemblyDetail(asmCurrent);

			dialog.ProgramName = details.Product;
			dialog.Version = details.ProductVersion;
			dialog.Comments = details.Description;
			dialog.Authors = new string[] { "Andrew Nagle" };
			dialog.Website = "https://github.com/kabili207/zoragen-gtk";
			dialog.Copyright = details.Copyright;
			dialog.Logo = Gdk.Pixbuf.LoadFromResource("Zyrenth.ZoraGen.GtkUI.Farore.ico");
			dialog.Icon = Gdk.Pixbuf.LoadFromResource("Zyrenth.ZoraGen.GtkUI.Farore.ico");
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
			chkFreeRingGiven.Active = _info.WasGivenFreeRing;
			cmbAnimal.SetActiveText(_info.Animal.ToString());
			cmbBehavior.SetActiveText(_info.Behavior.ToString());

			if (_info.Game == Game.Ages)
				rdoAges.Active = true;
			else
				rdoSeasons.Active = true;

			if (_info.Region == GameRegion.JP)
				rdoJP.Active = true;
			else if (_info.Region == GameRegion.US)
				rdoUS.Active = true;

			foreach (RingTreeNode node in _ringStore.OfType<RingTreeNode>())
			{
				node.IsChecked = (_info.Rings & node.RingValue) == node.RingValue;
			}
			nvRings.QueueDraw();
		}

		private void GetControlValues()
		{
			_info.Hero = txtHero.Text;
			_info.Child = txtChild.Text;
			_info.GameID = (short)spinID.ValueAsInt;
			_info.IsLinkedGame = chkLinked.Active;
			_info.IsHeroQuest = chkHeros.Active;
			_info.WasGivenFreeRing = chkFreeRingGiven.Active;

			_info.Game = rdoAges.Active ? Game.Ages : Game.Seasons;
			_info.Region = rdoJP.Active ? GameRegion.JP : GameRegion.US;

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
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.ZoraGen.GtkUI.Images.Characters.Ricky.gif");
						break;
					case Animal.Dimitri:
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.ZoraGen.GtkUI.Images.Characters.Dimitri.gif");
						break;
					case Animal.Moosh:
						imgAnimal.Pixbuf = Gdk.Pixbuf.LoadFromResource("Zyrenth.ZoraGen.GtkUI.Images.Characters.Moosh.gif");
						break;
				}
			}
		}

		private void SaveFile()
		{
			GetControlValues();
			_info.Write(_currentFile);
		}

		private void SaveAsFile()
		{
			GetControlValues();
			Gtk.FileChooserDialog fc =
				new Gtk.FileChooserDialog("Choose the file to save",
					this,
					FileChooserAction.Save,
					"Cancel", ResponseType.Cancel,
					"Save", ResponseType.Accept);
			var filter = new FileFilter();
			filter.Name = "Zora Files";
			filter.AddPattern("*.zora");
			fc.AddFilter(filter);

			if (fc.Run() == (int)ResponseType.Accept)
			{
				_info.Write(fc.Filename);
				_currentFile = fc.Filename;
			}
			//Don't forget to call Destroy() or the FileChooserDialog window won't get closed.
			fc.Destroy();
		}

		private void OpenFile()
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

			fc.PreviewWidget = new FilePreviewWidget();
			fc.PreviewWidgetActive = false;
			fc.UpdatePreview += OnUpdatePreview;

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

		private void OnUpdatePreview(object sender, EventArgs e)
		{
			var chooser = sender as Gtk.FileChooserDialog;
			if (chooser != null)
			{
				if (chooser.PreviewWidget is FilePreviewWidget)
				{
					try
					{
						using (System.IO.FileStream file = System.IO.File.OpenRead(chooser.PreviewFilename))
						{
							((FilePreviewWidget)chooser.PreviewWidget).GameInfo = GameInfo.Load(file);
							chooser.PreviewWidgetActive = true;
						}
					}
					catch
					{
						chooser.PreviewWidgetActive = false;
					}
				}
				else
				{
					chooser.PreviewWidgetActive = false;
				}
			}
		}

		protected void OnImportBattery(object sender, EventArgs e)
		{
			Gtk.FileChooserDialog fc =
				new Gtk.FileChooserDialog("Choose the file to open",
					this,
					FileChooserAction.Open,
					"Cancel", ResponseType.Cancel,
					"Open", ResponseType.Accept);
			var filter = new FileFilter();
			filter.Name = "Battery Files (*.sav, *.srm)";
			filter.AddPattern("*.sav");
			filter.AddPattern("*.srm");
			fc.AddFilter(filter);

			if (fc.Run() == (int)ResponseType.Accept)
			{
				using (System.IO.FileStream file = System.IO.File.OpenRead(fc.Filename))
				{
					var data = BatteryFileLoader.LoadAll(file);
					OpenGameInfoPicker(data);
				}
			}

			fc.Destroy();
		}

		private void OpenGameInfoPicker(IEnumerable<GameInfo> infos)
		{
			var dialog = new GamePickerDialog(infos);
			dialog.Modal = true;
			if (dialog.Run() == (int)ResponseType.Ok)
			{
				_info = dialog.SelectedGameInfo;
				_currentFile = "";
				SetControlValues();
			}
			dialog.Destroy();
		}

		private void GenerateSecrets()
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

		void InitializeRings()
		{
			nvRings.NodeStore = RingStore;
			var toggleCell = new Gtk.CellRendererToggle();
			toggleCell.Activatable = true;
			toggleCell.Toggled += OnRingToggled;

			nvRings.AppendColumn("d", toggleCell, "active", 0);
			nvRings.AppendColumn("Image", new Gtk.CellRendererPixbuf(), "pixbuf", 1);
			nvRings.AppendColumn("Name", new Gtk.CellRendererText(), "text", 2);
			nvRings.ShowAll();
		}

		void OnRingToggled(object sender, ToggledArgs e)
		{
			RingTreeNode node = _ringStore.GetNode(new Gtk.TreePath(e.Path)) as RingTreeNode;
			node.IsChecked = !node.IsChecked;
			if (node.IsChecked)
				_info.Rings |= node.RingValue;
			else
				_info.Rings ^= node.RingValue;
		}

		protected void OnBtnAllRingsClicked(object sender, EventArgs e)
		{
			foreach (RingTreeNode node in _ringStore.OfType<RingTreeNode>())
			{
				node.IsChecked = true;
			}
			_info.Rings = Rings.All;
			nvRings.QueueDraw();
		}

		protected void OnBtnNoRingsClicked(object sender, EventArgs e)
		{
			foreach (RingTreeNode node in _ringStore.OfType<RingTreeNode>())
			{
				node.IsChecked = false;
			}
			_info.Rings = Rings.None;
			nvRings.QueueDraw();
		}

		private void CheckForUpdates(bool silentCheck)
		{
			List<GitHubRelease> releases = null;
			try
			{
				string sURL;
				sURL = "https://api.github.com/repos/kabili207/zoragen-gtk/releases";

				// Mono doesn't need this, but it's a good idea to do it anyway in case
				// someone decides to run this on the .NET Framework.
				Extensions.SetAllowUnsafeHeaderParsing();

				// Mono, by default, doesn't include ANY ca certificates, nor does
				// it try to bridge to the OS cert store. So we have to trade features
				// for insecurity. I don't like it, but it's better than hard-coding
				// github's certificate...
				ServicePointManager.ServerCertificateValidationCallback =
					new System.Net.Security.RemoteCertificateValidationCallback
					(
						(srvPoint, certificate, chain, errors) => true
					);

				WebRequest request = WebRequest.Create(sURL);

				// GitHub requires a user agent
				((HttpWebRequest)request).UserAgent = "ZoraGen updater";

				using (Stream objStream = request.GetResponse().GetResponseStream())
				{
					StreamReader objReader = new StreamReader(objStream);
					string json = objReader.ReadToEnd();
					var serializer = new JavaScriptSerializer();
					serializer.RegisterConverters(new[] { new GitHubReleaseJsonConverter() });
					releases = serializer.Deserialize<List<GitHubRelease>>(json);
				}
			}
			catch (Exception ex)
			{
				if (!silentCheck)
					MessageBox.Show("Unable to check for updates." + Environment.NewLine +
						ex.Message, "Check for updates", ButtonsType.Ok, MessageType.Error);
			}

			if (releases != null)
			{
				AssemblyDetail detail = new AssemblyDetail(Assembly.GetExecutingAssembly());
				var releaseInfo = releases.Where(x => !x.IsPreRelease && !x.IsDraft &&
					x.TagName.StartsWith("v")).Select(x =>
					{
						string versionString = x.TagName.TrimStart('v', 'V');
						SemanticVersion version = SemanticVersion.Parse(versionString);
						return new { Version = version, Release = x };
					}).Where(x => x.Version > detail.ProductVersion).OrderByDescending(x => x.Version);

				if (releaseInfo.Count() > 0)
				{
					MessageBox.Show("There is an update available." + Environment.NewLine +
						"Current Version: " + detail.ProductVersion + Environment.NewLine +
						"Latest Version: " + releaseInfo.First().Release,
						"Update Available", ButtonsType.YesNo, MessageType.Info);
				}
				else if (!silentCheck)
				{
					MessageBox.Show("There are no new updates available", "No updates", ButtonsType.Ok, MessageType.Info);
				}
			}
		}

		protected void OnCheckForUpdatesActionActivated(object sender, EventArgs e)
		{
			CheckForUpdates(false);
		}
	}
}

