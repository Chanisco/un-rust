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



}
