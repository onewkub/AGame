using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_attack : MonoBehaviour
{
	public GameObject player;
	public float range = 5;
	public float delay = 2;
	float dist;
	float timer=0;
	Animator anim;
    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist < range && timer>delay)
		{
			timer = 0;
			anim.SetTrigger("attack");
		}
		
	}
}
