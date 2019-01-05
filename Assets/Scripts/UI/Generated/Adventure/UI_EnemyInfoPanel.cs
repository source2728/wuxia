/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_EnemyInfoPanel : GComponent
	{
		public GLabel m_LabelName;
		public GTextField m_LabelContent;
		public GLoader m_LoaderHead;
		public GButton m_BtnEscape;
		public GButton m_BtnFight;

		public const string URL = "ui://h4qtyuejbel9l";

		public static UI_EnemyInfoPanel CreateInstance()
		{
			return (UI_EnemyInfoPanel)UIPackage.CreateObject("Adventure","EnemyInfoPanel");
		}

		public UI_EnemyInfoPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelName = (GLabel)this.GetChildAt(1);
			m_LabelContent = (GTextField)this.GetChildAt(2);
			m_LoaderHead = (GLoader)this.GetChildAt(3);
			m_BtnEscape = (GButton)this.GetChildAt(4);
			m_BtnFight = (GButton)this.GetChildAt(5);
		}
	}
}