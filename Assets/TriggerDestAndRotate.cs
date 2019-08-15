using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestAndRotate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player Arrive trigger");
            WalkingPath.Instance.isTrigger();
            PlayerMovement.Instance.RotateToTarget(transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
