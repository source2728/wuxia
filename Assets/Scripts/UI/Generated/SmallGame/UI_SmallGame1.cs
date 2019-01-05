/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SmallGame
{
	public partial class UI_SmallGame1 : GComponent
	{
		public Controller m_ViewState;
		public GLoader m_Bg;
		public GLoader m_Sword;
		public GProgressBar m_ProgressCoundDown;
		public GComponent m_FightLose;
		public GComponent m_FightWin;
		public Transition m_t0;

		public const string URL = "ui://3vj0k6oh96ef8";

		public static UI_SmallGame1 CreateInstance()
		{
			return (UI_SmallGame1)UIPackage.CreateObject("SmallGame","SmallGame1");
		}

		public UI_SmallGame1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_Bg = (GLoader)this.GetChildAt(0);
			m_Sword = (GLoader)this.GetChildAt(2);
			m_ProgressCoundDown = (GProgressBar)this.GetChildAt(5);
			m_FightLose = (GComponent)this.GetChildAt(7);
			m_FightWin = (GComponent)this.GetChildAt(8);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}