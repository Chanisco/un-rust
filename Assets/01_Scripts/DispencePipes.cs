using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DispencePipes : MonoBehaviour
{
    public List<Transform> PipeExits = new List<Transform>();
    private BitController _bitController;
    private EventController _eventController;

    private void OnEnable()
    {
        _bitController = BitController.Instance;
        _eventController = EventController.Instance;
        _eventController.NewBitNeeded += InstansiateBitObject;

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
               /* t.GetComponent<Rigidbody>().isKinematic = true;
                t.GetComponent<Rigidbody>().detectCollisions = false;
                t.GetComponent<Rigidbody>().freezeRotation = true;*/

                t.transform.position = PipeExits[r].position;
                t.transform.rotation = PipeExits[r].rotation;
                t.gameObject.SetActive(true);

//t.gameObject.GetComponent<BitminBehaviour>().animator.SetTrigger("respawn");
                t.GetComponent<NavMeshAgent>().enabled = true;
            }
        }
    }

   


}
