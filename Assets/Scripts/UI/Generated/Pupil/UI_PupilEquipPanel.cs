/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pupil
{
	public partial class UI_PupilEquipPanel : GComponent
	{
		public Controller m_Type;
		public GList m_List;
		public GLabel m_LabelTitle;

		public const string URL = "ui://7eisj9pk9gjyg22";

		public static UI_PupilEquipPanel CreateInstance()
		{
			return (UI_PupilEquipPanel)UIPackage.CreateObject("Pupil","PupilEquipPanel");
		}

		public UI_PupilEquipPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Type = this.GetControllerAt(0);
			m_List = (GList)this.GetChildAt(1);
			m_LabelTitle = (GLabel)this.GetChildAt(2);
		}
	}
}