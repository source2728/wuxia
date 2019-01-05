using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AdventureController : MonoBehaviour
{
    protected const int ShowRange = 2;
    protected MapController m_MapController;
    protected HeroController m_HeroController;
    protected CameraController m_CameraController;
    protected IExploreMechanism m_ExploreMechanism;
    protected FightController m_FightController;

    public static AdventureController inst;

    void Awake()
    {
        inst = this;

        var gragInput = gameObject.AddComponent<GragInput>();
        gragInput.OnGragStart += OnGragStart;
        gragInput.OnGraging += OnGraging;
        gragInput.OnInertiaing += OnInertiaing;

        var zoomInput = gameObject.AddComponent<ZoomInput>();
        zoomInput.OnZoomIn += OnZoomIn;
        zoomInput.OnZoomOut += OnZoomOut;

        var clickInput = gameObject.AddComponent<ClickInput>();
        clickInput.OnClick += OnClick;

        m_MapController = gameObject.AddComponent<MapController>();

        m_CameraController = gameObject.AddComponent<CameraController>();

        m_FightController = gameObject.AddComponent<FightController>();
        m_FightController.OnFightFinish += OnFightFinish;

        m_ExploreMechanism = gameObject.AddComponent<ExploreMechanism2>();
        m_ExploreMechanism.SetMapController(m_MapController);

        m_HeroController = gameObject.AddComponent<HeroController>();
        m_HeroController.OnFinishMoveToTile += OnFinishMoveToTile;
    }

    void Start()
    {
        m_MapController.LoadMap();

        var heroStartTile = new Vector2(7, 9);
//        var heroStartTile = new Vector2(2, 5);

        m_HeroController.CreatePlayer(heroStartTile);
        m_CameraController.SetPosition(heroStartTile);
        m_ExploreMechanism.StartExplore(heroStartTile, ShowRange);
    }

    private void OnClick(Vector3 screenPoint)
    {
        var tilePoint = m_MapController.ScreenToTilePoint(screenPoint);
        TryMoveToTile(tilePoint);
    }

    private void OnZoomOut()
    {
        Camera.main.orthographicSize -= 0.1f;
    }

    private void OnZoomIn()
    {
        Camera.main.orthographicSize += 0.1f;
    }

    private void OnInertiaing(Vector3 offset)
    {
        Camera.main.transform.position = Camera.main.transform.position - offset / 125;
    }

    private void OnGraging(Vector3 offset)
    {
        Camera.main.transform.position = Camera.main.transform.position - offset / 200;
    }

    private void OnGragStart()
    {
        m_CameraController.UnlockTarget();
    }

    private void TryMoveToTile(Vector2 tilePoint)
    {
        var tileList = m_MapController.FindPath(m_HeroController.CurTilePoint, tilePoint);
        if (tileList == null)
        {
            return;
        }

        if (m_HeroController.IsMoving())
        {
            return;
        }
        var startPoint = tileList.Pop(); // 去掉开始点

        m_CameraController.LockToTarget(m_HeroController.GetHeroGo());
        m_HeroController.StartMove(tileList);
    }

    private bool OnFinishMoveToTile(Vector2 tilePoint, Vector2? nextTilePoint, bool isNextTileLast)
    {
        m_MapController.TileSink(tilePoint);
        m_ExploreMechanism.Explore(tilePoint);
        return false;
    }

    public bool HasEvent(Vector2 point)
    {
        var tileController = m_MapController.GetTileController(point);
        return tileController.MapObjectType > 0 && tileController.MapObjectType < (int) MapHelper.EMapObject.Obstacle;
    }

    public void TriggerEvent(Vector2 point)
    {
        var tileController = m_MapController.GetTileController(point);
        switch (tileController.MapObjectType)
        {
            case (int)MapHelper.EMapObject.npc_001:
            case (int)MapHelper.EMapObject.npc_004:
            case (int)MapHelper.EMapObject.npc_005:
            case (int)MapHelper.EMapObject.npc_006:
                FindEnemy(point, tileController.MapObjectType);
                break;

            case (int)MapHelper.EMapObject.npc_002:
                FindNpc(tileController);
                break;

            case (int)MapHelper.EMapObject.npc_003:
                FindBox(tileController);
                break;
        }
    }

    private void OnFightFinish(Vector2 point, bool isWin)
    {
        if (isWin)
        {
            var tileController = m_MapController.GetTileController(point);
            tileController.KillEnemy();
        }
    }

    protected void FindBox(TileController tileController)
    {
        WinCenter.inst.ShowPanel<UIBoxInfoPanel>(tileController);        
    }

    protected void FindEnemy(Vector2 tilePoint, int type)
    {
        int id = 0;
        switch ((MapHelper.EMapObject)type)
        {
            case MapHelper.EMapObject.npc_001:
                id = 3;
                break;
            case MapHelper.EMapObject.npc_004:
                id = 4;
                break;
            case MapHelper.EMapObject.npc_005:
                id = 1;
                break;
            case MapHelper.EMapObject.npc_006:
                id = 2;
                break;
        }
        WinCenter.inst.ShowPanel<UIEnemyInfoPanel>(tilePoint, id);
    }

    private void FindNpc(TileController tileController)
    {
        WinCenter.inst.ShowPanel<UIDialogPanel>(tileController);
    }
}
