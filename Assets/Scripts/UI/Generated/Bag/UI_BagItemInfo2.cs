/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bag
{
	public partial class UI_BagItemInfo2 : GComponent
	{
		public GButton m_BtnSell;
		public GButton m_BtnEquip;
		public GButton m_BtnStudy;

		public const string URL = "ui://7fzt93n4uafmp";

		public static UI_BagItemInfo2 CreateInstance()
		{
			return (UI_BagItemInfo2)UIPackage.CreateObject("Bag","BagItemInfo2");
		}

		public UI_BagItemInfo2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnSell = (GButton)this.GetChildAt(20);
			m_BtnEquip = (GButton)this.GetChildAt(21);
			m_BtnStudy = (GButton)this.GetChildAt(22);
		}
	}
}