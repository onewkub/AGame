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

    private void Start()
    {
        GameManager.gameManager.Arrived2fllor = true;
    }

}
