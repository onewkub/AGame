using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtter : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.LookAt(target);
        transform.RotateAround(transform.position, transform.up, 180f);
    }
}
