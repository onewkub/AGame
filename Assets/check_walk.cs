using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_walk : MonoBehaviour
{
	public AudioSource audio;
    // Update is called once per frame
    void Update()
    {
		if (PlayerMovement.Instance.isWalking)
		{
			audio.enabled = true;
		}
		else
		{
			audio.enabled = false;
		}
    }
}
