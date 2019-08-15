using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasHide : MonoBehaviour
{
    public GameObject ghostHeadTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Im hidding");

            ghostHeadTrigger.SetActive(false);
        }
    }
}
