/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Explore
{
	public partial class UI_PlaceSelectItem : GButton
	{
		public GTextField m_LabelName;
		public GTextField m_LabelLevel;
		public GTextField m_LabelProgress;

		public const string URL = "ui://cxpqtm7pm8xy1d";

		public static UI_PlaceSelectItem CreateInstance()
		{
			return (UI_PlaceSelectItem)UIPackage.CreateObject("Explore","PlaceSelectItem");
		}

		public UI_PlaceSelectItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelName = (GTextField)this.GetChildAt(3);
			m_LabelLevel = (GTextField)this.GetChildAt(4);
			m_LabelProgress = (GTextField)this.GetChildAt(5);
		}
	}
}