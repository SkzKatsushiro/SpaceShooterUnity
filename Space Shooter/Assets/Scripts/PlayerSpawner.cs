using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject playerPrefab;

    private void OnEnable()
    {
        EventManager.onStartGame += SpawnPlayer;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= SpawnPlayer;
    }


    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
    }
}
