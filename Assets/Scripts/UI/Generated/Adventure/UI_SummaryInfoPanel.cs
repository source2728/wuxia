/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_SummaryInfoPanel : GComponent
	{
		public Controller m_State;
		public GTextField m_LabelProgress;
		public GButton m_BtnCancel;
		public GButton m_BtnExit;
		public GList m_DropList;

		public const string URL = "ui://h4qtyuejokfst";

		public static UI_SummaryInfoPanel CreateInstance()
		{
			return (UI_SummaryInfoPanel)UIPackage.CreateObject("Adventure","SummaryInfoPanel");
		}

		public UI_SummaryInfoPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_State = this.GetControllerAt(0);
			m_LabelProgress = (GTextField)this.GetChildAt(6);
			m_BtnCancel = (GButton)this.GetChildAt(7);
			m_BtnExit = (GButton)this.GetChildAt(8);
			m_DropList = (GList)this.GetChildAt(9);
		}
	}
}