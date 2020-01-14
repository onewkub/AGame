using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breath_sound : MonoBehaviour
{
	public AudioSource audio;
	public float distance;
	public GameObject Ghost;
	public float petch=1;
	public float volume=1.5f;
	float timer=0;
    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		if ( Ghost!=null && Ghost.active == true)
		{
			audio.enabled = true;
			distance = Vector3.Distance(transform.position, Ghost.transform.position);
			distance /= 40;
			audio.pitch = petch+(1 / 1 + Mathf.Exp(-distance));
			distance /= 2;
			audio.volume =  (-volume)+ (1 / 1 + Mathf.Exp(-distance));


		}
		else
		{
			audio.enabled = false;

		}
		
		
    }
}
