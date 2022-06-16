using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alert : MonoBehaviour
{
    [SerializeField] string message;
    [SerializeField] UnityEvent OnAlertFinished;


    public Alert endAlert;
    private UnityEvent _subscribedEvent;


    public string GetMessage()
    {
        return message;
    }
    public virtual AlertType GetAlertType()
    {
        return AlertType.Simple;
    }
    public void SubscribeToEndEvent(UnityEvent ev)
    {
        _subscribedEvent = ev;
        _subscribedEvent.AddListener(EndAlert);
    }
    public void EndAlert()
    {
        Debug.Log("Alert Ended");
        if (_subscribedEvent != null)
        {
            _subscribedEvent.RemoveListener(EndAlert);
        }
        OnAlertFinished.Invoke();
    }
}
