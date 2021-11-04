using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum CursorInteractionState
{
    Impossible,
    OnlyMouseOver,
    Possible,
}
public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;

    [ShowInInspector] private CursorInteractionState cursorInterState;
    [ShowInInspector] private InteractableObject targetPicked;
    [ShowInInspector] private InteractableObject targetMouseOver;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Update()
    {
        if (cursorInterState == CursorInteractionState.Impossible)
            return;


    }
    private void ChangeCursorState(CursorInteractionState _cursorInterState)
    {
        if (targetPicked != null)
            ReplacePickedTarget();
        cursorInterState = _cursorInterState;
    }
    private void ReplacePickedTarget()
    {
        targetPicked.transform.position = targetPicked.GetComponent<InteractableObject>().GetOriginPosition();
        targetPicked = null;
    }
    public void ObjectMouseEnter(InteractableObject target)
    {
        if (cursorInterState == CursorInteractionState.Impossible || target == targetPicked)
            return;                     // 이미 고른 타겟이면, 발동하지 않는다.
        target.HighlightOn();
        targetMouseOver = target;
        // 아무 것도 드래그 하고 있지 않은 상태에서 위를 지나가야만 정보를 출력한다.
        if (targetPicked == null)
            target.PrintInfo();
    }
    public void ObjectMouseExit(InteractableObject target)
    {
        if (targetMouseOver == target)
        {
            target.HighlightOff();
            targetMouseOver = null;
        }
        target.RemoveInfo();
    }
    public void ObjectMouseDragged(InteractableObject target)
    {
        if (cursorInterState != CursorInteractionState.Possible)
            return;
        targetPicked = target;
    }
    public void ObjectMouseUp(InteractableObject target)
    {
        targetPicked = null;
    }
}
