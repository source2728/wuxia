/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_ComboBox_popup : GComponent
	{
		public GList m_list;

		public const string URL = "ui://e9zbmha1kjps1w";

		public static UI_ComboBox_popup CreateInstance()
		{
			return (UI_ComboBox_popup)UIPackage.CreateObject("Common","ComboBox_popup");
		}

		public UI_ComboBox_popup()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_list = (GList)this.GetChildAt(1);
		}
	}
}