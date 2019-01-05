/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_UIMain : GComponent
	{
		public Controller m_ViewState;
		public UI_BuildingList m_BuildingList;
		public GButton m_Button1;
		public GButton m_Button2;
		public GButton m_Button3;
		public GButton m_Button4;
		public GButton m_Button5;
		public GTextField m_TextGold;
		public GTextField m_TestHonor;
		public GButton m_BtnResetData;

		public const string URL = "ui://elyy36r6gja10";

		public static UI_UIMain CreateInstance()
		{
			return (UI_UIMain)UIPackage.CreateObject("Main","UIMain");
		}

		public UI_UIMain()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_BuildingList = (UI_BuildingList)this.GetChildAt(0);
			m_Button1 = (GButton)this.GetChildAt(2);
			m_Button2 = (GButton)this.GetChildAt(3);
			m_Button3 = (GButton)this.GetChildAt(4);
			m_Button4 = (GButton)this.GetChildAt(5);
			m_Button5 = (GButton)this.GetChildAt(6);
			m_TextGold = (GTextField)this.GetChildAt(8);
			m_TestHonor = (GTextField)this.GetChildAt(10);
			m_BtnResetData = (GButton)this.GetChildAt(11);
		}
	}
}