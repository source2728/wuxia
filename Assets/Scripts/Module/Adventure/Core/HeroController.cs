using UnityEngine;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using DragonBones;

public class HeroController : MonoBehaviour
{
    public delegate bool MoveToTileDelegate(Vector2 tilePoint, Vector2? nextTilePoint, bool isNextTileLast);
    public MoveToTileDelegate OnFinishMoveToTile = new MoveToTileDelegate(DelegateFunction);
    public static bool DelegateFunction(Vector2 tilePoint, Vector2? nextTilePoint, bool isNextTileLast) { return false; }

    protected GameObject GoPlayer;
    protected UnityArmatureComponent m_ArmatureComp;
    protected Dictionary<string, GameObject> m_ArmatureGoMap = new Dictionary<string, GameObject>();

    protected int _SortingOrder;
    protected int SortingOrder
    {
        get { return _SortingOrder; }
        set
        {
            _SortingOrder = value;
            if (m_ArmatureComp != null)
            {
                m_ArmatureComp.sortingOrder = _SortingOrder;
            }
        }
    }
    
    public Vector2 CurTilePoint { get; set; }

    protected Sequence m_MoveSequence;
    protected Stack<ASPoint> m_MovingPath;

    protected string DragonBonesName = "";
    protected const string DragonBonesPath = "DragonBones/Map/";

    public void CreatePlayer(Vector2 tilePoint)
    {
        CurTilePoint = tilePoint;
        var go = new GameObject("Hero");
        go.transform.SetParent(transform, true);
        go.transform.localPosition = MapHelper.TileToMapPoint(CurTilePoint);
        GoPlayer = go;

        var pupilInfo = PupilProxy.instance.getPupilInfo(AdventureProxy.instance.GetData().PupilId);
        var deploy = PupilDeploy.GetInfo(pupilInfo.DId);
        var sex = (deploy.Sex == ESex.Man) ? 1 : 2;
        DragonBonesName = (deploy.Sex == ESex.Man) ? "man" : "woman";
        UnityFactory.factory.LoadDragonBonesData(DragonBonesPath + DragonBonesName + "_ske");
        UnityFactory.factory.LoadTextureAtlasData(DragonBonesPath + DragonBonesName + "_tex");

        SortingOrder = MapHelper.GetTileUnitSortOrder(CurTilePoint, MapHelper.ETileObject.Hero);
        ChangeAnimation("front", "idel");
    }

    public void ChangeAnimation(string armatureName, string animationName)
    {
        if (m_ArmatureComp == null)
        {
            CreateArmatureGo(armatureName);
            m_ArmatureComp.animation.Play(animationName);
            return;
        }

        if (m_ArmatureComp.armature.name != armatureName)
        {
            m_ArmatureComp.gameObject.SetActive(false);
            CreateArmatureGo(armatureName);
            m_ArmatureComp.gameObject.SetActive(true);
            m_ArmatureComp.animation.Play(animationName);
        }
        else if (m_ArmatureComp.animation.lastAnimationName != animationName)
        {
            m_ArmatureComp.animation.Play(animationName);
        }
    }

    protected void CreateArmatureGo(string armatureName)
    {
        GameObject go;
        if (m_ArmatureGoMap.TryGetValue(armatureName, out go))
        {
            m_ArmatureComp = go.GetComponent<UnityArmatureComponent>();
        }
        else
        {
            go = new GameObject(armatureName);
            go.transform.SetParent(GoPlayer.transform, true);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            m_ArmatureComp = UnityFactory.factory.BuildArmatureComponent(armatureName, DragonBonesName, null, null, go);
            m_ArmatureGoMap.Add(armatureName, go);
        }
        m_ArmatureComp.sortingOrder = SortingOrder;
    }

    public void StartMove(Stack<ASPoint> path)
    {
        m_MovingPath = path;
        MoveLine();
    }

