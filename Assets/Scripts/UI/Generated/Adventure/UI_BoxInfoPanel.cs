/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_BoxInfoPanel : GComponent
	{
		public GButton m_BtnGainAll;
		public GButton m_BtnGiveUp;
		public GButton m_IconDrop1;
		public GButton m_IconDrop2;
		public GButton m_IconDrop3;

		public const string URL = "ui://h4qtyuejlrgr13";

		public static UI_BoxInfoPanel CreateInstance()
		{
			return (UI_BoxInfoPanel)UIPackage.CreateObject("Adventure","BoxInfoPanel");
		}

		public UI_BoxInfoPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnGainAll = (GButton)this.GetChildAt(4);
			m_BtnGiveUp = (GButton)this.GetChildAt(5);
			m_IconDrop1 = (GButton)this.GetChildAt(6);
			m_IconDrop2 = (GButton)this.GetChildAt(7);
			m_IconDrop3 = (GButton)this.GetChildAt(8);
		}
	}
}