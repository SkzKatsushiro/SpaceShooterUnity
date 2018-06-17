using UnityEngine;

public class GameUI : MonoBehaviour {

    bool isDisplayed = true;

    [SerializeField]
    GameObject gameUI;

    [SerializeField]
    GameObject mainMenu;

    private void OnEnable()
    {
        EventManager.onStartGame += ShowgGameUI;
        EventManager.onPlayerDeath += PlayerDeath;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= ShowgGameUI;
        EventManager.onPlayerDeath -= PlayerDeath;
    }

    void PlayerDeath()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    void ShowgGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
    }
}
