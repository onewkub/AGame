using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSceneScript : MonoBehaviour
{
    public GameObject PlayerWayPoint;
    private void Start()
    {
        PlayerWayPoint.SetActive(true);
    }
}
