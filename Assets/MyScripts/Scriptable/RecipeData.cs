using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RecipeData : ScriptableObject
{
    public Sprite Icon;
    public string URL;
    public string RecipeName;
    [SerializeField] string[] IngredientsNames;
    [SerializeField] float[] IngredientsValues;
    [SerializeField] string[] IngredientsValuesType;

    public string GetIngString()
    {
        string IngString = "";
        for (int i = 0; i < IngredientsNames.Length; i++)
        {
            IngString = IngString + IngredientsNames[i].ToString() + " " + IngredientsValues[i].ToString() + " " + IngredientsValuesType[i].ToString() + "\n";
        }
        return IngString;
    }
}


