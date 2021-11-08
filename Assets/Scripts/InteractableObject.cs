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
}