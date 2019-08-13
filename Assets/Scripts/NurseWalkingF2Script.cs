using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NurseWalkingF2Script : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform LastPos;
    private void Awake()
    {
        StartCoroutine(SetPosition());
    }

    IEnumerator SetPosition()
    {
        yield return new WaitForSeconds(3);
        navMeshAgent.SetDestination(LastPos.position);
        
    }
}


