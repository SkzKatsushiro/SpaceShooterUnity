using UnityEngine;

public class GameUI : MonoBehaviour {

    bool isDisplayed = true;

    [SerializeField]
    GameObject PlayButton;

    private void OnEnable()
    {
        EventManager.onStartGame += HidePanel;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= HidePanel;
    }

    void HidePanel()
    {
        isDisplayed = !isDisplayed;
        PlayButton.SetActive(isDisplayed);
    }    

    public void PlayGame()
    {
        EventManager.StartGame();
    }
}
