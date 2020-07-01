using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

[Serializable] public class MyRecipesDictionary : SerializableDictionary<string, PastaRecipesData> { }
public class RecipesController : MonoBehaviour
{
    //#########TEST TEMP##########
    #region TEST TEMP
    public GameObject Test;
    public Image RecipeImage;
    public Text RecipeName;
    public Text RecipeIngred;
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
            // instantiate AR object, set trackedImage.transform
            // use a Dictionary, the key could be the trackedImage, or the name of the reference image -> trackedImage.referenceImage.name
            // the value of the Dictionary is the AR object you instantiate.

            PastaRecipesData pastaRecipesData = RecipesData[trackedImage.referenceImage.name];
            RecipeData recipeData = pastaRecipesData.recipes[0];
            RecipeImage.sprite = recipeData.Icon;
            RecipeName.text = recipeData.RecipeName;
            RecipeIngred.text = recipeData.GetIngString();

          
        }

        for (int i = 0; i < eventArgs.updated.Count; i++)
        {
            trackedImage = eventArgs.updated[i];
            if (trackedImage.trackingState == TrackingState.Tracking)
            //if (trackedImage.trackingState != TrackingState.None)
            {
                // set AR object to active, use Dictionary to get AR object based on trackedImage
                // you can also include TrackingState.Limited by checking for None

                //camera.transform.Rotate(new Vector3(0, 0, 45), Space.Self);
                //camera.gameObject.SetActive(false);
                //PastaRecipesData pastaRecipesData = RecipesData[trackedImage.referenceImage.name];
                //RecipeData recipeData = pastaRecipesData.recipes[0];
                //RecipeImage.sprite = recipeData.Icon;
                //RecipeName.text = recipeData.RecipeName;
                //RecipeIngred.text = recipeData.GetIngString();

                Test.SetActive(true);
            }
            else
            {
                // set active to false

                Test.SetActive(false);
            }
        }

        for (int i = 0; i < eventArgs.removed.Count; i++)
        {
            // destroy AR object, or set active to false. Use Dictionary.
            Test.SetActive(false);
        }
    }
}
