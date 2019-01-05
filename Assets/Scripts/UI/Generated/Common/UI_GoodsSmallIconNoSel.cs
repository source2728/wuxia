/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_GoodsSmallIconNoSel : GButton
	{
		public Controller m_Quality;
		public Controller m_State;

		public const string URL = "ui://e9zbmha1vi2zg5a";

		public static UI_GoodsSmallIconNoSel CreateInstance()
		{
			return (UI_GoodsSmallIconNoSel)UIPackage.CreateObject("Common","GoodsSmallIconNoSel");
		}

		public UI_GoodsSmallIconNoSel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Quality = this.GetControllerAt(0);
			m_State = this.GetControllerAt(1);
		}
	}
}