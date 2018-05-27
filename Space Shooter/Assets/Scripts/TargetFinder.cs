using UnityEngine;

public class TargetFinder : MonoBehaviour {

    [SerializeField]
    private Transform targetTransform;

    public Transform TargetTransform
    { 
        get{return targetTransform;}
        set{ targetTransform = value; }
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

    private void FindMainCamera()
    {
        Debug.Log("In find  target");
        GameObject tmp = GameObject.FindGameObjectWithTag("MainCamera");
        Debug.Log(tmp);
        targetTransform = tmp.transform;
    }
}
