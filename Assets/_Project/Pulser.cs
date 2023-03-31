using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulser : MonoBehaviour
{
    [SerializeField] PulseSong _PulseSong;



    [SerializeField, Range(0, 1)] protected float range = 0.5f;

    [SerializeField] protected int indexAtRange = 0;
    [SerializeField] protected float magnitudeAtRange = 0;
    [SerializeField, Range(0.1f, 100)] protected float multiplier = 1;

    [SerializeField] protected float localMin = Mathf.Infinity;
    [SerializeField] protected float localMax = 0;

    private void OnValidate()
    {
        SetData();
    }


    private void Update()
    {
        SetData();

        if (magnitudeAtRange > localMax)
        {
            localMax = magnitudeAtRange;
        }
        if (magnitudeAtRange < localMin)
        {
            localMin = magnitudeAtRange;
        }
        //lerp the local min and max toward each other
        localMin = Mathf.Lerp(localMin, localMax, 0.1f * Time.deltaTime);
        localMax = Mathf.Lerp(localMax, localMin, 0.1f * Time.deltaTime);

        PulseUpdate();


    }

    protected virtual void PulseUpdate()
    {

    }

    void SetData()
    {
        int max = _PulseSong._Frequencys.Count - 1;
        int min = 0;

        indexAtRange = Mathf.RoundToInt(Mathf.Lerp(min, max, range));
        magnitudeAtRange = _PulseSong._Frequencys[indexAtRange] * multiplier;
    }
}
