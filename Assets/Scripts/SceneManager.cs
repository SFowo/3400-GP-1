using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    private int collectables;
    private int paintings;

    [SerializeField] private GameObject scoreUIPanel;
    [SerializeField] private Text scoreText;

    public void IncrementCollectables()
    {
        collectables++;
    }

    public void IncrementPaintings()
    {
        paintings++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowTotalScore();
        }
    }

    private void ShowTotalScore()
    {
        if (scoreUIPanel != null && scoreText != null)
        {
            scoreUIPanel.SetActive(true);
            scoreText.text = $"Total Score:\nCollectables: {collectables}\nPaintings: {paintings}";
        }
    }
}
