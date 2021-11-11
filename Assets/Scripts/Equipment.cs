using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Equipment : InformativeObject
{
    [SerializeField] protected Worker user;
    [SerializeField] protected WorkerFSM.State toBeState;
    [SerializeField] protected int oldAge;

    public abstract void Activate(Worker worker);
    public abstract void Deactivate();
    public WorkerFSM.State GetToBeState() => toBeState;
}
