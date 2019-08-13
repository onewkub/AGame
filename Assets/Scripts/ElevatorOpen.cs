using UnityEngine;

public class ElevatorOpen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ElevatorController.Instance.openElevator();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(this.tag == "FirstFloor")
            {
                ElevatorController.Instance.closeElevator();
            }
        }
    }
}
