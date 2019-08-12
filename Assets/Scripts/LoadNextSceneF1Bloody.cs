using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextSceneF1Bloody : MonoBehaviour
{
    private void OnLevelWasLoaded(int level)
    {
        SceneLoadManager.Instance.ElevatorLoadAsync("ElevatorScene");
        GameManager.gameManager.Arrive1FloorBloody = true;
    }
}
