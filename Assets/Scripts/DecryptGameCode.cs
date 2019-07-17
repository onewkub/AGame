using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecryptGameCode : MonoBehaviour
{
    public short[] numbersSet1;
    public short[] numbersSet2;
    public Text[] NumbersText;
    public short currset = 1;
    public short indexPointer = 0;
    private bool leftBumper , rightBumper;
    private bool leftTrigger, rightTrigger;
    private bool LTLastFrame, RTLastFrame;


    private void Start()
    {
        Random14Int();
    }
    private void Update()
    {
        GetInput();
        if (leftBumper || rightBumper || leftTrigger || rightTrigger)
            CheckState();
        CurrentState();
    }


    public void Random14Int()
    {
        for (int i = 0; i < 7; i++)
        {
            numbersSet1[i] = (short) Random.Range(1, 4);
            NumbersText[i].text = numbersSet1[i].ToString();
            numbersSet2[i] = (short) Random.Range(1, 4);
        }
    }

    public void GetInput()
    {
        leftBumper = Input.GetButtonDown("LeftBumper");
        rightBumper = Input.GetButtonDown("RightBumper");

        // like get button down but for axis
        if (!LTLastFrame)
        {
            leftTrigger = Input.GetAxis("LeftTrigger") == 1;
        }
        else
        {
            leftTrigger = false;
        }
        if (!RTLastFrame)
        {
            rightTrigger = Input.GetAxis("RightTrigger") == 1;
        }
        else
        {
            rightTrigger = false;
        }
        LTLastFrame = Input.GetAxis("LeftTrigger") == 1;
        RTLastFrame = Input.GetAxis("RightTrigger") == 1;
    }

    private void CurrentState()
    {
        if (indexPointer == 7)
        {
            indexPointer = 0;
            currset++;
            if (currset == 2)
            {
                for (int i = 0; i < 7; i++)
                {
                    NumbersText[i].text = numbersSet2[i].ToString();
                }
            }
            else if (currset == 3)
            {
                NumbersText[0].text = "Y";
                NumbersText[1].text = "O";
                NumbersText[2].text = "U";
                NumbersText[3].text = "";
                NumbersText[4].text = "W";
                NumbersText[5].text = "I";
                NumbersText[6].text = "N";
            }
        }

        for (int i = 0; i < 7; i++)
        {
            NumbersText[i].fontStyle = FontStyle.Normal;
        }
        if (currset < 3)
            for (int i = 0; i < 7; i++)
            {
                if (i == indexPointer)
                    NumbersText[i].color = Color.red;
                else
                {
                    float gray50 = 50 / 255;
                    NumbersText[i].color = new Color(gray50, gray50, gray50);
                    if (i < indexPointer)
                        NumbersText[i].fontStyle = FontStyle.Bold;
                }
            }
    }
    private void CheckState()
    {
        short currnum;
        // 1: LT
        // 2: LB
        // 3: RT
        // 4: RB
        if (currset == 1)
        {
            currnum = numbersSet1[indexPointer];
        }
        else
        {
            currnum = numbersSet2[indexPointer];
        }

        switch (currnum)
        {
            case 1:
                if (leftTrigger)
                {
                    indexPointer++;
                }
                else
                {
                    indexPointer = 0;
                }
                break;
            case 2:
                if (leftBumper)
                {
                    indexPointer++;
                }
                else
                {
                    indexPointer = 0;
                }
                break;
            case 3:
                if (rightTrigger)
                {
                    indexPointer++;
                }
                else
                {
                    indexPointer = 0;
                }
                break;
            case 4:
                if (rightBumper)
                {
                    indexPointer++;
                }
                else
                {
                    indexPointer = 0;
                }
                break;
        }
    }

}
