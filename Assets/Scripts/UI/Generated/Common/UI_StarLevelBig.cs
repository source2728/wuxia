/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_StarLevelBig : GComponent
	{
		public Controller m_Level;

		public const string URL = "ui://e9zbmha1imvtg1w";

		public static UI_StarLevelBig CreateInstance()
		{
			return (UI_StarLevelBig)UIPackage.CreateObject("Common","StarLevelBig");
		}

		public UI_StarLevelBig()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Level = this.GetControllerAt(0);
		}
	}
}