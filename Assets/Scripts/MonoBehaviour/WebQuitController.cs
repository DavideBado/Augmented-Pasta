using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebQuitController : MonoBehaviour
{
    [SerializeField] GameObject ARGobj;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            ARGobj.SetActive(true);
        }
    }
}
