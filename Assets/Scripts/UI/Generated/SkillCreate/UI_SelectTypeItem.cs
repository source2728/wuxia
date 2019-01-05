/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_SelectTypeItem : GButton
	{
		public Controller m_CondType;
		public Controller m_Type;
		public GButton m_Icon;
		public GTextField m_LabelName;
		public GTextField m_LabelCond;
		public GLabel m_LabelTypeValue;
		public GTextField m_LabelCount;

		public const string URL = "ui://7a7mjf879gjyn";

		public static UI_SelectTypeItem CreateInstance()
		{
			return (UI_SelectTypeItem)UIPackage.CreateObject("SkillCreate","SelectTypeItem");
		}

		public UI_SelectTypeItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_CondType = this.GetControllerAt(0);
			m_Type = this.GetControllerAt(1);
			m_Icon = (GButton)this.GetChildAt(1);
			m_LabelName = (GTextField)this.GetChildAt(2);
			m_LabelCond = (GTextField)this.GetChildAt(3);
			m_LabelTypeValue = (GLabel)this.GetChildAt(5);
			m_LabelCount = (GTextField)this.GetChildAt(6);
		}
	}
}