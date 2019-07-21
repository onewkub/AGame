using UnityEngine;

public class ElevatorLoadTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneLoadManager.Instance.ElevatorLoadAsync(1);
    }
}
