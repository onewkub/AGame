using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float walkSpeed;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        playerMovement();
    }

    private void playerMovement()
    {
        float HorizInput = Input.GetAxis("Horizontal");
        float VertInput = Input.GetAxis("Vertical");
        bool isWalking = !Mathf.Approximately(HorizInput, 0f) || !Mathf.Approximately(VertInput, 0f);
        Vector3 moveForward = transform.forward * VertInput;
        Vector3 moveSide = transform.right * HorizInput;

        //Debug.Log(HorizInput + " " + VertInput);


        if (isWalking)
        {
                characterController.SimpleMove((moveForward + moveSide) * walkSpeed);
        }
    }
}