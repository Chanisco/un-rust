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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bitmin"))
        {
            BitminBehaviour bitminScript = other.gameObject.GetComponent<BitminBehaviour>();
        }
    }
}
