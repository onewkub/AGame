using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breath_sound : MonoBehaviour
{
	public AudioSource audio;
	float distance;
	public GameObject Ghost;
	public float max_time=0.2f;
	float timer=0;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if (Ghost.active == true)
		{
			timer -= Time.deltaTime;
			distance = Vector3.Distance(transform.position, Ghost.transform.position);
			distance /= 40;
			max_time = 2.1f-(1/1+Mathf.Exp(-distance));
			if (timer < 0)
			{
				audio.Play();
				timer = max_time;
			}
			
		}
		
    }
}
