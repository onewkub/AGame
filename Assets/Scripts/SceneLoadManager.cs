using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance { get; private set; }
    public GameObject loadingCanvas;
    private AsyncOperation loading;
    private string sceneName;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void LoadElevator()
    {
        if (this.sceneName != "Elevator")
        {
            sceneName = "Elevator";
            StartCoroutine(LoadAsync(true));
        }
    }

    public void LoaderAsync(string sceneName)
    {
        if (this.sceneName != sceneName)
        {
            this.sceneName = sceneName;
            StartCoroutine(LoadAsync(false));
        }
    }

    public void SwitchSceneinLoading()
    {
        loadingCanvas.SetActive(true);
        loading.allowSceneActivation = true;
    }

    IEnumerator LoadAsync(bool allowActivation)
    {
        loading = SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("Loading Scene " + sceneName);
        loading.allowSceneActivation = allowActivation;
        while (!ActualIsDone())
        {
            Debug.Log("Load Progress: " + ProgressClamped());
            yield return null;
        }
        Debug.Log("Loading Complete");
    }

    public float ProgressClamped()
    {
        return Mathf.Clamp01(loading.progress / .9f);
    }

    public bool ActualIsDone()
    {
        return ProgressClamped() == 1f;
    }
}
