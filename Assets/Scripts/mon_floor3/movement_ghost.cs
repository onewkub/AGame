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
	//WheelChairMovement moveplayer;
	public float time_hold = 3;
	float timer_hold = 0;
	public float time_stun = 3;
	float timer_stun = 0;
	bool hold;
	bool stun;
	float dist;
	public move_ghost nursemove;
	public GameObject nurse;
	AudioSource audio;
	public AudioSource hit_head;
	
	bool idle = false;
	// Start is called before the first frame update
	void Start()
    {
		audio = gameObject.GetComponent<AudioSource>();
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		//moveplayer = player.GetComponent<WheelChairMovement>();
		audio.enabled = false;

	}

	// Update is called once per frame
	void Update()
	{
		if (idle)
		{
			hit_head.enabled = true;
		}
		else
		{
			hit_head.enabled = false;
		}
		if (gopoint) {
			go(p1, p2);
		}
		if (gopoint2)
		{

			go(p3, p4);

		}
		if (play) {
			idle = false;
			audio.enabled = true;
			anim.SetBool("walk", false);
			anim.SetBool("fastrun", true);
			if(hold)
			{
				audio.enabled = false;
				
				nursemove.backlift = false;
				nursemove.playerhide = false;
				timer_hold -= Time.deltaTime;
				anim.SetBool("holdplayer",true);
				//moveplayer.enabled = false;
				if (timer_hold<0)
				{
					
					hold = false;
					stun = true;
				}
				timer_stun = time_stun ;

			}
			if (stun)
			{
				audio.enabled = false;
				agent.SetDestination(transform.position);
				timer_stun -= Time.deltaTime;
				if (timer_stun < 0)
				{
					anim.SetBool("holdplayer", false);
					stun = false;
					audio.enabled = true;
				}
			}
			else
			{
				idle = false;
				agent.SetDestination(player.transform.position);
			}
			agent.stoppingDistance = range;
			agent.speed = run;
			
			dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist < range &&  !hold && ! stun)
			{
				gameObject.transform.LookAt(player.transform.position);
				timer_hold = time_hold;
				hold = true;
			}
			
		}
		
	}
	void go(GameObject p1,GameObject p2)
	{
			idle = false;
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
				if (dist <= 3 )
				{
					anim.SetBool("walk", false);
					gopoint2 = false;
					idle = true;
				}
			}
		
	}
}
