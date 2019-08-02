using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpen : MonoBehaviour
{
    public GameObject ElDoor;
    private Animator ElAnimator;
    private void Awake()
    {
        ElAnimator = ElDoor.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Testor")
        {
            ElAnimator.SetBool("Open", true);
            Debug.Log("Im in");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name == "Testor")
        {
            ElAnimator.SetBool("Open", false);
            Debug.Log("im out");
        }
    }
}
