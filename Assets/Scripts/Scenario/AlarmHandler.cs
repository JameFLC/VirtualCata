using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AlarmHandler : MonoBehaviour
{

    public UnityEvent OnAlarmStarted;
    private void Awake()
    {
        EventManager.instance.OnStartAlarm += InvokeEvent;
    }
    private void OnDestroy()
    {
        EventManager.instance.OnStartAlarm -= InvokeEvent;
    }
    private void InvokeEvent()
    {
        
        OnAlarmStarted.Invoke();
        Debug.Log("On Alarm Started Handeled");
    }
    
}
