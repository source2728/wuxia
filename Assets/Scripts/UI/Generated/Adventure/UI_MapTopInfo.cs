/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Adventure
{
	public partial class UI_MapTopInfo : GComponent
	{
		public GTextField m_LabelName;
		public GTextField m_LabelLevel;
		public GTextField m_LabelHonor;
		public GTextField m_LabelExp;
		public GTextField m_LabelGold;

		public const string URL = "ui://h4qtyueja9qbr";

		public static UI_MapTopInfo CreateInstance()
		{
			return (UI_MapTopInfo)UIPackage.CreateObject("Adventure","MapTopInfo");
		}

		public UI_MapTopInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelName = (GTextField)this.GetChildAt(1);
			m_LabelLevel = (GTextField)this.GetChildAt(2);
			m_LabelHonor = (GTextField)this.GetChildAt(3);
			m_LabelExp = (GTextField)this.GetChildAt(4);
			m_LabelGold = (GTextField)this.GetChildAt(5);
		}
	}
}