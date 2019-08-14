using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject PrepareScene;
    public GameObject WSCanvas;

    public void Start()
    {
        PrepareScene.SetActive(false);
    }

    public void LoadPrepareScene()
    {
        Debug.Log("LoadPrepareScene");
        PrepareScene.SetActive(true);
        WSCanvas.SetActive(false);
        SceneLoadManager.Instance.LoaderAsync("FirstFloor_start");
        SceneLoadManager.Instance.SwitchSceneinLoading();
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
