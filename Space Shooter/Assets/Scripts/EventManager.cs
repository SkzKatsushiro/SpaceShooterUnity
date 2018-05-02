using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void StartGameDelegate(); //define method signature
    public static StartGameDelegate onStartGame; //define the event

    public delegate void TakeDamageDelegate(float amount);
    public static TakeDamageDelegate onTakeDamage;

    public static void StartGame()
    {
        if (onStartGame != null)
        {
            onStartGame();
        }
    }

    public static void TakeDamage(float amount)
    {
        if (onTakeDamage != null)
        {
            onTakeDamage(amount);
        }
    }
}
