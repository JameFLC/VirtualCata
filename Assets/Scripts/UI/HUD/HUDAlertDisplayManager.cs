using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class HUDAlertDisplayManager : MonoBehaviour
{
    [SerializeField] RectTransform alertSimple;
    [SerializeField] RectTransform alertConfirm;
    [SerializeField] RectTransform alertChoice;
    [SerializeField] RectTransform alertButton;


    [SerializeField] float fadeInDuration = 0.75f;
    [SerializeField] float fadeOutDuration = 0.25f;
    [SerializeField] Ease fadeEasing = Ease.InOutSine;

    [SerializeField] float simpleAlertDuration = 5;


    private bool _isFading = false;
    private CanvasGroup _alertsGroup = null;
    private Alerts lastAlert;
    private const float timeBuffer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _alertsGroup = GetComponent<CanvasGroup>();
        if (!alertSimple || !alertConfirm || !alertChoice || !alertButton || !_alertsGroup)
        {
            Debug.LogError("Missing HUD game objects");
            gameObject.SetActive(false);
            return;
        }

        ToogleHudInteraction(false);
        ToggleHudVisibility(false);

    }

    public void DisplayAlert(Alerts alert, string newText)
    {
        if (_isFading)
            return;
        HideAlerts();

        StartCoroutine(WaitToShowAlert(alert, newText));

    }
    public void HideAlerts()
    {
        if (_isFading)
            return;
        Debug.Log("Fading Out HUD");
        _isFading = true;

        ToogleHudInteraction(false);


        ToogleAlertInteraction((RectTransform)alertSimple, (bool)false);
        ToogleAlertInteraction((RectTransform)alertConfirm, (bool)false);
        ToogleAlertInteraction((RectTransform)alertChoice, (bool)false);
        ToogleAlertInteraction((RectTransform)alertButton, (bool)false);

        _alertsGroup.DOFade(0, fadeOutDuration)
            .SetEase(fadeEasing)
            .OnComplete((TweenCallback)(() =>
            {
                ToogleAlertVisibility((RectTransform)alertSimple, (bool)false);
                ToogleAlertVisibility((RectTransform)alertConfirm, (bool)false);
                ToogleAlertVisibility((RectTransform)alertChoice, (bool)false);
                ToogleAlertVisibility((RectTransform)alertButton, (bool)false);
                _isFading = false;
            }));
    }
    private void ShowAlert(RectTransform alert)
    {
        if (_isFading)
            return;
        _isFading = true;

        ToogleAlertInteraction(alert, true);
        ToogleAlertVisibility(alert, true);

        ToogleHudInteraction(true);


        _alertsGroup.DOFade(1, fadeInDuration)
            .SetEase(fadeEasing).OnComplete(() => { _isFading = false; });

    }
    private void ToogleAlertInteraction(RectTransform alert, bool interact)
    {
        CanvasGroup group = alert.gameObject.GetComponent<CanvasGroup>();
        if (!group)
            return;
        group.interactable = interact;
        group.blocksRaycasts = interact;
    }
    private void ToogleHudInteraction(bool interact)
    {
        _alertsGroup.interactable = interact;
        _alertsGroup.blocksRaycasts = interact;
    }
    private void ToggleHudVisibility(bool visibility)
    {
        _alertsGroup.alpha = visibility ? 1 : 0;
    }
    private void ToogleAlertVisibility(RectTransform alert, bool visibility)
    {

        CanvasGroup group = alert.gameObject.GetComponent<CanvasGroup>();
        if (!group)
            return;
        group.alpha = visibility ? 1 : 0;

        Debug.Log("Set " + alert + " alpha to " + group.alpha);
    }
    public void DisplaySimpleAlert(string newText)
    {
        DisplayAlert(Alerts.Simple, newText);
    }
    public void DisplaySimpleAlertNoFadeOut(string newText)
    {
        if (_isFading)
            return;
        HideAlerts();
        StartCoroutine(WaitToShowSimpleAlertNoFade(newText));
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
        ShowAlert(alertSimple);
    }

    public float GetAlertSimpleDefaultDuration()
    {
        return simpleAlertDuration;
    }
    public void SetAlertSimpleDefaultDuration(float duration)
    {
        simpleAlertDuration = duration;
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
    IEnumerator WaitToShowAlert(Alerts alert, string newText)
    {
        lastAlert = alert;
        
        yield return new WaitForSeconds(fadeOutDuration + timeBuffer);
        Debug.Log("Fading In HUD");
        switch (alert)
        {
            case Alerts.Simple:
                UpdateText(alertSimple, newText);
                ShowAlert(alertSimple);
                StartCoroutine(WaitToHideSimpleAlert());
                break;
            case Alerts.Confirm:
                UpdateText(alertConfirm, newText);
                ShowAlert(alertConfirm);
                break;
            case Alerts.Choice:
                UpdateText(alertChoice, newText);
                ShowAlert(alertChoice);
                break;
            case Alerts.Button:
                UpdateText(alertButton, newText);
                ShowAlert(alertButton);
                break;
        }
    }
    IEnumerator WaitToHideSimpleAlert()
    {
        yield return new WaitForSeconds(fadeInDuration + simpleAlertDuration);
        if (lastAlert == Alerts.Simple)
        {
            HideAlerts();
        }

    }
    IEnumerator WaitToShowSimpleAlertNoFade(string newText)
    {
        yield return new WaitForSeconds(fadeOutDuration + timeBuffer);
        UpdateText(alertSimple, newText);
        ShowAlert(alertSimple);

    }
}
