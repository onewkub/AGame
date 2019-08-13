using UnityEngine;

public class LoadNextScenF2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneLoadManager.Instance.LoaderAsync("ElevatorScene", 5);

    }
}
