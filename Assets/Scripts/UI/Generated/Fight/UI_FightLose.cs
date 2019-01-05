/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Fight
{
	public partial class UI_FightLose : GComponent
	{
		public Transition m_t0;

		public const string URL = "ui://2pn8vgdcgfp819";

		public static UI_FightLose CreateInstance()
		{
			return (UI_FightLose)UIPackage.CreateObject("Fight","FightLose");
		}

		public UI_FightLose()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_t0 = this.GetTransitionAt(0);
		}
	}
}