using System;
using UnityEngine;


public class LaserBeam : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 100;

    [SerializeField]
    private float timeAlive = 1.0f;

    private Transform laserTranform;

    private void Awake()
    {
        laserTranform = transform;
        Destroy(gameObject, timeAlive);
    }

    private void Update()
    {
        laserTranform.position += laserTranform.forward * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
