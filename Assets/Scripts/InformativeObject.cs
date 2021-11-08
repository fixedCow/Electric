using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformativeObject : InteractableObject
{
    public GameObject info;
    public void PrintInfo() => info.SetActive(true);
    public void RemoveInfo() => info.SetActive(false);
}
