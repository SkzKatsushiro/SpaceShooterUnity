
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

    [SerializeField]
    Asteroid asteroid;

    [SerializeField]
    int maxAsteroids = 1000;

    [SerializeField]
    int gridSpacing = 10;

    public void Start()
    {
        PlaceAsteroid();
    }

    private void PlaceAsteroid()
    {
        for (int x = 0; x < maxAsteroids; x++)
        {
            float xpos = Random.Range(transform.position.x - gridSpacing, transform.position.x + gridSpacing);
            float ypos = Random.Range(transform.position.z - gridSpacing, transform.position.z + gridSpacing);
            float zpos = Random.Range(transform.position.y - gridSpacing, transform.position.y + gridSpacing);

            Vector3 position = new Vector3(xpos, ypos, zpos);
            CreateAsteroids(position);
        }
    }

    private void CreateAsteroids(Vector3 position)
    {
        Instantiate(asteroid, position, Quaternion.identity, transform);
    }
}
