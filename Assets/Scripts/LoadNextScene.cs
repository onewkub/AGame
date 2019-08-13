using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneLoadManager.Instance.LoaderAsync("SecondFloor");
        Destroy(gameObject);

    }
}
