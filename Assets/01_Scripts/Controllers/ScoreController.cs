using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : Singleton<ScoreController>
{
    public int Score = 0;
    private EventController _eventController;
    public int PointsForRightCombo = 200;
    public int PointsForWrongCombo = 100;
    private void OnEnable()
    {
        _eventController = EventController.Instance;
        _eventController.GameStart += init;

    }

    private void init()
    {
        Score = 0;
    }
    public void AddPointsToScore(int t)
    {
        Score += t;
        _eventController.AddScoreCall(t);
    }


}
