using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IORotationRecorder : IODataRecorder
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

        if (Time.time >= _lastTime + updateDelay)
        {
            _lastTime = Time.time;

            IODataUnit currentData = new IODataUnit(targetTransform.rotation.eulerAngles);

            data.AddData(currentData);
        }

    }
}
