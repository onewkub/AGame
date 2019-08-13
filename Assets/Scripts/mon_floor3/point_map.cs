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
	public WheelChairMovement playermove;
	float timerstop=0;
	public float timestop = 0;
	void Start()
    {
		;
	}

    // Update is called once per frame
    void Update()
    {
		timerstop -= Time.deltaTime;
		if (timerstop <= 0)
		{
			playermove.enabled = true;
		}
		if (point_ghost_in_room.ghost_state == false )
		{
			if (point_hide.state){
				nursemove.playerhide = true;
			}
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
				playermove.enabled = false;
				playerstop = true;
			}
			move.gopoint = true;
			nursemove.idle = false;
			nursemove.playerhide = false;
		}
		if (point_stop2.state == true)
		{
			move.gopoint = false;
			move.gopoint2 = true;
			nurse.SetActive(true);
		}
		if (point_stop3.state == true)
		{
			move.gopoint2 = false;
			move.play = true;
		}
	}

}
