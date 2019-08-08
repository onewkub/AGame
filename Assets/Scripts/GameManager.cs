using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public Vector3 PlayerPos;
    public Vector3 NursePos;
    public Quaternion NurseRot;
    public Quaternion PlayerRot;
    public Quaternion headRot;
    public Quaternion camRot;
    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
    }
}