using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    [SerializeField] movementFunctions movementFunctions; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        movementFunctions.hasLanded = true;
        gameObject.SetActive(false);

        print("hasLanded");

        if (other.CompareTag("Floor"))
        {
            
        }
    }
    //[SerializeField] private LayerMask floorLayer; // LayerMask for the floor

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == floorLayer)
    //    {
    //        movementFunctions.hasLanded = true;
    //        gameObject.SetActive(false);
    //        print("hasLanded");

    //        Debug.Log("Player touched the floor!");
    //        Play a landing sound effect
    //    }
    //}

}
