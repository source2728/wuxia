/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Explore
{
	public partial class UI_EmptyPupilMan : GButton
	{
		public Controller m_ViewState;
		public GLoader m_LoaderPupil;

		public const string URL = "ui://cxpqtm7pjus1s";

		public static UI_EmptyPupilMan CreateInstance()
		{
			return (UI_EmptyPupilMan)UIPackage.CreateObject("Explore","EmptyPupilMan");
		}

		public UI_EmptyPupilMan()
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