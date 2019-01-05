/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_CreatingBookInfo : GComponent
	{
		public GImage m_IconXinFaCond;
		public GImage m_IconCanBenCond;
		public GTextField m_LabelXinFaCond;
		public GTextField m_LabelCanBenCond;
		public GLoader m_IconFitness;
		public GLoader m_IconDiff;
		public GImage m_IconUp;

		public const string URL = "ui://7a7mjf87m3aa12";

		public static UI_CreatingBookInfo CreateInstance()
		{
			return (UI_CreatingBookInfo)UIPackage.CreateObject("SkillCreate","CreatingBookInfo");
		}

		public UI_CreatingBookInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_IconXinFaCond = (GImage)this.GetChildAt(1);
			m_IconCanBenCond = (GImage)this.GetChildAt(2);
			m_LabelXinFaCond = (GTextField)this.GetChildAt(3);
			m_LabelCanBenCond = (GTextField)this.GetChildAt(4);
			m_IconFitness = (GLoader)this.GetChildAt(6);
			m_IconDiff = (GLoader)this.GetChildAt(8);
			m_IconUp = (GImage)this.GetChildAt(9);
		}
	}
}