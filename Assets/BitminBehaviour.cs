using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BitminBehaviour : MonoBehaviour
{

    private NavMeshAgent ownNavMeshAgent;
    public GameObject test;
    public Mesh walkArea;
    // Start is called before the first frame update
    void Start()
    {
        if (ownNavMeshAgent == null){
            ownNavMeshAgent = this.GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ownNavMeshAgent.SetDestination(test.transform.position);
        Debug.Log(ownNavMeshAgent.remainingDistance);
    }
}
