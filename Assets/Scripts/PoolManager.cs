using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] int amount;
    public Food[] Foods;

    public Dictionary<Food, GameObject[]> FoodPool;

    private void Awake()
    {
        FoodPool = new Dictionary<Food, GameObject[]>();
        for (int i = 0; i < Foods.Length; i++)
        {
            GameObject[] _FoodObj = new GameObject[amount];
            for (int j = 0; j  < amount; j ++)
            {
                GameObject _foodInstance = Instantiate(Foods[i].Graphics, transform);
                _FoodObj[j] = _foodInstance;
                _foodInstance.SetActive(false);
            }
            FoodPool.Add(Foods[i], _FoodObj);
        }
    }
}
