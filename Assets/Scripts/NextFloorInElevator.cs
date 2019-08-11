using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloorInElevator : MonoBehaviour
{
    private void OnLevelWasLoaded(int level)
    {
        if (GameManager.gameManager.Arrive1FloorBloody)
        {
            SceneLoadManager.Instance.ElevatorLoadAsync("SecondFloor");
        }
        else if (!GameManager.gameManager.Arrive1FloorBloody)
        {
            SceneLoadManager.Instance.ElevatorLoadAsync("FirstFloor");
        }
        else
        {
            SceneLoadManager.Instance.ElevatorLoadAsync("ThirdFloor");
        }
    }
}
