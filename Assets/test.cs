using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        PlayerMovement.Instance.SetDestination(gameObject.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Yeah");
    }
}
