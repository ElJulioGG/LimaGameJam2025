using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{
    private float timeThatShouldTakeForTheFirstAudioManagerToStopPlayingSoThatTheOtherOneCanStart = 11.073f;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic("mainthemestart");
    }

    private void Update()
    {
        if (AudioManager.instance.musicSource.time > timeThatShouldTakeForTheFirstAudioManagerToStopPlayingSoThatTheOtherOneCanStart)
        {
            print("like magic, like magic, like magic, GONE");
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlayAltMusic("mainthemeloop");
        }
    }
}
