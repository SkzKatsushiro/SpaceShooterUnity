using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyFireManager : MonoBehaviour {

    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private LaserGun[] laserGuns;

    [SerializeField]
    private float laserDistance =  200f;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = transform;
    }

    private void Update()
    {

        if (!FoundTarget())
        {
            return;
        }

        if (IsInFront() && HasLineOfSight())
        {
            FireLasers();
        }
    }

    private void FireLasers()
    {
        foreach (LaserGun gun in laserGuns)
        {
            gun.Fire();
        }
    }

    bool IsInFront()
    {
        Vector3 directionToTarget = thisTransform.position - targetTransform.position;
        float angle = Vector3.Angle(thisTransform.position, directionToTarget);

        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            Debug.DrawLine(thisTransform.position, targetTransform.position, Color.yellow);
            Debug.Log("IsInFront()");
            return true;
        }
 
        return false;
    }

    bool HasLineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = targetTransform.position - thisTransform.position;
       

        if(Physics.Raycast(thisTransform.position, direction, out hit, laserDistance))
        {
            Debug.DrawRay(thisTransform.position, hit.point, Color.red);
            Debug.Log("Hit tag: "+ hit.transform.tag);
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

    bool FoundTarget()
    {
        if (targetTransform == null)
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log("Found target", targetTransform);
            return false;
           
        }
        else
        {
            return true;
        }
    }
}
