using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHead : MonoBehaviour
{
    public List<MachineButton> MachineBtns = new List<MachineButton>();

    private void CheckMachineBtns()
    {
        for (int i = 0; i < MachineBtns.Count; i++)
        {
            if(MachineBtns[i].hit == true)
            {
                break;
            }
        }
    }



}
