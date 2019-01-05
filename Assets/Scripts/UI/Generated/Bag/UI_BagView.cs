/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bag
{
	public partial class UI_BagView : GComponent
	{
		public Controller m_ViewState;
		public Controller m_SortType;
		public GLabel m_ListFrame;
		public GList m_List;
		public GTextField m_LabelCount;
		public GComboBox m_CBSort;
		public GTextField m_LabelEmpty;
		public GButton m_BtnBack;

		public const string URL = "ui://7fzt93n4uafmm";

		public static UI_BagView CreateInstance()
		{
			return (UI_BagView)UIPackage.CreateObject("Bag","BagView");
		}

		public UI_BagView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_SortType = this.GetControllerAt(1);
			m_ListFrame = (GLabel)this.GetChildAt(1);
			m_List = (GList)this.GetChildAt(7);
			m_LabelCount = (GTextField)this.GetChildAt(8);
			m_CBSort = (GComboBox)this.GetChildAt(9);
			m_LabelEmpty = (GTextField)this.GetChildAt(11);
			m_BtnBack = (GButton)this.GetChildAt(12);
		}
	}
}