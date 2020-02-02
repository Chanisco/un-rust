using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHead : MonoBehaviour
{
    public List<MachineButton> MachineBtns = new List<MachineButton>();

    private EventController _eventController;
    private GameController _gameController;

    private void OnEnable()
    {
        _eventController = EventController.Instance;
        _gameController = GameController.Instance;
        _eventController.AddScore += CheckMachineBtns;
    }

    private void OnDisable()
    {
        _eventController = EventController.Instance;

    }

    private void CheckMachineBtns(int score)
    {
        int i = 0;
        bool gameFinished = true;
        while (i < MachineBtns.Count)
        {
            if (MachineBtns[i].hit == false)
            {
                gameFinished = false;
                break;
            }
            i++;
        }

        if (gameFinished == true)
        {
            _gameController.NextLevel();

        }
    }



}
