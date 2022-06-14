
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CharacterSpeedChanger : MonoBehaviour
{
    [SerializeField] ActionBasedContinuousMoveProvider moveProvider;
    // Start is called before the first frame update


    public void SetCharachterSpeed(float newSpeed)
    {
        if (moveProvider)
        {
            moveProvider.moveSpeed = newSpeed;
        }

    }
}