    protected void MoveLine()
    {
        ASPoint startPoint = new ASPoint((int)CurTilePoint.x, (int)CurTilePoint.y);

        var adventureController = gameObject.GetComponent<AdventureController>();

        // 计算同一方向的最远格子
        var asPoint = m_MovingPath.Peek();
        List<ASPoint> linePoints = new List<ASPoint>();
        var curDirection = GetDirection(startPoint, asPoint);
        var curPoint = startPoint;
        while (m_MovingPath.Count > 1)
        {
            var nextPoint = m_MovingPath.Peek();
            var direction = GetDirection(curPoint, nextPoint);
            if (direction == curDirection)
            {
                linePoints.Add(nextPoint);
                m_MovingPath.Pop();
            }
            else
            {
                break;
            }
            curPoint = nextPoint;
        }

        // 最后一格是否遇到事件
        bool meetEvent = false;
        if (m_MovingPath.Count == 1)
        {
            var nextPoint = m_MovingPath.Peek();
            if (adventureController.HasEvent(new Vector2(nextPoint.X, nextPoint.Y)))
            {
                meetEvent = true;
            }
            else
            {
                var direction = GetDirection(curPoint, nextPoint);
                if (direction == curDirection)
                {
                    linePoints.Add(nextPoint);
                    m_MovingPath.Pop();
                }
            }
        }

        // 人物转向
        if (asPoint.X - startPoint.X > 0 || asPoint.Y - startPoint.Y > 0)
        {
            ChangeAnimation("front", "walk");
            m_ArmatureComp.armature.flipX = asPoint.X - startPoint.X > 0;
        }
        else
        {
            ChangeAnimation("back", "walk");
            m_ArmatureComp.armature.flipX = asPoint.Y - startPoint.Y < 0;
        }

        // 人物连贯动作
        if (linePoints.Count > 0)
        {
            GoPlayer.transform.DOLocalMove(MapHelper.TileToMapPoint(new Vector2(linePoints.Last().X, linePoints.Last().Y)), linePoints.Count * 0.4f);
        }

        // 人物移动中逻辑拆分
        var sequence = DOTween.Sequence();
        foreach (var nextPoint in linePoints)
        {
            sequence.AppendCallback((() =>
                {
                    var sortingOrder = MapHelper.GetTileUnitSortOrder(new Vector2(nextPoint.X, nextPoint.Y),
                        MapHelper.ETileObject.Hero);
                    if (sortingOrder > m_ArmatureComp.sortingOrder)
                    {
                        SortingOrder = sortingOrder;
                    }
                }))
                .AppendInterval(0.2f)
                .AppendCallback((() => { OnFinishMoveToTile(new Vector2(nextPoint.X, nextPoint.Y), null, true); }))
                .AppendInterval(0.2f)
                .AppendCallback((() =>
                {
                    CurTilePoint = new Vector2(nextPoint.X, nextPoint.Y);
                    SortingOrder = MapHelper.GetTileUnitSortOrder(CurTilePoint, MapHelper.ETileObject.Hero);
                }));
        }

        sequence.AppendCallback((() =>
        {
            if (meetEvent)
            {
                var nextPoint = m_MovingPath.Pop();
                adventureController.TriggerEvent(new Vector2(nextPoint.X, nextPoint.Y));

                ChangeAnimation(m_ArmatureComp.armature.name, "idel");
                m_MoveSequence = null;
            }
            else if (m_MovingPath.Count > 0)
            {
                MoveLine();
            }
            else
            {
                ChangeAnimation(m_ArmatureComp.armature.name, "idel");
                m_MoveSequence = null;
            }
        }));
        m_MoveSequence = sequence;
    }

    protected int GetDirection(ASPoint startPoint, ASPoint endPoint)
    {
        if (startPoint.X > endPoint.X)
        {
            return 1;
        }
        else if (startPoint.Y > endPoint.Y)
        {
            return 2;
        }
        else if (startPoint.X < endPoint.X)
        {
            return 3;
        }
        else if (startPoint.Y < endPoint.Y)
        {
            return 4;
        }
        return 0;
    }

    public GameObject GetHeroGo()
    {
        return GoPlayer;
    }

    public bool IsMoving()
    {
        return m_MoveSequence != null;
    }

    public void DoMoveToNextTile(Vector2 nextTilePoint)
    {
        AudioManager.inst.PlayAudioEffect("MapRun", false);

        var sortingOrder = MapHelper.GetTileUnitSortOrder(nextTilePoint, MapHelper.ETileObject.Hero);

        if (sortingOrder > m_ArmatureComp.sortingOrder)
        {
            SortingOrder = sortingOrder;
        }

        var move = GoPlayer.transform.DOLocalMove(MapHelper.TileToMapPoint(nextTilePoint), 0.4f);

        var sequence = DOTween.Sequence();
        sequence.Append(move).AppendCallback((() =>
        {
            CurTilePoint = nextTilePoint;
            SortingOrder = MapHelper.GetTileUnitSortOrder(CurTilePoint, MapHelper.ETileObject.Hero);
            m_MoveSequence = null;

            if (m_MovingPath.Count <= 0)
            {
                OnFinishMoveToTile(nextTilePoint, null, true);
                ChangeAnimation(m_ArmatureComp.armature.name, "idel");
            }
            else
            {
                var asPoint = m_MovingPath.Pop();
                var isMoveAgain = OnFinishMoveToTile(nextTilePoint, new Vector2(asPoint.X, asPoint.Y), m_MovingPath.Count <= 0);
                if (!isMoveAgain)
                {
                    ChangeAnimation(m_ArmatureComp.armature.name, "idel");
                }
            }
        }));

        m_MoveSequence = sequence;
        if (nextTilePoint.x - CurTilePoint.x > 0 || nextTilePoint.y - CurTilePoint.y > 0)
        {
            ChangeAnimation("front", "walk");
            m_ArmatureComp.armature.flipX = nextTilePoint.x - CurTilePoint.x > 0;
        }
        else
        {
            ChangeAnimation("back", "walk");
            m_ArmatureComp.armature.flipX = nextTilePoint.y - CurTilePoint.y < 0;
        }
    }
}
