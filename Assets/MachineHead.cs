using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineHead : MonoBehaviour
{
    public ParticleSystem DestructionParticle;
    public List<MachineButton> MachineBtns = new List<MachineButton>();
    private EventController _eventController;
    private GameController _gameController;

    public bool _fixed;

    private void OnEnable()
    {
        _eventController = EventController.Instance;
        _gameController = GameController.Instance;
        _eventController.AddScore += CheckMachineBtns;
        _eventController.GameStart += Init;

    }

    private void OnDisable()
    {
        _eventController.AddScore -= CheckMachineBtns;

    }

    private void Init()
    {
        DestructionParticle.gameObject.SetActive(true);

        DestructionParticle.Play();
    }

    public IEnumerator RemoveDestruction()
    {
        DestructionParticle.Stop();
        yield return new WaitForSeconds(0.5f);
        DestructionParticle.gameObject.SetActive(false);
    }

    private void CheckMachineBtns(int score)
    {
        int i = 0;
        bool machineFixed = true;
        while (i < MachineBtns.Count)
        {
            if (MachineBtns[i].hit == false)
            {
                machineFixed = false;
                break;
            }
            i++;
        }
        if (machineFixed == true)
        {
            ObjectFixed();
        }
    }

    private void ObjectFixed()
    {
        StartCoroutine("RemoveDestruction");
        _fixed = true;
    }
}
