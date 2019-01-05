/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_PlaceSelectIcon : GButton
	{
		public GTextField m_LabelName;
		public GTextField m_LabelLevel;
		public GTextField m_LabelGoodAt;
		public GTextField m_LabelEventRate;

		public const string URL = "ui://7a7mjf879gjyw";

		public static UI_PlaceSelectIcon CreateInstance()
		{
			return (UI_PlaceSelectIcon)UIPackage.CreateObject("SkillCreate","PlaceSelectIcon");
		}

		public UI_PlaceSelectIcon()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelName = (GTextField)this.GetChildAt(3);
			m_LabelLevel = (GTextField)this.GetChildAt(4);
			m_LabelGoodAt = (GTextField)this.GetChildAt(5);
			m_LabelEventRate = (GTextField)this.GetChildAt(6);
		}
	}
}