using UnityEngine;

public class LoadNextScenF2 : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (Time.timeSinceLevelLoad > 1f)
            SceneLoadManager.Instance.LoaderAsync("FirstFloor");
    }
}
