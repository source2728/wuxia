/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Explore
{
	public partial class UI_EmptyPupilWoman : GButton
	{
		public Controller m_ViewState;
		public GLoader m_LoaderPupil;

		public const string URL = "ui://cxpqtm7pjus1t";

		public static UI_EmptyPupilWoman CreateInstance()
		{
			return (UI_EmptyPupilWoman)UIPackage.CreateObject("Explore","EmptyPupilWoman");
		}

		public UI_EmptyPupilWoman()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_LoaderPupil = (GLoader)this.GetChildAt(3);
		}
	}
}