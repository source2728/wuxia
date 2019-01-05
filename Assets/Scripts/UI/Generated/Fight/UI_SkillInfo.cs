/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Fight
{
	public partial class UI_SkillInfo : GComponent
	{
		public GLoader m_LoaderIcon;
		public GLabel m_LabelName;

		public const string URL = "ui://2pn8vgdcjxu5v";

		public static UI_SkillInfo CreateInstance()
		{
			return (UI_SkillInfo)UIPackage.CreateObject("Fight","SkillInfo");
		}

		public UI_SkillInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LoaderIcon = (GLoader)this.GetChildAt(1);
			m_LabelName = (GLabel)this.GetChildAt(2);
		}
	}
}