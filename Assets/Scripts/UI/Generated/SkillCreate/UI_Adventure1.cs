/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_Adventure1 : GComponent
	{
		public GTextField m_LabelSuccess;
		public GTextField m_LabelPowerUp;
		public GButton m_BtnBack;
		public GButton m_BtnUp;
		public GButton m_BtnGoods1;
		public GButton m_BtnGoods2;
		public GButton m_BtnGoods3;

		public const string URL = "ui://7a7mjf87gja15";

		public static UI_Adventure1 CreateInstance()
		{
			return (UI_Adventure1)UIPackage.CreateObject("SkillCreate","Adventure1");
		}

		public UI_Adventure1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelSuccess = (GTextField)this.GetChildAt(4);
			m_LabelPowerUp = (GTextField)this.GetChildAt(5);
			m_BtnBack = (GButton)this.GetChildAt(6);
			m_BtnUp = (GButton)this.GetChildAt(7);
			m_BtnGoods1 = (GButton)this.GetChildAt(8);
			m_BtnGoods2 = (GButton)this.GetChildAt(9);
			m_BtnGoods3 = (GButton)this.GetChildAt(10);
		}
	}
}