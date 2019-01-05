/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SkillCreate
{
	public partial class UI_WaiGongFang : GComponent
	{
		public Controller m_ViewState;
		public Controller m_BookSelected;
		public Controller m_PupilSelected;
		public GLoader m_LoaderTopBody;
		public GProgressBar m_Progress;
		public UI_CreatingBookInfo m_CreatingBookInfo;
		public GGroup m_CreatingTop;
		public GGroup m_BeforeCreateBg;
		public GLabel m_LabelTitle;
		public GList m_ListSkillType;
		public GList m_ListSkill;
		public GButton m_BtnSelectType;
		public GButton m_BtnSelectSkill;
		public GImage m_FitnessTitle;
		public GLoader m_Fitness;
		public GGraph m_FireEffect;
		public GButton m_BtnSelectBookFinish;
		public GGroup m_SelectBookInfo;
		public GLoader m_IconXinFaCond;
		public GTextField m_LabelXinFaCond;
		public GLoader m_IconCanBenCond;
		public GTextField m_LabelCanBenCond;
		public GLabel m_LabelCreateDiff;
		public GLabel m_LabelCreateFitness;
		public GLoader m_IconSelectedPupilBody;
		public GLabel m_LabelSelectedPupilName;
		public GTextField m_LabelSelectedPupilLevel;
		public GGroup m_SelectedPupil;
		public GGroup m_PupilSelectCond;
		public GGraph m_CreatingEffect;
		public UI_CreateSkillInfo m_CreateSkillInfo;
		public GLoader m_LoaderBody;
		public GLoader m_LoaderUpIcon;
		public GTextField m_LabelUpValue;
		public GGroup m_GroupUpTips;
		public GGraph m_CreatingEffect1;
		public GGroup m_CreateValueInfo;
		public GList m_ListPlace;
		public GButton m_BtnStartPlace;
		public GGroup m_SelectPlace;
		public GButton m_BtnStartCreate;
		public GList m_ListPupil;
		public GGroup m_SelectPupil;
		public GButton m_BtnCreateAgain;
		public GButton m_BtnGoPlace;
		public GGroup m_Choking;
		public GButton m_BtnPowerUp;
		public GButton m_BtnQualityUp;
		public GGroup m_SelectEvent;
		public GButton m_BtnBack;
		public GButton m_BtnCreateFinish;
		public UI_LabelAttr m_LabelBasePower;
		public UI_LabelAttr m_LabelSkillPower;
		public UI_LabelAttr m_LabelValue;
		public UI_LabelAttr m_LabelDiff;
		public GButton m_IconUniqueSkill;
		public GLabel m_LabelCreatorName;
		public GLoader m_IconCreator;
		public GTextInput m_LabelNameInput;
		public GGroup m_CreateFinishedInfo;
		public GButton m_BtnCreate;
		public GList m_List;
		public GGroup m_BuyList;
		public Transition m_UpTips;

		public const string URL = "ui://7a7mjf87gja12";

		public static UI_WaiGongFang CreateInstance()
		{
			return (UI_WaiGongFang)UIPackage.CreateObject("SkillCreate","WaiGongFang");
		}

		public UI_WaiGongFang()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_ViewState = this.GetControllerAt(0);
			m_BookSelected = this.GetControllerAt(1);
			m_PupilSelected = this.GetControllerAt(2);
			m_LoaderTopBody = (GLoader)this.GetChildAt(1);
			m_Progress = (GProgressBar)this.GetChildAt(3);
			m_CreatingBookInfo = (UI_CreatingBookInfo)this.GetChildAt(4);
			m_CreatingTop = (GGroup)this.GetChildAt(5);
			m_BeforeCreateBg = (GGroup)this.GetChildAt(8);
			m_LabelTitle = (GLabel)this.GetChildAt(10);
			m_ListSkillType = (GList)this.GetChildAt(12);
			m_ListSkill = (GList)this.GetChildAt(13);
			m_BtnSelectType = (GButton)this.GetChildAt(14);
			m_BtnSelectSkill = (GButton)this.GetChildAt(15);
			m_FitnessTitle = (GImage)this.GetChildAt(16);
			m_Fitness = (GLoader)this.GetChildAt(17);
			m_FireEffect = (GGraph)this.GetChildAt(19);
			m_BtnSelectBookFinish = (GButton)this.GetChildAt(20);
			m_SelectBookInfo = (GGroup)this.GetChildAt(21);
			m_IconXinFaCond = (GLoader)this.GetChildAt(23);
			m_LabelXinFaCond = (GTextField)this.GetChildAt(24);
			m_IconCanBenCond = (GLoader)this.GetChildAt(25);
			m_LabelCanBenCond = (GTextField)this.GetChildAt(26);
			m_LabelCreateDiff = (GLabel)this.GetChildAt(28);
			m_LabelCreateFitness = (GLabel)this.GetChildAt(30);
			m_IconSelectedPupilBody = (GLoader)this.GetChildAt(32);
			m_LabelSelectedPupilName = (GLabel)this.GetChildAt(33);
			m_LabelSelectedPupilLevel = (GTextField)this.GetChildAt(36);
			m_SelectedPupil = (GGroup)this.GetChildAt(37);
			m_PupilSelectCond = (GGroup)this.GetChildAt(38);
			m_CreatingEffect = (GGraph)this.GetChildAt(40);
			m_CreateSkillInfo = (UI_CreateSkillInfo)this.GetChildAt(41);
			m_LoaderBody = (GLoader)this.GetChildAt(42);
			m_LoaderUpIcon = (GLoader)this.GetChildAt(43);
			m_LabelUpValue = (GTextField)this.GetChildAt(44);
			m_GroupUpTips = (GGroup)this.GetChildAt(45);
			m_CreatingEffect1 = (GGraph)this.GetChildAt(46);
			m_CreateValueInfo = (GGroup)this.GetChildAt(47);
			m_ListPlace = (GList)this.GetChildAt(49);
			m_BtnStartPlace = (GButton)this.GetChildAt(50);
			m_SelectPlace = (GGroup)this.GetChildAt(51);
			m_BtnStartCreate = (GButton)this.GetChildAt(52);
			m_ListPupil = (GList)this.GetChildAt(53);
			m_SelectPupil = (GGroup)this.GetChildAt(54);
			m_BtnCreateAgain = (GButton)this.GetChildAt(55);
			m_BtnGoPlace = (GButton)this.GetChildAt(56);
			m_Choking = (GGroup)this.GetChildAt(57);
			m_BtnPowerUp = (GButton)this.GetChildAt(58);
			m_BtnQualityUp = (GButton)this.GetChildAt(59);
			m_SelectEvent = (GGroup)this.GetChildAt(60);
			m_BtnBack = (GButton)this.GetChildAt(61);
			m_BtnCreateFinish = (GButton)this.GetChildAt(63);
			m_LabelBasePower = (UI_LabelAttr)this.GetChildAt(64);
			m_LabelSkillPower = (UI_LabelAttr)this.GetChildAt(65);
			m_LabelValue = (UI_LabelAttr)this.GetChildAt(66);
			m_LabelDiff = (UI_LabelAttr)this.GetChildAt(67);
			m_IconUniqueSkill = (GButton)this.GetChildAt(68);
			m_LabelCreatorName = (GLabel)this.GetChildAt(70);
			m_IconCreator = (GLoader)this.GetChildAt(71);
			m_LabelNameInput = (GTextInput)this.GetChildAt(73);
			m_CreateFinishedInfo = (GGroup)this.GetChildAt(75);
			m_BtnCreate = (GButton)this.GetChildAt(77);
			m_List = (GList)this.GetChildAt(78);
			m_BuyList = (GGroup)this.GetChildAt(79);
			m_UpTips = this.GetTransitionAt(0);
		}
	}
}