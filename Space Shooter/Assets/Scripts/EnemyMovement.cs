using UnityEngine;

[DisallowMultipleComponent]
public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float rotationalDamp = 0.5f;

    [SerializeField]
    private float movementSpeed = 50f;

    [SerializeField]
    private Thruster[] thrusters;

    private Transform shipTransform;

    private void Awake()
    {
        shipTransform = transform;

        foreach (Thruster truster in thrusters)
        {
            truster.Activate();
        }
    }

    private void Update()
    {
        //Turn();
        Move();
    }

    private void Turn()
    {
        Vector3 position = target.position - shipTransform.position;
        Quaternion rotation = Quaternion.LookRotation(position);
        shipTransform.rotation = Quaternion.Slerp(shipTransform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    private void Move()
    {
        shipTransform.position += shipTransform.forward * Time.deltaTime * movementSpeed;
    }
}
