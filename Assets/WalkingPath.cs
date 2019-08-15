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
    public GameObject start;
    private int currentIndex = 0;
    private bool _trigger = false;
    public GameObject ChoosenPosition;
    public bool haveChoose = false;
    public bool ChoosePathState = false;

    private void Update()
    {
        if (_trigger && haveChoose)
        {
            PlayerMovement.Instance.agent.SetDestination(ChoosenPosition.transform.position);
            ChoosenPosition.SetActive(true);
            _trigger = haveChoose = false;
            ChoosePathState = false;
        }
    }
    private void OnEnable()
    {
        start.SetActive(true);
        PlayerMovement.Instance.agent.SetDestination(start.transform.position);
    }

    public void isTrigger()
    {
        _trigger = true;
    }
    public bool getTrigger()
    {
        return _trigger;
    }
}
