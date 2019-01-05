using UnityEngine;
using System.Collections;
using DG.Tweening;
using DragonBones;

public class TileController : MonoBehaviour
{
    public int MapObjectType;
    public int SortingOrder;
    public bool HasExplore = false;

    public void Show(bool showAni)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            var spriteRenderer = child.GetChild(0).GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f);
            }
        }

        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);

            if (showAni)
            {
                var curY = transform.localPosition.y;
                transform.localPosition = new Vector3(transform.localPosition.x, curY - 1, transform.localPosition.z);
                transform.DOLocalMoveY(curY, 0.2f);
            }
        }
    }

    public void Hide()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);

            var spriteRenderer = child.GetChild(0).GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
            }
        }
    }

    public void ShowObject()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);

            var spriteRenderer = child.GetChild(0).GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f);
            }

            child.gameObject.SetActive(true);
        }
        gameObject.SetActive(true);
    }

    public void HideObject()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            

            var spriteRenderer = child.GetChild(0).GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
            }

            var tileObject = child.GetComponent<TileObject>();
            if (tileObject != null && tileObject.Type > 0 && tileObject.Type < (int)MapHelper.EMapObject.Obstacle)
            {
                tileObject.gameObject.SetActive(false);
            }
        }
    }

    public void OpenBox()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            var tileObject = child.GetComponent<TileObject>();
            if (tileObject != null)
            {
                var sequence = DOTween.Sequence();
                sequence.Append(child.transform.DOScale(1.2f, 0.15f))
                    .Append(child.transform.DOScale(0.8f, 0.15f))
                    .Append(child.transform.DOScale(1, 0.1f))
                    .AppendCallback((() => Destroy(child)));
                MapObjectType = 0;
                HasExplore = true;
                break;
            }
        }
    }

    public void KillEnemy()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            var tileObject = child.GetComponent<TileObject>();
            if (tileObject != null)
            {
                MapObjectType = 0;
                Destroy(child);
                HasExplore = true;
                break;
            }
        }
    }

    public void MeetNpc()
    {
        HasExplore = true;
    }
}
