using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCollider : MonoBehaviour
{
    [SerializeField] private int areaNum = 0;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            if(areaNum == 0) { 
                GameManager.instance.insideA = true;
            }
            else
            {
                GameManager.instance.insideA = false;
            }

            if (areaNum == 1)
            {
                GameManager.instance.insideB = true;
            }
            else
            {
                GameManager.instance.insideB = false;
            }

            if (areaNum == 2)
            {
                GameManager.instance.insideC = true;
            }
            else
            {
                GameManager.instance.insideC = false;
            }

        }
    }
}
