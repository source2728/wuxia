/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Pupil
{
	public partial class UI_TabPupilInfo : GComponent
	{
		public GTextField m_LabelWuXing;
		public GTextField m_LabelZiZhi;
		public GTextField m_LabelWaiGong;
		public GTextField m_LabelNeiGong;
		public GTextField m_LabelShenFa;
		public GTextField m_LabelDesc;
		public GTextField m_LabelShengMing;
		public GTextField m_LabelZhenQi;
		public GTextField m_LabelGongJi;
		public GTextField m_LabelFangYu;
		public GTextField m_LabelMingZhong;
		public GTextField m_LabelShanBi;
		public GTextField m_LabelBaoJi;
		public GTextField m_LabelKangBao;

		public const string URL = "ui://7eisj9pkimvt19";

		public static UI_TabPupilInfo CreateInstance()
		{
			return (UI_TabPupilInfo)UIPackage.CreateObject("Pupil","TabPupilInfo");
		}

		public UI_TabPupilInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelWuXing = (GTextField)this.GetChildAt(2);
			m_LabelZiZhi = (GTextField)this.GetChildAt(3);
			m_LabelWaiGong = (GTextField)this.GetChildAt(4);
			m_LabelNeiGong = (GTextField)this.GetChildAt(5);
			m_LabelShenFa = (GTextField)this.GetChildAt(6);
			m_LabelDesc = (GTextField)this.GetChildAt(9);
			m_LabelShengMing = (GTextField)this.GetChildAt(15);
			m_LabelZhenQi = (GTextField)this.GetChildAt(16);
			m_LabelGongJi = (GTextField)this.GetChildAt(17);
			m_LabelFangYu = (GTextField)this.GetChildAt(18);
			m_LabelMingZhong = (GTextField)this.GetChildAt(19);
			m_LabelShanBi = (GTextField)this.GetChildAt(20);
			m_LabelBaoJi = (GTextField)this.GetChildAt(21);
			m_LabelKangBao = (GTextField)this.GetChildAt(22);
		}
	}
}