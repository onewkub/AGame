using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadElevator : MonoBehaviour
{
    void Start()
    {
        SceneLoadManager.Instance.ElevatorLoadAsync(1);
    }
}
