using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    public GameObject head;
    public GameObject cam;


    private void Start()
    {
        if (GameManager.gameManager.PlayerPos != null && SceneManager.GetActiveScene().buildIndex != 1)
        {
            //Debug.Log("Set Pos in " + scene.name + " AT " + GameManager.gameManager.PlayerPos);
            Debug.Log("Set Position");
            
            transform.position = GameManager.gameManager.PlayerPos;
            transform.rotation = GameManager.gameManager.PlayerRot;
            head.transform.rotation = GameManager.gameManager.headRot;
            cam.transform.rotation = GameManager.gameManager.camRot;
        }
    }

}
