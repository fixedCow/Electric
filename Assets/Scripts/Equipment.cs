using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Equipment : InformativeObject
{
    [SerializeField] protected WorkerFSM user;
    [SerializeField] protected WorkerFSM.State userState;
    [SerializeField] protected int oldAge;
}
