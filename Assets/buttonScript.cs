using UnityEngine;

public class buttonScript : MonoBehaviour
{
    private bool isPlayerInTrigger;
    
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject buttonInformText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            if (buttonInformText!=null)
            {
                buttonInformText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInTrigger = false;
        if (buttonInformText!=null)
        {
            buttonInformText.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(buttonInformText);
            gameManager.GetComponent<GameManager>().StartShutDownCinematic();
        }
    }
}
