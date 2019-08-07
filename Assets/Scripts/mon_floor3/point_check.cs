using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_check : MonoBehaviour
{
	// Start is called before the first frame update
	public bool state=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter(Collider other)
	{
		state = true;
	}
}

