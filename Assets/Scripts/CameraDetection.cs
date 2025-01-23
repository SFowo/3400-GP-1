using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    [SerializeField] private SceneManager sceneManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraFOV"))
        {
            sceneManager?.IncrementScore(SceneManager.ScoreType.Detected);
            Debug.Log("Player is caught!");
        }
    }
}
