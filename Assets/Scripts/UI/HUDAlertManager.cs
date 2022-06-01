using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum Alerts
{
    Simple,
    Confirm,
    Choice,
    Button
}

public class HUDAlertManager : MonoBehaviour
{
    [SerializeField] RectTransform alertSimple;
    [SerializeField] RectTransform alertConfirm;
    [SerializeField] RectTransform alertChoice;
    [SerializeField] RectTransform alertButton;

    [SerializeField] float alertSimpleDuration = 5;

    private bool _isAlertActive = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!alertSimple || !alertConfirm || !alertChoice || !alertButton)
        {
            Debug.LogError("Missing Alrt game objects");
            gameObject.SetActive(false);
            return;
        }
        HideAlerts();
    }

    public void DisplayAlert(Alerts alerts, string newText)
    {
        HideAlerts();

        switch (alerts)
        {
            case Alerts.Simple:
                UpdateText(alertSimple, newText);
                alertSimple.gameObject.SetActive(true);
                StartCoroutine(SimpleAlertWait(alertSimpleDuration));
                break;
            case Alerts.Confirm:
                UpdateText(alertConfirm, newText);
                alertConfirm.gameObject.SetActive(true);
                break;
            case Alerts.Choice:
                UpdateText(alertChoice, newText);
                alertChoice.gameObject.SetActive(true);
                break;
            case Alerts.Button:
                UpdateText(alertButton, newText);
                alertButton.gameObject.SetActive(true);
                break;
        }
        SetAlertEnabled(true);
    }
    private void HideAlerts()
    {
        alertSimple.gameObject.SetActive(false);
        alertConfirm.gameObject.SetActive(false);
        alertChoice.gameObject.SetActive(false);
        alertButton.gameObject.SetActive(false);
        SetAlertEnabled(false);
    }
    public void ButtonPressed()
    {
        StartCoroutine(HideDelayWithDelay());
    }
    public void DisplaySimpleAlert(string newText)
    {
        DisplayAlert(Alerts.Simple, newText);
    }

    public void DisplayConfirmAlert(string newText)
    {
        DisplayAlert(Alerts.Confirm, newText);
    }
    public void DisplayChoiceAlert(string newText)
    {
        DisplayAlert(Alerts.Choice, newText);
    }
    public void DisplayButtonAlert(string newText)
    {
        DisplayAlert(Alerts.Button, newText);
    }
    public float GetAlertSimpleDuration()
    {
        return alertSimpleDuration;
    }
    public void SetAlertSimpleDuration(float duration)
    {
        alertSimpleDuration = duration;
    }
    
    private void SetAlertEnabled(bool enabled)
    {
        _isAlertActive = enabled;
    }
    

    private void UpdateText(RectTransform alert, string newText)
    {
        Transform alertChild = alert.gameObject.transform.GetChild(0);

        TextMeshProUGUI TMPtext = null;
        // Check recursively the first child of the object to find the text;
        int maxRecurtion = 3;
        for (int i = 0; i < maxRecurtion; i++)
        {

            if (alertChild)
                TMPtext = alertChild.GetComponent<TextMeshProUGUI>();
            if (TMPtext)
                break;
            if (alertChild)
                alertChild = alertChild.gameObject.transform.GetChild(0);


        }
        if (!TMPtext)
        {
            Debug.LogWarning("No Text Found");
            return;
        }
        TMPtext.text = newText;

    }
    IEnumerator SimpleAlertWait(float duration)
    {
        yield return new WaitForSeconds(duration);
        SetAlertEnabled(false);
    }
    IEnumerator HideDelayWithDelay()
    {
        yield return new WaitForEndOfFrame();
        alertSimple.gameObject.SetActive(false);
        alertConfirm.gameObject.SetActive(false);
        alertChoice.gameObject.SetActive(false);
        alertButton.gameObject.SetActive(false);
        SetAlertEnabled(false);
    }
}
