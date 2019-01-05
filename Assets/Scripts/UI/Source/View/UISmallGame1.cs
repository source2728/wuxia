using System;
using Common;
using DG.Tweening;
using FairyGUI;
using Fight;
using Main;
using SmallGame;
using UnityEngine;
using Random = UnityEngine.Random;

public class UISmallGame1 : ViewWin<UI_SmallGame1>
{
    public delegate void FinishDelegate(bool isWin);
    public FinishDelegate OnFinish = new FinishDelegate(DelegateFunction);
    public static void DelegateFunction(bool isWin) { }

    protected bool HasStart = false;
    protected bool HasClicked = false;
    protected bool HasFinished = false;
    protected GTweener m_GTweener;
    protected int m_SwordId = 0;

    protected readonly float[] RotateTimes = {2.5f, 1, 1.5f, 2};

    public UISmallGame1()
    {
        CommonBinder.BindAll();
        SmallGameBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/SmallGame");
        UIPackage.AddPackage("UI/Fight");
    }

    public override void OnRefresh()
    {
        m_UI.m_FightLose.visible = false;
        m_UI.m_FightWin.visible = false;
        HasStart = false;
        HasClicked = false;
        HasFinished = false;
        m_SwordId = Random.Range(1, 4);
        m_UI.m_Sword.icon = UIPackage.GetItemURL("SmallGame", "Sword_" + m_SwordId);

        m_UI.m_Sword.rotation = 0;
        m_UI.m_ViewState.selectedIndex = 0;
        m_UI.m_ProgressCoundDown.max = 3;
        m_UI.m_ProgressCoundDown.value = 3;
        m_UI.m_ProgressCoundDown.TweenValue(0, 3).OnComplete(OnCountDownFinish);

        AudioManager.inst.PlayBgAudio("SmallGame1");
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_Bg.onClick.Set(OnClick);
    }

    private void OnClick(EventContext context)
    {
        if (!HasStart || HasClicked || HasFinished)
        {
            return;
        }

        HasClicked = true;
        m_UI.GetTransition("t0").Play(OnPlayFinish);
        AudioManager.inst.PlayAudioEffect("SmallGameEffect1");
    }

    private void OnPlayFinish()
    {
        if (m_GTweener != null)
        {
            m_GTweener.Kill();
            m_GTweener = null;
        }
        OnGameOver(m_UI.m_Sword.rotation >= -110 && m_UI.m_Sword.rotation <= -85);
    }

    private void OnCountDownFinish()
    {
        HasStart = true;
        m_UI.m_ViewState.selectedIndex = 1;
        m_GTweener = m_UI.m_Sword.TweenRotate(-120, RotateTimes[m_SwordId - 1]).OnComplete(OnRotateFinish);
    }

    private void OnRotateFinish()
    {
        m_GTweener = null;
        OnGameOver(false);
    }

    private void OnGameOver(bool isWin)
    {
        HasFinished = true;

        var sequence = DOTween.Sequence();
        sequence.AppendInterval(0.5f)
            .AppendCallback((() =>
            {
                if (isWin)
                {
                    m_UI.m_FightWin.visible = true;
                    m_UI.m_FightWin.GetTransition("t0").Play();
                    AudioManager.inst.PlayAudioEffect("SmallGameEffect2");
                }
                else
                {
                    m_UI.m_FightLose.visible = true;
                    m_UI.m_FightLose.GetTransition("t0").Play();
                    AudioManager.inst.PlayAudioEffect("SmallGameEffect3");
                }
            }))
            .AppendInterval(1.5f)
            .AppendCallback((() =>
            {
                WinCenter.inst.ViewBack();
                AudioManager.inst.PlayBgAudio("Main");
                OnFinish(isWin);
            }));
    }
}
