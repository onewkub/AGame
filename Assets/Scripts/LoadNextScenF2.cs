using UnityEngine;

public class LoadNextScenF2 : MonoBehaviour
{
    private void Start()
    {
        SceneLoadManager.Instance.LoaderAsync("ElevatorScene", 5);

    }
}
