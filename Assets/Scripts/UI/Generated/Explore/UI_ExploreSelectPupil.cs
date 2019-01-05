/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Explore
{
	public partial class UI_ExploreSelectPupil : GComponent
	{
		public GList m_List;

		public const string URL = "ui://cxpqtm7phfka1e";

		public static UI_ExploreSelectPupil CreateInstance()
		{
			return (UI_ExploreSelectPupil)UIPackage.CreateObject("Explore","ExploreSelectPupil");
		}

		public UI_ExploreSelectPupil()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_List = (GList)this.GetChildAt(2);
		}
	}
}