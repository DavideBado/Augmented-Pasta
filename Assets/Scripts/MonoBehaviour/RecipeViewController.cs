using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class RecipeViewController : MonoBehaviour
{
    public Canvas canvas;
    public Image RecipeImage;
    public TMP_Text RecipeName;
    public TMP_Text RecipeIngred;
    public RectTransform ImagePanel;
    public RectTransform IngPanel;
    public float HideShowTime = 1;
    SwipeDetector swipeDetector;

    Vector3 hidePos = new Vector3();
    Vector3 showPos = new Vector3();

    public string URL;
    
    private void Awake()
    {
        swipeDetector = FindObjectOfType<SwipeDetector>();
        UpdatePos();
    }

    private void OnEnable()
    {
        swipeDetector.SwipeUp += () => { UpdatePos(); if(IngPanel.gameObject.activeSelf) HideIng(); };
        swipeDetector.SwipeDown += () => { UpdatePos(); if (!IngPanel.gameObject.activeSelf) ShowIng(); };
    }

    private void OnDisable()
    {
        swipeDetector.SwipeUp -= () => {UpdatePos(); HideIng(); };
        swipeDetector.SwipeDown -= () => { UpdatePos(); ShowIng(); };
    }

    void ShowIng() => ImagePanel.DOMove(showPos, HideShowTime).OnComplete(() => { IngPanel.gameObject.SetActive(true); });

    void HideIng()
    {
        IngPanel.gameObject.SetActive(false);
        ImagePanel.DOMove(hidePos, HideShowTime);
    }

    void UpdatePos()
    {
        hidePos = new Vector3(ImagePanel.transform.position.x, 0, ImagePanel.transform.position.z);
        showPos = hidePos + new Vector3(0, 50, 0);
    }
}
