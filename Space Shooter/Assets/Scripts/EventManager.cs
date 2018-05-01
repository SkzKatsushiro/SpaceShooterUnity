using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void StartGameDelegate(); //define method signature
    public static StartGameDelegate onStartGame; //define the event

    public static void StartGame()
    {
        Debug.Log("Start the game");
        if(onStartGame != null)
        {
            onStartGame();
        }
    }
}
