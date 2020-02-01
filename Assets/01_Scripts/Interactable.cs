using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    public Hand m_activateHand = null;
}
