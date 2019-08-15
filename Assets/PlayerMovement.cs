using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    static public PlayerMovement Instance { get; set; }
    public float RotateSpeed = 50f;
    private NavMeshAgent agent;
    private float initYRotation;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (agent.remainingDistance <= 0f)
        {
            Debug.Log("Im not walking");
        }
    }
    public void SetDestination(Vector3 target)
    {
        agent.SetDestination(target);
    }
}
