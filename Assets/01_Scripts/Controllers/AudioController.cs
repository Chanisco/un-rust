using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    public AudioClip mainMusic;

    private EventController _eventController;
    private AudioSource _audioSource;
    public AudioClip goodBtnFeedback;
    public AudioClip badBtnFeedback;
    public List<AudioClip> ClickSoundForBtnList = new List<AudioClip>();
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

    public void PlaySFXOnBtnPress(bool positive)
    {
        if (positive == true)
        {
            _audioSource.PlayOneShot(goodBtnFeedback);
        }
        else
        {
            _audioSource.PlayOneShot(badBtnFeedback);

        }
    }

    public void ClickSoundForBtn()
    {
        AudioClip t = ClickSoundForBtnList[Random.Range(0, ClickSoundForBtnList.Count)];
        _audioSource.PlayOneShot(t);
    }
}
