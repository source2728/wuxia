/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_GainSkill : GComponent
	{
		public Controller m_ViewState;
		public GButton m_Icon;
		public GTextField m_LabelBasePower;
		public GTextField m_LabelQuality;
		public GTextField m_LabelName;
		public GButton m_BtnNotSell;
		public GList m_List;

		public const string URL = "ui://7a7mjf87l1388";

		public static UI_GainSkill CreateInstance()
		{
			return (UI_GainSkill)UIPackage.CreateObject("SkillCreate","GainSkill");
		}

		public UI_GainSkill()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_Icon = (GButton)this.GetChildAt(2);
			m_LabelBasePower = (GTextField)this.GetChildAt(4);
			m_LabelQuality = (GTextField)this.GetChildAt(5);
			m_LabelName = (GTextField)this.GetChildAt(7);
			m_BtnNotSell = (GButton)this.GetChildAt(8);
			m_List = (GList)this.GetChildAt(9);
		}
	}
}