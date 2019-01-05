/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_BuildingOpen : GComponent
	{
		public GTextField m_LabelCost;
		public GButton m_BtnUnlock;

		public const string URL = "ui://elyy36r6t72ed";

		public static UI_BuildingOpen CreateInstance()
		{
			return (UI_BuildingOpen)UIPackage.CreateObject("Main","BuildingOpen");
		}

		public UI_BuildingOpen()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelCost = (GTextField)this.GetChildAt(3);
			m_BtnUnlock = (GButton)this.GetChildAt(4);
		}
	}
}