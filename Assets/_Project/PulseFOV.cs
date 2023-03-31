using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseFOV : Pulser
{
    public float minFov = 15f;
    public float maxFov = 90f;
    protected override void PulseUpdate()
    {
        float ratio = magnitudeAtRange / localMax;
        float fov = Mathf.Lerp(minFov, maxFov, ratio);
        GetComponent<Camera>().fieldOfView = fov;


    }
}
