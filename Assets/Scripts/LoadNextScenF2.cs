using UnityEngine;

public class LoadNextScenF2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Time.timeSinceLevelLoad > 1f)
            SceneLoadManager.Instance.LoaderAsync("ElevatorScene");
    }
}
