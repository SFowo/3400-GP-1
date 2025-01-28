using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShutdownBehavior : MonoBehaviour
{
    public AudioSource zombieScream;
    public ZombieMovement zombieMovement;
    public Transform zombieHand;
    public Transform zombiePosition;
    public float startingTimeBetween = 2;
    public float timeBetweenIncrement = 0.2f;
    public float minTimeBetween = 0.2f;
    private ShutoffBehavior[] lights;
    private int lightsDownCount = 0;

    private void Start()
    {
        lightsDownCount = 0;
        lights = FindObjectsOfType<ShutoffBehavior>().OrderBy(light => light.name).ToArray();

    }

    public void TriggerShutoff()
    {
        StartCoroutine(ShutoffLights());
    }

    private IEnumerator ShutoffLights()
    {
        zombieScream.Play();
        float delay = startingTimeBetween;
        zombieMovement.StartChase();

        foreach (ShutoffBehavior light in lights)
        {
            yield return new WaitForSeconds(delay);
            light.Shutoff();
            if (lightsDownCount <= 0)
            {
                zombiePosition.Translate(0f, 0f, -2.7f);
                zombieHand.Rotate(0f, -90f, 0f);
            }
            else if (lightsDownCount <= 6)
            {
                zombiePosition.Translate(3.3f, 0f, 0f);
            }
            else if (lightsDownCount == 7)
            {
                zombiePosition.Translate(0f, 0f, 0f);
                zombieHand.Rotate(0f, 90f, 0f);
            }
            else if (lightsDownCount <= 15)
            {
                zombiePosition.Translate(0f, 0f, -3.3f);
            }

            lightsDownCount += 1;
            delay -= timeBetweenIncrement;
            if (delay <= minTimeBetween)
            {
                delay = minTimeBetween;
            }
        }
    }
}
