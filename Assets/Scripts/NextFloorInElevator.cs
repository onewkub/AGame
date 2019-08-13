using UnityEngine;

public class NextFloorInElevator : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.gameManager.Arrive1FloorBloody && !GameManager.gameManager.Arrived2fllor)
        {
            SceneLoadManager.Instance.LoaderAsync("SecondFloor_2", 5);
        }
        else if (!GameManager.gameManager.Arrive1FloorBloody)
        {
            SceneLoadManager.Instance.LoaderAsync("FirstFloor", 5);
        }
        else
        {
            SceneLoadManager.Instance.LoaderAsync("ThirdFloor", 5);
        }
    }
}
