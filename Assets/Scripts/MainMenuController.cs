using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject PrepareScene;

    public void Start()
    {
        PrepareScene.SetActive(false);
    }

    public void LoadPrepareScene()
    {
        Debug.Log("LoadPrepareScene");
        PrepareScene.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            LoadPrepareScene();
        }
    }
    public void LoadSetting()
    {
        Debug.Log("Setting");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
