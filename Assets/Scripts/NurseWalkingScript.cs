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
    public Transform LastPos;
    public GameObject WheelChair;
    public GameObject CloseTrigger;
    public bool PlayerNotArrive = true;

    private NursePull nuresPull;
    private WheelChairMovement newWheelMove;
    private ElevatorClose elevatorClose;
    private void Awake()
    {
       StartCoroutine(SetPosition());
        nuresPull = WheelChair.GetComponent<NursePull>();
        newWheelMove = WheelChair.GetComponent<WheelChairMovement>();
        elevatorClose = CloseTrigger.GetComponent<ElevatorClose>();
    }


    IEnumerator SetPosition()
    {
        yield return new WaitForSeconds(3);
        navMeshAgent.SetDestination(FirstPos.position);
        //transform.Translate(FirstPos.position, Space.World);
        //Debug.Log("Im here");
        yield return new WaitWhile(() => DistanceToTarget(FirstPos));
        navMeshAgent.SetDestination(StartPos.position);
        yield return new WaitWhile(() => DistanceToTarget(StartPos));
        nuresPull.enabled = false;
        newWheelMove.enabled = true;
        navMeshAgent.SetDestination(FinalPos.position);
        yield return new WaitWhile(() => DistanceToTarget(FinalPos));
        navMeshAgent.SetDestination(StandPos.position);
        yield return new WaitWhile(() => PlayerNotArrive);
        navMeshAgent.SetDestination(LastPos.position);
        yield return new WaitWhile(() => DistanceToTarget(LastPos));
        elevatorClose.NurseNotArrive = false;

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
