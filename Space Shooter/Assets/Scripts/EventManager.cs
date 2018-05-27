using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDeath;

    public delegate void TakeDamageDelegate(float amount);
    public static TakeDamageDelegate onTakeDamage;

    public delegate void BlowUpDelegate(Vector3 pos);
    public static BlowUpDelegate onBlowUp;

   

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

    public static void BlowUp(Vector3 pos)
    {
        if(onBlowUp != null)
        {
            onBlowUp(pos);
        }
    }

    public static void PlayerDeath()
    {
        if(onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }
}
