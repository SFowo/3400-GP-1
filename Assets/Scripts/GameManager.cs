using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static readonly int Open = Animator.StringToHash("Open");
    [SerializeField] private Text timerText;
    [SerializeField] private Animator shutDownButtonAnimator;
    [SerializeField] private GameObject[] inventoryKeys;
    [SerializeField] private GameObject[] covers;
    [SerializeField] private GameObject[] windows;

    [SerializeField] private GameObject keyInformText;
    [SerializeField] private AudioSource laserAudioSource;

    private bool shutdown;
    private bool isTimerActive = true;

    public float timeRemaining = 59.99f;

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
        StopTerrainMovement();

        StartCoroutine(MoveCoversToWindows());
    }

    private System.Collections.IEnumerator MoveCoversToWindows()
    {
        for (int i = 0; i < covers.Length; i++)
        {
            if (i < windows.Length && covers[i] != null && windows[i] != null)
            {
                Transform cover = covers[i].transform;
                Transform window = windows[i].transform;

                Vector3 targetPosition = new Vector3(cover.position.x, window.position.y, cover.position.z);
                float duration = 2f;
                float elapsed = 0f;

                Vector3 startPosition = cover.position;

                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;
                    float t = elapsed / duration;
                    cover.position = Vector3.Lerp(startPosition, targetPosition, t);
                    yield return null;
                }

                cover.position = targetPosition;

                yield return new WaitForSeconds(0.5f);
            }
        }

        if (laserAudioSource != null)
        {
            laserAudioSource.Play();

            StartCoroutine(RestartLevelAfterDelay(10f));
        }
    }

    private System.Collections.IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RestartLevel();
    }

    private void StartShutDownProcess()
    {
        if (!shutdown)
        {
            shutdown = true;
            shutDownButtonAnimator.SetTrigger(Open);
        }
    }

    private void StopTerrainMovement()
    {
        RobotWalkSimulation[] walkSimulations = FindObjectsOfType<RobotWalkSimulation>();
        foreach (RobotWalkSimulation simulation in walkSimulations)
        {
            simulation.StopSimulation();
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
        isTimerActive = false;

        GameObject[] monitors = GameObject.FindGameObjectsWithTag("Monitor");
        foreach (GameObject monitor in monitors)
        {
            TurnMonitorOff monitorScript = monitor.GetComponent<TurnMonitorOff>();
            if (monitorScript != null)
            {
                monitorScript.SetColorToBlack();
            }
        }

        StopTerrainMovement();

        ColorLerper[] colorLerpers = FindObjectsOfType<ColorLerper>();
        foreach (ColorLerper lerper in colorLerpers)
        {
            lerper.StopLerping();
        }

        StartCoroutine(RestartLevelAfterDelay(5f));
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
