using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;

[Serializable] public class MyRecipesDictionary : SerializableDictionary<string, PastaRecipesData> { }
public class RecipesController : MonoBehaviour
{
    //#########TEST TEMP##########
    #region TEST TEMP
    [SerializeField] GameObject Test;

    [SerializeField] float SpawnDist;
    #endregion

    [SerializeField] Transform recipes;
    ARTrackedImageManager m_TrackedImageManager;

    public MyRecipesDictionary RecipesData;

    List<GameObject> RecipesInScene = new List<GameObject>();

    public GameObject TempPanels;
    void Awake()
    {
        m_TrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        ARTrackedImage trackedImage = null;
        //for (int i = 0; i < RecipesInScene.Count; i++)
        //{
        //    RecipesInScene[i].SetActive(false);
        //}
        //RecipesInScene.Clear();

        for (int i = 0; i < eventArgs.added.Count; i++)
        {
            trackedImage = eventArgs.added[i];

            ////PastaRecipesData pastaRecipesData = RecipesData[trackedImage.referenceImage.name];
            //for (int j = 0; j < Recipes.Length; j++)
            //{
            //    GameObject _RecipeGobj = Instantiate(Test, recipes);
            //    RecipesInScene.Add(_RecipeGobj);
            //    //RecipeViewController recipeViewController = _RecipeGobj.GetComponent<RecipeViewController>();

            //    _RecipeGobj.transform.position = trackedImage.transform.position + new Vector3(100 * j, 0, SpawnDist);

            //    //RecipeData recipeData = pastaRecipesData.recipes[j];
            //    //recipeViewController.RecipeImage.sprite = recipeData.Icon;
            //    //recipeViewController.RecipeName.text = recipeData.RecipeName;
            //    //recipeViewController.RecipeIngred.text = recipeData.GetIngString();
            //    //recipeViewController.URL = recipeData.URL;

                //_RecipeGobj.SetActive(true);
            TempPanels.SetActive(true);
            //}


        }

        for (int i = 0; i < eventArgs.removed.Count; i++)
        {
            //for (int j = 0;j < RecipesInScene.Count; j++)
            //{
            //    RecipesInScene[i].SetActive(false);
            //}
            //RecipesInScene.Clear();
            TempPanels.SetActive(false);
        }
    }
}
