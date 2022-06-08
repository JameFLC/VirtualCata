using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPositionAtBegining : MonoBehaviour
{
    const float WAIT_TIME = 0.1f;
    // Start is called before the first frame update
    void Awake()
    {
        LogPosition("On Awake");
    }
    private void Start()
    {
        LogPosition("On Start");
        //StartCoroutine(WaitToLogPosition(WAIT_TIME));
    }
    private void Update()
    {
        LogPosition(("At " + Time.time));
    }



    IEnumerator WaitToLogPosition(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    void LogPosition(string timeText)
    {
        Debug.Log(gameObject.name + " is at position : " + transform.position + " or local position : " + transform.localPosition + " " + timeText);
    }

}
