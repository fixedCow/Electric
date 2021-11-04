using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class InteractableObject : MonoBehaviour
{
    [ShowInInspector] protected Vector2 originPos;
    public GameObject highlighted;

    public abstract void OnMouseEnter();
    public abstract void OnMouseExit();
    public abstract void HighlightOn();
    public abstract void HighlightOff();
    public abstract void PrintInfo();
    public abstract void RemoveInfo();
    public Vector2 GetOriginPosition() => originPos;
    public void SetOriginPosition(Vector2 _pos) => originPos = _pos;
}
