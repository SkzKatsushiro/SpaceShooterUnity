using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieFighter : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TieFighter hit");
    }
}
