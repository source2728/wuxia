/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_CreateSkillInfo : GComponent
	{
		public GTextField m_LabelBasePower;
		public GTextField m_LabelSkillPower;
		public GTextField m_LabelValue;
		public GTextField m_LabelDiff;
		public GTextField m_LabelBasePowerAdd;
		public GTextField m_LabelSkillPowerAdd;

		public const string URL = "ui://7a7mjf87snek17";

		public static UI_CreateSkillInfo CreateInstance()
		{
			return (UI_CreateSkillInfo)UIPackage.CreateObject("SkillCreate","CreateSkillInfo");
		}

		public UI_CreateSkillInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelBasePower = (GTextField)this.GetChildAt(8);
			m_LabelSkillPower = (GTextField)this.GetChildAt(9);
			m_LabelValue = (GTextField)this.GetChildAt(10);
			m_LabelDiff = (GTextField)this.GetChildAt(11);
			m_LabelBasePowerAdd = (GTextField)this.GetChildAt(12);
			m_LabelSkillPowerAdd = (GTextField)this.GetChildAt(13);
		}
	}
}