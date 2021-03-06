
// This file has been generated by the GUI designer. Do not modify.
namespace Zyrenth.ZoraGen.GtkUI
{
	public partial class ViewSecretsDialog
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Label label1;

		private global::Zyrenth.ZoraGen.GtkUI.LargeSecretWidget swGame;

		private global::Gtk.Alignment alignment1;

		private global::Gtk.Label palInfoLabel;

		private global::Gtk.Label label2;

		private global::Zyrenth.ZoraGen.GtkUI.LargeSecretWidget swRings;

		private global::Gtk.Label label4;

		private global::Gtk.Table table2;

		private global::Gtk.Label label5;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec1;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec10;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec2;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec3;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec4;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec5;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec6;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec7;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec8;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swSec9;

		private global::Gtk.Table table1;

		private global::Gtk.Label label3;

		private global::Gtk.Label lblMem1;

		private global::Gtk.Label lblMem10;

		private global::Gtk.Label lblMem2;

		private global::Gtk.Label lblMem3;

		private global::Gtk.Label lblMem4;

		private global::Gtk.Label lblMem5;

		private global::Gtk.Label lblMem6;

		private global::Gtk.Label lblMem7;

		private global::Gtk.Label lblMem8;

		private global::Gtk.Label lblMem9;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem1;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem10;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem2;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem3;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem4;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem5;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem6;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem7;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem8;

		private global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget swMem9;

