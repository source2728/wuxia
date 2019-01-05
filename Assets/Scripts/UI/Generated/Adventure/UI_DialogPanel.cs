/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_DialogPanel : GComponent
	{
		public Controller m_State;
		public GButton m_BtnGain;
		public GTextField m_LabelContent;

		public const string URL = "ui://h4qtyuejm2iez";

		public static UI_DialogPanel CreateInstance()
		{
			return (UI_DialogPanel)UIPackage.CreateObject("Adventure","DialogPanel");
		}

		public UI_DialogPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_State = this.GetControllerAt(0);
			m_BtnGain = (GButton)this.GetChildAt(1);
			m_LabelContent = (GTextField)this.GetChildAt(3);
		}
	}
}