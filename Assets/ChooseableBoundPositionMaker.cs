using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseableBoundPositionMaker : MonoBehaviour
{
    public List<ChooseableBoundHolder> target = new List<ChooseableBoundHolder>();
    public GameObject t;
    private void OnEnable()
    {
        BitController.Instance._chooseableBoundPositionMaker = this;
    }
    private void Start()
    {
        int i = 0;
        while (i < target.Count - 1)
        {
            target[i].FillCridentials();

            i++;
        }
    }
    

    public Vector3 GetRandomPositionWithBounds()
    {
        int randomPlatform = Random.Range(0, target.Count);
        float randX = Random.Range(target[randomPlatform].mostLeftPoint,    target[randomPlatform].mostRightPoint);
        float randY = Random.Range(target[randomPlatform].LowestPoint,      target[randomPlatform].HighestPoint);
        float randZ = Random.Range(target[randomPlatform].mostBack,         target[randomPlatform].mostFront);
        return new Vector3(randX,randY,randZ);
    }
    


}

[System.Serializable]
public class ChooseableBoundHolder
{
    public List<Transform> targetBounds = new List<Transform>();
    public float mostLeftPoint;
    public float mostRightPoint;

    public float LowestPoint;
    public float HighestPoint;

    public float mostFront;
    public float mostBack;

    public ChooseableBoundHolder()
    {
        if (targetBounds.Count != 0)
        {
            FillCridentials();

        }
    }

    public void FillCridentials()
    {
        mostLeftPoint = targetBounds[0].position.x;
        mostRightPoint = targetBounds[0].position.x;
        LowestPoint = targetBounds[0].position.y;
        HighestPoint = targetBounds[0].position.y;
        mostFront = targetBounds[0].position.z;
        mostBack = targetBounds[0].position.z;
        for (int i = 1; i < targetBounds.Count; i++)
        {
            if (targetBounds[i].position.x > mostLeftPoint)
            {
                mostLeftPoint = targetBounds[i].position.x;
            }
            else if (targetBounds[i].position.x < mostRightPoint)
            {

                mostRightPoint = targetBounds[i].position.x;
            }

            if (targetBounds[i].position.y < LowestPoint)
            {
                LowestPoint = targetBounds[i].position.y;
            }
            else if (targetBounds[i].position.y > HighestPoint)
            {
                HighestPoint = targetBounds[i].position.y;
            }

            if (targetBounds[i].position.z < mostFront)
            {
                mostFront = targetBounds[i].position.z;
            }
            else if (targetBounds[i].position.z > mostBack)
            {
                mostBack = targetBounds[i].position.z;

            }

        }
    }
}
