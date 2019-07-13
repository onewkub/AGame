using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform ObjectToFollow;
    public Vector3 offset;
    public float followSpeed = 10f;
    public float lookSpeed = 10f;

    public void lookAtTarget()
    {
        Vector3 _lookDirection = ObjectToFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }

    public void followTarget()
    {
        Vector3 _targetPos = ObjectToFollow.position +
            ObjectToFollow.forward * offset.z +
            ObjectToFollow.right * offset.x +
            ObjectToFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        lookAtTarget();
        followTarget();
    }
}
