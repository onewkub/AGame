using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWheelMove : MonoBehaviour
{
    public WheelCollider leftWheel, rightWheel;
    public Transform leftWheelT, rightWheelT;
    public float motorForce = 100f;
    public float BrakePower = 50f;
    private bool isBraking = false;
    public string VerticalLeft;
    public string VerticalRight;
    private float m_leftVertical, m_rightVertical;
    public Slider staminaBar;
    public float totalStamina = 10;
    public float currentStamina = 10;
    private bool tiredStatus = false;

    public void GetInput()
    {
        if (tiredStatus && currentStamina >= totalStamina/2)
        {
            tiredStatus = false;
        }
        if(currentStamina <= 0)
        {
            m_leftVertical = 0;
            m_rightVertical = 0;
            tiredStatus = true;
            currentStamina += Time.deltaTime;
        }
        else if (Mathf.Abs(Input.GetAxis(VerticalLeft)) == 1 && Mathf.Abs(Input.GetAxis(VerticalRight)) == 1 && !tiredStatus)
        {
                m_leftVertical = Input.GetAxis(VerticalLeft);
                m_rightVertical = Input.GetAxis(VerticalRight);
                isBraking = false;
                currentStamina -= Time.deltaTime;

        }
        else if (Mathf.Abs(Input.GetAxis(VerticalLeft)) == 1f && !tiredStatus)
        {

                m_leftVertical = Input.GetAxis(VerticalLeft);
                m_rightVertical = 0f;
                isBraking = false;
                currentStamina -= Time.deltaTime;

        }
        else if (Mathf.Abs(Input.GetAxis(VerticalRight)) == 1 && !tiredStatus)
        {
                m_leftVertical = 0f;
                m_rightVertical = Input.GetAxis(VerticalRight);
                isBraking = false;
                currentStamina -= Time.deltaTime;

        }
        else
        {
            m_leftVertical = 0f;
            m_rightVertical = 0f;
            if (currentStamina < totalStamina)
            {
                if (tiredStatus)
                    currentStamina += Time.deltaTime * 0.75f;
                else
                    currentStamina += Time.deltaTime;
            }

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

    private void UpdateStaminaBar()
    {
        staminaBar.value = currentStamina / totalStamina;
    }

    private void WheelsPoseUpdate()
    {
        WheelPoseUpdate(leftWheel, leftWheelT);
        WheelPoseUpdate(rightWheel, rightWheelT);

    }

    private void WheelPoseUpdate(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;
        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }
    private void Update()
    {
        GetInput();

    }

    private void FixedUpdate()
    {
        WheelsMove();
        WheelsPoseUpdate();
        BrakeWheel();
        UpdateStaminaBar();
        Debug.Log(currentStamina);
    }
}
