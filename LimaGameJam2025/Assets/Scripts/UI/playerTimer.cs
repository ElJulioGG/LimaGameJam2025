using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class playerTimer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private string scene;
    [SerializeField] private float playerTime;
    [SerializeField] private UnityEvent<string> _clock;

    public GameObject canvasOver;

    // Update is called once per frame
    void Update()
    {
        playerTime -= Time.deltaTime;
        int minutes = (int)playerTime / 60;
        int seconds = (int)playerTime % 60;

        _clock.Invoke(string.Format("{0:00}:{1:00}", minutes, seconds));

        if (playerTime < 0)
        {
            player.SetActive(false);
            canvas.SetActive(true);
            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.None;
        }
        if (minutes == 10) {
            canvasOver.gameObject.SetActive(true);

        }

    }

    
}
