using System;
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
>>>>>>> Change-target-functionality-
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

    void LockCursor()
    {
        Debug.Log("game started!!!");
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
    }
=======
>>>>>>> Change-target-functionality-
}
