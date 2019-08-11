using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneBloody : MonoBehaviour
{
    IEnumerator waitElevatorClose()
    {
        yield return new WaitWhile(() => ElevatorController.Instance.SoundFXisPlaying());
        SceneLoadManager.Instance.SwitchSceneinLoading();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ElevatorController.Instance.closeElevator();
        }
        StartCoroutine(waitElevatorClose());
    }
}
