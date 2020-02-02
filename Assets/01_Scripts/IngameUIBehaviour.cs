using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngameUIBehaviour : MonoBehaviour
{
    private EventController _eventController;
    private ScoreController _scoreController;

    public TMP_Text SecondsUI;
    public TMP_Text ScoreUI;

    private void Start()
    {
        _eventController = EventController.Instance;
        _scoreController = ScoreController.Instance;
        _eventController.ChangeTime += Changetime;
        _eventController.AddScore += ChangeScore;
        
    }

    private void Changetime(int sec)
    {
        SecondsUI.text = sec + " sec.";
    }

    private void ChangeScore(int score)
    {
        ScoreUI.text = _scoreController.Score + " pt.";
    }

}
