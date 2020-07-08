using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PastaController : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreTxt;
    [SerializeField] TMP_Text ScoreMultiTxt;
    int Score = 0;
    int Multi = 1;
    [SerializeField] int SingleFoodScore = 5;
    [SerializeField] float speedMod = 0.01f;
    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text = "Score = " + Score.ToString();
        ScoreMultiTxt.text = "Multi = " + Multi.ToString();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedMod, transform.position.y + touch.deltaPosition.y * speedMod, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CorrectFood")
        {
            Score += SingleFoodScore * Multi;
            Multi++;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "WrongFood")
        {
            Multi = 1;
            other.gameObject.SetActive(false);
        }
    }
}