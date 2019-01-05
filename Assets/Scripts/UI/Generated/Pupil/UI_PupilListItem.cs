/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pupil
{
	public partial class UI_PupilListItem : GButton
	{
		public GLoader m_IconHead;
		public GComponent m_StarLevel;
		public GTextField m_LabelName;
		public GTextField m_LabelCombat;
		public GLabel m_LabelWuXing;
		public GLabel m_LabelZiZhi;
		public GLabel m_LabelWaiGong;
		public GLabel m_LabelNeiGong;
		public GLabel m_LabelShenFa;
		public GTextField m_LabelLevel;

		public const string URL = "ui://7eisj9pkqw3pg1v";

		public static UI_PupilListItem CreateInstance()
		{
			return (UI_PupilListItem)UIPackage.CreateObject("Pupil","PupilListItem");
		}

		public UI_PupilListItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_IconHead = (GLoader)this.GetChildAt(2);
			m_StarLevel = (GComponent)this.GetChildAt(4);
			m_LabelName = (GTextField)this.GetChildAt(5);
			m_LabelCombat = (GTextField)this.GetChildAt(6);
			m_LabelWuXing = (GLabel)this.GetChildAt(7);
			m_LabelZiZhi = (GLabel)this.GetChildAt(8);
			m_LabelWaiGong = (GLabel)this.GetChildAt(9);
			m_LabelNeiGong = (GLabel)this.GetChildAt(10);
			m_LabelShenFa = (GLabel)this.GetChildAt(11);
			m_LabelLevel = (GTextField)this.GetChildAt(12);
		}
	}
}