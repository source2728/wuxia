/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pupil
{
	public partial class UI_PupilEquipItem : GComponent
	{
		public GButton m_Icon;
		public GTextField m_LabelName;
		public GTextField m_LabelType;
		public GTextField m_LabelValue;
		public GButton m_BtnSelect;

		public const string URL = "ui://7eisj9pksnekg23";

		public static UI_PupilEquipItem CreateInstance()
		{
			return (UI_PupilEquipItem)UIPackage.CreateObject("Pupil","PupilEquipItem");
		}

		public UI_PupilEquipItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Icon = (GButton)this.GetChildAt(0);
			m_LabelName = (GTextField)this.GetChildAt(1);
			m_LabelType = (GTextField)this.GetChildAt(2);
			m_LabelValue = (GTextField)this.GetChildAt(3);
			m_BtnSelect = (GButton)this.GetChildAt(4);
		}
	}
}