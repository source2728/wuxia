/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Explore
{
	public partial class UI_ExploreView : GComponent
	{
		public Controller m_ViewState;
		public Controller m_Combat;
		public Controller m_Sex;
		public Controller m_WuXue;
		public Controller m_NeiGong;
		public Controller m_WaiGong;
		public GTextField m_LabelPlaceName;
		public GTextField m_LabelPlaceLevel;
		public GTextField m_LabelCombat;
		public GTextField m_LabelSex;
		public GTextField m_LabelWuXue;
		public GTextField m_LabelNeiGong;
		public GTextField m_LabelWaiGong;
		public GTextField m_LabelExploreProgress;
		public GTextField m_LabelSuccessRate;
		public UI_EmptyPupilWoman m_BtnSelectRight;
		public UI_EmptyPupilMan m_BtnSelectLeft;
		public GButton m_BtnReceiveReward;
		public GTextField m_LabelTime;
		public GTextField m_LabelCost;
		public GButton m_BtnExplore;
		public GLabel m_IconReward1;
		public GLabel m_IconReward2;
		public GLabel m_IconReward3;
		public GList m_PlaceList;
		public GButton m_BtnBack;
		public GLabel m_LabelLeftName;
		public GButton m_BtnLeftCancel;
		public GGroup m_LeftNameAndCancel;
		public GLabel m_LabelRightName;
		public GButton m_BtnRightCancel;
		public GGroup m_RightNameAndCancel;

		public const string URL = "ui://cxpqtm7pjus10";

		public static UI_ExploreView CreateInstance()
		{
			return (UI_ExploreView)UIPackage.CreateObject("Explore","ExploreView");
		}

		public UI_ExploreView()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_Combat = this.GetControllerAt(1);
			m_Sex = this.GetControllerAt(2);
			m_WuXue = this.GetControllerAt(3);
			m_NeiGong = this.GetControllerAt(4);
			m_WaiGong = this.GetControllerAt(5);
			m_LabelPlaceName = (GTextField)this.GetChildAt(6);
			m_LabelPlaceLevel = (GTextField)this.GetChildAt(7);
			m_LabelCombat = (GTextField)this.GetChildAt(9);
			m_LabelSex = (GTextField)this.GetChildAt(11);
			m_LabelWuXue = (GTextField)this.GetChildAt(12);
			m_LabelNeiGong = (GTextField)this.GetChildAt(13);
			m_LabelWaiGong = (GTextField)this.GetChildAt(16);
			m_LabelExploreProgress = (GTextField)this.GetChildAt(17);
			m_LabelSuccessRate = (GTextField)this.GetChildAt(21);
			m_BtnSelectRight = (UI_EmptyPupilWoman)this.GetChildAt(25);
			m_BtnSelectLeft = (UI_EmptyPupilMan)this.GetChildAt(26);
			m_BtnReceiveReward = (GButton)this.GetChildAt(27);
			m_LabelTime = (GTextField)this.GetChildAt(29);
			m_LabelCost = (GTextField)this.GetChildAt(31);
			m_BtnExplore = (GButton)this.GetChildAt(33);
			m_IconReward1 = (GLabel)this.GetChildAt(35);
			m_IconReward2 = (GLabel)this.GetChildAt(36);
			m_IconReward3 = (GLabel)this.GetChildAt(37);
			m_PlaceList = (GList)this.GetChildAt(40);
			m_BtnBack = (GButton)this.GetChildAt(43);
			m_LabelLeftName = (GLabel)this.GetChildAt(44);
			m_BtnLeftCancel = (GButton)this.GetChildAt(45);
			m_LeftNameAndCancel = (GGroup)this.GetChildAt(46);
			m_LabelRightName = (GLabel)this.GetChildAt(47);
			m_BtnRightCancel = (GButton)this.GetChildAt(48);
			m_RightNameAndCancel = (GGroup)this.GetChildAt(49);
		}
	}
}