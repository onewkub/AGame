using TMPro;
using UnityEngine;
using System.Collections;

public class DecryptGameCode : MonoBehaviour
{
    private short[] numbersSet1 = new short[7];
    private short[] numbersSet2 = new short[7];
    public TextMeshProUGUI[] NumbersText;
    private short currset = 1;
    private short indexPointer = -1;
    private bool leftBumper, rightBumper;
    private bool leftTrigger, rightTrigger;
    private bool LTLastFrame, RTLastFrame;
    private bool scrambling = false;
    private bool pausing = false;

    public int pauseTimes;
    public int scrambleTimes;
    public float scrambleWaitSecond;

    private void OnEnable()
    {
        Random14Int();
        StartCoroutine(NumScrambler(scrambleTimes, scrambleWaitSecond));
    }

    IEnumerator NumScrambler(int time, float wait)
    {
        scrambling = true;
        if (indexPointer == -1)
        {
            NumbersText[0].text = "";
            NumbersText[1].text = "H";
            NumbersText[2].text = "E";
            NumbersText[3].text = "L";
            NumbersText[4].text = "L";
            NumbersText[5].text = "O";
            NumbersText[6].text = "";
            yield return new WaitForSeconds(pauseTimes);
        }
        else if (currset == 3) {
            time /= 2;
        }
        for (int i = 0; i < 7; i++)
        {
            NumbersText[i].color = Color.yellow;
        }
        while (time > 0)
        {
            NumbersText[0].text = Random.Range(1, 5).ToString();
            NumbersText[1].text = Random.Range(1, 5).ToString();
            NumbersText[2].text = Random.Range(1, 5).ToString();
            NumbersText[3].text = Random.Range(1, 5).ToString();
            NumbersText[4].text = Random.Range(1, 5).ToString();
            NumbersText[5].text = Random.Range(1, 5).ToString();
            NumbersText[6].text = Random.Range(1, 5).ToString();
            time--;
            yield return new WaitForSeconds(wait);
        }
        if (currset == 1)
        {
            for (int i = 0; i < 7; i++)
            {
                NumbersText[i].text = numbersSet1[i].ToString();
            }
        }
        else if (currset == 2)
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
            SceneLoadManager.Instance.SwitchSceneinLoading();
        }
        indexPointer = 0;
        scrambling = false;
    }

    IEnumerator textGreen()
    {
        pausing = true;
        for (int i = 0; i < 7; i++)
        {
            NumbersText[i].color = Color.green;
        }
        yield return new WaitForSeconds(pauseTimes);
        pausing = false;
        StartCoroutine(NumScrambler(scrambleTimes, scrambleWaitSecond));
    }

    private void Update()
    {
        if (!scrambling && !pausing)
        {
            GetInput();
            if (leftBumper || rightBumper || leftTrigger || rightTrigger)
                CheckState();
            CurrentState();
        }
    }


    public void Random14Int()
    {
        for (int i = 0; i < 7; i++)
        {
            numbersSet1[i] = (short)Random.Range(1, 5);
            NumbersText[i].text = numbersSet1[i].ToString();
            numbersSet2[i] = (short)Random.Range(1, 5);
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
            StartCoroutine(textGreen());
            return;
        }
        for (int i = 0; i < 7; i++)
        {
            NumbersText[i].fontStyle = FontStyles.Normal;
        }
        if (currset < 3)
        {
            for (int i = 0; i < 7; i++)
            {
                if (i == indexPointer)
                    NumbersText[i].color = Color.red;
                else
                {
                    NumbersText[i].color = Color.white;
                    if (i < indexPointer)
                        NumbersText[i].fontStyle = FontStyles.Bold;
                }
            }
        }
        if (currset == 3)
        {
            for (int i = 0; i < 7; i++)
            {
                NumbersText[i].color = Color.green;
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
