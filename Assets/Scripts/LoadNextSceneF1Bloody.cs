using UnityEngine;

public class LoadNextSceneF1Bloody : MonoBehaviour
{
    private void Start()
    {
        SceneLoadManager.Instance.LoaderAsync("ElevatorScene");
        GameManager.gameManager.Arrive1FloorBloody = true;
    }
}
