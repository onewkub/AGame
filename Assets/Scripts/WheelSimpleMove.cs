using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSimpleMove : MonoBehaviour
{
    public WheelCollider leftWheel, rightWheel;
    public Transform leftWheelT, rightWheelT;
    public float motorForce = 100f;
    public float BrakePower = 50f;
    private bool isBraking = false;

    private float m_leftVertical, m_rightVertical;


    public void GetInput()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            isBraking = true;
            m_leftVertical = 0f;
            m_rightVertical = 0f;
        }
        else
        {
            m_leftVertical = Input.GetAxis("VerticalLeft");
            m_rightVertical = Input.GetAxis("VerticalRight");
            isBraking = false;
        }

    }
    
    private void WheelsMove()
    {
        leftWheel.motorTorque = motorForce * m_leftVertical;
        rightWheel.motorTorque = motorForce * m_rightVertical;
    }

    private void BrakeWheel()
    {

        if (isBraking)
        {

            leftWheel.brakeTorque = BrakePower;
            rightWheel.brakeTorque = BrakePower;
        }
        else
        {
            leftWheel.brakeTorque = 0f;
            rightWheel.brakeTorque = 0f;
        }
        

    }

    private void FixedUpdate()
    {
        GetInput();
        WheelsMove();
        BrakeWheel(); 

    }
}
