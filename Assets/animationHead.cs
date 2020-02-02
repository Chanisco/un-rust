using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHead : MonoBehaviour
{
    // Start is called before the first frame update
public void doneDancing()
    {
        this.GetComponentInParent<BitminBehaviour>().startWalking();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
