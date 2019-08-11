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

    public bool Arrived2fllor;
    public bool Arrive1FloorBloody;


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
        Arrive1FloorBloody = false;
        Arrived2fllor = false;
    }

}