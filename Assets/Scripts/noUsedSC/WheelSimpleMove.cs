using UnityEngine;

public class WheelSimpleMove : MonoBehaviour
{
    public WheelCollider leftWheel, rightWheel;
    public Transform leftWheelT, rightWheelT;
    public float motorForce = 100f;
    public float BrakePower = 50f;
    private bool isBraking = false;
    public string VerticalLeft;
    public string VerticalRight;
    private float m_leftVertical, m_rightVertical;
    public float moveCooldown = 1.85f;
    public float movingTime = 0.925f;
    private float sinceLastMove = 0f;

    public void GetInput()
    {
        
        if (Input.GetAxis(VerticalLeft) !=0f || Input.GetAxis(VerticalRight) !=0f )
        {
            if (sinceLastMove <= 0f)
            {
                m_leftVertical = Input.GetAxis(VerticalLeft);
                m_rightVertical = Input.GetAxis(VerticalRight);
                //Debug.Log($"{m_leftVertical} {m_rightVertical}");
                isBraking = false;
                sinceLastMove = moveCooldown;
            }
            else if (sinceLastMove < moveCooldown - movingTime)
            {
                //isBraking = true;
                m_leftVertical = 0f;
                m_rightVertical = 0f;
            }
        }
        #if UNITY_EDITOR
        //for debug (this move both wheel at once)
        else if (Input.GetAxis("RightTrigger") != 0f){
            if (sinceLastMove <= 0f) {
                m_leftVertical = Input.GetAxis("RightTrigger");
                m_rightVertical = Input.GetAxis("RightTrigger");
                isBraking = false;
                sinceLastMove = moveCooldown;
            }
            else if(sinceLastMove < moveCooldown - movingTime)
            {
                //isBraking = true;
                m_leftVertical = 0f;
                m_rightVertical = 0f;
            }
        }
        #endif
        else if(Input.GetAxis("LeftTrigger") != 0f)
        {
            if (sinceLastMove <= 0f)
            {
                m_leftVertical = -Input.GetAxis("LeftTrigger");
                m_rightVertical = -Input.GetAxis("LeftTrigger");
                isBraking = false;
                sinceLastMove = moveCooldown;
            }
            else if(sinceLastMove < moveCooldown - movingTime)
            {
                //isBraking = true;
                m_leftVertical = 0f;
                m_rightVertical = 0f;
            }
        }

        else
        {
            sinceLastMove = 0f;
            isBraking = true;
            m_leftVertical = 0f;
            m_rightVertical = 0f;
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
        Debug.Log(sinceLastMove);
    }
}
