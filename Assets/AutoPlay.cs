using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlay : MonoBehaviour
{
    public static AutoPlay Instance { get; set; }
    public GameObject[] Positions;
    private GameObject CurrentPos = null;
    private int currentIndex = 0;
    private bool isTrigger = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Update()
    {
        if (isTrigger && currentIndex+1 < Positions.Length)
        {
            currentIndex++;
            CurrentPos = Positions[currentIndex];
            CurrentPos.SetActive(true);
            PlayerMovement.Instance.agent.SetDestination(CurrentPos.transform.position);
            isTrigger = false;

        }
    }

    public void StartScript()
    {
        CurrentPos = Positions[currentIndex];
        CurrentPos.SetActive(true);
        PlayerMovement.Instance.agent.SetDestination(CurrentPos.transform.position);
    }

    public void itTrigger()
    {
        isTrigger = true;
    }
}
