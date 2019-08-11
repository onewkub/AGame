using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class NormalNurse : MonoBehaviour
{

    public NurseWalkingF1Script F1Script;
    public NurseAnimatorController nurseController;
    public NavMeshAgent agent;
    public Scene scene;



    private void Start()
    {
        scene = SceneManager.GetActiveScene();
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
            nurseController.isWalking();
        else nurseController.stopWalking();


    }


    private void OnLevelWasLoaded(int level)
    {
        transform.position = GameManager.gameManager.NursePos;
        transform.rotation = GameManager.gameManager.NurseRot;
    }


}
