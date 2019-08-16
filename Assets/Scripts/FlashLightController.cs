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
        Flashlight.SetActive(Inventory.inventory.FlashLight);
    }
}
