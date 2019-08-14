using UnityEngine;

public class NextFloorInElevator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.gameManager.Arrive1FloorBloody && !GameManager.gameManager.Arrived2fllor && Time.timeSinceLevelLoad > 1f)
        {
            SceneLoadManager.Instance.LoaderAsync("SecondFloor_2");
        }
        else if (!GameManager.gameManager.Arrive1FloorBloody)
        {
            SceneLoadManager.Instance.LoaderAsync("FirstFloor");
        }
        else
        {
            SceneLoadManager.Instance.LoaderAsync("ThirdFloor");
        }
        Destroy(gameObject);

    }
}
