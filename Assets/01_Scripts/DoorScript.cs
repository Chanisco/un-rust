using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private int PauseBetweenLevel = 2;
    private EventController _eventController;
    private GameController _gameController;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _eventController = EventController.Instance;
        _eventController.GameStart += DoorOpen;
        _eventController.GameEnd += DoorClose;
        _eventController.GameOverByFinish += DoorCloseForNextLevel;


        _gameController = GameController.Instance;

    }

    public void DoorOpen()
    {
        _animator.SetBool("Open",true);
    }

    public void DoorClose()
    {
        _animator.SetBool("Open",false);
    }

    public void DoorCloseForNextLevel()
    {
        DoorClose();

    }

}
