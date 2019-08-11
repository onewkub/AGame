﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory { get; set; }
    
    public bool Key = false;
    public bool FlashLight = false;

    private void Awake()
    {
        if(inventory != null && inventory != this)
        {
            Destroy(gameObject);
        }
        else
        {
            inventory = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    

}