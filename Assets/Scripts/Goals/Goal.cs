
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    [SerializeField] protected string message = "";


    public UnityEvent OnBegin;
    public UnityEvent OnFinish;


    protected bool _isGoalBegan;
    public void BeginGoal()
    {
        OnBegin.Invoke();
        _isGoalBegan = true;
        BeginCustomGoal();
    }
    protected virtual void BeginCustomGoal()
    {
        return;
    }
    public void FinishGoal()
    {
        OnFinish.Invoke();
        _isGoalBegan = false;
        FinishCustomGoal();
    }
    protected virtual void FinishCustomGoal()
    {
        return;
    }

    public string GetMessage()
    {
        return message;
    }
    public bool getBegan()
    {
        return _isGoalBegan;
    }
}
