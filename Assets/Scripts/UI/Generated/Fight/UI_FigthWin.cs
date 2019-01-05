/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Fight
{
	public partial class UI_FigthWin : GComponent
	{
		public Transition m_t0;

		public const string URL = "ui://2pn8vgdcicyq18";

		public static UI_FigthWin CreateInstance()
		{
			return (UI_FigthWin)UIPackage.CreateObject("Fight","FigthWin");
		}

		public UI_FigthWin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_t0 = this.GetTransitionAt(0);
		}
	}
}