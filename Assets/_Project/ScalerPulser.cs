using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerPulser : Pulser
{

    Vector3 startScale = Vector3.one;
    private void Start()
    {
        startScale = transform.localScale;

        //enable emission
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    protected override void PulseUpdate()
    {
        float ratio = magnitudeAtRange / localMax;
        float hueBasedOnMagnitude = Mathf.Lerp(0, 0.1f, ratio);
        Color color = Color.HSVToRGB(hueBasedOnMagnitude, 1, 1);
        GetComponent<Renderer>().material.color = color;

        //set the emission color
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        //set the emission intensity
        GetComponent<Renderer>().material.SetFloat("_EmissionIntensity", magnitudeAtRange * 2);

        transform.localScale = startScale + Vector3.up * magnitudeAtRange;
    }
}
