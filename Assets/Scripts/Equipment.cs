using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Equipment : InteractableObject
{
    [ShowInInspector] protected WorkerFSM user;
    [ShowInInspector] protected WorkerFSM.State userState;
    [ShowInInspector] protected int oldAge;
}
