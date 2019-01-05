/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Fight
{
	public partial class UI_CharacterInfo : GComponent
	{
		public GTextField m_LabelLevel;
		public GTextField m_LabelCombat;
		public GLabel m_LabelName;

		public const string URL = "ui://2pn8vgdcjxu5w";

		public static UI_CharacterInfo CreateInstance()
		{
			return (UI_CharacterInfo)UIPackage.CreateObject("Fight","CharacterInfo");
		}

		public UI_CharacterInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelLevel = (GTextField)this.GetChildAt(3);
			m_LabelCombat = (GTextField)this.GetChildAt(5);
			m_LabelName = (GLabel)this.GetChildAt(6);
		}
	}
}