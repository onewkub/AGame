using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpen2FFloor : MonoBehaviour
{
    public GameObject ELDoor;
    public ElevatorController elevatorController;
    private Animator ELDoorAnimator;


    private void Start()
    {
        ELDoorAnimator = ELDoor.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if(other.tag == "Ghost") {

            elevatorController.openElevator();
        }
        else if(other.tag == "Player")
        {
            elevatorController.closeElevator();
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneLoadManager.Instance.SwitchSceneinLoading();
            GameManager.gameManager.Arrived2fllor = true;
        }
    }
}
