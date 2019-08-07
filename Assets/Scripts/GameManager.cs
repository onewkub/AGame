using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Player { get; private set; }

    private void Awake()
    {
        if (Player != null && Player != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Player = this;
        }
    }
    private void Update()
    {
        //Debug.Log(SceneLoadManager.Instance.ProgressClamped());
    }
}