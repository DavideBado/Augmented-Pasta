using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RecipeViewController : MonoBehaviour
{
    [SerializeField] RectTransform ImagePanel;
    [SerializeField] RectTransform IngPanel;
    [SerializeField] float HideShowTime = 1;
    SwipeDetector swipeDetector;

    Vector3 hidePos = new Vector3();
    Vector3 showPos = new Vector3();
    private void Awake()
    {
        swipeDetector = FindObjectOfType<SwipeDetector>();
        hidePos = ImagePanel.transform.position;
        showPos = hidePos + new Vector3(0,50,0);
    }

    private void OnEnable()
    {
        swipeDetector.SwipeUp += HideIng;
        swipeDetector.SwipeDown += ShowIng;
    }

    private void OnDisable()
    {
        swipeDetector.SwipeUp -= HideIng;
        swipeDetector.SwipeDown -= ShowIng;
    }

    void ShowIng() => ImagePanel.DOMove(showPos, HideShowTime).OnComplete(() => { IngPanel.gameObject.SetActive(true); });

    void HideIng()
    {
        IngPanel.gameObject.SetActive(false);
        ImagePanel.DOMove(hidePos, HideShowTime);
    }
}
