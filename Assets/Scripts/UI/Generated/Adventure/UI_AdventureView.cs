/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_AdventureView : GComponent
	{
		public GTextField m_LabelLevel;
		public GList m_List;
		public GButton m_BtnBack;

		public const string URL = "ui://h4qtyuejiaak0";

		public static UI_AdventureView CreateInstance()
		{
			return (UI_AdventureView)UIPackage.CreateObject("Adventure","AdventureView");
		}

		public UI_AdventureView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelLevel = (GTextField)this.GetChildAt(3);
			m_List = (GList)this.GetChildAt(4);
			m_BtnBack = (GButton)this.GetChildAt(5);
		}
	}
}