using UnityEngine;
using UnityEngine.AI;

public class NurseMadnessSecondFloor : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool running;
    public bool walking;
    public AudioSource RunningSound;
    private void Update()
    {
        walking = isMoving();

        if (running && isMoving())
        {
            agent.speed = 8f;
            NurseMadnessController.Instance.Running();
            if (!RunningSound.isPlaying)
                RunningSound.Play();
        }
        else
        {
            agent.speed = 3.5f;
            NurseMadnessController.Instance.StopRunning();
            RunningSound.Stop();
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
