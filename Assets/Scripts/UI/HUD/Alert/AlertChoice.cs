using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlertChoice : Alert
{
    [SerializeField] private UnityEvent OnAlertDenied;
    public Alert denyAlert;

    private UnityEvent _subscribedEventDenied;
    public override AlertType GetAlertType()
    {
        return AlertType.Choice;
    }
    public void SubscribeToEndEventDeny(UnityEvent ev)
    {
        _subscribedEventDenied = ev;
        _subscribedEventDenied.AddListener(EndAlertDenied);
    }
    public void EndAlertDenied()
    {
        Debug.Log("Alert Denied");
        if (_subscribedEventDenied != null)
        {
            _subscribedEventDenied.RemoveListener(EndAlertDenied);
        }
        OnAlertDenied.Invoke();
    }
}
