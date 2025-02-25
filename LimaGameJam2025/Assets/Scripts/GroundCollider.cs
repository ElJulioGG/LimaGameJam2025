using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    [SerializeField] movementFunctions movementFunctions;
    [SerializeField] CameraShake2 camShake;
    [SerializeField] private float landAmplitude =0.5f;
    [SerializeField] private float landDuration = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        movementFunctions.hasLanded = true;
        gameObject.SetActive(false);

        print("hasLanded");

        //camShake.setShakeCam(landAmplitude, landDuration);
        AudioManager.instance.PlaySfx("Caida");

        //if (other.CompareTag("Floor"))
        //{
        //    
        //}
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
