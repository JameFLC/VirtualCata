using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;


    public event Action OnStartEvacuation;
    public event Action OnStartAlarm;
    public event Action OnTogglePathDebug;
    // Singleton Setup
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            //Rest of Awake
        }
        else
        {
            Destroy(this);
        }
    }
    public void StartEvacuation() => OnStartEvacuation?.Invoke();
    public void StartAlarm() => OnStartAlarm?.Invoke();
    public void TogglePathDebug() => OnTogglePathDebug?.Invoke();
}
