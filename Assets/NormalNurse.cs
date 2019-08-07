using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNurse : MonoBehaviour
{
    public static NormalNurse Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
}
