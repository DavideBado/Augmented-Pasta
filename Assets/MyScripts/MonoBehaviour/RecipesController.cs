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
    [SerializeField] Image RecipeImage;
    [SerializeField] TMP_Text RecipeName;
    [SerializeField] TMP_Text RecipeIngred;
    [SerializeField] float SpawnDist;
    #endregion

    ARTrackedImageManager m_TrackedImageManager;

    public MyRecipesDictionary RecipesData;

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
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

        for (int i = 0; i < eventArgs.added.Count; i++)
        {
            trackedImage = eventArgs.added[i];

            PastaRecipesData pastaRecipesData = RecipesData[trackedImage.referenceImage.name];
            RecipeData recipeData = pastaRecipesData.recipes[0];
            RecipeImage.sprite = recipeData.Icon;
            RecipeName.text = recipeData.RecipeName;
            RecipeIngred.text = recipeData.GetIngString();

            Test.transform.position = trackedImage.transform.position + new Vector3(0,0, SpawnDist);

            Test.SetActive(true);
        }

        //for (int i = 0; i < eventArgs.updated.Count; i++)
        //{
        //    trackedImage = eventArgs.updated[i];
        //    if (trackedImage.trackingState == TrackingState.Tracking)            
        //    {
        //        Test.SetActive(true);
        //    }
        //    else
        //    {
        //        // set active to false

        //        //Test.SetActive(false);
        //    }
        //}

        for (int i = 0; i < eventArgs.removed.Count; i++)
        {
            Test.SetActive(false);
        }
    }
}
