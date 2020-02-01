using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{

    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_pose = null;
    private FixedJoint m_Joint = null;

    private Interactable m_CurrentInteractable = null;
    public List<Interactable> m_ContactInteractables = new List<Interactable>();
    // Start is called before the first frame update

    private void Awake()
    {
        m_pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();

    }

    // Update is called once per frame
    void Update()
    {
        //down
        if (m_GrabAction.GetLastStateDown(m_pose.inputSource))
        {
            print(m_pose.inputSource + " Trigger Down");
            Pickup();
        }
        //up

        if (m_GrabAction.GetLastStateUp(m_pose.inputSource))
        {
            print(m_pose.inputSource + " Trigger up");
            Drop();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("bitmin"))
        {
            return;
        }
        m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("bitmin"))
        {
            return;
        }
        m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
    }

    public void Pickup()
    {
        // get nearest
        m_CurrentInteractable = GetNearestInteractable();

        // null check

        if (!m_CurrentInteractable)
        {
            return;
        }

        //already held, check

        if (m_CurrentInteractable.m_activateHand)
        {
            m_CurrentInteractable.m_activateHand.Drop();
        }

        //positionin
        m_CurrentInteractable.transform.position = transform.position;

        // attach
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        // set active hand
        m_CurrentInteractable.m_activateHand = this;
    }

    private void Drop()
    {
        // null check

        if (!m_CurrentInteractable)
        {
            return;
        }

        //Apply velocity
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = m_pose.GetVelocity();
        targetBody.angularVelocity = m_pose.GetAngularVelocity();


        //Dettach
        m_Joint.connectedBody = null;

        //clear
        m_CurrentInteractable.m_activateHand = null;
        m_CurrentInteractable = null;

    }

    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (Interactable interactable in m_ContactInteractables) {

            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }
        return nearest;
    }
}
