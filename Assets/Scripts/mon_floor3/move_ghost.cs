using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move_ghost : MonoBehaviour
{


	Animator anim;
	NavMeshAgent agent;
	public bool idle =false;
	public float timerfindplayer=4;
	public bool backlift=false;
	public GameObject player;
	public bool playerhide;
	float dist;
	public float range = 5;
	public float delay = 10;
    float timer = 10;
	public float run = 7f;
	public GameObject point_frontlift;
	public GameObject point_find;
	AudioSource audio;
	// Start is called before the first frame update
	void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		audio = gameObject.GetComponent<AudioSource>();
		agent.speed = run;
	}

    // Update is called once per frame
    void Update()
    {
		
		if (!playerhide)
		{
			audio.enabled = true;
			agent.speed = 5f;
			agent.stoppingDistance = range;
			timer += Time.deltaTime;
			agent.SetDestination(player.transform.position);
			dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist < range)
			{
				audio.enabled = false;
				anim.SetBool("isRunning", false);
				if (timer >= delay)
				{
					
					anim.SetTrigger("isHitting");
					timer = 0;
				}
				
				

			}
			else
			{
				anim.SetBool("isRunning", true);
			}
		}
		else
		{
			if (backlift)
			{
				audio.enabled = true;
				agent.speed = 5f;
				agent.SetDestination(point_frontlift.transform.position);
				dist = Vector3.Distance(point_frontlift.transform.position, transform.position);
				if (dist <=3)
				{
					audio.enabled = false;
					anim.SetBool("isRunning", false);
					anim.SetBool("Angry", true);
					timerfindplayer = 5;
				}
			}
			else{
				audio.enabled = true;
				agent.SetDestination(point_find.transform.position);
				agent.stoppingDistance = 0;
				dist = Vector3.Distance(point_find.transform.position, transform.position);
				if (dist <= 3)
				{
					audio.enabled = false;
					anim.SetBool("isRunning", false);
					anim.SetBool("findplayer", true);
					timerfindplayer -= Time.deltaTime;
					
				}
				if (timerfindplayer < 0)
				{
					backlift = true;
					audio.enabled = true;
					anim.SetBool("isRunning", true);
					anim.SetBool("findplayer", false);
				}
			}
			
		}
		
	}
}
