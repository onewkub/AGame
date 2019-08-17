using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject WSCanvas;

    public void LoadPrepareScene()
    {
        Debug.Log("LoadPrepareScene");
        WSCanvas.SetActive(false);
        SceneLoadManager.Instance.LoaderAsync("FirstFloor_start");
        SceneLoadManager.Instance.SwitchSceneinLoading();
    }
    private void Update()
    {
        if (Input.GetButton("Space"))
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
