using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTimer : MonoBehaviour
{
    [SerializeField] protected bool startTimerOnStartup = false;
    [SerializeField] protected float timerLengh = 10;

    public UnityEvent OnTimerFinished;


    private bool _isTmerStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (startTimerOnStartup)
        {
            StartTimer();
        }
    }
    public void StartTimer()
    {
        if (!_isTmerStarted)
        {
            StartCoroutine(BeginTimer());
        }
    }
    private IEnumerator BeginTimer()
    {
        yield return new WaitForSeconds(timerLengh);
        OnTimerFinished.Invoke();
    }
}
