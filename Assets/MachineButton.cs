using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour
{
    public Collider buttonCollider;
    public Material buttonMaterial;
    public Color buttonColor;
    public enum buttonSize{big, medium, small, tiny };
    // Start is called before the first frame update
    void Start()
    {
        buttonMaterial.color = buttonColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
