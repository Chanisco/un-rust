using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : Singleton<ScoreController>
{
    public int Score = 0;
    private EventController _eventController;

    private void OnEnable()
    {
        _eventController = EventController.Instance;
        _eventController.AddScore += AddPointsToScore;

    }

    private void AddPointsToScore(int t)
    {

    }


}
