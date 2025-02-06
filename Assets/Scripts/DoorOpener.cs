using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int DoorOpen = Animator.StringToHash("Door-Open");
    private static readonly int DoorClose = Animator.StringToHash("Door-Close");

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger(DoorOpen);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger(DoorClose);
        }
    }
}