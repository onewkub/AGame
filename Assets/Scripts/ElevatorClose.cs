using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorClose : MonoBehaviour
{
    public GameObject ElDoor;
    private Animator ElAnimator;
    private void Awake()
    {
        ElAnimator = ElDoor.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ElAnimator.SetBool("Open", false);
            SceneLoadManager.Instance.SwitchSceneinLoading();
        }
    }
}
