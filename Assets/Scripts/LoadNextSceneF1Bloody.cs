using UnityEngine;

public class LoadNextSceneF1Bloody : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
    {
        SceneLoadManager.Instance.LoaderAsync("ElevatorScene");
        GameManager.gameManager.Arrive1FloorBloody = true;
        Destroy(gameObject);

    }
}
