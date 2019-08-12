using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NurseMadnessSecondFloor : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool running;
    public bool walking;

    private void Update()
    {
        walking = isMoving();

        if (running && isMoving())
        {
            agent.speed = 5f;
            NurseMadnessController.Instance.Running();
        }
        else
        {
            agent.speed = 3.5f;
            NurseMadnessController.Instance.StopRunning();
        }

        if (walking)
        {
            NurseMadnessController.Instance.Walking();
        }
        else
        {
            NurseMadnessController.Instance.StopWaling();
        }
    }

    public void SetTargetPostion(Transform targer)
    {
        agent.SetDestination(targer.position);
    }

    public bool isMoving()
    {
        if(agent.remainingDistance >= 0.5)
        {
            return true;
        }
        return false;
    }
   
}
