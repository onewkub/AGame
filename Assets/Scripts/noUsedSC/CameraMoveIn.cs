using UnityEngine;

public class CameraMoveIn : MonoBehaviour
{
    public GameObject finalPosition;
    public float time;
    private Vector3 velocity;
    public DecryptGameCode codeManager;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition.transform.position, ref velocity, time);
        if (Vector3.SqrMagnitude(transform.position - finalPosition.transform.position) < 1.5)
        {
            codeManager.enabled = true;
        }
    }
}
