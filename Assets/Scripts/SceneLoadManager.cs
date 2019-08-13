using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance { get; private set; }
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
        StartCoroutine(LoadAsync("Elevator", true));
    }

    public void LoaderAsync(string sceneName, float delay)
    {
        if (this.sceneName != sceneName)
        {
            this.sceneName = sceneName;
            Invoke("Load", delay);
        }
    }

    private void Load()
    {
        StartCoroutine(LoadAsync(false));
    }

    public void SwitchSceneinLoading()
    {
        StartCoroutine(SwitcherCoroutine());
    }

    IEnumerator SwitcherCoroutine()
    {
        while (true)
        {
            if (ActualIsDone())
            {
                yield return new WaitForSeconds(2.5f);
                loading.allowSceneActivation = true;
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator LoadAsync(string sceneName, bool allowActivation)
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
