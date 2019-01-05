using System;
using DragonBones;
using FairyGUI;
using Fight;
using UnityEngine;
using static FightController;

public class CharacterController
{
    public bool IsAttacking { get; set; }
    public ETeamType TeamType { get; set; }
    public int SkillId { get; set; }

    public UI_Character m_UICharacter;
    protected float m_Cd = 0;
    protected int AttackCount = 0;

    protected int m_MaxHp;
    protected int m_CurHp;

    protected BaseAttack m_NormalAttack = null;
    protected BaseAttack m_SkillAttack = null;

    public void InitHp(int max, int cur)
    {
        m_MaxHp = max;
        m_CurHp = cur;
    }

    public void InitNormalAttack(BaseAttack attack)
    {
        m_NormalAttack = attack;
        m_NormalAttack.Owner = this;
        m_NormalAttack.OnAttackFinish += OnAttackFinish;
    }

    public void InitSkillAttack(BaseAttack attack)
    {
        m_SkillAttack = attack;
        m_SkillAttack.Owner = this;
        m_SkillAttack.OnAttackFinish += OnAttackFinish;
    }

    public void InitView(UI_Character view, ETeamType side, int id)
    {
        m_UICharacter = view;

        if (side == ETeamType.LeftSide)
        {
            var pupilInfo = PupilProxy.instance.getPupilInfo(id);
            var deploy = PupilDeploy.GetInfo(pupilInfo.DId);
            var sex = (deploy.Sex == ESex.Man) ? 1 : 2;
            var prefab = Resources.Load("Fight/FightPupil_" + sex);
            var go = UnityEngine.Object.Instantiate(prefab) as GameObject;
            go.transform.localScale = new Vector3(100, 100, 1);
            view.m_Body.SetNativeObject(new GoWrapper(go));
            view.BodyObject = go;
            go.transform.GetChild(0).GetComponent<UnityArmatureComponent>().armature.flipX = side == ETeamType.LeftSide;
        }
        else
        {
            var prefab = Resources.Load("Fight/FightNpc_" + id);
            var go = UnityEngine.Object.Instantiate(prefab) as GameObject;
            go.transform.localScale = new Vector3(100, 100, 1);
            view.m_Body.SetNativeObject(new GoWrapper(go));
            view.BodyObject = go;
            go.transform.GetChild(0).GetComponent<UnityArmatureComponent>().armature.flipX = side == ETeamType.LeftSide;
        }

        m_UICharacter.InitHp(m_MaxHp, m_CurHp);
    }

    public void UpdateAttackCd(float dt)
    {
        m_Cd -= dt;
    }

    public bool CanAttack()
    {
        return m_Cd <= 0 && !IsAttacking && m_NormalAttack != null;
    }

    public void StartAttack(FightController fightController)
    {
        IsAttacking = true;
        AttackCount++;
   
        if (AttackCount % 4 == 0 && SkillId > 0)
        {
            m_SkillAttack.StartAttack(fightController); 
        }
        else
        {
            m_NormalAttack.StartAttack(fightController);
        }
    }

    private void OnAttackFinish()
    {
        IsAttacking = false;
        m_Cd = (TeamType == ETeamType.LeftSide) ? 1 : 1.3f;
    }

    public void Hurt(int hp, bool isCrit)
    {
        m_CurHp = Math.Max(0, m_CurHp - hp);
        m_UICharacter.SetHp(m_CurHp);

        string comName = isCrit ? "LabelCritHurt" : "LabelNormalHurt";
        var labelHurt = UIPackage.CreateObject("Common", comName);
        m_UICharacter.m_HurtStart.asCom.AddChild(labelHurt);
        labelHurt.text = hp.ToString();
        labelHurt.Center();
        labelHurt.TweenMoveY(labelHurt.position.y - 50, 1).OnComplete((() =>
        {
            labelHurt.RemoveFromParent();
            labelHurt.Dispose();
        }));
    }

    public bool IsDead()
    {
        return m_CurHp <= 0;
    }
}