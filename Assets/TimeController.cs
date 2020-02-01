using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public int currentTimeInSeconds;
    public EventController _eventController;

    private void Start()
    {
        _eventController = EventController.Instance;
        _eventController.GameStart += StartTime;
    }

    private void StartTime()
    {
        currentTimeInSeconds = 90;
        StartCoroutine("timeRoutine");
    }

    IEnumerator timeRoutine()
    {
        yield return new WaitForSeconds(1);
        currentTimeInSeconds--;
        _eventController.ChangeTimeCall(currentTimeInSeconds);

    }


}
