using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the specified scene
            SceneManager.LoadScene(0);
        }
    }
    private void OnEnable()
    {
        textMeshPro.text = scoreManager.score.ToString();
    }
}
