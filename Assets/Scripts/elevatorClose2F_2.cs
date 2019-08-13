using System.Collections;
using UnityEngine;

public class elevatorClose2F_2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            ElevatorController.Instance.closeElevator();
            Debug.Log("Don't Get out");
            StartCoroutine(waitElevatroClose());
        }
    }

    IEnumerator waitElevatroClose() {
        yield return new WaitWhile(() => ElevatorController.Instance.SoundFXisPlaying());
        SceneLoadManager.Instance.SwitchSceneinLoading();

    }
}
