/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bag
{
	public partial class UI_BagItemInfo1 : GComponent
	{
		public GButton m_BtnSell;
		public GButton m_IconHead;
		public GTextField m_LabelName;
		public GTextField m_LabelValue;
		public GTextField m_LabelType;
		public GTextField m_LabelQuality;
		public GTextField m_LabelCount;
		public GTextField m_LabelDesc;

		public const string URL = "ui://7fzt93n4uafmo";

		public static UI_BagItemInfo1 CreateInstance()
		{
			return (UI_BagItemInfo1)UIPackage.CreateObject("Bag","BagItemInfo1");
		}

		public UI_BagItemInfo1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BtnSell = (GButton)this.GetChildAt(1);
			m_IconHead = (GButton)this.GetChildAt(2);
			m_LabelName = (GTextField)this.GetChildAt(3);
			m_LabelValue = (GTextField)this.GetChildAt(4);
			m_LabelType = (GTextField)this.GetChildAt(6);
			m_LabelQuality = (GTextField)this.GetChildAt(7);
			m_LabelCount = (GTextField)this.GetChildAt(8);
			m_LabelDesc = (GTextField)this.GetChildAt(10);
		}
	}
}