using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOPositionRecorder : IODataRecorder
{
    [SerializeField] Transform targetTransform;

    private float _lastTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        data = new IOVectors3(dataName);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isEnabled)
            return;

        if (Time.time >= _lastTime + updateDelay) // Use invoke repeating if performance is an issue
            {
                _lastTime = Time.time;
                IODataTypes currentData = new IODataTypes(targetTransform.position);

                data.AddData(currentData);
            }
        
    }
}
