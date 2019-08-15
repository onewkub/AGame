using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTheWay : MonoBehaviour
{
    [Header("WayPoint")]
    public GameObject Left;
    public GameObject Right;
    public GameObject Forward;
    public GameObject Backward;
    [Header("UI")]
    public GameObject LeftButton;
    public GameObject RightButton; 
    public GameObject ForwardButton;
    public GameObject BackwardButton;
    private bool HaveChoose;
    private void Start()
    {
        //CheckTheWay();
        HaveChoose = false;
    }
    private void CheckTheWay()
    {
        LeftButton.SetActive(Left != null);
        RightButton.SetActive(Right != null);
        ForwardButton.SetActive(Forward != null);
        BackwardButton.SetActive(Backward != null);
    }
    private void Update()
    {   if(!WalkingPath.Instance.haveChoose)
            CheckTheWay();
        if (Input.GetButtonDown("Left") && Left != null && !HaveChoose)
        {
            Debug.Log("Choose Left");
            HaveChoose = true;
            WalkingPath.Instance.ChoosenPosition = Left;
            WalkingPath.Instance.haveChoose = true;
            if(RightButton != null)
                RightButton.SetActive(false);
            if(ForwardButton != null)
                ForwardButton.SetActive(false);
            if(BackwardButton != null)
                BackwardButton.SetActive(false);
            gameObject.SetActive(false);
        }
        else if (Input.GetButtonDown("Right") && Right != null && !HaveChoose)
        {
            Debug.Log("Choose Right");
            
            WalkingPath.Instance.ChoosenPosition = Right;
            WalkingPath.Instance.haveChoose = true;
            if (LeftButton != null)
                LeftButton.SetActive(false);
            if (ForwardButton != null)
                ForwardButton.SetActive(false);
            if (BackwardButton != null)
                BackwardButton.SetActive(false);
            gameObject.SetActive(false);



        }
        else if (Input.GetButtonDown("Up") && Forward != null && !HaveChoose)
        {
            Debug.Log("Choose Forward");

            WalkingPath.Instance.ChoosenPosition = Forward;
            WalkingPath.Instance.haveChoose = true;
            if (RightButton != null)
                RightButton.SetActive(false);
            if (LeftButton != null)
                LeftButton.SetActive(false);
            if (BackwardButton != null)
                BackwardButton.SetActive(false);

            gameObject.SetActive(false);


        }
        else if (Input.GetButtonDown("Down") && Backward != null && !HaveChoose)
        {
            Debug.Log("Choose Backward");

            WalkingPath.Instance.ChoosenPosition = Backward;
            WalkingPath.Instance.haveChoose = true;
            if (RightButton != null)
                RightButton.SetActive(false);
            if (ForwardButton != null)
                ForwardButton.SetActive(false);
            if (ForwardButton != null)
                ForwardButton.SetActive(false);
            gameObject.SetActive(false);

        }
    }
}
