using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenMainMenu : MonoBehaviour
{
    public CustomLoadBar loadingbar;
    private void Update()
    {
        if (!SceneLoadManager.Instance.ActualIsDone())
        {
            loadingbar.LoadPercentage = SceneLoadManager.Instance.ProgressClamped();
        }
    }
}
