using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddingSpot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Im hidding");
            PlayerMovement.Instance.agent.Stop();
            PlayerMovement.Instance.RotateToTarget(transform.rotation);
        }
    }
}
