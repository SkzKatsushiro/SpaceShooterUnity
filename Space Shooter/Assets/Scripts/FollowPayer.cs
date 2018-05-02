using System;
using UnityEngine;

[DisallowMultipleComponent]
public class FollowPayer : MonoBehaviour {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector3 offsetDistance = new Vector3(0f, 2f, -10f);

    [SerializeField]
    private float distanceDamp = 1.5f;

    private Vector3 velovity = Vector3.one; 

    Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = transform;
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        SmoothFollow();
    }

    private void SmoothFollow()
    {

        Vector3 toPos = player.position + (player.rotation * offsetDistance);
        Vector3 curPos = Vector3.SmoothDamp(cameraTransform.position, toPos, ref velovity, distanceDamp);
        cameraTransform.position = curPos;

        cameraTransform.LookAt(player, player.up);
    }
}
