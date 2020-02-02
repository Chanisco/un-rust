using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHead : MonoBehaviour
{
    public List<MachineHead> MachineHeads = new List<MachineHead>();

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
        _eventController.AddScore -= CheckMachineBtns;

    }

    private void CheckMachineBtns(int score)
    {
        int i = 0;
        bool gameFinished = true;
        while (i < MachineHeads.Count)
        {
            if (MachineHeads[i]._fixed == false)
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
