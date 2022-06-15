using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(HUDAlertDisplayManager))]
public class HUDAlertManager : MonoBehaviour
{

    [SerializeField] Button confirmButton;
    [SerializeField] Button acceptButton;
    [SerializeField] Button denyButton;
    [SerializeField] Button simpleButton;

    private HUDAlertDisplayManager _displayManager;
    private UnityEvent _simpleAlertEnd = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {

        _displayManager = GetComponent<HUDAlertDisplayManager>();
        if (!confirmButton || !acceptButton || !denyButton || !simpleButton)
        {
            Debug.Log("Missing button reference");
            Destroy(this);
        }

    }

    public void ShowNewAlert(Alert alert)
    {
        if (!alert)
        {
            Debug.Log("No Alert to display");
            return;
        }
        RemoveListeners();

        
        switch (alert.GetAlertType())
        {
            case AlertType.Simple:
                SetupAlertSimple(alert);
                break;
            case AlertType.Confirm:
                SetupAlertConfirm((AlertConfirm)alert);
                break;
            case AlertType.Choice:
                SetupAlertChoice((AlertChoice)alert);

                break;
            case AlertType.Button:
                SetupAlertButton((AlertButton)alert);

                break;
        }
        _displayManager.DisplayAlert(alert.GetAlertType(), alert.GetMessage());
    }

    public void HideAlerts()
    {
        _displayManager.HideAlerts();
        RemoveListeners();
    }
    private void SetupAlertSimple(Alert alert)
    {
        alert.SubscribeToEndEvent(_simpleAlertEnd);

        Alert alertEnd = alert.endAlert;

        if (alertEnd)
        {
            _simpleAlertEnd.AddListener(() => ShowNewAlert(alertEnd));
        }
        else
        {
            _simpleAlertEnd.AddListener(_displayManager.HideAlerts);
        }
        if (_displayManager.GetAlertSimpleDefaultDuration() > 0)
        {
            StartCoroutine(WaitToEndSimpleAlert());
        }
    }
    public void EndSimpleAlert()
    {
        _simpleAlertEnd.Invoke();
    }

    private void SetupAlertButton(AlertButton alert)
    {
        alert.SubscribeToEndEvent(simpleButton.onClick);


        Alert alertEnd = alert.endAlert;

        if (alertEnd)
        {
            simpleButton.onClick.AddListener(() => ShowNewAlert(alertEnd));
        }
        else
        {
            simpleButton.onClick.AddListener(_displayManager.HideAlerts);
        }
    }

    private void SetupAlertChoice(AlertChoice alert)
    {


        Alert alertEnd = alert.endAlert;

        if (alertEnd)
        {
            acceptButton.onClick.AddListener(() => ShowNewAlert(alertEnd));
        }
        else
        {
            acceptButton.onClick.AddListener(_displayManager.HideAlerts);
        }

        alert.SubscribeToEndEvent(acceptButton.onClick);


        Alert alertDeny = alert.denyAlert;

        if (alertDeny)
        {
            denyButton.onClick.AddListener(() => ShowNewAlert(alertDeny));
        }
        else
        {
            denyButton.onClick.AddListener(_displayManager.HideAlerts);
        }
        alert.SubscribeToEndEventDeny(denyButton.onClick);
    }

    private void SetupAlertConfirm(AlertConfirm alert)
    {
        alert.SubscribeToEndEvent(confirmButton.onClick);

        Alert alertConfirm = alert.endAlert;

        if (alertConfirm)
        {
            confirmButton.onClick.AddListener(() => ShowNewAlert(alertConfirm));
        }
        else
        {
            confirmButton.onClick.AddListener(_displayManager.HideAlerts);
        }
    }

    private void RemoveListeners()
    {
        confirmButton.onClick.RemoveAllListeners();
        acceptButton.onClick.RemoveAllListeners();
        denyButton.onClick.RemoveAllListeners();
        simpleButton.onClick.RemoveAllListeners();

        _simpleAlertEnd.RemoveAllListeners();
    }
    
    IEnumerator WaitToEndSimpleAlert()
    {
        float waitTime = _displayManager.GetFadeInDuration() + _displayManager.GetAlertSimpleDefaultDuration();
        Debug.Log("WaitToEndSimpleAlert started for " + waitTime + " seconds");

        yield return new WaitForSeconds(waitTime);

        Debug.Log("WaitToEndSimpleAlert waited");
        if (_displayManager.getLastAlert() == AlertType.Simple)
        {
            EndSimpleAlert();
        }
    }
}
