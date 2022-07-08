using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class IOTimeRecorder : IODataRecorder
{
    protected float _beginTime = 0;
    protected bool _hasBegun = false;

    private float _lastTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        data = new IOStrings(dataName);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _lastTime + updateDelay)
        {
            _lastTime = Time.time;

            if (!_isEnabled && _hasBegun)
            {
                _hasBegun = false;

                string endingMessage = "Ending : [" + _beginTime.ToString("F" + 2, CultureInfo.InvariantCulture) + "]";
                IODataUnit endingData = new IODataUnit(endingMessage);
                Debug.Log(endingMessage);
                data.AddData(endingData);


                string durationMessage = "Duration : {" + (Time.time - _beginTime).ToString("F" + 1, CultureInfo.InvariantCulture) + "}";
                IODataUnit durationData = new IODataUnit(durationMessage);
                data.AddData(durationData);
                return;
            }

            if (_isEnabled && _hasBegun)
                return;
            if (!_isEnabled && !_hasBegun)
                return;
            
            if (_isEnabled && !_hasBegun)
            {
                _hasBegun = true;
                _beginTime = Time.time;
                string beginingMessage = "Begining : [" + Time.time.ToString("F" + 1, CultureInfo.InvariantCulture) + "]";

                IODataUnit beginingData = new IODataUnit(beginingMessage);
                Debug.Log(beginingMessage);
                data.AddData(beginingData);




                return;
            }
            
        }
    }
}
