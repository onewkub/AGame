using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public GameObject head;
    public GameObject cam;


    private void OnLevelWasLoaded()
    {
        controller.enabled = false;
        if (GameManager.gameManager.PlayerPos != null)
        {
            //Debug.Log("Set Pos in " + scene.name + " AT " + GameManager.gameManager.PlayerPos);
            Debug.Log("Set Position");
            
            transform.position = GameManager.gameManager.PlayerPos;
            transform.rotation = GameManager.gameManager.PlayerRot;
            head.transform.rotation = GameManager.gameManager.headRot;
            cam.transform.rotation = GameManager.gameManager.camRot;
        }
        controller.enabled = true;
    }

}
