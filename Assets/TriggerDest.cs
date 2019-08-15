using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDest : MonoBehaviour
{
    public GameObject UI;
    public ChooseTheWay Script;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           //Debug.Log("player Arrive trigger");
            WalkingPath.Instance.isTrigger();
            Script.enabled = true;
            UI.SetActive(true);
            
            WalkingPath.Instance.ChoosePathState = true;

            //gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            WalkingPath.Instance.ChoosePathState = false;

            gameObject.SetActive(false);

        }
    }
}
