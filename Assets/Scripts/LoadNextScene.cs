using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    private void OnLevelWasLoaded(int level)
    {
        SceneLoadManager.Instance.ElevatorLoadAsync("SecondFloor");

    }
}
