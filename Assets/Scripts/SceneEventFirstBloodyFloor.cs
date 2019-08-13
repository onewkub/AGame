using UnityEngine;

public class SceneEventFirstBloodyFloor : MonoBehaviour
{
    public static SceneEventFirstBloodyFloor Instance { get; set; }
    public Light r1, r2, r3;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void closeAllLight()
    {
        r1.enabled = r2.enabled = r3.enabled = false;
    }
}
