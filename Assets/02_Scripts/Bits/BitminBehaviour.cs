using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BitminBehaviour : MonoBehaviour
{

    private NavMeshAgent ownNavMeshAgent;
    public Vector3 targetPosition;
    private BitController _bitController;
    private bool thinking = false;
    private void OnEnable()
    {
        _bitController = BitController.Instance;
    }
    private void OnDisable()
    {

    }

    void Start()
    {
        if (ownNavMeshAgent == null){
            ownNavMeshAgent = this.GetComponent<NavMeshAgent>();
        }
        StartCoroutine("changeMind");

    }
    
    void Update()
    {
        if (ownNavMeshAgent.remainingDistance < 00.1 && thinking == true)
        {
            StartCoroutine("changeMind");
            ownNavMeshAgent.isStopped = true;
        }
        else
        {
            ownNavMeshAgent.SetDestination(targetPosition);
        }
    }

    private IEnumerator changeMind()
    {
        thinking = true;
        int r = Random.Range(2, 10);
        yield return new WaitForSeconds(r);
        ownNavMeshAgent.isStopped = false;
        targetPosition = _bitController.GiveNewPositionForPlayfield();


    }
}
