/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_GoodsIcon : GButton
	{
		public Controller m_Quality;
		public GLoader m_IconHead;
		public GTextField m_LabelName;
		public GTextField m_LabelCount;

		public const string URL = "ui://e9zbmha111qbg1s";

		public static UI_GoodsIcon CreateInstance()
		{
			return (UI_GoodsIcon)UIPackage.CreateObject("Common","GoodsIcon");
		}

		public UI_GoodsIcon()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Quality = this.GetControllerAt(0);
			m_IconHead = (GLoader)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(4);
			m_LabelCount = (GTextField)this.GetChildAt(5);
		}
	}
}