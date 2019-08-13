using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform cameraView;
    public LayerMask layerMask;
    public float maxRange = 10f;

    private void PointObject()
    {
        RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraView.position, cameraView.transform.forward, out hit, maxRange, layerMask))
        {
            Debug.Log(hit.transform.name);
        } 
    }

    private void Update()
    {
        if (Input.GetButton("RightBumper"))
        {
            PointObject();
        }
    }

}
