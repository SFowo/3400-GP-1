using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float spinSpeed = 100f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3. right* spinSpeed * Time.deltaTime, Space.Self);
    }
}