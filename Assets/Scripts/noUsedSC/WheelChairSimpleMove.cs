using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairSimpleMove : MonoBehaviour
{
    public WheelCollider LeftWheel, RightWheel, FrontLeftWheel, FrontRightWheel;
    public Transform LeftWheelTransform, RightWheelTransform, FrontLeftWheelTransform, FrontRightWheelTransform;
    public float ForceWheel = 10f;
    public float BrakeFroce = 5f;
    public float maxSpeed = 1f;


    private float m_horizontal;
    private float m_vertical;
    private float m_steerAngle;
    private bool isBrake = false;


    private void GetInput()
    {
        m_horizontal = Input.GetAxis("HorizontalLeft");
        m_vertical = Input.GetAxis("VerticalLeft");
        isBrake = Input.GetButton("RightBumper");
    }
    private void Accelerate()
    {
        if (m_vertical == 0)
        {
            LeftWheel.motorTorque = m_horizontal * ForceWheel ;
            RightWheel.motorTorque = m_horizontal * ForceWheel * -1 ;
        }
        else
        {
            LeftWheel.motorTorque = m_vertical * (Mathf.Abs(m_vertical) * ForceWheel + m_horizontal * ForceWheel);
            RightWheel.motorTorque = m_vertical * (Mathf.Abs(m_vertical) * ForceWheel - m_horizontal * ForceWheel);

        }
    }
    private void Brake()
    {
        if (isBrake)
        {
            LeftWheel.brakeTorque = BrakeFroce;
            RightWheel.brakeTorque = BrakeFroce;

        }
        else
        {
            LeftWheel.brakeTorque = 0f;
            RightWheel.brakeTorque = 0f;
        }
    }
    private void UpdateWheelPoses()
        {
            UpdateWheelPose(FrontLeftWheel, FrontLeftWheelTransform);
            UpdateWheelPose(FrontRightWheel, FrontRightWheelTransform);
            UpdateWheelPose(LeftWheel, LeftWheelTransform);
            UpdateWheelPose(RightWheel, RightWheelTransform);
        }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
        {
            Vector3 _pos = _transform.position;
            Quaternion _quat = _transform.rotation;

            _collider.GetWorldPose(out _pos, out _quat);
            _transform.position = _pos;
            _transform.rotation = _quat;
        }

    public void OpenWheelCollider()
    {
        LeftWheel.enabled = true;
        RightWheel.enabled = true;
        FrontRightWheel.enabled = true;
        FrontLeftWheel.enabled = true;
    }
    private void Update()
    {
        //Debug.Log(rigidbody.velocity.magnitude);
        GetInput();
        Brake();
        Accelerate();
        UpdateWheelPoses();
    }
}
