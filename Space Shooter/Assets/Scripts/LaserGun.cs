using System;
using UnityEngine;

public class LaserGun : MonoBehaviour {

    Transform laserGunTranform;
    Light lasergunLight;

    [SerializeField]
    float fireDelay;

    [SerializeField]
    float lightTimeOffTime;

    [SerializeField]
    LaserBeam laserbeam;

    Boolean canFire;

    private void Awake()
    {
        lasergunLight = GetComponent<Light>();
        laserGunTranform = transform;
        lasergunLight.enabled = false;
        canFire = true;
    }

    public void Fire()
    {
        Debug.Log("EndFire" + canFire);
        if (canFire) {
            Debug.Log("EndFire");
            BeginFire();
            Invoke("EndFire", lightTimeOffTime);
            canFire = false;
        }
    }

    private void BeginFire()
    {
        lasergunLight.enabled = true;
        Quaternion roatation = laserGunTranform.rotation;
        Instantiate(laserbeam, laserGunTranform.position, roatation);
        Debug.Log(laserbeam);
    }

    private void EndFire()
    {
        lasergunLight.enabled = false;
        canFire = true;
    }
}
