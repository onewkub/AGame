﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactItem : MonoBehaviour
{
    public GameObject canvas;
    public Transform objectToLook;
    public GameObject openTrigger;
    public GameObject closeTrigger;

    private bool PlayerOnArea = false;
    private void Start()
    {
        canvas.SetActive(false);
    }

    private void Update()
    {
        lookAtObject();
        if(Input.GetKey(KeyCode.E) && PlayerOnArea)
        {
            Destroy(gameObject);
        }
    }



    private void lookAtObject()
    {
        canvas.transform.LookAt(objectToLook, Vector3.up);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canvas.SetActive(true);
            PlayerOnArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(false);
            PlayerOnArea = false;
        }
    }
    private void OnDestroy()
    {
        Debug.Log("Weeh");
        Debug.Log(gameObject.tag);
        if(gameObject.tag == "Key")
        {
            Debug.Log("Get Key");
            Inventory.inventory.Key = true;
        }
        else if(gameObject.tag == "Flashlight")
        {
            Debug.Log("Get Flashlight");
            Inventory.inventory.FlashLight = true;
        }
        openTrigger.SetActive(true);
        closeTrigger.SetActive(true);
    }
}