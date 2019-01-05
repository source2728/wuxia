using System;
using Explore;
using FairyGUI;
using UnityEngine;

namespace ViewState.ExploreView
{
    public class PrepareExploreState : UIViewState<UI_ExploreView>
    {
        public override void OnEnter()
        {
            var data = m_UI.data as ExploreData;
            var deploy = ExplorePlaceDeploy.GetInfo(data.PlaceId);
            m_UI.m_LabelPlaceName.SetText(deploy.Name);
            m_UI.m_LabelPlaceLevel.SetValue(deploy.Level);
            m_UI.m_LabelExploreProgress.SetValue(0);
            m_UI.m_LabelCost.SetText(deploy.Cost);

            m_UI.m_LabelCombat.SetText(deploy.Combat);
            m_UI.m_LabelSex.SetText((deploy.Sex == ESex.Man) ? "男性" : "女性");
            m_UI.m_LabelNeiGong.SetValue(deploy.NeiGong);
            m_UI.m_LabelWaiGong.SetValue(deploy.WaiGong);

            m_UI.m_Combat.selectedIndex = 0;
            m_UI.m_Sex.selectedIndex = 0;
            m_UI.m_WuXue.selectedIndex = 0;
            m_UI.m_NeiGong.selectedIndex = 0;
            m_UI.m_WaiGong.selectedIndex = 0;

            m_UI.m_LeftNameAndCancel.visible = false;
            m_UI.m_RightNameAndCancel.visible = false;
        }

        public override void OnInit(StateViewWin<UI_ExploreView> view)
        {
            base.OnInit(view);
            m_UI.m_BtnExplore.onClick.Set(OnClickExplore);
            m_UI.m_BtnSelectLeft.onClick.Set(OnSelectLeft);
            m_UI.m_BtnSelectRight.onClick.Set(OnSelectRight);
            m_UI.m_BtnLeftCancel.onClick.Set(OnLeftCancel);
            m_UI.m_BtnRightCancel.onClick.Set(OnRightCancel);
        }

        private void OnRightCancel(EventContext context)
        {
            var data = m_UI.data as ExploreData;
            data.PupilId2 = 0;
            m_UI.m_BtnSelectRight.m_ViewState.selectedIndex = 0;
            m_UI.m_RightNameAndCancel.visible = false;
        }

        private void OnLeftCancel(EventContext context)
        {
            var data = m_UI.data as ExploreData;
            data.PupilId1 = 0;
            m_UI.m_BtnSelectLeft.m_ViewState.selectedIndex = 0;
            m_UI.m_LeftNameAndCancel.visible = false;
        }

        private void OnSelectRight(EventContext context)
        {
            var panel = WinCenter.inst.ShowPanel<UIExploreSelectPupil>();
            panel.OnSelect = (id) =>
            {
                var pupil = PupilDeploy.GetInfo(id);
                m_UI.m_BtnSelectRight.m_ViewState.selectedIndex = 1;
                m_UI.m_BtnSelectRight.m_LoaderPupil.icon = UIUtil.GetPupilBodyUrl(pupil.Sex);
                m_UI.m_LabelRightName.title = pupil.Name;
                m_UI.m_RightNameAndCancel.visible = true;

                var data = m_UI.data as ExploreData;
                data.PupilId2 = id;

                (m_View as UIExploreView).RefreshCond();
            };
        }

        private void OnSelectLeft(EventContext context)
        {
            var panel = WinCenter.inst.ShowPanel<UIExploreSelectPupil>();
            panel.OnSelect = (id) => 
            {
                var pupil = PupilDeploy.GetInfo(id);
                m_UI.m_BtnSelectLeft.m_ViewState.selectedIndex = 1;
                m_UI.m_BtnSelectLeft.m_LoaderPupil.icon = UIUtil.GetPupilBodyUrl(pupil.Sex);
                m_UI.m_LabelLeftName.title = pupil.Name;
                m_UI.m_LeftNameAndCancel.visible = true;

                var data = m_UI.data as ExploreData;
                data.PupilId1 = id;

                (m_View as UIExploreView).RefreshCond();
            };
        }

        private void OnClickExplore(EventContext context)
        {
            var data = m_UI.data as ExploreData;
            ExploreFacade.getInstance().StartExplore(data);
        }
    }
}
