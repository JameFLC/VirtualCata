using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class ControllerButtonDisplayer : MonoBehaviour
{
    
    [SerializeField] private InputActionProperty trackpadAction;
    [SerializeField] private InputActionProperty trackpadToutchedAction;
    [SerializeField] private Transform trackpad;
    [SerializeField] private Transform gizmo;


    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] private InputActionProperty triggerClickAction;
    [SerializeField] private Transform trigger;



    [SerializeField] private InputActionProperty gripAction;
    [SerializeField] private Transform grip;


    [SerializeField] private float duration = 0.1f;
    [SerializeField] private Ease easing = Ease.InOutSine;


    private float _lastTriggerValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        trackpadAction.action.performed += ReadTrackpad;

        trackpadToutchedAction.action.started += ReadTrackpadToutched;
        trackpadToutchedAction.action.canceled += ReadTrackpadToutched;

        triggerAction.action.performed += ReadTrigger;

        triggerClickAction.action.started += ReadTriggerClick;
        triggerClickAction.action.canceled += ReadTriggerClick;

        gripAction.action.started += ReadGrip;
        gripAction.action.canceled += ReadGrip;

        FadeGizmo(0, 0);
    }
    private void ReadTrackpad(InputAction.CallbackContext context)
    {
        Vector2 trackpadValue = trackpadAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
        gizmo.transform.localPosition = new Vector3(trackpadValue.x, 0, trackpadValue.y);

        Debug.Log("Trackpad " + context.interaction);
    }
    private void ReadTrackpadToutched(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            FadeGizmo(1, duration);
        }

        if (context.canceled)
        {
            FadeGizmo(0, duration * 5);
            Debug.Log("Trackpad released");
        }
    }
    private void FadeGizmo(float alpha,float fadeDuration)
    {
        Material mat = gizmo.gameObject.GetComponent<MeshRenderer>().material;
        if (mat != null)
        {
            mat.DOKill(false);
            mat.DOFloat(alpha, "_Alpha", fadeDuration).SetEase(easing);
        }
    }
    private void ReadTrigger(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            const float MAX_ROTATION = -20;
            float triggerValue = triggerAction.action?.ReadValue<float>() ?? 0;
            Debug.Log("Trigger " + triggerValue);
            trigger.localRotation= Quaternion.Euler(triggerValue * (MAX_ROTATION), 0, 0);
            _lastTriggerValue = triggerAction.action?.ReadValue<float>() ?? _lastTriggerValue;
        }
    }
    private void ReadTriggerClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            const float END_ROTATION = -28;
            trigger.DOLocalRotate(new Vector3(END_ROTATION, 0, 0), duration).SetEase(easing);
            
        }
        if (context.canceled)
        {
            trigger.DOKill();
            //trigger.localRotation = Quaternion.Euler(_lastTriggerValue, 0, 0);
        }
        Debug.Log("TriggerClick " + context);
         
    }
    private void ReadGrip(InputAction.CallbackContext context) 
    {
        Debug.Log(context);
        if (context.started)
        {
            const float PRESSED_SCALE = 0.95f;
            grip.DOScaleX(PRESSED_SCALE, duration).SetEase(easing);
        
        }
        if(context.canceled)
        {
            grip.DOScaleX(1f, duration).SetEase(easing);
        }
       
    }

}
