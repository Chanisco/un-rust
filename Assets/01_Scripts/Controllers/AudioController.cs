using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip mainMusic;

    private EventController _eventController;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _eventController = EventController.Instance;
        _eventController.GameStart += InitMainMusic;
        _eventController.GameEnd += turnOffMainMusic;
        _eventController.GameOverByFinish += turnOffMainMusic;

    }

    private void InitMainMusic()
    {
        _audioSource.clip = mainMusic;
        _audioSource.Play();
    }

    private void turnOffMainMusic()
    {
        _audioSource.Stop();
    }

}
