using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPath : MonoBehaviour
{

    public static WalkingPath Instance { get; set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public GameObject[] Path;

    private int currentIndex = 0;
    private bool _trigger = false;

    private void Update()
    {
        if (_trigger)
        {
            if (currentIndex + 1 < Path.Length)
            {
                currentIndex++;
                Path[currentIndex].SetActive(true);
                PlayerMovement.Instance.agent.SetDestination(Path[currentIndex].transform.position);

                _trigger = false;
            }
        }
    }
    private void OnEnable()
    {
        Path[currentIndex].SetActive(true);
        PlayerMovement.Instance.agent.SetDestination(Path[currentIndex].transform.position);
    }

    public void isTrigger()
    {
        _trigger = true;
    }
}
