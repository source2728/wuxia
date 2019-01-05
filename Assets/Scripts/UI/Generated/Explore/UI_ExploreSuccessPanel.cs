/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Explore
{
	public partial class UI_ExploreSuccessPanel : GComponent
	{
		public GLabel m_LabelPlaceName;
		public GLabel m_IconReward1;
		public GLabel m_IconReward2;
		public GLabel m_IconReward3;

		public const string URL = "ui://cxpqtm7pn960u";

		public static UI_ExploreSuccessPanel CreateInstance()
		{
			return (UI_ExploreSuccessPanel)UIPackage.CreateObject("Explore","ExploreSuccessPanel");
		}

		public UI_ExploreSuccessPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_LabelPlaceName = (GLabel)this.GetChildAt(1);
			m_IconReward1 = (GLabel)this.GetChildAt(6);
			m_IconReward2 = (GLabel)this.GetChildAt(7);
			m_IconReward3 = (GLabel)this.GetChildAt(8);
		}
	}
}