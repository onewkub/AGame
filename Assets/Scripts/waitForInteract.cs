using UnityEngine;

public class waitForInteract : MonoBehaviour
{
    public CustomLoadBar loadingbar;
    public GameObject loadedText;

    private void Update()
    {
        if (!SceneLoadManager.Instance.ActualIsDone())
        {
            loadingbar.LoadPercentage = SceneLoadManager.Instance.ProgressClamped();
        }
        else
        {
            loadingbar.gameObject.SetActive(false);
            loadedText.SetActive(true);
        }
        if (Input.anyKey && SceneLoadManager.Instance.ActualIsDone())
        {
            SceneLoadManager.Instance.SwitchSceneinLoading();
        }
    }

    private void OnEnable()
    {
        SceneLoadManager.Instance.LoaderAsync("FirstFloor_start", 0);
    }
}
