using UnityEngine;

public class TargetFinder : MonoBehaviour
{

    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private bool shouldLookForOtherTargets = true;

    public Transform TargetTransform
    {
        get { return targetTransform; }
        set { targetTransform = value; }
    }

    private void OnEnable()
    {
        EventManager.onPlayerDeath += FindMainCamera;
    }

    private void OnDisable()
    {
        EventManager.onPlayerDeath -= FindMainCamera;
    }

    public bool FoundTarget()
    {


        if (targetTransform == null)
        {
            GameObject target = GameObject.FindGameObjectWithTag("Player");

            if (target == null)
            {
                return false;
            }

            targetTransform = target.transform;
        }
        return true;
    }

    private void FindMainCamera()
    {
        if (!shouldLookForOtherTargets)
        {
            return;
        }

        Debug.Log("In find  target");
        GameObject tmp = GameObject.FindGameObjectWithTag("MainCamera");
        Debug.Log(tmp);
        targetTransform = tmp.transform;
    }
}
