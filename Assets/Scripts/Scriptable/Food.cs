using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class Food : ScriptableObject
{
    public string Name;
    public GameObject Graphics;
    public string UnitOM;
    public float AverageValuePerUnit;
}
