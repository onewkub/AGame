using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class movement_ghost : MonoBehaviour
{
	Animator anim;
	NavMeshAgent agent;
	public GameObject player;
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
		

		agent.SetDestination(player.transform.position);
	    dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist > 5)
		{
			anim.SetBool("walk", true);
			agent.SetDestination(player.transform.position);
			
		}
		else
		{
			anim.SetBool("walk", false);
			anim.SetTrigger("attack");
		}
	}
}
