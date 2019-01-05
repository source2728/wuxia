/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Fight
{
	public partial class UI_FightStart : GComponent
	{
		public Transition m_t0;

		public const string URL = "ui://2pn8vgdclz1cx";

		public static UI_FightStart CreateInstance()
		{
			return (UI_FightStart)UIPackage.CreateObject("Fight","FightStart");
		}

		public UI_FightStart()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_t0 = this.GetTransitionAt(0);
		}
	}
}