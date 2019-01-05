using Explore;
using FairyGUI;

namespace ViewState.ExploreView
{
    public class SelectPlaceState : UIViewState<UI_ExploreView>
    {
        public override void OnEnter()
        {
            m_UI.m_PlaceList.SetData(ExplorePlaceDeploy.GetIds());
        }

        public override void OnInit(StateViewWin<UI_ExploreView> view)
        {
            base.OnInit(view);
            m_UI.m_PlaceList.onClickItem.Set(OnClickItem);
            m_UI.m_PlaceList.itemRenderer = OnItemRenderer;
        }

        private void OnItemRenderer(int index, GObject obj)
        {
            var id = m_UI.m_PlaceList.GetData<int>(index);
            var deploy = ExplorePlaceDeploy.GetInfo(id);
            var item = obj as UI_PlaceSelectItem;
            item.m_LabelName.SetText(deploy.Name);
            item.m_LabelLevel.SetValue(deploy.Level);
            item.m_LabelProgress.SetValue(0);
        }

        private void OnClickItem(EventContext context)
        {
            var data = m_UI.data as ExploreData;
            data.PlaceId = m_UI.m_PlaceList.GetSelectedData<int>();
            m_View.ChangeViewState(UIExploreView.EViewState.PrepareExplore);
        }
    }
}
