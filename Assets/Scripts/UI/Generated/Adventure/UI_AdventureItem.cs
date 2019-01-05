/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_AdventureItem : GComponent
	{
		public Controller m_State;
		public GButton m_BtnDetail;
		public GList m_List;

		public const string URL = "ui://h4qtyuejiaakk";

		public static UI_AdventureItem CreateInstance()
		{
			return (UI_AdventureItem)UIPackage.CreateObject("Adventure","AdventureItem");
		}

		public UI_AdventureItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_State = this.GetControllerAt(0);
			m_BtnDetail = (GButton)this.GetChildAt(4);
			m_List = (GList)this.GetChildAt(6);
		}
	}
}