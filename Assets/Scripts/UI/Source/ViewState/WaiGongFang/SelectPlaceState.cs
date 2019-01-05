using FairyGUI;
using SkillCreate;

public class SelectPlaceState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
        m_UI.m_ListPlace.itemRenderer = PlaceItemRenderer;
        m_UI.m_ListPlace.onClickItem.AddCapture(OnPlaceSelected);

        m_UI.m_BtnStartPlace.onClick.Set(OnClickStartPlace);     // 开始领悟
    }

    public override void OnEnter()
    {
        m_View.RefreshProgress();
        m_UI.m_ListPlace.SetData(PlaceDeploy.GetIds());
        m_View.OnRefreshPupilBody();
        m_UI.m_CreatingBookInfo.m_IconUp.visible = false;
    }

    private void PlaceItemRenderer(int index, GObject obj)
    {
        var id = m_UI.m_ListPlace.GetData<int>(index);
        var deploy = PlaceDeploy.GetInfo(id);
        var item = obj as UI_PlaceSelectIcon;

        item.m_LabelName.SetText(deploy.Name);
        item.m_LabelLevel.SetValue(deploy.Level);
        item.m_LabelGoodAt.SetValue(deploy.GoodAt);
        item.m_LabelEventRate.SetValue((int)(deploy.EventPro * 100));
    }

    private void OnPlaceSelected(EventContext context)
    {
        var placeId = m_UI.m_ListPlace.GetSelectedData<int>();
        m_View.Data.PlaceId = placeId;
        var placeDeploy = PlaceDeploy.GetInfo(placeId);

        var fitness = placeDeploy.AddAtt.AddShenFa;

        var xinfaDeploy = XinFaDeploy.GetInfo(m_View.Data.SkillType);
        if (xinfaDeploy.Type == ESkillType.NeiGong)
        {
            fitness += placeDeploy.AddAtt.AddNeiGong;
        }
        else if (xinfaDeploy.Type == ESkillType.WaiGong)
        {
            fitness += placeDeploy.AddAtt.AddWaiGong;
        }

        var canbenDeploy = CanBenDeploy.GetInfo(m_View.Data.SkillId);
        if (canbenDeploy.Type == ESkillType.DaoFa)
        {
            fitness += placeDeploy.AddAtt.AddDaoFa;
        }
        else if (canbenDeploy.Type == ESkillType.JianFa)
        {
            fitness += placeDeploy.AddAtt.AddJianFa;
        }

        var createDeploy = UniqueSkillCreateDeploy.GetInfo(m_View.Data.SkillType, m_View.Data.SkillId);

        var oriFit = Define.ValueToFit(createDeploy.Value.FitValue);
        var curFit = Define.ValueToFit(createDeploy.Value.FitValue + fitness);
        m_UI.m_CreatingBookInfo.m_IconFitness.icon = UIUtil.GetFitnessUrl(createDeploy.Value.FitValue + fitness);

        m_UI.m_CreatingBookInfo.m_IconUp.visible = (int)curFit > (int)oriFit;
    }

    /// <summary>
    /// 开始领悟
    /// </summary>
    /// <param name="context"></param>
    private void OnClickStartPlace(EventContext context)
    {
        SkillCreateFacade.getInstance().TryEvent(m_View.Data.PlaceId);
    }
}
