using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private EventController _eventController;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _eventController = EventController.Instance;
        _eventController.GameStart += DoorOpen;
    }

    public void DoorOpen()
    {
        _animator.SetTrigger("Activate");
    }

    public void DoorClose()
    {
        _animator.SetTrigger("Activate");
    }


}
