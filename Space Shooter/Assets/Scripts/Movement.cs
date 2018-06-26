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
    Transform playerTransform;

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
        Turn();
        Thrust();
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
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
    }
    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        canMove = false;
    }
}
