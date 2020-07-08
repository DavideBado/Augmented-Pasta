using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class MyRecipeDictionary : SerializableDictionary<int, float> { }
[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public Food[] foods;
    [SerializeField] MyRecipeDictionary Ingredients;

}
