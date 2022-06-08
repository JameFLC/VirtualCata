using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HUDAlertDisplayManager))]
public class HUDAlertManager : MonoBehaviour
{

    [SerializeField] Button confirmButton;
    [SerializeField] Button acceptButton;
    [SerializeField] Button denyButton;
    [SerializeField] Button simpleButton;

    private HUDAlertDisplayManager _displayManager;
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
        RemoveButtonsListeners();


        switch (alert.GetAlertType())
        {
            case AlertType.Simple:
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
        RemoveButtonsListeners();
    }
    private void SetupAlertButton(AlertButton alert)
    {
        alert.SubscribeToEndEvent(simpleButton.onClick);


        Alert alertButton = alert.buttonAlert;

        if (alertButton)
        {
            simpleButton.onClick.AddListener(() => ShowNewAlert(alertButton));
        }
        else
        {
            simpleButton.onClick.AddListener(_displayManager.HideAlerts);
        }
    }

    private void SetupAlertChoice(AlertChoice alert)
    {
        

        Alert alertAccept = alert.acceptAlert;

        if (alertAccept)
        {
            acceptButton.onClick.AddListener(() => ShowNewAlert(alertAccept));
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

        Alert alertConfirm = alert.confirmAlert;

        if (alertConfirm)
        {
            confirmButton.onClick.AddListener(() => ShowNewAlert(alertConfirm));
        }
        else
        {
            confirmButton.onClick.AddListener(_displayManager.HideAlerts);
        }
    }

    private void RemoveButtonsListeners()
    {
        confirmButton.onClick.RemoveAllListeners();
        acceptButton.onClick.RemoveAllListeners();
        denyButton.onClick.RemoveAllListeners();
        simpleButton.onClick.RemoveAllListeners();
    }

}
