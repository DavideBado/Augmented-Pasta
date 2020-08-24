using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PastaManager : MonoBehaviour
{
    public static PastaManager instance = null;

   // public TMP_Text IngTxt;
    [SerializeField] TMP_Text TimerTxt;
    [SerializeField] TMP_Text ScoreTxt;
    [SerializeField] TMP_Text ScoreMultiTxt;
    public int Score = 0;
    public int Multi = 1;
    public int SingleFoodScore = 5;
    [SerializeField] float speedMod = 0.01f;
    [SerializeField] float Timer = 30f;

    [SerializeField] GameObject Game;
    [SerializeField] GameObject GameOver;
    [SerializeField] TMP_Text GameOverTxt;
    float savedTime;

    Recipe recipe;

    public void SetRecipe(Recipe _recipe)
    {
        recipe = _recipe;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        string IngString = "";

        for (int i = 0; i < recipe.foods.Length; i++)
        {
            IngString = IngString + recipe.foods[i].Name + "\n";
        }

        //IngTxt.text = IngString;

        savedTime = Timer;
    }
    // Update is called once per frame
    void Update()
    {
        TimerTxt.text = "Timer = " + Timer.ToString("n0");
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            GameOverTxt.text = "Score = " + Score.ToString();
            GameOver.SetActive(true);
            Game.SetActive(false);
        }
        ScoreTxt.text = "Score = " + Score.ToString();
        ScoreMultiTxt.text = "Multi = " + Multi.ToString();
    }

}
