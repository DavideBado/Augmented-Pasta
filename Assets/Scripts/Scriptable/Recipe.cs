using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class MyRecipeDictionary : SerializableDictionary<Food, float> { }
[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    [SerializeField] MyRecipeDictionary Ingredients;
}
