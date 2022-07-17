using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAlertDisplayer : MonoBehaviour
{
    [SerializeField] private HUDAlertManager alertManager;
    [SerializeField] private Alert endingAlert;
    // Start is called before the first frame update
    public void DisplayEndingAlert()
    {
        alertManager.ShowNewAlert(endingAlert);
    }
}
