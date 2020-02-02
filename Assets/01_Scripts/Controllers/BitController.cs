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
    public enum COLORS { ORANGE, YELLOW, BLUE, PURPLE, MAGNETA, CORRECT, NOT_CORRECT }


    private static Hashtable hueColourValues = new Hashtable{
         { COLORS.ORANGE,   new Color32( 255 , 173 , 77, 1 ) },
         { COLORS.YELLOW,   new Color32( 254 , 255 , 142, 1 ) },
         { COLORS.BLUE,     new Color32( 77 , 158 , 255, 1 ) },
         { COLORS.PURPLE,   new Color32( 173 , 112 , 255, 1 ) },
         { COLORS.MAGNETA,  new Color32( 248 , 112 , 248, 1 ) },
         { COLORS.NOT_CORRECT,  new Color32( 255 , 0 , 0, 1 ) },
         { COLORS.CORRECT,      new Color32( 77 , 255 , 50, 1 ) },
     };

    public static Color32 HueColourValue(COLORS color)
    {
        return (Color32)hueColourValues[color];
    }
}

