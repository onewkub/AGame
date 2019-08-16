using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextSceneF2_2 : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			SceneLoadManager.Instance.LoaderAsync("ElevatorScene");
		}
	}
}
