using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ActionLauncher : MonoBehaviour
{
    [SerializeField] private InputActionProperty actionReference;

    public UnityEvent OnActionStarted;
    private void Awake()
    {
        actionReference.action.started += TriggerAction;
    }
    private void OnDestroy()
    {
        actionReference.action.started -= TriggerAction;
    }
    private void TriggerAction(InputAction.CallbackContext context)
    {
        OnActionStarted.Invoke();
    }
}
