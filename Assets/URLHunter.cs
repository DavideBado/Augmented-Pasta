using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLHunter : MonoBehaviour
{
    [SerializeField] WebViewTest webView;
    [SerializeField] Camera RayCamera;
    [SerializeField] GameObject ARObj;
    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 2000))
                {
                    RecipeViewController recipeViewController = hit.transform.GetComponentInParent<RecipeViewController>();
                    if (recipeViewController != null)
                    {
                        webView.URL = recipeViewController.URL;
                        webView.gameObject.SetActive(true);
                        ARObj.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
