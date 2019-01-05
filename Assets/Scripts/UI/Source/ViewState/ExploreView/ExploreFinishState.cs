using System;
using Explore;
using FairyGUI;
using UnityEngine;

namespace ViewState.ExploreView
{
    public class ExploreFinishState : UIViewState<UI_ExploreView>
    {
        public override void OnEnter()
        {
            var data = m_UI.data as ExploreData;
            var deploy = ExplorePlaceDeploy.GetInfo(data.PlaceId);
            m_UI.m_LabelPlaceName.SetText(deploy.Name);
            m_UI.m_LabelPlaceLevel.SetValue(deploy.Level);
            m_UI.m_LabelExploreProgress.SetValue(0);
            m_UI.m_LabelCost.SetText(deploy.Cost);

            if (data.PupilId1 > 0)
            {
                var pupil = PupilDeploy.GetInfo(data.PupilId1);
                m_UI.m_BtnSelectLeft.m_ViewState.selectedIndex = 1;
                m_UI.m_BtnSelectLeft.m_LoaderPupil.icon = UIUtil.GetPupilBodyUrl(pupil.Sex);
            }
            else
            {
                m_UI.m_BtnSelectLeft.m_ViewState.selectedIndex = 0;
            }

            if (data.PupilId2 > 0)
            {
                var pupil = PupilDeploy.GetInfo(data.PupilId2);
                m_UI.m_BtnSelectRight.m_ViewState.selectedIndex = 1;
                m_UI.m_BtnSelectRight.m_LoaderPupil.icon = UIUtil.GetPupilBodyUrl(pupil.Sex);
            }
            else
            {
                m_UI.m_BtnSelectRight.m_ViewState.selectedIndex = 0;
            }

            m_UI.m_BtnSelectLeft.touchable = false;
            m_UI.m_BtnSelectRight.touchable = false;
        }

        public override void OnExit()
        {
            m_UI.m_BtnSelectLeft.touchable = true;
            m_UI.m_BtnSelectRight.touchable = true;
        }

        public override void OnInit(StateViewWin<UI_ExploreView> view)
        {
            base.OnInit(view);
            m_UI.m_BtnReceiveReward.onClick.Set(OnClickReceiveReward);
        }

        private void OnClickReceiveReward(EventContext context)
        {
            ExploreFacade.getInstance().FinishExplore();
        }
    }
}
