using UnityEngine;

public class SceneEventSecondFloor : MonoBehaviour
{
    public static SceneEventSecondFloor Instance{get; set;}


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


    public Light r1, r2, r3, r4, r5;

    public void closeAllLight()
    {
        r1.enabled = r2.enabled = r3.enabled = r4.enabled = r5.enabled =false;
    }
    public void openAllLight()
    {
        r1.enabled = r2.enabled = r3.enabled = r4.enabled = r5.enabled =true;
    }

}
