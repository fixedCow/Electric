using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using EPOOutline;
using DG.Tweening;

public abstract class InteractableObject : MonoBehaviour
{
    public GameObject appearance;
    [SerializeField] protected Vector2 originPos;
    [HorizontalGroup] public Outlinable highlighted;
    [HorizontalGroup] public AudioSource highlightedAudio;

    public void OnMouseEnter() => CursorManager.instance.ObjectMouseEnter(this);
    public void OnMouseExit() => CursorManager.instance.ObjectMouseExit(this);
    public void HighlightOn() => highlighted.enabled = true;
    public void HighlightOff() => highlighted.enabled = false;
    public void PopAppearance()
    {
        float scaleToBe = 1.4f;
        gameObject.transform.localScale = new Vector3(scaleToBe, scaleToBe, scaleToBe);
        gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
    }
    public Vector2 GetOriginPosition() => originPos;
    public void SetOriginPosition(Vector2 _pos) => originPos = _pos;
    public void Replace() => transform.position = originPos;
    public void FollowCursor() => transform.position = Utils.mousePos;
    public void SetSortingOrder(int num) => appearance.GetComponent<SpriteRenderer>().sortingOrder = num;
    public void SetLayer(string str) => gameObject.layer = LayerMask.NameToLayer(str);
    public bool DoesHaveInfo() => gameObject.GetComponent<InformativeObject>() != null ? true : false;
    public abstract void InteractWith(InteractableObject io);
    public bool IsSameWith(InteractableObject io) => io.gameObject.tag == this.gameObject.tag ? true : false;
}