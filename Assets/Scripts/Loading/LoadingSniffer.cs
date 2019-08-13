using UnityEngine;
using System.Collections;
using TMPro;

public class LoadingSniffer : MonoBehaviour
{
    public CustomLoadBar loadBar;
    public TextMeshProUGUI loadText;
    string dot = "";

    private void Start()
    {
        StartCoroutine(Dotter());
    }
    // Update is called once per frame
    void Update()
    {
        loadText.text = (SceneLoadManager.Instance.ActualIsDone() ? "Complete" : "Loading") + dot;
        loadBar.LoadPercentage = SceneLoadManager.Instance.ProgressClamped();
    }

    IEnumerator Dotter()
    {
        while (true)
        {
            dot += ".";
            if (dot == "....")
                dot = ".";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