		private global::Gtk.Button buttonOk;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Zyrenth.ZoraGen.GtkUI.ViewSecretsDialog
			this.Name = "Zyrenth.ZoraGen.GtkUI.ViewSecretsDialog";
			this.Title = global::Mono.Unix.Catalog.GetString("Generate Secrets");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource("Zyrenth.ZoraGen.GtkUI.Farore.ico");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.DestroyWithParent = true;
			// Internal child Zyrenth.ZoraGen.GtkUI.ViewSecretsDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(8));
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Secret to start game:");
			this.vbox2.Add(this.label1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.swGame = new global::Zyrenth.ZoraGen.GtkUI.LargeSecretWidget();
			this.swGame.WidthRequest = 172;
			this.swGame.HeightRequest = 52;
			this.swGame.Events = ((global::Gdk.EventMask)(256));
			this.swGame.Name = "swGame";
			this.vbox2.Add(this.swGame);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.swGame]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.BottomPadding = ((uint)(4));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.palInfoLabel = new global::Gtk.Label();
			this.palInfoLabel.Name = "palInfoLabel";
			this.alignment1.Add(this.palInfoLabel);
			this.vbox2.Add(this.alignment1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.alignment1]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Ring Secret:");
			this.vbox2.Add(this.label2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label2]));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.swRings = new global::Zyrenth.ZoraGen.GtkUI.LargeSecretWidget();
			this.swRings.WidthRequest = 172;
			this.swRings.HeightRequest = 52;
			this.swRings.Events = ((global::Gdk.EventMask)(256));
			this.swRings.Name = "swRings";
			this.vbox2.Add(this.swRings);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.swRings]));
			w7.Position = 4;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.WidthRequest = 172;
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Memory secrets can only be used AFTER you find the corresponding person in the game.");
			this.label4.Wrap = true;
			this.vbox2.Add(this.label4);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label4]));
			w8.Position = 5;
			w8.Expand = false;
			w8.Fill = false;
			this.hbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.table2 = new global::Gtk.Table(((uint)(11)), ((uint)(1)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(1));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Secret\n(for Game1)");
			this.label5.Justify = ((global::Gtk.Justification)(2));
			this.table2.Add(this.label5);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table2[this.label5]));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec1 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec1.Events = ((global::Gdk.EventMask)(256));
			this.swSec1.Name = "swSec1";
			this.table2.Add(this.swSec1);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec1]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec10 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec10.Events = ((global::Gdk.EventMask)(256));
			this.swSec10.Name = "swSec10";
			this.table2.Add(this.swSec10);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec10]));
			w12.TopAttach = ((uint)(10));
			w12.BottomAttach = ((uint)(11));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec2 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec2.Events = ((global::Gdk.EventMask)(256));
			this.swSec2.Name = "swSec2";
			this.table2.Add(this.swSec2);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec2]));
			w13.TopAttach = ((uint)(2));
			w13.BottomAttach = ((uint)(3));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec3 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec3.Events = ((global::Gdk.EventMask)(256));
			this.swSec3.Name = "swSec3";
			this.table2.Add(this.swSec3);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec3]));
			w14.TopAttach = ((uint)(3));
			w14.BottomAttach = ((uint)(4));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec4 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec4.Events = ((global::Gdk.EventMask)(256));
			this.swSec4.Name = "swSec4";
			this.table2.Add(this.swSec4);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec4]));
			w15.TopAttach = ((uint)(4));
			w15.BottomAttach = ((uint)(5));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec5 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec5.Events = ((global::Gdk.EventMask)(256));
			this.swSec5.Name = "swSec5";
			this.table2.Add(this.swSec5);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec5]));
			w16.TopAttach = ((uint)(5));
			w16.BottomAttach = ((uint)(6));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec6 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec6.Events = ((global::Gdk.EventMask)(256));
			this.swSec6.Name = "swSec6";
			this.table2.Add(this.swSec6);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec6]));
			w17.TopAttach = ((uint)(6));
			w17.BottomAttach = ((uint)(7));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec7 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec7.Events = ((global::Gdk.EventMask)(256));
			this.swSec7.Name = "swSec7";
			this.table2.Add(this.swSec7);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec7]));
			w18.TopAttach = ((uint)(7));
			w18.BottomAttach = ((uint)(8));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec8 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec8.Events = ((global::Gdk.EventMask)(256));
			this.swSec8.Name = "swSec8";
			this.table2.Add(this.swSec8);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec8]));
			w19.TopAttach = ((uint)(8));
			w19.BottomAttach = ((uint)(9));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.swSec9 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swSec9.Events = ((global::Gdk.EventMask)(256));
			this.swSec9.Name = "swSec9";
			this.table2.Add(this.swSec9);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table2[this.swSec9]));
			w20.TopAttach = ((uint)(9));
			w20.BottomAttach = ((uint)(10));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox1.Add(this.table2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.table2]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			w21.Padding = ((uint)(6));
			// Container child hbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(11)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(1));
			this.table1.ColumnSpacing = ((uint)(8));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Memories\n(for Game2)");
			this.label3.Justify = ((global::Gtk.Justification)(2));
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem1 = new global::Gtk.Label();
			this.lblMem1.Name = "lblMem1";
			this.lblMem1.Xalign = 0F;
			this.lblMem1.LabelProp = global::Mono.Unix.Catalog.GetString("label1");
			this.table1.Add(this.lblMem1);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem1]));
			w23.TopAttach = ((uint)(1));
			w23.BottomAttach = ((uint)(2));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(2));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem10 = new global::Gtk.Label();
			this.lblMem10.Name = "lblMem10";
			this.lblMem10.Xalign = 0F;
			this.lblMem10.LabelProp = global::Mono.Unix.Catalog.GetString("label10");
			this.table1.Add(this.lblMem10);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem10]));
			w24.TopAttach = ((uint)(10));
			w24.BottomAttach = ((uint)(11));
			w24.LeftAttach = ((uint)(1));
			w24.RightAttach = ((uint)(2));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem2 = new global::Gtk.Label();
			this.lblMem2.Name = "lblMem2";
			this.lblMem2.Xalign = 0F;
			this.table1.Add(this.lblMem2);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem2]));
			w25.TopAttach = ((uint)(2));
			w25.BottomAttach = ((uint)(3));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem3 = new global::Gtk.Label();
			this.lblMem3.Name = "lblMem3";
			this.lblMem3.Xalign = 0F;
			this.lblMem3.LabelProp = global::Mono.Unix.Catalog.GetString("label3");
			this.table1.Add(this.lblMem3);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem3]));
			w26.TopAttach = ((uint)(3));
			w26.BottomAttach = ((uint)(4));
			w26.LeftAttach = ((uint)(1));
			w26.RightAttach = ((uint)(2));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem4 = new global::Gtk.Label();
			this.lblMem4.Name = "lblMem4";
			this.lblMem4.Xalign = 0F;
			this.lblMem4.LabelProp = global::Mono.Unix.Catalog.GetString("label4");
			this.table1.Add(this.lblMem4);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem4]));
			w27.TopAttach = ((uint)(4));
			w27.BottomAttach = ((uint)(5));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(2));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem5 = new global::Gtk.Label();
			this.lblMem5.Name = "lblMem5";
			this.lblMem5.Xalign = 0F;
			this.lblMem5.LabelProp = global::Mono.Unix.Catalog.GetString("label5");
			this.table1.Add(this.lblMem5);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem5]));
			w28.TopAttach = ((uint)(5));
			w28.BottomAttach = ((uint)(6));
			w28.LeftAttach = ((uint)(1));
			w28.RightAttach = ((uint)(2));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem6 = new global::Gtk.Label();
			this.lblMem6.Name = "lblMem6";
			this.lblMem6.Xalign = 0F;
			this.lblMem6.LabelProp = global::Mono.Unix.Catalog.GetString("label6");
			this.table1.Add(this.lblMem6);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem6]));
			w29.TopAttach = ((uint)(6));
			w29.BottomAttach = ((uint)(7));
			w29.LeftAttach = ((uint)(1));
			w29.RightAttach = ((uint)(2));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem7 = new global::Gtk.Label();
			this.lblMem7.Name = "lblMem7";
			this.lblMem7.Xalign = 0F;
			this.lblMem7.LabelProp = global::Mono.Unix.Catalog.GetString("label7");
			this.table1.Add(this.lblMem7);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem7]));
			w30.TopAttach = ((uint)(7));
			w30.BottomAttach = ((uint)(8));
			w30.LeftAttach = ((uint)(1));
			w30.RightAttach = ((uint)(2));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem8 = new global::Gtk.Label();
			this.lblMem8.Name = "lblMem8";
			this.lblMem8.Xalign = 0F;
			this.lblMem8.LabelProp = global::Mono.Unix.Catalog.GetString("label8");
			this.table1.Add(this.lblMem8);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem8]));
			w31.TopAttach = ((uint)(8));
			w31.BottomAttach = ((uint)(9));
			w31.LeftAttach = ((uint)(1));
			w31.RightAttach = ((uint)(2));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblMem9 = new global::Gtk.Label();
			this.lblMem9.Name = "lblMem9";
			this.lblMem9.Xalign = 0F;
			this.lblMem9.LabelProp = global::Mono.Unix.Catalog.GetString("label9");
			this.table1.Add(this.lblMem9);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.table1[this.lblMem9]));
			w32.TopAttach = ((uint)(9));
			w32.BottomAttach = ((uint)(10));
			w32.LeftAttach = ((uint)(1));
			w32.RightAttach = ((uint)(2));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem1 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem1.Events = ((global::Gdk.EventMask)(256));
			this.swMem1.Name = "swMem1";
			this.table1.Add(this.swMem1);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem1]));
			w33.TopAttach = ((uint)(1));
			w33.BottomAttach = ((uint)(2));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem10 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem10.Events = ((global::Gdk.EventMask)(256));
			this.swMem10.Name = "swMem10";
			this.table1.Add(this.swMem10);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem10]));
			w34.TopAttach = ((uint)(10));
			w34.BottomAttach = ((uint)(11));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem2 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem2.Events = ((global::Gdk.EventMask)(256));
			this.swMem2.Name = "swMem2";
			this.table1.Add(this.swMem2);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem2]));
			w35.TopAttach = ((uint)(2));
			w35.BottomAttach = ((uint)(3));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem3 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem3.Events = ((global::Gdk.EventMask)(256));
			this.swMem3.Name = "swMem3";
			this.table1.Add(this.swMem3);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem3]));
			w36.TopAttach = ((uint)(3));
			w36.BottomAttach = ((uint)(4));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem4 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem4.Events = ((global::Gdk.EventMask)(256));
			this.swMem4.Name = "swMem4";
			this.table1.Add(this.swMem4);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem4]));
			w37.TopAttach = ((uint)(4));
			w37.BottomAttach = ((uint)(5));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem5 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem5.Events = ((global::Gdk.EventMask)(256));
			this.swMem5.Name = "swMem5";
			this.table1.Add(this.swMem5);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem5]));
			w38.TopAttach = ((uint)(5));
			w38.BottomAttach = ((uint)(6));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem6 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem6.Events = ((global::Gdk.EventMask)(256));
			this.swMem6.Name = "swMem6";
			this.table1.Add(this.swMem6);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem6]));
			w39.TopAttach = ((uint)(6));
			w39.BottomAttach = ((uint)(7));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem7 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem7.Events = ((global::Gdk.EventMask)(256));
			this.swMem7.Name = "swMem7";
			this.table1.Add(this.swMem7);
			global::Gtk.Table.TableChild w40 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem7]));
			w40.TopAttach = ((uint)(7));
			w40.BottomAttach = ((uint)(8));
			w40.XOptions = ((global::Gtk.AttachOptions)(4));
			w40.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem8 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem8.Events = ((global::Gdk.EventMask)(256));
			this.swMem8.Name = "swMem8";
			this.table1.Add(this.swMem8);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem8]));
			w41.TopAttach = ((uint)(8));
			w41.BottomAttach = ((uint)(9));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.swMem9 = new global::Zyrenth.ZoraGen.GtkUI.SmallSecretWidget();
			this.swMem9.Events = ((global::Gdk.EventMask)(256));
			this.swMem9.Name = "swMem9";
			this.table1.Add(this.swMem9);
			global::Gtk.Table.TableChild w42 = ((global::Gtk.Table.TableChild)(this.table1[this.swMem9]));
			w42.TopAttach = ((uint)(9));
			w42.BottomAttach = ((uint)(10));
			w42.XOptions = ((global::Gtk.AttachOptions)(4));
			w42.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox1.Add(this.table1);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.table1]));
			w43.Position = 2;
			w43.Expand = false;
			w43.Fill = false;
			w1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(w1[this.hbox1]));
			w44.Position = 0;
			w44.Expand = false;
			w44.Fill = false;
			// Internal child Zyrenth.ZoraGen.GtkUI.ViewSecretsDialog.ActionArea
			global::Gtk.HButtonBox w45 = this.ActionArea;
			w45.Name = "dialog1_ActionArea";
			w45.Spacing = 10;
			w45.BorderWidth = ((uint)(5));
			w45.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget(this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w46 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w45[this.buttonOk]));
			w46.Expand = false;
			w46.Fill = false;
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 403;
			this.DefaultHeight = 313;
			this.Show();
			this.buttonOk.Pressed += new global::System.EventHandler(this.OnButtonOkPressed);
		}
	}
}
