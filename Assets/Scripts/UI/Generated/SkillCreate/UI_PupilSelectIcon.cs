/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_PupilSelectIcon : GButton
	{
		public GLoader m_IconHead;
		public GLabel m_LabelName;
		public GComponent m_StarLevel;
		public GTextField m_LabelLevel;
		public GLoader m_IconXinFaCond;
		public GLoader m_IconCanBenCond;
		public GTextField m_LabelXinFaCond;
		public GTextField m_LabelCanBenCond;

		public const string URL = "ui://7a7mjf879gjyr";

		public static UI_PupilSelectIcon CreateInstance()
		{
			return (UI_PupilSelectIcon)UIPackage.CreateObject("SkillCreate","PupilSelectIcon");
		}

		public UI_PupilSelectIcon()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_IconHead = (GLoader)this.GetChildAt(1);
			m_LabelName = (GLabel)this.GetChildAt(2);
			m_StarLevel = (GComponent)this.GetChildAt(3);
			m_LabelLevel = (GTextField)this.GetChildAt(5);
			m_IconXinFaCond = (GLoader)this.GetChildAt(6);
			m_IconCanBenCond = (GLoader)this.GetChildAt(7);
			m_LabelXinFaCond = (GTextField)this.GetChildAt(8);
			m_LabelCanBenCond = (GTextField)this.GetChildAt(9);
		}
	}
}