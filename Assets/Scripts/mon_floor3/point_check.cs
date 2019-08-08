using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_check : MonoBehaviour
{
	// Start is called before the first frame update
	public bool state=false;
	public bool ghost_state = false;
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			state = true;
		}
		if (other.tag == "GHost")
		{
			ghost_state = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			state = false;
		}
		if (other.tag == "GHost")
		{
			ghost_state = false;
		}
	}
}

