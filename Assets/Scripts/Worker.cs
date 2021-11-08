using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class Worker : InformativeObject
{
    [SerializeField] private string nameField;
    [SerializeField] private int age;
    [SerializeField] private int workYear;
    [SerializeField] private int happiness;
    [SerializeField] private int health;
    [ReadOnly] [ShowInInspector] public int income { get { int _income = age <= 3 ? 2 : 5; return _income + workYear; } }
    [ReadOnly] [ShowInInspector] public float laborForce { get { float _laborForce = age <= 3 ? 3 : 5; return _laborForce + Mathf.Lerp(0f, 10f, (float)workYear / 10f); } }
    [SerializeField] private bool isPaidAlready;

    private void OnEnable()
    {
        Initialize();
    }
    public void OnMouseDown()
    {
        CursorManager.instance.ObjectMouseDown(this);
    }
    public void OnMouseUp()
    {
        CursorManager.instance.ObjectMouseUp();
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