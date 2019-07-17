using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecryptGameCode : MonoBehaviour
{
    public int[] numbers;
    public Text[] NumbersText;
    private int indexPointer = 0;
    private int SltState;
    private bool leftBumper , rightBumper;
    private bool leftTrigger, RighTrigger;


    private void Start()
    {
        Random14Int();
    }
    private void Update()
    {
        CurrentState();
    }


    public void Random14Int()
    {
        for(int i= 0; i < 14; i++)
        {
            numbers[i] = Random.Range(1, 4);
            NumbersText[i].text = numbers[i].ToString();
        }
    }

    public void GetInput()
    {
        leftBumper = Input.GetButton("LeftBumper");
        rightBumper = Input.GetButton("RightBumper");
        leftTrigger = Input.GetAxis("LeftTrigger") == 1;
        RighTrigger = Input.GetAxis("RightTrigger") == 1;
    }

    private void CurrentState()
    {
        NumbersText[indexPointer].fontStyle = FontStyle.Bold;

    }
    private void CheckState()
    {
        
    }

}
