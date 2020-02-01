using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEVChooseableBoundPositionVisual : MonoBehaviour
{
    public List<GameObject> boundPositions = new List<GameObject>();

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        for (int i = 0; boundPositions.Count > i ; i++)
        {
            if (i >= boundPositions.Count - 1)
            {
                Gizmos.DrawLine(boundPositions[i].transform.position, boundPositions[0].transform.position);

            }
            else
            {
                Gizmos.DrawLine(boundPositions[i].transform.position, boundPositions[i + 1].transform.position);
            }
        }
    }
}
