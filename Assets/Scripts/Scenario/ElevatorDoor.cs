using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ElevatorDoor : MonoBehaviour
{
    [SerializeField] private ScaleTo[] doors;
    [SerializeField] private float doorDuration = 3;
    [SerializeField] private Ease doorEasing = Ease.InOutSine;
    [SerializeField] private float doorOvershoot = 0;

    private void Start()
    {

    }
    public void OpenElevator()
    {
        ToggleElevator(true);
        Debug.Log("Door Open");
    }
    public void CloseElevator()
    {
        ToggleElevator(false);
    }
    private void ToggleElevator(bool open)
    {
        if (open)
        {
            foreach (ScaleTo door in doors)
            {
                if (door !=null)
                {
                    SetupDoor(door);
                    door.BeginScaleEase();
                }
            }
        }
        else
        {
            foreach (ScaleTo door in doors)
            {
                if (door != null)
                {
                    SetupDoor(door);
                    door.ResetScaleEase();
                }
            }
        }
    }

    private void SetupDoor(ScaleTo door)
    {
        door.duration = doorDuration;
        door.easing = doorEasing;
        door.overshoot = doorOvershoot;
    }
}
