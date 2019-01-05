/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pupil
{
	public partial class UI_PupilListView : GButton
	{
		public Controller m_ShowState;
		public GList m_List;
		public GButton m_BtnBack;

		public const string URL = "ui://7eisj9pkoeeuj";

		public static UI_PupilListView CreateInstance()
		{
			return (UI_PupilListView)UIPackage.CreateObject("Pupil","PupilListView");
		}

		public UI_PupilListView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ShowState = this.GetControllerAt(0);
			m_List = (GList)this.GetChildAt(2);
			m_BtnBack = (GButton)this.GetChildAt(3);
		}
	}
}