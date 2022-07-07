using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOHeightRecorder : IODataRecorder
{
    [SerializeField] CharacterController playerController;
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
            if (playerController != null)
            {
            IODataUnit currentData = new IODataUnit(playerController.height);
            data.AddData(currentData);
            }
        }

    }
}
