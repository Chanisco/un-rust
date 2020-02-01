using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStartBtn : MonoBehaviour
{
    private EventController _eventController;
    public Color offColor;
    public Color onColor;
    public Canvas startCanvas;
    private MeshRenderer meshRenderer;


    private void OnEnable()
    {
        startCanvas.enabled = true;
        meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.material.color = offColor;
        _eventController = EventController.Instance;
        _eventController.GameEnd += ResetButton;
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
        gameObject.GetComponent<BoxCollider>().enabled = false;
        meshRenderer.material.color = onColor;
        startCanvas.enabled = false;

    }

    private void ResetButton()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;

    }
}
