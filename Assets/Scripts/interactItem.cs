using UnityEngine;

public class interactItem : MonoBehaviour
{
    public GameObject canvas;
    public Transform objectToLook;
    public GameObject openTrigger;
    public GameObject closeTrigger;
    //public GameObject GhostHead;

    private bool PlayerOnArea = false;
    private void Start()
    {
        canvas.SetActive(false);
    }

    private void Update()
    {
        lookAtObject();
        if(Input.GetButton("InteractItem") && PlayerOnArea)
        {
            Destroy(gameObject);
        }
    }



    private void lookAtObject()
    {
        canvas.transform.LookAt(objectToLook, Vector3.up);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canvas.SetActive(true);
            PlayerOnArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(false);
            PlayerOnArea = false;
        }
    }
    private void OnDestroy()
    {
        //Debug.Log("Weeh");
        //Debug.Log(gameObject.tag);
        if(gameObject.tag == "Key")
        {
            Debug.Log("Get Key");
            Inventory.inventory.Key = true;
            //GhostHead.SetActive(true);
        }
        else if(gameObject.tag == "Flashlight")
        {
            Debug.Log("Get Flashlight");
            SceneEventFirstBloodyFloor.Instance.closeAllLight();
            Inventory.inventory.FlashLight = true;
        }
        if(openTrigger != null && closeTrigger != null)
        {
            openTrigger.SetActive(true);
            closeTrigger.SetActive(true);

        }
    }
}
