using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<ColorLerper>()?.startPOVChange();
            FindObjectOfType<PlayerCam>()?.StartPlayerDeath();
            FindObjectOfType<PlayerMovement>()?.StartPlayerDeath();
            StartCoroutine(ReloadLevelAfterDelay(5f));
        }
    }

    private IEnumerator ReloadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
