using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    private new string tag;

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
        tag = gameObject.tag;

        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

    private void Regenerate()
    {
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth += regenarationAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        float amount = currentHealth / (float)maxHealth;

        EventManager.TakeDamage(amount);

        if (tag.Equals("Player"))
        {
            EventManager.UpdateShiledUI(amount);
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

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        float amount = currentHealth / (float)maxHealth;
        EventManager.TakeDamage(amount);

        if (tag.Equals("PlayerShip"))
        {
            EventManager.UpdateShiledUI(amount);
        }

        if (currentHealth <= 0)
        {
            BlowUp(pos);
        }
    }

    private void BlowUp(Vector3 pos)
    {

        if (tag.Equals("PlayerShip"))
        {
            EventManager.PlayerDeath();
        }

        EventManager.BlowUp(pos);
        DestroyObject(gameObject);
        EventManager.BlowUp(pos);

        if (gameObject.tag == "PlayerShip")
        {
            Debug.Log("BlowUp Player");
            EventManager.PlayerDeath();
        }
    }

    private void Hit(Vector3 pos)
    {
        TakeDamage(pos);
    }
}
