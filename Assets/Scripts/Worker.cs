using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class Worker : InteractableObject
{
    [ShowInInspector] private string nameField;
    [ShowInInspector] private int age;
    [ShowInInspector] private int workYear;
    [ShowInInspector] private int happiness;
    [ShowInInspector] private int health;
    [ReadOnly] [ShowInInspector] public int income { get { int _income = age <= 3 ? 2 : 5; return _income + workYear; } }
    [ReadOnly] [ShowInInspector] public float laborForce { get { float _laborForce = age <= 3 ? 3 : 5; return _laborForce + Mathf.Lerp(0f, 10f, (float)workYear / 10f); } }
    [ShowInInspector] private bool isPaidAlready;

    private void OnEnable()
    {
        Initialize();
    }
    public override void OnMouseEnter()
    {
        // CursorManager의 타겟이 이 오브젝트가 아니면 하이라이트 처리, 맞다면 return;
        Debug.Log("Enter");
    }
    public override void OnMouseExit()
    {
        Debug.Log("Exit");
    }
    public void OnMouseDrag()
    {
        // OnMouseExit();
        Debug.Log("Draged");
    }
    public void OnMouseUp()
    {
        // OnMouseExit();
        Debug.Log("Up");
    }
    public override void HighlightOn()
    {

    }
    public override void HighlightOff()
    {

    }
    public override void PrintInfo()
    {

    }
    public override void RemoveInfo()
    {

    }
    public void Initialize()
    {
        MakeName();
        age = Random.Range(1, 7);
        happiness = Random.Range(15, 19);
        health = happiness;
        AddRandomWorkYearAbility();
    }
    private void MakeName()
    {
        Utils namemaker = new Utils();
        nameField = namemaker.MakeName();
    }
    private void AddRandomWorkYearAbility()
    {
        if (age > 4)
            workYear = Random.Range(0, age - 4);
    }
    public void SetIsPaid(bool paidAlready) => isPaidAlready = paidAlready;
    public int GetAge() => age;
    public int GetHealth() => Mathf.Clamp(health, 0, happiness);
    public void AddHealth(int num) => health += num;
}