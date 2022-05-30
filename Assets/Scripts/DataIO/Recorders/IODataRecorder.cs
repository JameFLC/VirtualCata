using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IODataRecorder : MonoBehaviour
{
    [SerializeField] protected string dataName = "";
    [SerializeField] protected float updateDelay = 0.1f;
    protected IOData data;
    protected bool _isEnabled = false;
    
    public float getUpdateDelay()
    {
        return updateDelay;
    }
    public IOData getData()
    {
        return data;
    }

    public bool GetEnabled()
    {
        return _isEnabled;
    }
    public void SetEnabled(bool enabled)
    {
        _isEnabled = enabled;
    } 
}
