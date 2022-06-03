using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertButton : Alert
{
    public Alert buttonAlert;
    public override AlertType GetAlertType()
    {
        return AlertType.Button;
    }
}
