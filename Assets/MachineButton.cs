using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour
{
    public GameObject buttonPart;
    public Collider buttonCollider;
    public MeshRenderer buttonMaterial;
    public BitController.COLORS buttonColor;
    public ParticleSystem correctEffect;
    public enum ButtonSize{big, medium, small, tiny };
    public ButtonSize buttonSize;


    // Start is called before the first frame update
    void Start()
    {
        buttonMaterial.material.color = BitController.HueColourValue(buttonColor);
    }
    
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("I AM COLEDING");
        if (other.gameObject.CompareTag("Bitmin"))
        {
            Debug.Log("HIT");
            BitminBehaviour bitminScript = other.gameObject.GetComponent<BitminBehaviour>();
        }
        else
        {
            Debug.Log("NO HIT");
        }
    }
}
