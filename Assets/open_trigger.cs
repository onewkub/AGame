using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_trigger : MonoBehaviour
{
	public GameObject open_Trigger, close_trigger;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			open_Trigger.SetActive(true);
			close_trigger.SetActive(true);
		}
	}

}
