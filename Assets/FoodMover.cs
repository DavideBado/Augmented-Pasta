using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMover : MonoBehaviour
{
    [SerializeField] float Speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0), Space.Self);
    }
}
