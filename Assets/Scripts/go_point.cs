using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class go_point : MonoBehaviour
{
	NavMeshAgent nav;
    // Start is called before the first frame update
	public GameObject point_go;
    Animator anim;
	AudioSource audio;
	float distace;
    void Start()
    {
		nav = gameObject.GetComponent<NavMeshAgent>();
		anim = gameObject.GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
		audio.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
		anim.SetBool("fastrun", true);
		nav.SetDestination(point_go.transform.position);
		distace = Vector3.Distance(gameObject.transform.position, point_go.transform.position);
		if (distace <= 1)
		{
			gameObject.SetActive(false);
		}
    }
}
