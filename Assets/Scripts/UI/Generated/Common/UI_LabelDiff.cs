/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_LabelDiff : GLabel
	{
		public Controller m_Value;

		public const string URL = "ui://e9zbmha1s9fag3m";

		public static UI_LabelDiff CreateInstance()
		{
			return (UI_LabelDiff)UIPackage.CreateObject("Common","LabelDiff");
		}

		public UI_LabelDiff()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Value = this.GetControllerAt(0);
		}
	}
}