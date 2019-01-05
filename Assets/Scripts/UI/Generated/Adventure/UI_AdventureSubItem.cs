/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_AdventureSubItem : GComponent
	{
		public GButton m_BtnSelect;

		public const string URL = "ui://h4qtyuej91v01a";

		public static UI_AdventureSubItem CreateInstance()
		{
			return (UI_AdventureSubItem)UIPackage.CreateObject("Adventure","AdventureSubItem");
		}

		public UI_AdventureSubItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnSelect = (GButton)this.GetChildAt(2);
		}
	}
}