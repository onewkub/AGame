using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMiniGame : MonoBehaviour
{
    public GameObject miniGameManager;
    private DecryptGameCode dcGame;

    private void Start()
    {
        dcGame = miniGameManager.GetComponent<DecryptGameCode>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dcGame.enabled = true;
        }
    }
}
