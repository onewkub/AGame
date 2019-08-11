using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInsideF1Bloody : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ElevatorController.Instance.openElevator();
        }
    }
}
