using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static readonly int Open = Animator.StringToHash("Open");
    [SerializeField] private Text timerText;
    [SerializeField] private Animator shutDownButtonAnimator;
    [SerializeField] private GameObject[] windowCovers;
    [SerializeField] private GameObject[] inventoryKeys;
    
    [SerializeField] private GameObject keyInformText;

    private bool shutdown;
    private bool isTimerActive = true; // Control timer activity

    private float timeRemaining = 59.99f;

    private void Update()
    {
        if (isTimerActive && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0)
            {
                timeRemaining = 0;
                StartKillProcess();
            }

            UpdateTimerDisplay();
        }

        if (shutdown)
        {
            // Additional logic if needed when shutdown is active
        }
    }

    private void UpdateTimerDisplay()
    {
        int seconds = Mathf.FloorToInt(timeRemaining);
        int milliseconds = Mathf.FloorToInt((timeRemaining - seconds) * 100);
        timerText.text = $"{seconds:00}:{milliseconds:00}";
    }

    private void StartKillProcess()
    {
        // Logic when timer reaches zero
    }

    private void StartShutDownProcess()
    {
        if (!shutdown)
        {
            shutdown = true;
            shutDownButtonAnimator.SetTrigger(Open); 
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

    private void CheckAllKeysRemoved()
    {
        foreach (GameObject key in inventoryKeys)
        {
            if (key != null)
                return;
        }

        keyInformText.SetActive(false);
        StartShutDownProcess();
    }

    public void StartShutDownCinematic()
    {
        // Stop the timer
        isTimerActive = false;

        // Stop monitors
        GameObject[] monitors = GameObject.FindGameObjectsWithTag("Monitor");
        foreach (GameObject monitor in monitors)
        {
            TurnMonitorOff monitorScript = monitor.GetComponent<TurnMonitorOff>();
            if (monitorScript != null)
            {
                monitorScript.SetColorToBlack();
            }
        }

        // Stop terrain movement and stomp audio
        RobotWalkSimulation[] walkSimulations = FindObjectsOfType<RobotWalkSimulation>();
        foreach (RobotWalkSimulation simulation in walkSimulations)
        {
            simulation.StopSimulation();
        }

        // Stop all color lerping effects
        ColorLerper[] colorLerpers = FindObjectsOfType<ColorLerper>();
        foreach (ColorLerper lerper in colorLerpers)
        {
            lerper.StopLerping();
        }

        // Other cinematic effects can be added here
    }

}
