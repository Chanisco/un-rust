using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : Singleton<EventController> {
    
    public event Action GameOverByFinish;
    void OnGameOverByFinish() {
        if (GameOverByFinish != null) {
            GameOverByFinish();
        }
    }
    public void GameOverByFinishCall() {
        OnGameOverByFinish();
    }

    public event Action GameStart;
    void OnGameStart()
    {
        if (GameStart != null)
        {
            GameStart();
        }
    }
    public void GameStartCall()
    {
        OnGameStart();
    }

    public event Action GameEnd;
    void OnGameEnd()
    {
        if (GameEnd != null)
        {
            GameEnd();
        }
    }
    public void GameEndCall()
    {
        OnGameEnd();
    }


    public event Action NewBitNeeded;
    void OnNewBitNeeded()
    {
        if (NewBitNeeded != null)
        {
            NewBitNeeded();
        }
    }
    public void NewBitNeededCall()
    {
        OnNewBitNeeded();
    }

    public event Action<int> AddScore;
    void OnAddScore(int targetAmount)
    {
        if (AddScore != null)
        {
            AddScore(targetAmount);
        }
    }
    public void AddScoreCall(int targetAmount)
    {
        OnAddScore(targetAmount);
    }

    public event Action<int> ChangeTime;
    void OnChangeTime(int targetAmount)
    {
        if (ChangeTime != null)
        {
            ChangeTime(targetAmount);
        }
    }
    public void ChangeTimeCall(int targetAmount)
    {
        OnChangeTime(targetAmount);
    }




}
