using UnityEngine;

public class NurseAnimatorController : MonoBehaviour
{
    public Animator animatorController;
    public void isWalking()
    {
        animatorController.SetBool("isWalking", true);
    }

    public void stopWalking()
    {
        animatorController.SetBool("isWalking", false);
    }

    public void withWheelchair()
    {
        animatorController.SetBool("WithWheelChair", true);

    }

    public void stopWithWheelchair()
    {
        animatorController.SetBool("WithWheelChair", false);
    }
}
