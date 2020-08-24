using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField] PastaController pastaController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CorrectFood") pastaController.Multi = 1;
        other.gameObject.SetActive(false);

    }
}
