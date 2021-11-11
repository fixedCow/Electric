using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Equipment
{
    public override void Activate(Worker worker)
    {
        user = worker;
    }
    public override void Deactivate()
    {

    }
    public override void InteractWith(InteractableObject io)
    {

    }
}