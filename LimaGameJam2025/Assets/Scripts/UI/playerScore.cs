using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerScore : MonoBehaviour
{
    [SerializeField] private float playerPoints;
    [SerializeField] private UnityEvent<string> _score;

    // Update is called once per frame
    void Update()
    {
        playerPoints += Time.deltaTime;
        _score.Invoke(string.Format("{0:000000}", (int)playerPoints));
    }
}
