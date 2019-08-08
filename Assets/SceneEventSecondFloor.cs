using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEventSecondFloor : MonoBehaviour
{
    public GameObject Nurse;
    public NormalNurse normalNurseScritp;

    private void Start()
    {
        normalNurseScritp = GetComponent<NormalNurse>(); 
    }

}
