using UnityEngine;

[DisallowMultipleComponent]
public class TieFighter : MonoBehaviour {

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private float explosionDuration;

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private float regenerationRate;

    [SerializeField]
    private int regenarationAmount;

    [SerializeField]
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

    private void Regenerate()
    {
        Debug.Log("Regenerating");
        currentHealth += regenarationAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Hit(contact.point);
    }

    private void TakeDamage(Vector3 pos, int damageAmount = 1)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            BlowUp(pos);
        }
    }

    private void BlowUp(Vector3 pos)
    {
        GameObject exposionParticles = Instantiate(explosion, pos, Quaternion.identity, transform);
        Destroy(exposionParticles, explosionDuration);
    }

    private void Hit(Vector3 pos)
    {
        TakeDamage(pos);
    }
}
