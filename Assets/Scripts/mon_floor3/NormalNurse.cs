using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalNurse : MonoBehaviour
{

    private void OnLevelWasLoaded(int level)
    {
        transform.position = GameManager.gameManager.NursePos;
        transform.rotation = GameManager.gameManager.NurseRot;
    }
}
