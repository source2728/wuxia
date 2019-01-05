/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Fight
{
	public partial class UI_FightView : GComponent
	{
		public UI_CharacterInfo m_LeftCharacterInfo;
		public UI_CharacterInfo m_RightCharacterInfo;
		public GLoader m_LoaderRight;
		public GLoader m_LoaderLeft;
		public UI_SkillInfo m_LeftSkillInfo;
		public UI_SkillInfo m_RightSkillInfo;
		public UI_FightStart m_FightStart;
		public UI_FigthWin m_FightWin;
		public UI_FightLose m_FightLose;
		public GGraph m_LeftSkillTriggerPoint;
		public GGraph m_RightSkillTriggerPoint;
		public GTextField m_LabelRightSkillName;
		public GTextField m_LabelLeftSkillName;
		public Transition m_t0;
		public Transition m_t1;

		public const string URL = "ui://2pn8vgdcjxu53";

		public static UI_FightView CreateInstance()
		{
			return (UI_FightView)UIPackage.CreateObject("Fight","FightView");
		}

		public UI_FightView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LeftCharacterInfo = (UI_CharacterInfo)this.GetChildAt(1);
			m_RightCharacterInfo = (UI_CharacterInfo)this.GetChildAt(2);
			m_LoaderRight = (GLoader)this.GetChildAt(5);
			m_LoaderLeft = (GLoader)this.GetChildAt(8);
			m_LeftSkillInfo = (UI_SkillInfo)this.GetChildAt(10);
			m_RightSkillInfo = (UI_SkillInfo)this.GetChildAt(15);
			m_FightStart = (UI_FightStart)this.GetChildAt(16);
			m_FightWin = (UI_FigthWin)this.GetChildAt(17);
			m_FightLose = (UI_FightLose)this.GetChildAt(18);
			m_LeftSkillTriggerPoint = (GGraph)this.GetChildAt(19);
			m_RightSkillTriggerPoint = (GGraph)this.GetChildAt(20);
			m_LabelRightSkillName = (GTextField)this.GetChildAt(21);
			m_LabelLeftSkillName = (GTextField)this.GetChildAt(22);
			m_t0 = this.GetTransitionAt(0);
			m_t1 = this.GetTransitionAt(1);
		}
	}
}