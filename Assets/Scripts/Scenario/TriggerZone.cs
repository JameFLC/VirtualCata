using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerZone : MonoBehaviour
{
    [TagSelector] public string[] triggerTags;

    public UnityEvent OnZoneEnter;
    public UnityEvent OnZoneExit;


    private bool _isEnabled = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!_isEnabled)
            return;

            foreach (var triggerTag in triggerTags)
        {
            if (other.gameObject.CompareTag(triggerTag))
            {
                Debug.Log("Object of tag " + triggerTags + " entered zone");
                OnZoneEnter.Invoke();
                TriggerEntered();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!_isEnabled)
            return;
        foreach (var triggerTag in triggerTags)
        {
            if (other.gameObject.CompareTag(triggerTag))
            {
                Debug.Log("Object of tag " + triggerTags + " exited zone");
                OnZoneExit.Invoke();
                TriggerExited();
            }
        }
    }

    protected virtual void TriggerEntered() { }
    protected virtual void TriggerExited() { }

    public void TriggerEnable() 
    {
        _isEnabled = true;
    }
    public void TriggerDisable() 
    {
        _isEnabled = false;
    }
}

