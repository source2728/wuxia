/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Fight
{
	public partial class UI_Character : GLabel
	{
		public GProgressBar m_BarHp;
		public GGraph m_Body;
		public GComponent m_HurtStart;

		public const string URL = "ui://2pn8vgdcgfsb1";

		public static UI_Character CreateInstance()
		{
			return (UI_Character)UIPackage.CreateObject("Fight","Character");
		}

		public UI_Character()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BarHp = (GProgressBar)this.GetChildAt(0);
			m_Body = (GGraph)this.GetChildAt(1);
			m_HurtStart = (GComponent)this.GetChildAt(2);
		}
	}
}