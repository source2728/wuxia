/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_SelectPupilView : GComponent
	{
		public UI_PupilInfoIcon m_SelectedPupilInfo;
		public GList m_List;
		public GButton m_BtnStart;
		public GButton m_BtnBack;

		public const string URL = "ui://h4qtyuejnlw41b";

		public static UI_SelectPupilView CreateInstance()
		{
			return (UI_SelectPupilView)UIPackage.CreateObject("Adventure","SelectPupilView");
		}

		public UI_SelectPupilView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_SelectedPupilInfo = (UI_PupilInfoIcon)this.GetChildAt(8);
			m_List = (GList)this.GetChildAt(10);
			m_BtnStart = (GButton)this.GetChildAt(11);
			m_BtnBack = (GButton)this.GetChildAt(12);
		}
	}
}