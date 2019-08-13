using UnityEngine;

public class waitForInteract : MonoBehaviour
{

    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            SceneLoadManager.Instance.SwitchSceneinLoading();
        }
    }

    private void OnEnable()
    {
        SceneLoadManager.Instance.ElevatorLoadAsync("FirstFloor_start");
    }
}
