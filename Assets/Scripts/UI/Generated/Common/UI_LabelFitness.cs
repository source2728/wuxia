/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_LabelFitness : GLabel
	{
		public Controller m_Value;

		public const string URL = "ui://e9zbmha1pkb1g4z";

		public static UI_LabelFitness CreateInstance()
		{
			return (UI_LabelFitness)UIPackage.CreateObject("Common","LabelFitness");
		}

		public UI_LabelFitness()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Value = this.GetControllerAt(0);
		}
	}
}