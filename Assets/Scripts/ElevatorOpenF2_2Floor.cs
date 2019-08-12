using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpenF2_2Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ElevatorController.Instance.openElevator();
            gameObject.SetActive(false);
        }
        
    }

    private void OnLevelWasLoaded(int level)
    {
        GameManager.gameManager.Arrived2fllor = true;
    }

}
