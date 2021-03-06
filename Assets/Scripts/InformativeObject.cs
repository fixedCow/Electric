using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InformativeObject : InteractableObject
{
    public GameObject info;
    public void PrintInfo() => info.SetActive(true);
    public void RemoveInfo() => info.SetActive(false);
}
