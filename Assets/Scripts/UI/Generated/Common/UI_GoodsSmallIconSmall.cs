/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_GoodsSmallIconSmall : GButton
	{
		public Controller m_Quality;
		public Controller m_State;

		public const string URL = "ui://e9zbmha1nlw4g6j";

		public static UI_GoodsSmallIconSmall CreateInstance()
		{
			return (UI_GoodsSmallIconSmall)UIPackage.CreateObject("Common","GoodsSmallIconSmall");
		}

		public UI_GoodsSmallIconSmall()
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