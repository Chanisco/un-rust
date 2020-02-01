using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitController : Singleton<BitController>
{
    [HideInInspector]
    public ChooseableBoundPositionMaker _chooseableBoundPositionMaker;
    private EventController _eventController;

    public List<BitminBehaviour> Bitmins = new List<BitminBehaviour>();
    private void Start()
    {
        _eventController = EventController.Instance;
    }
    public Vector3 GiveNewPositionForPlayfield()
    {
        return _chooseableBoundPositionMaker.GetRandomPositionWithBounds();
    }
    
    public void NewBitNeededRequest()
    {
        _eventController.NewBitNeededCall();
    }

}

public enum BIT_COLORS
{
    RED,
    BLUE,
    YELLOW
}
