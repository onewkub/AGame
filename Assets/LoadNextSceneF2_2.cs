using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextSceneF2_2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneLoadManager.Instance.LoaderAsync("ThirdFloor");
    }
}
