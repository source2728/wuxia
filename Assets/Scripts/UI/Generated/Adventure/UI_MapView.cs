/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_MapView : GComponent
	{
		public GButton m_BtnBack;
		public UI_MapTopInfo m_TopInfo;
		public GButton m_IconHead;

		public const string URL = "ui://h4qtyuejqr8d0";

		public static UI_MapView CreateInstance()
		{
			return (UI_MapView)UIPackage.CreateObject("Adventure","MapView");
		}

		public UI_MapView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnBack = (GButton)this.GetChildAt(0);
			m_TopInfo = (UI_MapTopInfo)this.GetChildAt(1);
			m_IconHead = (GButton)this.GetChildAt(5);
		}
	}
}