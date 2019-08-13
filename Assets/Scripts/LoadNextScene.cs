using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    private void Start()
    {
        SceneLoadManager.Instance.LoaderAsync("SecondFloor");

    }
}
