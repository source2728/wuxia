/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_Scene : GComponent
	{
		public GGraph m_Splash1;
		public GGraph m_Splash2;
		public Transition m_t0;
		public Transition m_t1;

		public const string URL = "ui://elyy36r6cz4pg37";

		public static UI_Scene CreateInstance()
		{
			return (UI_Scene)UIPackage.CreateObject("Main","Scene");
		}

		public UI_Scene()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Splash1 = (GGraph)this.GetChildAt(43);
			m_Splash2 = (GGraph)this.GetChildAt(44);
			m_t0 = this.GetTransitionAt(0);
			m_t1 = this.GetTransitionAt(1);
		}
	}
}