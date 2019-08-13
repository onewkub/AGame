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
        if(Mathf.Abs(Input.GetAxis("VerticalLeft")) > 0.1f)
        {
            m_vertical = Input.GetAxis("VerticalLeft");

        }
        else
        {
            m_vertical = 0f;
        }
        if(Mathf.Abs(Input.GetAxis("HorizontalLeft")) > 0.1f)
        {
            m_horizontal = Input.GetAxis("HorizontalLeft");

        }
        else
        {
            m_horizontal = 0f;
        }
        //Debug.Log(m_vertical + " " + m_horizontal);

    }

    private void rotate()
    {
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
