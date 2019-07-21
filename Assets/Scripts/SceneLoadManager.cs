using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance { get; private set; }
    private AsyncOperation loading;

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
        StartCoroutine(LoadAsync(0, true));
    }

    public void ElevatorLoadAsync(int index)
    {
        StartCoroutine(LoadAsync(index, false));
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

    IEnumerator LoadAsync(int index, bool allowActivation)
    {
        loading = SceneManager.LoadSceneAsync(index);
        Debug.Log("Loading Scene " + index);
        loading.allowSceneActivation = allowActivation;
        while (!ActualIsDone())
        {
            Debug.Log("Load Progress: " + ProgressClamped());
            yield return null;
        }
    }

    public float ProgressClamped()
    {
        return Mathf.Clamp01(loading.progress / .9f);
    }

    public bool ActualIsDone()
    {
        return Mathf.Clamp01(loading.progress / .9f) == 1f;
    }
}
