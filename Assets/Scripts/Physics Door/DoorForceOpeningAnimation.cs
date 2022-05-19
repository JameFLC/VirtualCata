using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorForceOpeningAnimation : DoorOpeningAnimation
{
        override public void OpenDoor()
    {
        _doorOpeningStates.SetDoorOpening(Force);
    }
}
