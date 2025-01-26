using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerTimer : MonoBehaviour
{
    [SerializeField] private float playerTime;
    [SerializeField] private UnityEvent<string> _clock;

    // Update is called once per frame
    void Update()
    {
        playerTime -= Time.deltaTime;
        int minutes = (int)playerTime / 60;
        int seconds = (int)playerTime % 60;

        _clock.Invoke(string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
