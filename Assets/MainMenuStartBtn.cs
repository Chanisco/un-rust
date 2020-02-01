using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStartBtn : MonoBehaviour
{
    private EventController _eventController;
    
    private void OnEnable()
    {
        _eventController = EventController.Instance;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bitmin")
        {
            InitiateStartGame();
        }
    }

    private void InitiateStartGame()
    {

        //TODO Aaron wilt een animatie maken voor de btn
        _eventController.GameStartCall();
        gameObject.SetActive(false);
    }
}
