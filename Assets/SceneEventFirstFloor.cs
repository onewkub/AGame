using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEventFirstFloor : MonoBehaviour
{
    public static SceneEventFirstFloor Instance { get; set; }
    private bool PassTutorial;
    public GameObject OpenTrigger;
    public GameObject CloseTrigger;
    public GameObject InsideTrigger;

    private void Start()
    {
        PassTutorial = false;
        OpenTrigger.SetActive(false);
        CloseTrigger.SetActive(false);
    }


}
