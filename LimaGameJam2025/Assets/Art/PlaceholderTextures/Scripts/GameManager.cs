using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;
    public int levelsCompleted = 0;
    public int paintSize = 10;

    public float combo = 0f;

    public bool introHasPlayed = false;
    public bool reachEnding = false;

    public bool GameOver = false;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
      
    }
    void Start()
    {
        AudioManager.instance.PlayMusic("MainThemeOG");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
