using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_beat : MonoBehaviour
{
	// Start is called before the first frame update
	bool leftroom;
	bool rightroom;
	
	public point_check point_chair;
	public point_check on_left_room;
	public point_check on_right_room;
	public point_check on_lift;
	public GameObject ghost_HM;
	public GameObject ghost_HM2;
	public float max_time = 0.5f;
	public broken_ghost broken;
	float timer = 0;
	int co = 3;
	public AudioSource audio;
	go_point go;
	
	void Start()
    {
		go = ghost_HM.GetComponent<go_point>();
		
	}

    // Update is called once per frame
    void Update()
    {
		timer -= Time.deltaTime;
		if (point_chair.state == true)
		{
			ghost_HM.SetActive(false);
			
		}
		
		if (on_left_room.state == true && leftroom == false) // ไปทางซ้ายด้วยไม่ผ่านทางขวาเท่านั้น
		{
			leftroom = true;
			ghost_HM.SetActive(true);
			broken.enabled=true;
			audio.enabled = true;
			if (rightroom == false)
			{
				ghost_HM.SetActive(true);
			}
			



		}
		if (on_right_room.state == true && rightroom==false) //ไปทางขวาด้วยยังไม่ไปทางซ้าย
		{
			rightroom = true;
			ghost_HM.SetActive(true);
			if (leftroom == false)
			{
				
				
				go.enabled = true;
			}
			
			
			

			// เจอตัวนี้ในชั้น 2 อีกรอบ
		}
		if (rightroom == true && leftroom == true) //ไปทางขวาด้วยผ่านทางซ้ายมาแล้ว
		{
			if (on_lift.state == true)
			{
				go.enabled = true;
			}
		}

	}
}
