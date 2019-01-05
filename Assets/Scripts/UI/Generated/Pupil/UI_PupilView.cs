/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pupil
{
	public partial class UI_PupilView : GComponent
	{
		public Controller m_ViewState;
		public Controller m_JueXueState;
		public Controller m_Sex;
		public GTextField m_LabelName;
		public GTextField m_LabelLevel;
		public GTextField m_LabelCombat;
		public GLoader m_IconBody;
		public GProgressBar m_ProgressExp;
		public GComponent m_StarLevel;
		public UI_TabPupilInfo m_TabPupilInfo;
		public GButton m_IconWuXue;
		public GButton m_BtnChangeJueXue;
		public GTextField m_LabelWuXueName;
		public GTextField m_LabelWuXueType;
		public GTextField m_LabelWuXueCombat;
		public GTextField m_LabelWuXueDesc;
		public GButton m_BtnEquipJueXue;
		public GGroup m_TabJueXue;
		public GButton m_BtnBack;

		public const string URL = "ui://7eisj9pkvstlk";

		public static UI_PupilView CreateInstance()
		{
			return (UI_PupilView)UIPackage.CreateObject("Pupil","PupilView");
		}

		public UI_PupilView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_JueXueState = this.GetControllerAt(1);
			m_Sex = this.GetControllerAt(2);
			m_LabelName = (GTextField)this.GetChildAt(3);
			m_LabelLevel = (GTextField)this.GetChildAt(4);
			m_LabelCombat = (GTextField)this.GetChildAt(5);
			m_IconBody = (GLoader)this.GetChildAt(8);
			m_ProgressExp = (GProgressBar)this.GetChildAt(9);
			m_StarLevel = (GComponent)this.GetChildAt(10);
			m_TabPupilInfo = (UI_TabPupilInfo)this.GetChildAt(15);
			m_IconWuXue = (GButton)this.GetChildAt(22);
			m_BtnChangeJueXue = (GButton)this.GetChildAt(23);
			m_LabelWuXueName = (GTextField)this.GetChildAt(24);
			m_LabelWuXueType = (GTextField)this.GetChildAt(25);
			m_LabelWuXueCombat = (GTextField)this.GetChildAt(26);
			m_LabelWuXueDesc = (GTextField)this.GetChildAt(28);
			m_BtnEquipJueXue = (GButton)this.GetChildAt(31);
			m_TabJueXue = (GGroup)this.GetChildAt(32);
			m_BtnBack = (GButton)this.GetChildAt(34);
		}
	}
}