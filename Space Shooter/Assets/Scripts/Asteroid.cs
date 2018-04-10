using UnityEngine;

public class Asteroid : MonoBehaviour
{

    Transform asteroidTransform;
    Vector3 randomRotationVector;

    [SerializeField]
    private float MinSizeRange = 1.0f;

    [SerializeField]
    private float MaxSizeRange = 4.0f;

    [SerializeField]
    private float rotationOffset = 50f;

    [SerializeField]
    private float explosionDuration = 6f;

    [SerializeField]
    private GameObject explosion;


    void Update()
    {
        asteroidTransform.Rotate(randomRotationVector * Time.deltaTime);
    }

    void Start()
    {
        //Random Size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(MinSizeRange, MaxSizeRange);
        scale.z = Random.Range(MinSizeRange, MaxSizeRange);
        scale.y = Random.Range(MinSizeRange, MaxSizeRange);

        asteroidTransform.localScale = scale;

        //Random Rotation

        randomRotationVector.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotationVector.z = Random.Range(-rotationOffset, rotationOffset);
        randomRotationVector.y = Random.Range(-rotationOffset, rotationOffset);
    }

    private void Awake()
    {
        asteroidTransform = transform;
    }

    private void Hit(Vector3 pos)
    {
        GameObject exposionParticles = Instantiate(explosion, pos, Quaternion.identity, asteroidTransform);
        Destroy(exposionParticles, explosionDuration);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Asteroid hit");
        ContactPoint contact = collision.contacts[0];
        Hit(contact.point);
    }
}
