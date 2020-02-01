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

    public enum COLORS { RED, ORANGE, YELLOW, GREEN, BLUE, PURPLE, MAGNETA, CORRECT, NOT_CORRECT}


    private static Hashtable hueColourValues = new Hashtable{
         { COLORS.NOT_CORRECT,      new Color32( 255 , 0 , 0, 1 ) },
         { COLORS.ORANGE,   new Color32( 255 , 125 , 0, 1 ) },
         { COLORS.YELLOW,   new Color32( 255 , 255 , 0, 1 ) },
         { COLORS.CORRECT,    new Color32( 0 , 255 , 50, 1 ) },
         { COLORS.BLUE,     new Color32( 0 , 200 , 255, 1 ) },
         { COLORS.PURPLE,   new Color32( 125 , 0 , 255, 1 ) },
         { COLORS.MAGNETA,  new Color32( 255 , 0 , 255, 1 ) },

     };

    public static Color32 HueColourValue(COLORS color)
    {
        return (Color32)hueColourValues[color];
    }
}



