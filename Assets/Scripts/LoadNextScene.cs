using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    private void Start()
    {
        SceneLoadManager.Instance.ElevatorLoadAsync("SecondFloor");

    }
}
