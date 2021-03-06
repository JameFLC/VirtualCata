using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Tayx.Graphy;

public class DebugToggler : MonoBehaviour
{
    [SerializeField] private InputActionProperty toggleReference;
    [SerializeField] private ProfileTextDisplayer profileTextDisplayer;
    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        
        toggleReference.action.started += ToggleGraphy;
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.interactable = false;
        _canvasGroup.alpha = 0f;
    }
    private void OnDestroy()
    {
        toggleReference.action.started -= ToggleGraphy;

    }
    private void ToggleGraphy(InputAction.CallbackContext context)
    {
        if (Debug.isDebugBuild)
        {
            GraphyManager.Instance.ToggleActive();

            _canvasGroup.interactable = !_canvasGroup.interactable;
            _canvasGroup.alpha = Mathf.Abs(_canvasGroup.alpha - 1);
            if (profileTextDisplayer != null && Mathf.Abs(_canvasGroup.alpha - 1) == 1)
            {
                profileTextDisplayer.Init();
            }
        }
        else
        {
            _canvasGroup.interactable = false;
            _canvasGroup.alpha = 0;
        }
        

    }
}
