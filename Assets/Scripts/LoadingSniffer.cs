using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class LoadingSniffer : MonoBehaviour
{
    public Slider loadBar;
    public TextMeshProUGUI loadText;

    private void Start()
    {
        StartCoroutine(dotter());
    }
    // Update is called once per frame
    void Update()
    {
        loadText.text = SceneLoadManager.Instance.ActualIsDone() ? "Complete" : "Loading";
        loadBar.value = SceneLoadManager.Instance.ProgressClamped();
    }

    IEnumerator dotter()
    {
        string dot = ".";
        dot = dot + ".";
        loadText.text = loadText + dot;
        if (dot == "...")
            dot = ".";
        yield return new WaitForSeconds(0.5f);
    }
}
