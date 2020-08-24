using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARBarillaController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (PastaManager.instance)
        {
            if (other.tag == "CorrectFood")
            {
                PastaManager.instance.Score += PastaManager.instance.SingleFoodScore * PastaManager.instance.Multi;
                PastaManager.instance.Multi++;
                other.gameObject.SetActive(false);
            }
            else if (other.tag == "WrongFood")
            {
                PastaManager.instance.Multi = 1;
                other.gameObject.SetActive(false);
            }
        }
    }
}
