using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    static public PlayerMovement Instance { get; set; }
    public NavMeshAgent agent;
    public float RotateSpeed;
    private float initYRotation;
    private Quaternion originRotation;
    private bool Rotate;
    private Quaternion targetRotation;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        originRotation = transform.rotation;
    }
	public bool isWalking = false;
    private void Update()
    {
        if (Rotate)
        {
            if (transform.rotation == targetRotation)
                Rotate = false;
            else
                turnToRotation();
        }
		if (agent != null && agent.hasPath && agent.remainingDistance >= 3f)
		{
			//Debug.Log("walk");

			isWalking = true;
		}
		else if(agent != null)
		{
			//Debug.Log("idle");
			isWalking = false;
		}
    }
    public void turnToRotation()
    {
        transform.rotation = Quaternion.RotateTowards(targetRotation, originRotation, RotateSpeed*Time.deltaTime);
        
    }
    public void RotateToTarget(Quaternion target)
    {
        targetRotation = target;
        Rotate = true;
    }
}
