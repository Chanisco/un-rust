using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispencePipes : MonoBehaviour
{
    public List<Transform> PipeExits = new List<Transform>();
    private BitController _bitController;

    private void OnEnable()
    {
        _bitController = BitController.Instance;
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            InstansiateBitObject();
        }
    }

    private void InstansiateBitObject()
    {
        GameObject t = null;
        for (int i = 0; i < _bitController.Bitmins.Count; i++)
        {
            if (_bitController.Bitmins[i].gameObject.activeSelf == false)
            {
                t = _bitController.Bitmins[i].gameObject;
                int r = Random.Range(0, PipeExits.Count);
                t.transform.position = PipeExits[r].position;
                t.gameObject.SetActive(true);
            }
        }
    }
}
