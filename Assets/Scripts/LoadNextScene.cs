using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Time.timeSinceLevelLoad > 1f)
            SceneLoadManager.Instance.LoaderAsync("SecondFloor");

    }
}
