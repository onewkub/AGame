using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move_ghost : MonoBehaviour
{


	Animator anim;
	NavMeshAgent agent;
	public GameObject player;
	float dist;
	public float range = 5;
	
	public float run = 7f;
	// Start is called before the first frame update
	void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		agent.stoppingDistance = range / 2;
		agent.speed = run;
	}

    // Update is called once per frame
    void Update()
    {
	
		agent.SetDestination(player.transform.position);
		dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist > range)
		{
			anim.SetBool("run", true);
		}
		else
		{
			anim.SetBool("run", false);
			anim.SetTrigger("attack");
		}
	}
}
