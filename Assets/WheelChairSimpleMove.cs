using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairSimpleMove : MonoBehaviour
{
    public WheelCollider LeftWheel, RightWheel, FrontLeftWheel, FrontRightWheel;
    public Transform LeftWheelTransform, RightWheelTransform, FrontLeftWheelTransform, FrontRightWheelTransform;
    public float ForceWheel = 10f;
    public float BrakeFroce = 5f;

    private float m_horizontal;
    private float m_vertical;
    private float maxSteerAngle = 40f;
    private float m_steerAngle;
    private bool isBrake = false;

    private void GetInput()
    {
        m_horizontal = Input.GetAxis("HorizontalLeft");
        m_vertical = Input.GetAxis("VerticalLeft");
        isBrake = Input.GetButton("RightBumper");
    }
    private void Steer()
    {
        m_steerAngle = maxSteerAngle * m_horizontal;
        FrontLeftWheel.steerAngle = m_steerAngle;
        FrontRightWheel.steerAngle = m_steerAngle;
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
    
    private void Accelerate()
    {
        if (!isBrake)
        {
            if(m_vertical != 0)
            {
                //Debug.Log("GO Forward");
                LeftWheel.motorTorque = m_vertical * ForceWheel;
                RightWheel.motorTorque = m_vertical * ForceWheel;

            }
            else if(m_vertical == 0 && m_horizontal != 0)
            {
                if(m_horizontal < 0)
                {
                    //Debug.Log("turnLeft");
                    LeftWheel.motorTorque = -ForceWheel * 0.7f;
                    RightWheel.motorTorque = ForceWheel * 0.7f;
                }
                else if(m_horizontal > 0)
                {
                    //Debug.Log("turnRight");
                    LeftWheel.motorTorque = ForceWheel * 0.7f;
                    RightWheel.motorTorque = -ForceWheel * 0.7f;
                }
            }
            else
            {
                RightWheel.motorTorque = 0f;
                LeftWheel.motorTorque = 0f;
            }

        }
        else
        {

            RightWheel.motorTorque = 0f;
            LeftWheel.motorTorque = 0f;
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
    public void OpenWheelCollider()
    {
        LeftWheel.enabled = true;
        RightWheel.enabled = true;
        FrontLeftWheel.enabled = true;
        FrontRightWheel.enabled = true;
    }
    private void Update()
    {
        Debug.Log(m_horizontal + " " + m_vertical);
        GetInput();
        Steer();
        Brake();
        Accelerate();
        UpdateWheelPoses();
    }
}
