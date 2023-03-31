using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Testing : MonoBehaviour
{
    public FrequencyBandAnalyser _FrequencyBandAnalyser;
    public FrequencyBandAnalyser.Bands _Bands = FrequencyBandAnalyser.Bands.SixtyFour;

    //color selector


    public int resolution;

    public List<float> _Frequencys = new List<float>();
    public List<UnityEvent<float>> _Events;


    private void OnValidate()
    {
        _Frequencys.Clear();


        resolution = _Bands == FrequencyBandAnalyser.Bands.Eight ? 8 : 64;

        if (_Events.Count > resolution)
            _Events.RemoveRange(resolution, _Events.Count - resolution);
        for (int i = 0; i < resolution; i++)
        {
            _Frequencys.Add(0);

            if (_Events.Count < resolution)
                _Events.Add(new UnityEvent<float>());
        }
    }

    private void Update()
    {
        if (_Bands == FrequencyBandAnalyser.Bands.Eight)
        {
            for (int i = 0; i < resolution; i++)
            {
                float frequency = _FrequencyBandAnalyser._FreqBands8[i];
                _Frequencys[i] = Mathf.Max(frequency, _Frequencys[i] - Time.deltaTime * _FrequencyBandAnalyser._SmoothDownRate);
            }
        }
        if (_Bands == FrequencyBandAnalyser.Bands.SixtyFour)
        {
            for (int i = 0; i < resolution; i++)
            {
                float frequency = _FrequencyBandAnalyser._FreqBands64[i];
                _Frequencys[i] = Mathf.Max(frequency, _Frequencys[i] - Time.deltaTime * _FrequencyBandAnalyser._SmoothDownRate);
            }
        }
    }



}
