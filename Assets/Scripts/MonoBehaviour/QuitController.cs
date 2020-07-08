using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitController : MonoBehaviour
{
    private void Update() {if (Input.GetKeyDown(KeyCode.Escape)) Quit(); }

    public void Quit()
    {
        Application.Quit();
    }
}
