using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePanelController : MonoBehaviour
{
    [SerializeField] Recipe recipe;
    [SerializeField] TMPro.TMP_Text IngTxt;

    private void Awake()
    {
        string IngString = "";

        for (int i = 0; i < recipe.foods.Length; i++)
        {
            IngString = IngString + recipe.foods[i].Name + "\n";
        }

        IngTxt.text = IngString;
    }

}
