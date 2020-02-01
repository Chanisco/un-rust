using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

public class BitminBehaviour : MonoBehaviour
{

    private NavMeshAgent ownNavMeshAgent;
    public MeshRenderer[] accentMeshes;
    public Vector3 targetPosition;
    private BitController _bitController;
    public BitController.COLORS bitminColor;
    public bool thinking = false;
    public Throwable throwScript;
    public int minThinking;
    public int maxThinking;
    private void OnEnable()
    {
        _bitController = BitController.Instance;
    }
    private void OnDisable()
    {

    }

    void Start()
    {
        throwScript = this.GetComponent<Throwable>();
        foreach(MeshRenderer meshRenderer in accentMeshes)
        {
            meshRenderer.material.color = BitController.HueColourValue(bitminColor);
        }
        if (ownNavMeshAgent == null){
            ownNavMeshAgent = this.GetComponent<NavMeshAgent>();
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

    private void Holding()
    {
        ownNavMeshAgent.enabled = false;
        //his.enabled = false ;
    }
}
