using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitController : Singleton<BitController>
{
    [HideInInspector]
    public ChooseableBoundPositionMaker _chooseableBoundPositionMaker;

    public List<BitminBehaviour> Bitmins = new List<BitminBehaviour>();

    public Vector3 GiveNewPositionForPlayfield()
    {
        return _chooseableBoundPositionMaker.GetRandomPositionWithBounds();
    }

}
