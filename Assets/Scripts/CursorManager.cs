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

        if (IsTargetPicked())
            targetPicked.FollowCursor();
    }
    private void ChangeCursorState(CursorInteractionState _cursorInterState)
    {
        if (IsTargetPicked())
            targetPicked.Replace();
        cursorInterState = _cursorInterState;
    }
    public void ObjectMouseEnter(InteractableObject target)
    {
        if (cursorInterState == CursorInteractionState.Impossible || target == targetPicked)
            return;                     // 호출 대상이 targetPicked이면, return;
        targetMouseOver = target;
        targetMouseOver.HighlightOn();
        // 아무 것도 드래그 하고 있지 않은 상태에서 위를 지나가야만 정보를 출력한다.
        if (targetMouseOver.DoesHaveInfo())
            GetInformativeObject(targetMouseOver).PrintInfo();
    }
    public void ObjectMouseExit(InteractableObject target)
    {
        if (target == targetMouseOver)
        {
            targetMouseOver.HighlightOff();
            targetMouseOver = null;
        }
        if (target.DoesHaveInfo())
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
        if (IsTargetMouseOverAvailable())
        {
            if (targetPicked.IsSameWith(targetMouseOver))
                ChangePosition(targetPicked, targetMouseOver);      // 좀 더 깔끔하게 바꿀 순 없을까? 이중 조건문 너무 지저분한데.
            else
                targetPicked.InteractWith(targetMouseOver);
        }
        // targetPicked.Replace();
        targetPicked.SetOriginPosition(targetPicked.transform.position);
        ObjectMouseExit(targetPicked);
        PutTheTarget();
    }
    private void HoldTheTarget(InteractableObject target)
    {
        targetPicked = target;
        targetPicked.SetSortingOrder(100);
        targetPicked.SetLayer("Ignore Raycast");
    }
    private void PutTheTarget()
    {
        targetPicked.SetSortingOrder(0);
        targetPicked.SetLayer("Object");
        targetPicked = null;
    }
    public bool IsTargetPicked() => targetPicked != null ? true : false;
    private InformativeObject GetInformativeObject(InteractableObject target) => target.gameObject.GetComponent<InformativeObject>();
    private bool IsTargetMouseOverAvailable() => targetMouseOver != null ? true : false;
    private void ChangePosition(InteractableObject picked, InteractableObject mouseover)
    {
        picked.transform.position = mouseover.transform.position;
        mouseover.transform.position = picked.GetOriginPosition();
        picked.SetOriginPosition(picked.transform.position);
        mouseover.SetOriginPosition(mouseover.transform.position);
    }
}
