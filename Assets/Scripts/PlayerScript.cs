using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    private Scene scene;

    private void OnLevelWasLoaded()
    {
        scene = SceneManager.GetActiveScene();
        if (GameManager.gameManager.PlayerPos != null)
        {
            //Debug.Log("Set Pos in " + scene.name + " AT " + GameManager.gameManager.PlayerPos);
            Debug.Log("Set Position");
            Invoke("SetPos", 2);

        }
    }
    private void SetPos()
    {
        transform.position = GameManager.gameManager.PlayerPos;
        transform.rotation = GameManager.gameManager.PlayerRot;
    }

}
