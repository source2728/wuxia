/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pupil
{
	public partial class UI_TabPupilEquip : GComponent
	{
		public GButton m_Btn;
		public GButton m_Btn_2;
		public GButton m_Btn_3;

		public const string URL = "ui://7eisj9pknqkwg21";

		public static UI_TabPupilEquip CreateInstance()
		{
			return (UI_TabPupilEquip)UIPackage.CreateObject("Pupil","TabPupilEquip");
		}

		public UI_TabPupilEquip()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Btn = (GButton)this.GetChildAt(5);
			m_Btn_2 = (GButton)this.GetChildAt(11);
			m_Btn_3 = (GButton)this.GetChildAt(17);
		}
	}
}