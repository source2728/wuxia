/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_BuildingLevelUp : GComponent
	{
		public GTextField m_LabelCurLevel;
		public GTextField m_LabelCost;
		public GButton m_BtnLevelUp;

		public const string URL = "ui://elyy36r6t72ec";

		public static UI_BuildingLevelUp CreateInstance()
		{
			return (UI_BuildingLevelUp)UIPackage.CreateObject("Main","BuildingLevelUp");
		}

		public UI_BuildingLevelUp()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelCurLevel = (GTextField)this.GetChildAt(3);
			m_LabelCost = (GTextField)this.GetChildAt(5);
			m_BtnLevelUp = (GButton)this.GetChildAt(6);
		}
	}
}