using UnityEngine;

public class GameUI : MonoBehaviour {

    bool isDisplayed = true;

    [SerializeField]
    GameObject gameUI;

    [SerializeField]
    GameObject mainMenu;

    private void Start()
    {
        ShowMainMenu();
    }

    private void OnEnable()
    {
        EventManager.onStartGame += ShowGameUI;
        EventManager.onPlayerDeath += ShowMainMenu;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= ShowGameUI;
        EventManager.onPlayerDeath -= ShowMainMenu;
    }

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
    }
}
