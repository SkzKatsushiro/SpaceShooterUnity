using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("X-wing hit");
    }
}
