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

    [SerializeField] private CursorInteractionState cursorInterState;
    [SerializeField] private InteractableObject targetPicked;
    [SerializeField] private InteractableObject targetMouseOver;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Update()
    {
        if (cursorInterState == CursorInteractionState.Impossible)
            return;

        if (targetPicked != null)
            TargetPickedFollowCursor();
    }
    private void ChangeCursorState(CursorInteractionState _cursorInterState)
    {
        if (targetPicked != null)
            ReplacePickedTarget();
        cursorInterState = _cursorInterState;
    }
    public void ObjectMouseEnter(InteractableObject target)
    {
        if (cursorInterState == CursorInteractionState.Impossible || target == targetPicked)
            return;                     // 호출 대상이 targetPicked이면, return;
        targetMouseOver = target;
        targetMouseOver.HighlightOn();
        // 아무 것도 드래그 하고 있지 않은 상태에서 위를 지나가야만 정보를 출력한다.
        if (DoesTargetHaveInfo(targetMouseOver))
            GetInformativeObject(targetMouseOver).PrintInfo();
    }
    public void ObjectMouseExit(InteractableObject target)
    {
        if (target == targetMouseOver)
        {
            targetMouseOver.HighlightOff();
            targetMouseOver = null;
        }
        if (DoesTargetHaveInfo(target))
            GetInformativeObject(target).RemoveInfo();
    }
    public void ObjectMouseDown(InteractableObject target)
    {
        if (cursorInterState != CursorInteractionState.Possible)
            return;
        if (targetMouseOver == target)
            ObjectMouseExit(target);
        HoldTheTarget(target);
        targetPicked.PopAppearance();
    }
    public void ObjectMouseUp()
    {
        ReplacePickedTarget();
        ObjectMouseExit(targetPicked);
        PutTheTarget();
    }
    private void HoldTheTarget(InteractableObject target)
    {
        targetPicked = target;
        SetTargetPickedSortingOrder(100);
        SetTargetPicekdLayerToIgnoreRaycast();
    }
    private void PutTheTarget()
    {
        SetTargetPickedSortingOrder(0);
        SetTargetPickedLayerToObject();
        targetPicked = null;
    }
    private void ReplacePickedTarget() => targetPicked.transform.position = targetPicked.GetComponent<InteractableObject>().GetOriginPosition();
    private void SetTargetPickedSortingOrder(int num) => targetPicked.appearance.GetComponent<SpriteRenderer>().sortingOrder = num;
    private void SetTargetPicekdLayerToIgnoreRaycast() => targetPicked.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    private void SetTargetPickedLayerToObject() => targetPicked.gameObject.layer = LayerMask.NameToLayer("Object");
    private void TargetPickedFollowCursor() => targetPicked.transform.position = Utils.mousePos;
    private bool DoesTargetHaveInfo(InteractableObject target) => target.gameObject.GetComponent<InformativeObject>() != null ? true : false;
    private InformativeObject GetInformativeObject(InteractableObject target) => target.gameObject.GetComponent<InformativeObject>();
}
