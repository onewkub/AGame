using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerTester : MonoBehaviour
{
    public Text title;
    public Text Axis0;
    public Text Axis1;
    public Text Axis2;
    public Text Axis3;

    private void Start()
    {
        string[] controller = Input.GetJoystickNames();
        title.text = $"Axis text :3 ({controller[0]})";
    }

    void Update()
    {
        Axis0.text = $"Horizontal = {Input.GetAxis("Horizontal")}";
        Axis1.text = $"Horizontal2 = {Input.GetAxis("Horizontal2")}";

        Axis2.text = $"VerticalLeft = {Input.GetAxis("VerticalLeft")}";
        Axis3.text = $"VerticalRight = {Input.GetAxis("VerticalRight")}";
    }
}
