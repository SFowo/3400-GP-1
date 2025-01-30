using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownTrigger : MonoBehaviour
{
    private bool triggered = false;
    public GameObject quote;

    private void Start()
    {
        triggered = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !triggered)
        {
            FindObjectOfType<ShutdownBehavior>()?.TriggerShutoff();
            quote.SetActive(false);
            triggered = true;
        }
        
    }
}
