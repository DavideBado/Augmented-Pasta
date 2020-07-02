using UnityEngine;
using DG.Tweening;

public class RecipesGroupViewController : MonoBehaviour
{
    [SerializeField] Transform recipes;
    [SerializeField] float rotationTime;
    [SerializeField] float rotationAngle;
    SwipeDetector swipeDetector;

    private void Awake()
    {
        swipeDetector = FindObjectOfType<SwipeDetector>();
    }
    private void OnEnable()
    {
        swipeDetector.SwipeLeft += () => RotateRecipes(-1);
        swipeDetector.SwipeRight += () => RotateRecipes(1);
    }

    void RotateRecipes(int dir)
    {
        recipes.DORotate(new Vector3(0, rotationAngle * dir + (recipes.rotation.y), 0), rotationTime, RotateMode.LocalAxisAdd);
    }
}
