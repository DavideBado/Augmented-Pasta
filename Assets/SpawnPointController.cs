using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    public Recipe CurrentRecipe;
    Food[] CorrectFood;
    List<Food> WrongFood = new List<Food>();
    [SerializeField] PoolManager poolManager;
    [SerializeField] Transform[] SpawnPoints;
    [SerializeField] float SpawnRate;
    [SerializeField] int SpawnChanceInitValue = 50;
    [SerializeField] int SpawnChanceDelta = 5;
    int SpawnChance;
    float lastSpawnTimeValue = 0;

    private void Start()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            SpawnPoints[i].position = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / SpawnPoints.Length) * i, Screen.height, 10));
            SpawnPoints[i].position += new Vector3(SpawnPoints[i].lossyScale.x, SpawnPoints[i].lossyScale.y, 0);
        }

        SetupFood(CurrentRecipe);

        SpawnChance = SpawnChanceInitValue;
    }

    private void Update()
    {
        if (Time.time > lastSpawnTimeValue + SpawnRate)
        {
            Spawn();
            lastSpawnTimeValue = Time.time;
        }
    }

    void Spawn()
    {
        Transform _CurrentSpawn = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        int _randValue = Random.Range(0, 100);

        if(_randValue >= SpawnChance)
        {
            int _randomIndex = Random.Range(0, WrongFood.Count - 1);
            // Spawn wrong
            for (int i = 0; i < WrongFood.Count; i++)
            {
                if(!poolManager.FoodPool[WrongFood[_randomIndex % WrongFood.Count]][poolManager.FoodPool[WrongFood[_randomIndex % WrongFood.Count]].Length - 1].activeSelf)
                {
                    for (int j = 0; j < poolManager.FoodPool[WrongFood[_randomIndex % WrongFood.Count]].Length; j++)
                    {
                        GameObject obj = poolManager.FoodPool[WrongFood[_randomIndex % WrongFood.Count]][j];
                        if (!obj.activeSelf)
                        {
                            obj.transform.position = _CurrentSpawn.position;
                            obj.SetActive(true);
                            return;
                        }
                    }
                }
            }
            SpawnChance += SpawnChanceDelta;
        }
        else
        {
            // Spawn Correct
            int _randomIndex = Random.Range(0, CorrectFood.Length - 1);
            for (int i = 0; i < CorrectFood.Length; i++)
            {
                if (!poolManager.FoodPool[CorrectFood[_randomIndex % CorrectFood.Length]][poolManager.FoodPool[CorrectFood[_randomIndex % CorrectFood.Length]].Length - 1].activeSelf)
                {
                    for (int j = 0; j < poolManager.FoodPool[CorrectFood[_randomIndex % CorrectFood.Length]].Length; j++)
                    {
                        GameObject obj = poolManager.FoodPool[CorrectFood[_randomIndex % CorrectFood.Length]][j];
                        if (!obj.activeSelf)
                        {
                            obj.transform.position = _CurrentSpawn.position;
                            obj.SetActive(true);
                            return;
                        }
                    }
                }
            }
            SpawnChance = SpawnChanceInitValue;
        }
    }

    void SetupFood(Recipe _recipe)
    {
        CorrectFood = _recipe.foods;
        WrongFood = poolManager.Foods.ToList();
        for (int i = 0; i < CorrectFood.Length; i++)
        {
            WrongFood.Remove(CorrectFood[i]);
        }

        for (int i = 0; i < WrongFood.Count; i++)
        {
            for (int j = 0; j < poolManager.FoodPool[WrongFood[i]].Length; j++)
            {
                poolManager.FoodPool[WrongFood[i]][j].tag = "WrongFood";
            }
        }

        for (int i = 0; i < CorrectFood.Length; i++)
        {
            for (int j = 0; j < poolManager.FoodPool[CorrectFood[i]].Length; j++)
            {
                poolManager.FoodPool[CorrectFood[i]][j].tag = "CorrectFood";
            }
        }
    }

    public void SetupRecipe(Recipe _recipe)
    {
        CurrentRecipe = _recipe;
    }
}
