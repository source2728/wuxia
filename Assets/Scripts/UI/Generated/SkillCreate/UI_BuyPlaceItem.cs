/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_BuyPlaceItem : GComponent
	{
		public Controller m_Hot;
		public GLoader m_LoaderIcon;
		public GLabel m_LabelName;
		public GTextField m_LabelInfo1;
		public GTextField m_LabelInfo2;

		public const string URL = "ui://7a7mjf87deyy1s";

		public static UI_BuyPlaceItem CreateInstance()
		{
			return (UI_BuyPlaceItem)UIPackage.CreateObject("SkillCreate","BuyPlaceItem");
		}

		public UI_BuyPlaceItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Hot = this.GetControllerAt(0);
			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelName = (GLabel)this.GetChildAt(2);
			m_LabelInfo1 = (GTextField)this.GetChildAt(3);
			m_LabelInfo2 = (GTextField)this.GetChildAt(4);
		}
	}
}