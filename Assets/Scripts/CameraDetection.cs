using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraFOV"))
        {
            Debug.Log("Player is caught!");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CameraFOV"))
        {
            Debug.Log("Player is caught!");
        }
    }

}
