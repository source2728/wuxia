/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_LabelAttr : GLabel
	{
		public GTextField m_LabelValue;

		public const string URL = "ui://7a7mjf87snek16";

		public static UI_LabelAttr CreateInstance()
		{
			return (UI_LabelAttr)UIPackage.CreateObject("SkillCreate","LabelAttr");
		}

		public UI_LabelAttr()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelValue = (GTextField)this.GetChildAt(2);
		}
	}
}