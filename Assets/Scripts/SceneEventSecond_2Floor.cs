using UnityEngine;

public class SceneEventSecond_2Floor : MonoBehaviour
{
	public Transform CloseTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ElevatorController.Instance.openElevator();
			PlayerMovement.Instance.agent.SetDestination(CloseTrigger.position);
        }
    }
}
