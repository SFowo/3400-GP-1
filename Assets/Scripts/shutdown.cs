using UnityEngine;
using UnityEngine.UI;

public class Shutdown : MonoBehaviour
{
    [SerializeField] private GameObject key1;
    [SerializeField] private GameObject key2;
    [SerializeField] private GameObject key3;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject informText;

    private bool isPlayerInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            informText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            informText.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                key1.SetActive(true);
                gameManager.RemoveKeyAtIndex(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                key2.SetActive(true);
                gameManager.RemoveKeyAtIndex(2); 
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                key3.SetActive(true);
                gameManager.RemoveKeyAtIndex(3);
            }
        }
    }
}