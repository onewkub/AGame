using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_ghost : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject canava;
	bool f = false,o=false;
	public float timer = 3;

    // Update is called once per frame
    void Update()
    {
		if (f&&o==false)
		{
			timer -= Time.deltaTime;
			if (timer < 0)
			{
				canava.SetActive(true);
				Destroy(canava, 2);
				o = true;
				
			}
		}
		
    }
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ghost2" && f == false)
		{
			f = true;
		}
	}
}
