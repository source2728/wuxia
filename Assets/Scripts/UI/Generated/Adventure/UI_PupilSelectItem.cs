/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_PupilSelectItem : GButton
	{
		public GLoader m_LoaderHead;
		public GTextField m_LabelLevel;
		public GLabel m_LabelName;
		public GTextField m_LabelAttr1;
		public GTextField m_LabelAttr2;
		public GComponent m_StarLevel;

		public const string URL = "ui://h4qtyuejnlw425";

		public static UI_PupilSelectItem CreateInstance()
		{
			return (UI_PupilSelectItem)UIPackage.CreateObject("Adventure","PupilSelectItem");
		}

		public UI_PupilSelectItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderHead = (GLoader)this.GetChildAt(2);
			m_LabelLevel = (GTextField)this.GetChildAt(4);
			m_LabelName = (GLabel)this.GetChildAt(5);
			m_LabelAttr1 = (GTextField)this.GetChildAt(7);
			m_LabelAttr2 = (GTextField)this.GetChildAt(9);
			m_StarLevel = (GComponent)this.GetChildAt(11);
		}
	}
}