using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform cameraView;
    public float maxRange = 10f;

    private void PointObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraView.position, cameraView.transform.forward, out hit, maxRange))
        {
            Debug.Log(hit.transform.name);
        } 
    }
    private void Update()
    {
        if (Input.GetButton("RightBumper"))
        {
            PointObject();
        }
    }

}
