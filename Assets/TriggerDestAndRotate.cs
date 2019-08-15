using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestAndRotate : MonoBehaviour
{
    public GameObject UI;
    public ChooseTheWay Script;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WalkingPath.Instance.isTrigger();
            if (UI != null)
                UI.SetActive(true);
            if (Script != null)
                Script.enabled = true;
            //Debug.Log("player Arrive trigger");
            PlayerMovement.Instance.RotateToTarget(transform.rotation);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            WalkingPath.Instance.ChoosePathState = false;

            gameObject.SetActive(false);
        }
    }
}
