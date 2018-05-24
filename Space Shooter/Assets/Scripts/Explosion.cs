using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private float explosionDuration;

    private void OnEnable()
    {
        EventManager.onBlowUp += BlowUp;
    }

    private void OnDisable()
    {
        EventManager.onBlowUp -= BlowUp;
    }

    private void BlowUp(Vector3 pos)
    {
        GameObject exposionParticles = Instantiate(explosion, pos, Quaternion.identity);
        Destroy(exposionParticles, explosionDuration);
    }
}
