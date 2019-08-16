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
	public float range = 7;
	public float delay = 10;
    float timer = 10;
	public float run = 7f;
	public GameObject point_frontlift;
	public GameObject point_find;
	AudioSource audio;
    //public WheelChairMovement move;
    //public GameObject inHiddingSpot;
    //public GameObject Escape;
    public GameObject Head;
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
			agent.stoppingDistance = range-2;
			timer += Time.deltaTime;
			agent.SetDestination(player.transform.position);
			dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist < range)
			{
				audio.enabled = false;
				anim.SetBool("isRunning", false);
                PlayerMovement.Instance.agent.Stop();

                if (timer >= delay)
				{
                    Rigidbody HeadCut = Head.GetComponent<Rigidbody>();
                    Head.GetComponent<BoxCollider>().enabled = true;
                    HeadCut.freezeRotation = false;
                    HeadCut.useGravity = true;
                    HeadCut.AddForceAtPosition(Vector3.left, Head.transform.forward);
                    end_game.Instance.PlayerIsDead();
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
					//move.enabled = false;
					
				}
				if (timerfindplayer < 0)
				{
                    //move.enabled = true;
                    Debug.Log("Done");
                    //inHiddingSpot.GetComponent<ChooseTheWay>().Left = Escape;
                    AutoPlay.Instance.itTrigger();
                    PlayerMovement.Instance.agent.Resume();
					backlift = true;
					audio.enabled = true;
					anim.SetBool("isRunning", true);
					anim.SetBool("findplayer", false);
				}
			}
			
		}
		
	}
}
