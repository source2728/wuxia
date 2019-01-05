/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_GoodsSmallIcon : GButton
	{
		public Controller m_Quality;
		public Controller m_State;
		public GImage m_IconAdd;

		public const string URL = "ui://e9zbmha1tqrzg39";

		public static UI_GoodsSmallIcon CreateInstance()
		{
			return (UI_GoodsSmallIcon)UIPackage.CreateObject("Common","GoodsSmallIcon");
		}

		public UI_GoodsSmallIcon()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Quality = this.GetControllerAt(0);
			m_State = this.GetControllerAt(1);
			m_IconAdd = (GImage)this.GetChildAt(2);
		}
	}
}