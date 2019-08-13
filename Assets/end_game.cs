using UnityEngine;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{
    public GameObject Survive;
    public GameObject NotSurvie;
    public GameObject EndGameUI;
    public GameObject GhostHead;
    public GameObject Nurse;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(GhostHead);
            Destroy(Nurse);
            EndGameUI.SetActive(true);
            Survive.SetActive(Inventory.inventory.Key);
            NotSurvie.SetActive(!Inventory.inventory.Key);
            Debug.Log("Game is END");
        }
    }
    public void LoadMainMenuScene()
    {
        SceneUI.sceneUI.DestroyIT();
        Inventory.inventory.DestroyIT();
        GameManager.gameManager.DestroyIT();
        SceneManager.LoadScene("MainMenu");
    }
}
