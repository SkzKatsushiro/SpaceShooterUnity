﻿using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Movement : MonoBehaviour {

    private static readonly string FORWARD = "Vertical";
    private static readonly string HORIZONTAL = "Horizontal";
    private static readonly string PITCH = "Pitch";
    private static readonly string ROLL = "Roll";

    [SerializeField]
    private Thruster[] thrusters;

    [SerializeField]
    private float movementSpeed = 100;

    [SerializeField]
    private float turnSpeed = 60;

    Transform playerTransform;

    void Awake()
    {
        playerTransform = transform;
        LockCursor();
    }

    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        if (!canMove)
        {
            Debug.Log("In return");
            return;
        }
            Turn();
            Thrust();
=======
        Turn();
        Thrust();
>>>>>>> parent of 0f30cc6... Merge branch 'dev' into Change-target-functionality-
=======
        Turn();
        Thrust();
>>>>>>> parent of 29b0e97... Merge pull request #5 from SkzKatsushiro/mouse-control-feature
    }

    private void Turn()
    {
        float yaw =  turnSpeed * Time.deltaTime * Input.GetAxis(HORIZONTAL);
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis(PITCH);
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis(ROLL);

        playerTransform.Rotate(pitch, yaw, -roll);
    }

    private void Thrust()
    {
        if (Input.GetAxis(FORWARD) > 0) {
            playerTransform.position += playerTransform.forward * movementSpeed * Time.deltaTime * Input.GetAxis(FORWARD);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (Thruster truster in thrusters)
            {
                truster.Activate();
            }
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            foreach (Thruster truster in thrusters)
            {
                truster.Activate(false);
            }
        }
    }
<<<<<<< HEAD
<<<<<<< HEAD

    void LockCursor()
    {
        Debug.Log("game started!!!");
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
    }
=======
>>>>>>> parent of 0f30cc6... Merge branch 'dev' into Change-target-functionality-
=======
>>>>>>> parent of 29b0e97... Merge pull request #5 from SkzKatsushiro/mouse-control-feature
}
