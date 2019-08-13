using UnityEngine;

public class LoadNextSceneF1Bloody : MonoBehaviour
{
    private void Start()
    {
        SceneLoadManager.Instance.ElevatorLoadAsync("ElevatorScene");
        GameManager.gameManager.Arrive1FloorBloody = true;
    }
}
