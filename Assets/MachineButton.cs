using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour
{
    public MeshRenderer buttonmeshRenderer;
    public BitController.COLORS buttonColor;
    public ParticleSystem correctEffect;
    public BUTTONSIZE buttonSize;

    private EventController _eventController;
    private ScoreController _scoreController;



    void Start()
    {
        _eventController = EventController.Instance;
        _scoreController = ScoreController.Instance;
        _eventController.GameStart += PreparePosition;
        _eventController.GameEnd += ResetButton;
    }

    void PreparePosition()
    {
        buttonmeshRenderer = GetComponent<MeshRenderer>();
        buttonmeshRenderer.material.color = BitController.HueColourValue(buttonColor);
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bitmin")
        {

            BitminBehaviour bitminScript = other.gameObject.GetComponent<BitminBehaviour>();
            if(bitminScript.bitminColor == buttonColor)
            {
                _scoreController.AddPointsToScore(_scoreController.PointsForRightCombo);
                buttonmeshRenderer.material.color = new Color(0, 0, 0);
            }
            else
            {
                _scoreController.AddPointsToScore(_scoreController.PointsForWrongCombo);
            }
            bitminScript.RemoveBit();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void ResetButton()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

public enum BUTTONSIZE {
    BIG,
    MEDIUM,
    SMALL,
    TINY
};