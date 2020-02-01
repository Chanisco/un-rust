﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

public class BitminBehaviour : MonoBehaviour
{

    public NavMeshAgent ownNavMeshAgent;
    public Vector3 targetPosition;
    private BitController _bitController;
    public bool thinking = false;
    public Throwable throwScript;
    public int minThinking;
    public int maxThinking;
    private void OnEnable()
    {
        _bitController = BitController.Instance;
        if (ownNavMeshAgent != null)
        {
            ownNavMeshAgent.enabled = true;
        }

    }
    private void OnDisable()
    {

    }

    void Start()
    {
        throwScript = GetComponent<Throwable>();
        if (ownNavMeshAgent == null){
            ownNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        StartCoroutine("changeMind");

    }
    
    void Update()
    {

        if (throwScript.attached == true)
        {
            Holding();
        }

        if (ownNavMeshAgent.remainingDistance < 0.1f && thinking == false)
        {
            StartCoroutine("changeMind");
            ownNavMeshAgent.isStopped = true;
        }
        else
        {
            ownNavMeshAgent.SetDestination(targetPosition);
        }
        CheckIfOutBound();
    }

    private IEnumerator changeMind()
    {
        if (thinking == false)
        {
            thinking = true;
            int r = Random.Range(minThinking, maxThinking);
            yield return new WaitForSeconds(r);
            ownNavMeshAgent.isStopped = false;
            targetPosition = _bitController.GiveNewPositionForPlayfield();
            thinking = false;
        }


    }
    private void CheckIfOutBound()
    {
        if (transform.position.y < -2)
        {
            gameObject.SetActive(false);
            _bitController.NewBitNeededRequest();
        }
    }

    private void Holding()
    {
        ownNavMeshAgent.enabled = false;
        //his.enabled = false ;
    }
}
