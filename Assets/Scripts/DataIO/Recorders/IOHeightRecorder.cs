using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOHeightRecorder : IODataRecorder
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float baseHeight = 0f;
    private float _lastTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        data = new IOFloats(dataName);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isEnabled)
            return;

        if (Time.time >= _lastTime + updateDelay)
        {
            _lastTime = Time.time;
            IODataTypes currentData = new IODataTypes(targetTransform.position.y- baseHeight);
            data.AddData(currentData);
        }

    }
}
