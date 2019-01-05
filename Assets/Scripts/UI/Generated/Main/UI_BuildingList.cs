/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_BuildingList : GComponent
	{
		public UI_Scene m_Scene;
		public GButton m_BtnZhengDian;
		public GButton m_BtnWaiGongFang;
		public GButton m_BtnShangPu;

		public const string URL = "ui://elyy36r6wm4qg1y";

		public static UI_BuildingList CreateInstance()
		{
			return (UI_BuildingList)UIPackage.CreateObject("Main","BuildingList");
		}

		public UI_BuildingList()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Scene = (UI_Scene)this.GetChildAt(0);
			m_BtnZhengDian = (GButton)this.GetChildAt(4);
			m_BtnWaiGongFang = (GButton)this.GetChildAt(5);
			m_BtnShangPu = (GButton)this.GetChildAt(6);
		}
	}
}