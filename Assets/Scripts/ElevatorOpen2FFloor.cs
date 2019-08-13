using UnityEngine;

public class ElevatorOpen2FFloor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if(other.tag == "Ghost") {

            ElevatorController.Instance.openElevator();
        }
        gameObject.SetActive(false);
        /*else if(other.tag == "Player")
        {
            ElevatorController.Instance.closeElevator();
        }*/   
    }
    /*private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneLoadManager.Instance.SwitchSceneinLoading();
        }
    }*/
}
