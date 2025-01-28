using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void Start()
    {
        triggered = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !triggered)
        {
            FindObjectOfType<ShutdownBehavior>()?.TriggerShutoff();
            triggered = true;
        }
        
    }
}
