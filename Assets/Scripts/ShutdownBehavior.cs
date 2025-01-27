using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShutdownBehavior : MonoBehaviour
{
    public float startingTimeBetween = 2;
    public float timeBetweenIncrement = 0.2f;
    public float minTimeBetween = 0.2f;
    private ShutoffBehavior[] lights;

    private void Start()
    {
        lights = FindObjectsOfType<ShutoffBehavior>().OrderBy(light => light.name).ToArray();

    }

    public void TriggerShutoff()
    {
        StartCoroutine(ShutoffLights());
    }

    private IEnumerator ShutoffLights()
    {
        float delay = startingTimeBetween;

        foreach (ShutoffBehavior light in lights)
        {
            yield return new WaitForSeconds(delay);
            light.Shutoff();
            delay -= timeBetweenIncrement;
            if (delay <= minTimeBetween)
            {
                delay = minTimeBetween;
            }
        }
    }
}
