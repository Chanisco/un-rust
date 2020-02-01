using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehaviour : MonoBehaviour
{
    public void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bitmin")
        {
            
        }
    }

}
