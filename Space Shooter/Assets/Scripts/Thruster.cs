using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour {

    TrailRenderer trRenderer;
    Light thrusterLight;

    void Awake()
    {
        trRenderer = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent <Light>();
    }

    public void Activate(bool activate = true)
    {
        if (activate)
        {
            trRenderer.enabled = true;
            thrusterLight.enabled = true;
        }
        else
        {
            trRenderer.enabled = false;
            thrusterLight.enabled = false;
        }
    }
}
