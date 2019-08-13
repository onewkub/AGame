using UnityEngine;

public class NextFloorInElevator : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.gameManager.Arrive1FloorBloody && !GameManager.gameManager.Arrived2fllor)
        {
            SceneLoadManager.Instance.ElevatorLoadAsync("SecondFloor_2");
        }
        else if (!GameManager.gameManager.Arrive1FloorBloody)
        {
            SceneLoadManager.Instance.ElevatorLoadAsync("FirstFloor");
        }
        else
        {
            SceneLoadManager.Instance.ElevatorLoadAsync("ThirdFloor");
        }
    }
}
