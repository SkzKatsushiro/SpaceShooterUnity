using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing : MonoBehaviour {

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private float explosionDuration;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("X-wing hit");
        ContactPoint contact = collision.contacts[0];
        Hit(contact.point);
    }

    private void Hit(Vector3 pos)
    {
        GameObject exposionParticles = Instantiate(explosion, pos, Quaternion.identity, transform);
        Destroy(exposionParticles, explosionDuration);
    }
}
