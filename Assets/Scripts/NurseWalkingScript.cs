using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NurseWalkingScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform FirstPos;
    public Transform StartPos;
    public Transform FinalPos;
    public Transform StandPos;
    public GameObject WheelChair;

    private NursePull nuresPull;
    private WheelChairSimpleMove newWheelMove;

    private void Awake()
    {
       StartCoroutine(WaitElevatorOpen());
        nuresPull = WheelChair.GetComponent<NursePull>();
        newWheelMove = WheelChair.GetComponent<WheelChairSimpleMove>();
    }

    private void SwitchCoroutine()
    {
        StartCoroutine(WaitUntillTarget());

    }

    IEnumerator WaitElevatorOpen()
    {
        yield return new WaitForSeconds(3);
        navMeshAgent.SetDestination(FirstPos.position);
        SwitchCoroutine();
    }
    IEnumerator WaitUntillTarget()
    {
        //Debug.Log("Im here");
        yield return new WaitWhile(() => DistanceToTarget(FirstPos));
        navMeshAgent.SetDestination(StartPos.position);
        yield return new WaitWhile(() => DistanceToTarget(StartPos));
        nuresPull.enabled = false;
        newWheelMove.enabled = true;
        navMeshAgent.SetDestination(FinalPos.position);
        yield return new WaitWhile(() => DistanceToTarget(FinalPos));
        newWheelMove.OpenWheelCollider();
        navMeshAgent.SetDestination(StandPos.position);


    }
    private bool DistanceToTarget(Transform destination) {
        //Debug.Log(Vector3.Distance(transform.position, destination.position));
        if(Vector3.Distance(transform.position, destination.position) <= 0.5f)
        {
            return false;
        }
        return true;
    }
}
