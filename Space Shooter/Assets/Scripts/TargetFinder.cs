using UnityEngine;

public class TargetFinder : MonoBehaviour {

    [SerializeField]
    private Transform targetTransform;

    public Transform TargetTransform
    { 
        get{return targetTransform;}
        set{ targetTransform = value; }
    }

    public bool FoundTarget()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");

        if (target == null)
        {
            return false;
        }
        else
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            return true;
        }
    }
}
