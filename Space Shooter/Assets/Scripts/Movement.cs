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
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= LockCursor;
    }

    void Awake()
    {
        playerTransform = transform;
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }
            Turn();
            Thrust();
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

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
    }
}
