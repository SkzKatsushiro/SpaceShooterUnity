using UnityEngine;

[DisallowMultipleComponent]
public class FollowPayer : MonoBehaviour {

    [SerializeField]
    private Vector3 offsetDistance = new Vector3(0f, 2f, -10f);

    [SerializeField]
    private float distanceDamp = 1.5f;

    private Vector3 velovity = Vector3.one; 

    private Transform cameraTransform;

    [SerializeField]
    private TargetFinder targetFinder;

    private void Awake()
    {
        cameraTransform = transform;
        targetFinder = gameObject.GetComponent<TargetFinder>();
    }

    private void LateUpdate()
    {
        if (targetFinder.FoundTarget())
        {
                SmoothFollow();
        }
}

    private void SmoothFollow()
    {
        Transform tranformPlayer = targetFinder.TargetTransform;
        Vector3 toPos = tranformPlayer.position + (tranformPlayer.rotation * offsetDistance);
        Vector3 curPos = Vector3.SmoothDamp(cameraTransform.position, toPos, ref velovity, distanceDamp);
        cameraTransform.position = curPos;

        cameraTransform.LookAt(tranformPlayer, tranformPlayer.up);
    }
}
