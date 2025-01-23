using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    [SerializeField] private LevelManager sceneManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraFOV"))
        {
            sceneManager?.IncrementScore(LevelManager.ScoreType.Detected);
            Debug.Log("Player is caught!");
        }
    }
}
