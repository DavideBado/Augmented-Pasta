﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelector : MonoBehaviour
{
  public void LoadScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
