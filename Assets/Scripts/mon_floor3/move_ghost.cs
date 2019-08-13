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
	// Start is called before the first frame update
	void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		agent.stoppingDistance = range;
		agent.speed = run;
	}

    // Update is called once per frame
    void Update()
    {
		if (idle)
		{
			return;
		}
		if (!playerhide)
		{
			timer += Time.deltaTime;
			agent.SetDestination(player.transform.position);
			dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist < range && timer >= delay)
			{
				anim.SetBool("run", false);
				anim.SetTrigger("attack");
				timer = 0;

			}
			else
			{
				anim.SetBool("run", true);
			}
		}
		else
		{
			if (backlift && timerfindplayer<0)
			{
				
				agent.SetDestination(point_frontlift.transform.position);
				dist = Vector3.Distance(point_frontlift.transform.position, transform.position);
				if (dist <=7)
				{
					timerfindplayer = 4;
					backlift = false;
					idle = true;
					
				}
			}
			else{
				agent.SetDestination(point_find.transform.position);
				dist = Vector3.Distance(point_find.transform.position, transform.position);
				if (dist <= 7)
				{
					backlift = true;
					timerfindplayer -= Time.deltaTime;
				}
			}
			
		}
		
	}
}
