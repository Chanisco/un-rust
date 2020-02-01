using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

public class BitminBehaviour : MonoBehaviour
{

    public NavMeshAgent ownNavMeshAgent;
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
        if (ownNavMeshAgent != null)
        {
            ownNavMeshAgent.enabled = true;
        }
        ChangeColor();


    }
    private void OnDisable()
    {

    }

    public void ChangeColor() {
        bitminColor = (BitController.COLORS)Random.Range(0, (int)System.Enum.GetValues(typeof(BitController.COLORS)).Length -2);
        Debug.Log(bitminColor);

        foreach (MeshRenderer meshRenderer in accentMeshes)
        {
            meshRenderer.material.color = BitController.HueColourValue(bitminColor);
        }
    }
    void Start()
    {
        throwScript = GetComponent<Throwable>();
        throwScript = this.GetComponent<Throwable>();

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
