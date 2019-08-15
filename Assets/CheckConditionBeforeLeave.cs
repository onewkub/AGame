using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckConditionBeforeLeave : MonoBehaviour
{
    public GameObject FlashLight;
    public GameObject ClearWay;
    public ChooseTheWay Script;
    public GameObject GhostTrigger;
    private bool haveChoose= false;
    private void Start()
    {
        if (Inventory.inventory.FlashLight)
        {
            Script.Forward = ClearWay;

        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Up") && !haveChoose)
        {
            Debug.Log("SafeWay");
            FlashLight.SetActive(true);
            haveChoose = true;

        }
        else if (Input.GetButton("Left") && !haveChoose)
        {
            Debug.Log("NotSafeWay");
            GhostTrigger.SetActive(true);
            haveChoose = true;

        }
    }
}
