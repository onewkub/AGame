﻿using UnityEngine;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour
{
    public static SceneUI sceneUI { get; set; }

    private void Awake()
    {
        if(sceneUI != null && sceneUI != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sceneUI = this;
        }
    }
    public GameObject Key, Flashlight, FlashlightUI;

    private RawImage KeyCom, FlashlightCom;

    private void Start()
    {
        KeyCom = Key.GetComponent<RawImage>();
        FlashlightCom = Flashlight.GetComponent<RawImage>();
        KeyCom.color = new Color(255f, 255f, 255f, .2f);
        FlashlightCom.color = new Color(255f, 255f, 255f, .2f);



    }
    private void Update()
    {
        if (Inventory.inventory.FlashLight)
        {
            FlashlightCom.color = new Color(255f, 255f, 255f, 1f);
			FlashlightUI.SetActive(true);
		}
        if (Inventory.inventory.Key)
        {
            KeyCom.color = new Color(255f, 255f, 255f, 1f);
        }
		
    }
    public void DestroyIT()
    {
        Destroy(gameObject);
    }
}
