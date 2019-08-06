using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class movement_ghost : MonoBehaviour
{
	Animator anim;
	NavMeshAgent agent;
	public GameObject player;
	public float range = 5;
	public float walk = 3.5f;
	public float run = 7f;
	public bool play = false;
	public bool gopoint = false;
	public bool gopoint2 = false;
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	float dist;
	
	// Start is called before the first frame update
	void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		
	}

	// Update is called once per frame
	void Update()
	{
		
		if (gopoint) {
			go(p1, p2);
		}
		if (gopoint2)
		{
			go(p3, p4);
		}
		if (play) {
			anim.SetBool("walk", false);
			agent.stoppingDistance = range / 2;
			agent.speed = run;
			agent.SetDestination(player.transform.position);
			dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist > range)
			{
				anim.SetBool("fastrun", true);
			}
			else
			{
				anim.SetBool("fastrun", false);
			}
		}
		
	}
	void go(GameObject p1,GameObject p2)
	{
		
			anim.SetBool("walk", true);
			dist = Vector3.Distance(p1.transform.position, transform.position);
			if (dist > 10)
			{
				agent.SetDestination(p1.transform.position);
			}
			else
			{
				dist = Vector3.Distance(p2.transform.position, transform.position);
				agent.SetDestination(p2.transform.position);
				if (dist < 2)
				{
					anim.SetBool("walk", false);
				}
			}
		
	}
}
