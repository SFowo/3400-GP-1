using UnityEngine;

public class TrashGrabber : MonoBehaviour
{
    [SerializeField] private SceneManager sceneManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        sceneManager?.IncrementScore(SceneManager.ScoreType.Collectables);
        gameObject.SetActive(false);
    }
}
