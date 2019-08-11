using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactItem : MonoBehaviour
{
    public GameObject canvas;
    public Transform objectToLook;

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
        Debug.Log("Weeh!!!!");   
    }
}
