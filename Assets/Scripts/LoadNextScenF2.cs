using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextScenF2 : MonoBehaviour
{
    private void OnLevelWasLoaded(int level)
    {
        if (GameManager.gameManager.Arrived2fllor)
        {
            SceneLoadManager.Instance.ElevatorLoadAsync("ThirdFloor");
        }
        else
        {
            SceneLoadManager.Instance.ElevatorLoadAsync("ElevatorScene");
        }
    }
}
