using UnityEngine;

public class TriggerCubeLoad : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        SceneLoadManager.Instance.LoadElevator();
    }
}
