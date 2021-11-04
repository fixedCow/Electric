using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    [ShowInInspector] public Dictionary<string, bool> Policy = new Dictionary<string, bool>();
}