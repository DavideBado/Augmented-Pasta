using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text DebugText;

    SwipeDetector swipeDetector;

    private void Awake()
    {
        swipeDetector = FindObjectOfType<SwipeDetector>();
    }

    private void OnEnable()
    {
        swipeDetector.SwipeUp += OnSwipeUp;
        swipeDetector.SwipeDown += OnSwipeDown;
        swipeDetector.SwipeLeft += OnSwipeLeft;
        swipeDetector.SwipeRight += OnSwipeRight;
    }

    private void OnDisable()
    {
        swipeDetector.SwipeUp -= OnSwipeUp;
        swipeDetector.SwipeDown -= OnSwipeDown;
        swipeDetector.SwipeLeft -= OnSwipeLeft;
        swipeDetector.SwipeRight -= OnSwipeRight;
    }
    void OnSwipeUp()
    {
        DebugText.text = ("Swipe UP");
    }

    void OnSwipeDown()
    {
        DebugText.text = ("Swipe Down");
    }

    void OnSwipeLeft()
    {
        DebugText.text = ("Swipe Left");
    }

    void OnSwipeRight()
    {
        DebugText.text = ("Swipe Right");
    }
}
