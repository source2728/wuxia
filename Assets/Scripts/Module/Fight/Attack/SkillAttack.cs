using DG.Tweening;
using DragonBones;
using FairyGUI;
using UnityEngine;

public class SkillAttack : BaseAttack
{
    public int AttackCount { get; set; }
    public int AttackHurt { get; set; }
    public int SkillId { get; set; }

    public override void StartAttack(FightController fightController)
    {
        AttackTarget = fightController.GetEnemyCharacter(Owner);

        Owner.m_UICharacter.BodyObject.transform.GetChild(0)
            .GetComponent<UnityArmatureComponent>()
            .animation.Play("attack_01", 1);

        switch (SkillId)
        {
            case 1:
                ShowTargetSkillEffect(fightController, "wx_tjjz_tx");
                break;
            case 2:
                ShowTargetSkillEffect(fightController, "wx_tjdz_tx");
                break;
            case 3:
                ShowSelfSkillEffect(fightController, "wx_cyjq_tx");
                break;
            case 4:
                ShowTargetSkillEffect(fightController, "wx_hxdq_tx");
                break;
            case 5:
                ShowTargetSkillEffect(fightController, "wx_djzx_tx");
                break;
            case 6:
                ShowTargetSkillEffect(fightController, "wx_ddzx_tx");
                break;
            case 7:
                ShowSelfSkillEffect(fightController, "wx_lcjf_tx");
                break;
            case 8:
                ShowSelfSkillEffect(fightController, "wx_lkdf_tx");
                break;
        }
        fightController.FightView.m_UI.m_LeftSkillTriggerPoint.visible = true;
        fightController.FightView.m_UI.m_RightSkillTriggerPoint.visible = true;
        if (Owner.TeamType == FightController.ETeamType.LeftSide)
        {
            fightController.FightView.m_UI.GetTransition("t0").Play();
        }
        else
        {
            fightController.FightView.m_UI.GetTransition("t1").Play();
        }

        var sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => { return 1f; }, (float val) => { }, 1, 0.6f));
        for (int i = 0; i < AttackCount; i++)
        {
            sequence.AppendCallback(DoHurt);
            sequence.Append(DOTween.To(() => { return 1f; }, (float val) => { }, 1, 0.1f));
        }
        sequence.Append(DOTween.To(() => { return 1f; }, (float val) => { }, 1, 1f));
        sequence.AppendCallback(() =>
        {
            OnAttackFinish();
            Owner.m_UICharacter.BodyObject.transform.GetChild(0)
                .GetComponent<UnityArmatureComponent>()
                .animation.Play("idel");
            fightController.FightView.m_UI.m_LeftSkillTriggerPoint.visible = false;
            fightController.FightView.m_UI.m_RightSkillTriggerPoint.visible = false;
        });
    }

    private void ShowSelfSkillEffect(FightController fightController, string name)
    {
        if (Owner.TeamType == FightController.ETeamType.LeftSide)
        {
            var prefab = Resources.Load("Art_A/Effect/prefabs/" + name);
            var go = Object.Instantiate(prefab) as GameObject;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector3(100, 100, 1);
            fightController.FightView.m_UI.m_LeftSkillTriggerPoint.SetNativeObject(new GoWrapper(go));
        }
        else
        {
            var prefab = Resources.Load("Art_A/Effect/prefabs/" + name);
            var go = Object.Instantiate(prefab) as GameObject;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector3(-100, 100, 1);
            fightController.FightView.m_UI.m_RightSkillTriggerPoint.SetNativeObject(new GoWrapper(go));
        }
    }

    private void ShowTargetSkillEffect(FightController fightController, string name)
    {
        if (Owner.TeamType == FightController.ETeamType.RightSide)
        {
            var prefab = Resources.Load("Art_A/Effect/prefabs/" + name);
            var go = Object.Instantiate(prefab) as GameObject;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector3(100, 100, 1);
            go.transform.localRotation = Quaternion.Euler(10.0f, 0.0f, 0.0f);
            fightController.FightView.m_UI.m_LeftSkillTriggerPoint.SetNativeObject(new GoWrapper(go));
        }
        else
        {
            var prefab = Resources.Load("Art_A/Effect/prefabs/" + name);
            var go = Object.Instantiate(prefab) as GameObject;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector3(-100, 100, 1);
            go.transform.localRotation = Quaternion.Euler(10.0f, 0.0f, 0.0f);
            fightController.FightView.m_UI.m_RightSkillTriggerPoint.SetNativeObject(new GoWrapper(go));
        }
    }

    private void DoHurt()
    {
        var isCrit = Random.value <= 0.1;
        if (isCrit)
        {
            AttackTarget.Hurt((int)(AttackHurt * 1.2f), true);
        }
        else
        {
            AttackTarget.Hurt(AttackHurt, false);
        }
    }
}