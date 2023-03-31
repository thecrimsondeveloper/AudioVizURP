using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePulser : Pulser
{

    [SerializeField] ParticleSystem _ParticleSystem;

    protected override void PulseUpdate()
    {
        float ratio = magnitudeAtRange / localMax;
        float hueBasedOnMagnitude = Mathf.Lerp(0, 0.1f, ratio);
        Color color = Color.HSVToRGB(hueBasedOnMagnitude, 1, 1);

        //set the emission color
        var main = _ParticleSystem.main;
        main.startColor = color;
        //set the emission intensity
        var emission = _ParticleSystem.emission;
        emission.rateOverTime = magnitudeAtRange * 500;

        //change the movement speed
        var velocity = _ParticleSystem.velocityOverLifetime;
        velocity.speedModifier = magnitudeAtRange * 10;

    }

}
