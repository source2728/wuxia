using System;
using System.Collections.Generic;
using Common;
using DG.Tweening;
using FairyGUI;

public class WinCenter
{
    public static WinCenter _inst;
    public static WinCenter inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = new WinCenter();
            }

            return _inst;
        }
    }

    protected Dictionary<Type, BaseWindow> WinMap = new Dictionary<Type, BaseWindow>();

    protected Stack<BaseWindow> ViewStack = new Stack<BaseWindow>();
    protected BaseWindow ShowingView = null;

    public BaseWindow GetWinObj<T>() where T : BaseWindow, new()
    {
        var t = typeof(T);
        BaseWindow win;
        if (!WinMap.TryGetValue(t, out win))
        {
            win = new T();
            WinMap.Add(t, win);
        }
        return win;
    }

    public T ShowPanel<T>(params object[] datas) where T : BaseWindow, new()
    {
        BaseWindow win = GetWinObj<T>();
        win.OnUpdateData(datas);
        win.Show();
        return win as T;
    }

    public T ShowFirstView<T>(params object[] datas) where T : BaseWindow, new()
    {
        BaseWindow win = GetWinObj<T>();
        win.OnUpdateData(datas);
        win.Show();
        ShowingView = win;
        return win as T;
    }

    public T TransView<T>(params object[] datas) where T : BaseWindow, new()
    {
        ShowingView.Hide();
        ViewStack.Push(ShowingView);

        BaseWindow win = GetWinObj<T>();
        win.OnUpdateData(datas);
        win.Show();
        ShowingView = win;
        return win as T;
    }

    public void ViewBack()
    {
        ShowingView.Hide();
        ShowingView = ViewStack.Pop();
        ShowingView.Show();
    }

    public void ClearAll()
    {
        if (ShowingView != null)
        {
            ShowingView.Hide();
            ShowingView = null;
        }   
    }

    public void ShowTips(string content)
    {
        CommonBinder.BindAll();
        var tips = UI_CommonTips.CreateInstance();
        tips.title = content;
        GRoot.inst.AddChild(tips);
        tips.Center();

        tips.TweenMoveY(tips.position.y - 50, 1f)
            .OnComplete((() =>
                    {
                        tips.TweenFade(0, 0.15f).OnComplete((() =>
                        {
                            tips.Dispose();
                        }));
                    }
                ));
    }
}