using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class NormalNurse : MonoBehaviour
{

    public NurseWalkingF1Script F1Script;
    public NurseAnimatorController nurseController;
    public NavMeshAgent agent;
    public GameObject Sound;
    private AudioSource walkingSound;
    private Scene scene;
    
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        walkingSound = Sound.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (scene.name == "FirstFloor_start" || F1Script == null) 
        {
            if (F1Script.nurseWheelChairState())
                nurseController.withWheelchair();
            else nurseController.stopWithWheelchair();

        }
        if (agent.remainingDistance > 0.5f)
        {
            Debug.Log("NurseWalking");
            nurseController.isWalking();
            if (!walkingSound.isPlaying) walkingSound.Play();

        }
        else
        {
            Debug.Log("NurseNotWalking");
            walkingSound.Stop();
            nurseController.stopWalking();
        }

    }


    private void OnLevelWasLoaded(int level)
    {
        if(level != 1)
        {
            transform.position = GameManager.gameManager.NursePos;
            transform.rotation = GameManager.gameManager.NurseRot;

        }
    }


}
