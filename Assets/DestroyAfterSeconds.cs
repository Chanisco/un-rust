using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float timeInSeconds = 0.5f;
    private void OnEnable()
    {
        Destroy(gameObject, timeInSeconds);
    }
    
}
