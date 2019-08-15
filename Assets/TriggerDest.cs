using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player Arrive trigger");
            WalkingPath.Instance.isTrigger();
            gameObject.SetActive(false);
        }
    }
}
