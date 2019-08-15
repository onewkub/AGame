using UnityEngine;

public class SceneEventFirstFloor : MonoBehaviour
{
    public GameObject OpenTrigger;
    public GameObject CloseTrigger;
    public GameObject InsideTrigger;

    private void Start()
    {
        OpenTrigger.SetActive(false);
        CloseTrigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenTrigger.SetActive(true);
        CloseTrigger.SetActive(true);
        InsideTrigger.SetActive(false);

    }
}
