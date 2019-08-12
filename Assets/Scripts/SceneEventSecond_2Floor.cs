using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEventSecond_2Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ElevatorController.Instance.openElevator();
        }
    }
}
