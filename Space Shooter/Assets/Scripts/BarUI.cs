using UnityEngine;

public class BarUI : MonoBehaviour {

    [SerializeField]
    RectTransform barRectTransform;

    float maxBarWidth;

    private void Awake()
    {
        maxBarWidth = barRectTransform.rect.width;
    }

    private void OnEnable()
    {
        EventManager.onUpdateShiledUI += UpdateShieldDisplay;
       
    }

    private void OnDestroy()
    {
        EventManager.onUpdateShiledUI -= UpdateShieldDisplay;
    }

    private void UpdateShieldDisplay(float percentage)
    {
        barRectTransform.sizeDelta = new Vector2(maxBarWidth * percentage, barRectTransform.sizeDelta.y);
    }
}
