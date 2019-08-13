using UnityEngine;

public class NurseMadnessController : MonoBehaviour
{
    public static NurseMadnessController Instance { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Running()
    {
        animator.SetBool("isRunning", true);
    }
   public void StopRunning()
    {
        animator.SetBool("isRunning", false);

    }
    public void Walking()
    {
        animator.SetBool("isWalking", true);
    }

    public void StopWaling()
    {
        animator.SetBool("isWalking", false);
    }

    public void Hit()
    {
        animator.SetBool("isHitting", true);
    }

    public void StopHit()
    {
        animator.SetBool("isHitting", false);

    }

}
