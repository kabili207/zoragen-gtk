using System;
using System.Linq;

namespace Zyrenth.OracleHack.GtkUI
{
	[Gtk.TreeNode(ListOnly = true)]
	public class RingTreeNode : Gtk.TreeNode
	{
		const string ImagePattern = "Zyrenth.OracleHack.GtkUI.Images.Rings.{0}.gif";

		Rings _ringValue;
		string _name;
		string _description;

		[Gtk.TreeNodeValue(Column = 0)]
		public bool IsChecked { get; set; }

		[Gtk.TreeNodeValue(Column = 2)]
		public string Name { get { return _name; } }


		[Gtk.TreeNodeValue(Column = 1)]
		public Gdk.Pixbuf Image
		{
			get
			{
				return Gdk.Pixbuf.LoadFromResource(string.Format(ImagePattern, _ringValue));
			}
		}

		public Rings RingValue
		{
			get { return _ringValue; }
		}

		public RingTreeNode(Rings ringValue)
		{
			_ringValue = ringValue;
			Type ringType = typeof(Rings);
			Type infoType = typeof(RingInfoAttribute);

			RingInfoAttribute attr = ringType.GetMember(ringValue.ToString())[0].GetCustomAttributes(infoType, false)
					.Cast<RingInfoAttribute>().SingleOrDefault();

			_name = attr.name;
			_description = attr.description;
		}
	}
}

