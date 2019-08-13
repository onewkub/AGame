using UnityEngine;

public class LoadNextSceneF1Bloody : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
    {
        SceneLoadManager.Instance.LoaderAsync("ElevatorScene", 5);
        GameManager.gameManager.Arrive1FloorBloody = true;
        Destroy(gameObject);

    }
}
