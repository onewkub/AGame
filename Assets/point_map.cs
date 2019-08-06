using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_map : MonoBehaviour
{
	// Start is called before the first frame update
	public point_check point_stop;
	public point_check point_stop2;
	public point_check point_stop3;
	public point_check point_ghost_head1;
	public movement_ghost move;
	public GameObject nurse;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(point_stop.state == true)
		{
			move.gopoint = true;
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
