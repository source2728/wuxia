using DG.Tweening;
using DragonBones;
using UnityEngine;

public class NormalAttack : BaseAttack
{
    public int AttackCount { get; set; }
    public int AttackHurt { get; set; }

    public override void StartAttack(FightController fightController)
    {
        AttackTarget = fightController.GetEnemyCharacter(Owner);

        Owner.m_UICharacter.BodyObject.transform.GetChild(0)
            .GetComponent<UnityArmatureComponent>()
            .animation.Play("attack_01", 1);

        var sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => { return 1f; }, (float val) => { }, 1, 0.6f));
        sequence.AppendCallback(DoHurt);
        sequence.Append(DOTween.To(() => { return 1f; }, (float val) => { }, 1, 1f));
        sequence.AppendCallback(AttackFinigh);
    }

    private void DoHurt()
    {
        var isCrit = Random.value <= 0.3;
        if (isCrit)
        {
            AttackTarget.Hurt((int)(AttackHurt * 1.2f), true);
        }
        else
        {
            AttackTarget.Hurt(AttackHurt, false);
        }
    }

    private void AttackFinigh()
    {
        OnAttackFinish();
        Owner.m_UICharacter.BodyObject.transform.GetChild(0)
            .GetComponent<UnityArmatureComponent>()
            .animation.Play("idel");
    }
}