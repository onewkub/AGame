using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broken_ghost : MonoBehaviour
{
	
	
	public float minVal=0.1f, maxVal=0.5f;
	public float max_time = 5;
	public GameObject disppear;
	float timer;
	float delay;

	// Start is called before the first frame update
	
	private void Update()
	{
		if (max_time < 0)
		{
			this.enabled = false;
			disppear.SetActive(false);
		}
		timer -= Time.deltaTime;
		max_time -= Time.deltaTime;
		if (timer < 0)
		{
			delay = Random.Range(minVal, maxVal);
			timer = delay;
			disppear.SetActive(!disppear.active);
		}
		
	}
	
}
