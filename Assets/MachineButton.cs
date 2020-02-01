using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour
{
    public MeshRenderer buttonmeshRenderer;
    public BitController.COLORS buttonColor;
    public ParticleSystem correctEffect;
    public BUTTONSIZE buttonSize;


    void Start()
    {
        buttonmeshRenderer = GetComponent<MeshRenderer>();
        buttonmeshRenderer.material.color = BitController.HueColourValue(buttonColor);
    }
    
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("I colleide");
        if (other.gameObject.tag == "Bitmin")
        {
            Debug.Log("I is bitmin");

            BitminBehaviour bitminScript = other.gameObject.GetComponent<BitminBehaviour>();
            if(bitminScript.bitminColor == buttonColor)
            {
                Debug.Log("HIT");
                buttonmeshRenderer.material.color = new Color(0, 0, 0);
            }
            else
            {
                Debug.Log("WrongHit");
            }
            bitminScript.RemoveBit();
        }
    }
}

public enum BUTTONSIZE {
    BIG,
    MEDIUM,
    SMALL,
    TINY
};