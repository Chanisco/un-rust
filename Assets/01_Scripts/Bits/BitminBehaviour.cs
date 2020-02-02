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
    public bool isHolding = false;
    public bool hasHolded = false;
    public Animator animator;
    public ModalThrowable throwScript;
    public int minThinking;
    public int maxThinking;
    public GameObject[] model;
    public TrailRenderer trail;
    private AudioController _audioController;
    private int currentModel;

    private void OnEnable()
    {
        currentModel = Random.Range(0, model.Length);
        foreach (GameObject model in model)
        {
            model.SetActive(false);
        }

        model[currentModel].SetActive(true);
        animator = model[currentModel].GetComponent<Animator>();
        gameObject.tag = "Bitmin";
        _bitController = BitController.Instance;
        _audioController = AudioController.Instance;
        if (ownNavMeshAgent != null)
        {
            ownNavMeshAgent.enabled = true;
        }
        ChangeColor();
        trail.gameObject.SetActive(false);


    }

    public void ChangeColor() {
        bitminColor = (BitController.COLORS)Random.Range(0, (int)System.Enum.GetValues(typeof(BitController.COLORS)).Length -2);
        trail.startColor = BitController.HueColourValue(bitminColor);
        foreach (MeshRenderer meshRenderer in accentMeshes)
        {
            meshRenderer.material.color = BitController.HueColourValue(bitminColor);
        }
    }
    void Start()
    {
        throwScript = this.GetComponent<ModalThrowable>();

        if (ownNavMeshAgent == null){
            ownNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        StartCoroutine("changeMind");

    }
    
    void Update()
    {

        if (throwScript.attached == true)
        {
            if (isHolding == false)
            {
                Holding();
            }
        }
        if (throwScript.attached == false && hasHolded == true)
        {
            isHolding = false;
            hasHolded = false;
            animator.SetBool("isGrabbed", false);
        }


        if (ownNavMeshAgent.isActiveAndEnabled == true)
        {
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

        CheckIfOutBound();
    }

    private IEnumerator changeMind()
    {
        if (thinking == false)
        {
            thinking = true;
            int r = Random.Range(minThinking, maxThinking);
            yield return new WaitForSeconds(r);
            if (ownNavMeshAgent.isActiveAndEnabled == true)
            {
                ownNavMeshAgent.isStopped = false;
                targetPosition = _bitController.GiveNewPositionForPlayfield();
                thinking = false;
            }
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

    public void RemoveBit()
    {
        gameObject.SetActive(false);
        _bitController.NewBitNeededRequest();

    }

    private void Holding()
    {
        isHolding = true;
        hasHolded = true;
        ownNavMeshAgent.enabled = false;
        _audioController.BitSound();
        trail.gameObject.SetActive(true);
        animator.SetBool("isGrabbed",true);
    }
}
