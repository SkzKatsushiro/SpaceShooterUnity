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

    [SerializeField]
    public float cameraSensitivity = 90;

    private Transform playerTransform;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private bool canMove = false;

    private void OnEnable()
    {
        EventManager.onStartGame += LockCursor;
        EventManager.onPlayerDeath += UnlockCursor;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= LockCursor;
        EventManager.onPlayerDeath -= UnlockCursor;
    }

    void Awake()
    {
        playerTransform = transform;
        LockCursor();
    }

    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 6449a3f... Revert "Fixed unlock cursor on death"
        if (!canMove)
        {
            Debug.Log("In return");
            return;
        }
            Turn();
            Thrust();
<<<<<<< HEAD
=======
        Turn();
        Thrust();
>>>>>>> parent of 0f30cc6... Merge branch 'dev' into Change-target-functionality-
=======
        Turn();
        Thrust();
>>>>>>> parent of 0f30cc6... Merge branch 'dev' into Change-target-functionality-
=======
>>>>>>> parent of 6449a3f... Revert "Fixed unlock cursor on death"
    }

    private void Turn()
    {
        rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        playerTransform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        playerTransform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
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
<<<<<<< HEAD
=======
>>>>>>> parent of 6449a3f... Revert "Fixed unlock cursor on death"

    void LockCursor()
    {
        Debug.Log("game started!!!");
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
    }
<<<<<<< HEAD
=======
>>>>>>> parent of 0f30cc6... Merge branch 'dev' into Change-target-functionality-
=======
>>>>>>> parent of 0f30cc6... Merge branch 'dev' into Change-target-functionality-
=======

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        canMove = false;
    }
>>>>>>> parent of 6449a3f... Revert "Fixed unlock cursor on death"
}
