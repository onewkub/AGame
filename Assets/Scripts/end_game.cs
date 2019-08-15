using UnityEngine;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{
    public static end_game Instance { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public GameObject Survive;
    public GameObject NotSurvie;
    public GameObject EndGameUI;
    public GameObject GhostHead;
    public GameObject Die;
    public GameObject Nurse;
    private bool GameIsEnd = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(GhostHead);
            Destroy(Nurse);
            EndGameUI.SetActive(true);
            Survive.SetActive(Inventory.inventory.Key);
            NotSurvie.SetActive(!Inventory.inventory.Key);
            GameIsEnd = true;
            Debug.Log("Game is END");
        }
    }
    public void PlayerIsDead()
    {
        EndGameUI.SetActive(true);
        Die.SetActive(true);
        GameIsEnd = true;
        Debug.Log("Game is END");

    }
    public void LoadMainMenuScene()
    {
        SceneUI.sceneUI.DestroyIT();
        Inventory.inventory.DestroyIT();
        GameManager.gameManager.DestroyIT();
        SceneManager.LoadScene("MainMenu");
    }
    private void Update()
    {
        if (GameIsEnd && Input.GetKey(KeyCode.Joystick1Button2))
        {
            LoadMainMenuScene();
        }
    }
}
