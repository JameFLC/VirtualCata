using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertConfirm : Alert
{
    public Alert confirmAlert;
    public override AlertType GetAlertType()
    {
        return AlertType.Confirm;
    }
    
}
