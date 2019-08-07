using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    public Transform wheelLeft, wheelRight, sWheelLeft, sWheelRight;
    private float m_vertical;
    private float m_horizontal;
    
    private CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    private void getInput()
    {
        m_vertical = Input.GetAxis("VerticalLeft");
        m_horizontal = Input.GetAxis("HorizontalLeft");
    }

    private void rotate()
    {
        if (m_vertical < 0)       
            transform.Rotate(0f, rotateSpeed * -m_horizontal * Time.deltaTime, 0f);
        else
            transform.Rotate(0f, rotateSpeed * m_horizontal * Time.deltaTime, 0f);
    }

    private void movement()
    {
        controller.SimpleMove(moveSpeed * transform.forward * m_vertical * Time.deltaTime);
    }

    private void wheelRotate()
    {
        wheelLeft.Rotate(controller.velocity.magnitude + m_horizontal * rotateSpeed/36f, 0f, 0f);
        wheelRight.Rotate(controller.velocity.magnitude - m_horizontal * rotateSpeed/36f, 0f, 0f);
        sWheelLeft.Rotate(controller.velocity.magnitude + m_horizontal, 0f, 0f);
        sWheelRight.Rotate(controller.velocity.magnitude + m_horizontal, 0f, 0f);

    }


    private void FixedUpdate()
    {
        getInput();
        movement();
        rotate();
        wheelRotate();
    }

}
