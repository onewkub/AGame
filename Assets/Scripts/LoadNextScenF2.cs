using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextScenF2 : MonoBehaviour
{
    private void OnLevelWasLoaded(int level)
    {
        SceneLoadManager.Instance.ElevatorLoadAsync("ElevatorScene");

    }
}
