using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Tayx.Graphy;

public class GraphyToggler : MonoBehaviour
{
    [SerializeField] private InputActionProperty toggleReference;

    private void Awake()
    {
        toggleReference.action.started += ToggleGraphy;
    }
    private void OnDestroy()
    {
        toggleReference.action.started -= ToggleGraphy;
    }
    private void ToggleGraphy(InputAction.CallbackContext context)
    {
        GraphyManager.Instance.ToggleActive();
    }
    
}
