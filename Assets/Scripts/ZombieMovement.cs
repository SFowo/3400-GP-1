using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    private Vector3 startPosition;
    private float lerpTime;
    private bool CHASING = false;

    void Start()
    {
        CHASING = false;
        startPosition = transform.position;
    }

    void Update()
    {
        if (CHASING)
        {
            lerpTime += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPosition, target.position, lerpTime);

            if (lerpTime >= 1f)
            {
                lerpTime = 0f; // Reset for re-use, if needed
                startPosition = transform.position; // Update starting position
            }

        }
    }

    public void StartChase()
    {
        CHASING = true;
    }
}
