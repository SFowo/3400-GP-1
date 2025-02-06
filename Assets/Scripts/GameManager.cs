using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Animator shutDownButtonAnimator;
    [SerializeField] private GameObject[] windowCovers;
    [SerializeField] private GameObject[] inventoryKeys;

    private bool shutdown;

    private float timeRemaining = 59.99f;

    private void Update()
    {
        if (shutdown || timeRemaining <= 0)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            StartKillProcess();
        }

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int seconds = Mathf.FloorToInt(timeRemaining);
        int milliseconds = Mathf.FloorToInt((timeRemaining - seconds) * 100);
        timerText.text = $"{seconds:00}:{milliseconds:00}";
    }

    private void StartKillProcess()
    {
        
    }

    private void StartShutDownProcess()
    {
        if (!shutdown)
        {
            shutdown = true;
            shutDownButtonAnimator.SetTrigger("StartShutdown"); 
        }
    }

    public void RemoveKeyAtIndex(int index)
    {
        if (index >= 1 && index <= 3)
        {
            int actualIndex = index - 1;
            if (inventoryKeys[actualIndex] != null)
            {
                Destroy(inventoryKeys[actualIndex]);
                inventoryKeys[actualIndex] = null;

                CheckAllKeysRemoved();
            }
        }
    }

    public void InsertKey(int index)
    {
        if (index >= 1 && index <= 3)
        {
            int actualIndex = index - 1;
            if (inventoryKeys[actualIndex] != null)
            {
                Destroy(inventoryKeys[actualIndex]);
                inventoryKeys[actualIndex] = null;

                CheckAllKeysRemoved();
            }
        }
    }

    private void CheckAllKeysRemoved()
    {
        foreach (GameObject key in inventoryKeys)
        {
            if (key != null)
                return;
        }
        StartShutDownProcess();
    }
}
