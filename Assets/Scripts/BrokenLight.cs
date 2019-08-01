using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLight : MonoBehaviour
{
    private float delay;
    private bool lightStatus = true;
    public Light m_light;
    private void Start()
    {
        m_light = GetComponent<Light>();
    }

    private void Update()
    {
        float timeRand = Random.Range(0f, 1f);
        
    }
}
