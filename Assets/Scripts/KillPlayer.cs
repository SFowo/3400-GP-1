using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<ColorLerper>()?.startPOVChange();
            FindObjectOfType<PlayerCam>()?.StartPlayerDeath();
            FindObjectOfType<PlayerMovement>()?.StartPlayerDeath();
        }
    }
}
