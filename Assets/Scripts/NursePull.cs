using UnityEngine;

public class NursePull : MonoBehaviour
{
    //private WheelChairMovement Controlable;
    public Transform ObjectToFollow;
    public Vector3 offset;
    public float followSpeed = 10f;
    public float lookSpeed = 10f;

    private void Start()
    {
        //Controlable = GetComponent<WheelChairMovement>();
        //Controlable.enabled = false;
    }
    public void followTarget()
    {
        Vector3 _targetPos = ObjectToFollow.position +
            ObjectToFollow.forward * offset.z +
            ObjectToFollow.right * offset.x +
            ObjectToFollow.up * offset.y;
        transform.position = _targetPos;
    }

    public void lookAtTarget()
    {

        transform.rotation = ObjectToFollow.rotation;
    }
    private void Update()
    {
        followTarget();
        lookAtTarget();
    }
}
