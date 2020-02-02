using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour
{
    public MeshRenderer buttonmeshRenderer;
    public BitController.COLORS buttonColor;
    public ParticleSystem correctEffect;
    public BUTTONSIZE buttonSize;
    public bool hit;

    private EventController _eventController;
    private ScoreController _scoreController;



    void Start()
    {
        _eventController = EventController.Instance;
        _scoreController = ScoreController.Instance;
        _eventController.GameStart += PreparePosition;
        _eventController.GameEnd += ResetButton;
        _eventController.GameOverByFinish += ResetButton;
        PreparePosition();
    }

    void PreparePosition()
    {
        buttonmeshRenderer = GetComponent<MeshRenderer>();
        ChangeColor();
    }

    public void ChangeColor()
    {
        buttonColor = (BitController.COLORS)Random.Range(0, (int)System.Enum.GetValues(typeof(BitController.COLORS)).Length - 2);
        buttonmeshRenderer.material.color = BitController.HueColourValue(buttonColor);
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bitmin")
        {
            hit = true;
            BitminBehaviour bitminScript = other.gameObject.GetComponent<BitminBehaviour>();
            if (bitminScript.bitminColor == buttonColor)
            {
                _scoreController.AddPointsToScore(_scoreController.PointsForRightCombo);
                buttonmeshRenderer.material.color = BitController.HueColourValue(BitController.COLORS.CORRECT);
            }
            else
            {
                _scoreController.AddPointsToScore(_scoreController.PointsForWrongCombo);
                buttonmeshRenderer.material.color = BitController.HueColourValue(BitController.COLORS.NOT_CORRECT);

            }
            bitminScript.RemoveBit();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void ResetButton()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        hit = false;
    }
}
public enum BUTTONSIZE {
    BIG,
    MEDIUM,
    SMALL,
    TINY
};