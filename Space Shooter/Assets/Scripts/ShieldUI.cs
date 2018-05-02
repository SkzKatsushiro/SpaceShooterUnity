using UnityEngine;

public class ShieldUI : MonoBehaviour {

    [SerializeField]
    RectTransform barRectTransform;

    float maxBarWidth;

    private void Awake()
    {
        maxBarWidth = barRectTransform.rect.width;
    }

    private void OnEnable()
    {
        EventManager.onTakeDamage += UpdateShieldDisplay;
    }

    private void OnDestroy()
    {
        EventManager.onTakeDamage -= UpdateShieldDisplay;
    }

    private void UpdateShieldDisplay(float percentage)
    {
        barRectTransform.sizeDelta = new Vector2(maxBarWidth * percentage, barRectTransform.sizeDelta.y);
    }
}
