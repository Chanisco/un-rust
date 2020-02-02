using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHeadHolder : MonoBehaviour
{
    public List<LevelHead> levelHeads = new List<LevelHead>();
    private GameController _gameController;
    private int currentlvl;

    private void OnEnable()
    {
        _gameController = GameController.Instance;
        _gameController.lvlheadHolder = this;
    }

    public void RequestLevelChange(int targetLevel)
    {
        currentlvl = targetLevel;
        StartCoroutine("DelayInLevelChangeForCurtainDrop");
    }

    private IEnumerator DelayInLevelChangeForCurtainDrop()
    {
        yield return new WaitForSeconds(3);
        changeLevel(currentlvl);
    }

    private void changeLevel(int targetLevel)
    {
        for (int i = 0; i < levelHeads.Count; i++)
        {
            if (i == targetLevel)
            {
                levelHeads[i].gameObject.SetActive(true);

            }
            else
            {
                levelHeads[i].gameObject.SetActive(false);

            }
        }
        _gameController.StartGame();
    }
}
