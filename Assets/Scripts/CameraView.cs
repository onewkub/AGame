using UnityEngine;

public class CameraView : MonoBehaviour
{
    private float xAxixClamp;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xAxixClamp = 0f;
    }
    [Range(10f, 100f)]
    public float mouseSensetive = 40f;
    public GameObject mainCam;
    public GameObject PlayerBody;

    private void Update()
    {
        CameraRotation();
        if (Input.GetButtonDown("RightBumper"))
        {
            transform.localRotation = Quaternion.identity;
            mainCam.transform.localRotation = Quaternion.identity;
        }
    }
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensetive;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensetive;
        xAxixClamp += mouseY;
        if(xAxixClamp > 90.0f)
        {
            xAxixClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if(xAxixClamp < -90.0f)
        {
            xAxixClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);

        }
        mainCam.transform.Rotate(Vector3.left * mouseY);
        PlayerBody.transform.Rotate(Vector3.up * mouseX);
    }
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = mainCam.transform.eulerAngles;
        eulerRotation.x = value;
        mainCam.transform.eulerAngles = eulerRotation;
    }
}
