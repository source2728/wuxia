/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_PupilInfoIcon : GComponent
	{
		public Controller m_State;
		public GLabel m_LabelName;
		public GTextField m_LabelLevel;
		public GComponent m_StarLevel;
		public GLoader m_LoaderHead;

		public const string URL = "ui://h4qtyuejnlw426";

		public static UI_PupilInfoIcon CreateInstance()
		{
			return (UI_PupilInfoIcon)UIPackage.CreateObject("Adventure","PupilInfoIcon");
		}

		public UI_PupilInfoIcon()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_State = this.GetControllerAt(0);
			m_LabelName = (GLabel)this.GetChildAt(1);
			m_LabelLevel = (GTextField)this.GetChildAt(3);
			m_StarLevel = (GComponent)this.GetChildAt(4);
			m_LoaderHead = (GLoader)this.GetChildAt(5);
		}
	}
}