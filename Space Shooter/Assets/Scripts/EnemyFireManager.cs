using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyFireManager : MonoBehaviour
{

    private TargetFinder targetFinder;

    [SerializeField]
    private LaserGun[] laserGuns;

    [SerializeField]
    private float laserDistance = 200f;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = transform;
        targetFinder = GameObject.FindObjectOfType<TargetFinder>();
    }

    private void Update()
    {

        if (targetFinder.TargetTransform == null)
        {
            return;
        }

        if (!targetFinder.FoundTarget())
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
        Vector3 directionToTarget = thisTransform.position - targetFinder.TargetTransform.position;
        float angle = Vector3.Angle(thisTransform.position, directionToTarget);

        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            Debug.DrawLine(thisTransform.position, targetFinder.TargetTransform.position, Color.yellow);
            Debug.Log("IsInFront()");
            return true;
        }

        return false;
    }

    bool HasLineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = targetFinder.TargetTransform.position - thisTransform.position;


        if (Physics.Raycast(thisTransform.position, direction, out hit, laserDistance))
        {
            Debug.DrawRay(thisTransform.position, hit.point, Color.red);
            Debug.Log("Hit tag: " + hit.transform.tag);
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
}
