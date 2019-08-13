using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    public GameObject Flashlight;
    private Flashlight_PRO flashlight_;
    private bool hasFlashlight;
    private void Start()
    {
        flashlight_ = Flashlight.GetComponent<Flashlight_PRO>();
    }


    private void Update()
    {


        hasFlashlight = Inventory.inventory.FlashLight;
        Flashlight.SetActive(hasFlashlight);
        if (hasFlashlight)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("!!!");
                flashlight_.Switch();
            }
        }

    }
}
