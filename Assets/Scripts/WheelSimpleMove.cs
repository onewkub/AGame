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
    public float moveCooldown = 1.85f;
    public float movingTime = 0.925f;
    private float sinceLastMove = 0f;


    public void GetInput()
    {
        
        if (Input.GetAxis("VerticalLeft") > 0 || Input.GetAxis("VerticalRight") > 0)
        {
            if (sinceLastMove <= 0)
            {
                m_leftVertical = Input.GetAxis("VerticalLeft");
                m_rightVertical = Input.GetAxis("VerticalRight");
                isBraking = false;
                sinceLastMove = moveCooldown;
            }
            else if (sinceLastMove < moveCooldown - movingTime)
            {
                isBraking = true;
                m_leftVertical = 0;
                m_rightVertical = 0;
            }
        }
        else
        {
            sinceLastMove = 0;
            isBraking = true;
            m_leftVertical = 0;
            m_rightVertical = 0;
        }
        sinceLastMove -= Time.deltaTime;

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

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        WheelsMove();
        BrakeWheel(); 

    }
}
