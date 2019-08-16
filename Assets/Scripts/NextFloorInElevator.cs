using UnityEngine;

public class NextFloorInElevator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

		if (!GameManager.gameManager.Arrive1FloorBloody)
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
