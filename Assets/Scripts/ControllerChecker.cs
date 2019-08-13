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
        LB.text = "LeftBumper(2) :" + Input.GetButton("LeftBumper");
        RB.text = "RightBumper(4) :" + Input.GetButton("RightBumper");
        LT.text = "LeftTrigger(1) :" + Input.GetAxis("LeftTrigger");
        RT.text = "RightTrigger(3) :" + Input.GetAxis("RightTrigger");
        VL.text = "VerticalLeft: " + Input.GetAxis("VerticalLeft");
        VR.text = "VerticalRight: " + Input.GetAxis("VerticalRight");



    }


}
