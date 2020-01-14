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
		Debug.Log("In out Trigger funtion");
        if(other.tag == "Player")
        {
			Debug.Log("Out of Trigger");
            WalkingPath.Instance.ChoosePathState = false;
			Script.enabled = false;
			UI.SetActive(false);
            gameObject.SetActive(false);

        }
    }
}
