/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_Adventure2 : GComponent
	{
		public GTextField m_LabelQualityUp;
		public GButton m_BtnBack;
		public GButton m_BtnUp;

		public const string URL = "ui://7a7mjf87l1386";

		public static UI_Adventure2 CreateInstance()
		{
			return (UI_Adventure2)UIPackage.CreateObject("SkillCreate","Adventure2");
		}

		public UI_Adventure2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelQualityUp = (GTextField)this.GetChildAt(6);
			m_BtnBack = (GButton)this.GetChildAt(7);
			m_BtnUp = (GButton)this.GetChildAt(8);
		}
	}
}