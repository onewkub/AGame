using UnityEngine;

public class point_map : MonoBehaviour
{
	// Start is called before the first frame update
	public point_check point_stop;
	public point_check point_stop2;
	public point_check point_stop3;
	public point_check point_ghost_head1;
	public point_check point_ghost_in_room;
	public point_check point_hide;
	public movement_ghost move;
	public move_ghost nursemove;
	public GameObject nurse;
	float timer = 0;
	public bool  playerstop=false;
	//public WheelChairMovement playermove;
	float timerstop=0;
	public float timestop = 0;
	public AudioSource ting;
	public AudioSource lift;
	float timers =1.5f;
	public AudioSource audio;

	void Start()
    {
		ElevatorController.Instance.openElevator();

	}

    // Update is called once per frame
    void Update()
    {
		
		timerstop -= Time.deltaTime;
		if (timerstop <= 0)
		{
            PlayerMovement.Instance.agent.Resume();
		}
		if (point_ghost_in_room.ghost_state == false )
		{
			nursemove.playerhide = point_hide.state;
			if (nursemove.backlift)
			{
				nursemove.playerhide = true;
			}

		}
		
		
		if (point_stop.state == true)
		{
			if (playerstop == false)
			{
				timerstop = timestop;
                //playermove.enabled = false;
				
                PlayerMovement.Instance.agent.Stop();
				playerstop = true;
			}
			move.gopoint = true;
			nursemove.backlift = false;
			nursemove.playerhide = false;
		}
		if (point_stop2.state == true)
		{
			move.gopoint = false;
			move.gopoint2 = true;
			nursecome();
		}
		if (point_stop3.state == true)
		{
			move.gopoint2 = false;
			move.play = true;
			nursecome();

		}
	}
	void nursecome()
	{
		timers -= Time.deltaTime;
		nurse.SetActive(true);
		ting.enabled = true;
		if (timers <= 0)
		{
			
			lift.enabled = true;
		}
		

	}

}

