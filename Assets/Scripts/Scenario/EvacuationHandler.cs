using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EvacuationHandler : MonoBehaviour
{

    public UnityEvent OnEvacuationStarted;
    private void Awake()
    {
        EventManager.instance.OnStartEvacuation += InvokeEvent;
    }
    private void OnDestroy()
    {
        EventManager.instance.OnStartEvacuation -= InvokeEvent;
    }
    private void InvokeEvent()
    {
        OnEvacuationStarted.Invoke();
    }
    
}
