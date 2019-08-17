using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_scare : MonoBehaviour
{
	public GameObject canava;
	bool f = true;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && f==true)
		{
			canava.SetActive(true);
			Destroy(canava, 2);
			f = false;
		}
	}
}
