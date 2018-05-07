using System;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyMovement : MonoBehaviour
{

    private TargetFinder targetFinder;

    [SerializeField]
    private float rotationalDamp = 0.5f;

    [SerializeField]
    private float movementSpeed = 50f;

    [SerializeField]
    private Thruster[] thrusters;

    [SerializeField]
    private float pathFindingRaycastOffset = 2.5f;

    [SerializeField]
    private float pathDetectionDistance = 20f;

    [SerializeField]
    private float rotaionOffset = 5f;

    private Transform shipTransform;

    private void Awake()
    {
        shipTransform = transform;
        targetFinder = gameObject.GetComponent<TargetFinder>();
    }

    private void Update()
    {
        if (!targetFinder.FoundTarget())
        {
            return;
        }
        ActivateThrusters();
        PathFinding();
        Move();
    }

    private void ActivateThrusters()
    {
        foreach (Thruster truster in thrusters)
        {
            truster.Activate();
        }
    }

    private void Turn()
    {
        Vector3 position = targetFinder.TargetTransform.position - shipTransform.position;
        Quaternion rotation = Quaternion.LookRotation(position);
        shipTransform.rotation = Quaternion.Slerp(shipTransform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    private void Move()
    {
        shipTransform.position += shipTransform.forward * Time.deltaTime * movementSpeed;
    }

    private void PathFinding()
    {
        RaycastHit hit;

        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = shipTransform.position - shipTransform.right * pathFindingRaycastOffset;
        Vector3 right = shipTransform.position + shipTransform.right * pathFindingRaycastOffset;
        Vector3 up = shipTransform.position + shipTransform.up * pathFindingRaycastOffset;
        Vector3 down = shipTransform.position - shipTransform.up * pathFindingRaycastOffset;

        Debug.DrawRay(left, shipTransform.forward * pathDetectionDistance, Color.green);
        Debug.DrawRay(right, shipTransform.forward * pathDetectionDistance, Color.cyan);
        Debug.DrawRay(up, shipTransform.forward * pathDetectionDistance, Color.green);
        Debug.DrawRay(down, shipTransform.forward * pathDetectionDistance, Color.green);

        if (Physics.Raycast(left, shipTransform.forward, out hit, pathDetectionDistance))
        {
            raycastOffset += Vector3.right;
        }
        else if (Physics.Raycast(right, shipTransform.forward, out hit, pathDetectionDistance))
        {
            raycastOffset -= Vector3.right;
        }

        if (Physics.Raycast(up, shipTransform.forward, out hit, pathDetectionDistance))
        {
            raycastOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, shipTransform.forward, out hit, pathDetectionDistance))
        {
            raycastOffset += Vector3.up;
        }


        if (raycastOffset != Vector3.zero)
        {
            Vector3 position = raycastOffset - shipTransform.position;
            Quaternion rotation = Quaternion.LookRotation(position);
            shipTransform.rotation = Quaternion.Slerp(shipTransform.rotation, rotation, rotaionOffset * Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }
}
