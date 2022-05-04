using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningStates : MonoBehaviour
{


    private HingeJoint _hingeJoint;
    private JointSpring _defaultSpring;
    private float _limitMax;

    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _defaultSpring = _hingeJoint.spring;
        _limitMax = _hingeJoint.limits.max;

    }
    public void SetDoorOpening(float openingForce)
    {
        JointSpring spring = _defaultSpring;
        spring.spring = openingForce;
        spring.targetPosition = _limitMax;
        _hingeJoint.spring = spring;
    }
    public void SetDoorClosing(float openingForce)
    {
        JointSpring spring = _defaultSpring;
        spring.spring = openingForce;
        _hingeJoint.spring = spring;
    }
    public void SetDoorNeutral()
    {
        _hingeJoint.spring = _defaultSpring;
    }
    
}
