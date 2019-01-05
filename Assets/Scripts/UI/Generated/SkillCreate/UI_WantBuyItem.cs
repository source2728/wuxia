/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_WantBuyItem : GComponent
	{
		public GLoader m_LoaderIcon;
		public GTextField m_LabelName;
		public GButton m_BtnSell;
		public GTextField m_LabelDesc;

		public const string URL = "ui://7a7mjf87ffmq24";

		public static UI_WantBuyItem CreateInstance()
		{
			return (UI_WantBuyItem)UIPackage.CreateObject("SkillCreate","WantBuyItem");
		}

		public UI_WantBuyItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderIcon = (GLoader)this.GetChildAt(2);
			m_LabelName = (GTextField)this.GetChildAt(3);
			m_BtnSell = (GButton)this.GetChildAt(4);
			m_LabelDesc = (GTextField)this.GetChildAt(5);
		}
	}
}