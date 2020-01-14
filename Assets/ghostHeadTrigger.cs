using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostHeadTrigger : MonoBehaviour
{
	public GameObject Ghost_head;
	private void OnTriggerEnter(Collider other)
	{
		Ghost_head.SetActive(false);
	}
}
