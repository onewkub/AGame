using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerChecker : MonoBehaviour
{
    public Text Device;
    public Text LB, RB, LT, RT, VL, VR;

    void Start()
    {
        string controllerName = Input.GetJoystickNames()[0];
        Device.text = "Device: " + controllerName;

    }

    void Update()
    {
        LB.text = "LeftBumper :" + Input.GetButton("LeftBumper");
        RB.text = "RightBumper :" + Input.GetButton("RightBumper");
        LT.text = "LeftTrigger :" + Input.GetAxis("LeftTrigger");
        RT.text = "RightTrigger :" + Input.GetAxis("RightTrigger");
        VL.text = "VerticalLeft: " + Input.GetAxis("VerticalLeft");
        VR.text = "VerticalRight: " + Input.GetAxis("VerticalRight");



    }


}
