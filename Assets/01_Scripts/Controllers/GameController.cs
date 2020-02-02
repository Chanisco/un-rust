using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    private EventController _eventController;
    public LevelHeadHolder lvlheadHolder;
    public int currentLevel = 1;

    private void Start()
    {
        _eventController = EventController.Instance;

    }

    public void StartGame()
    {
        _eventController.GameStartCall();

    }

    public void NextLevel()
    {
        _eventController.GameOverByFinishCall();
        currentLevel++;
        lvlheadHolder.RequestLevelChange(currentLevel - 1);
    }

    public void OnDead()
    {
        _eventController.GameEndCall();
        currentLevel = 1;
        lvlheadHolder.RequestLevelChange(currentLevel - 1);

    }



}
