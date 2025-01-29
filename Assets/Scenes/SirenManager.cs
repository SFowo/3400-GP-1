using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenManager : MonoBehaviour
{
    [SerializeField] private Light sirenLight;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 2f;
    [SerializeField] private float speed = 2f;

    private float time;

    void Update()
    {
        time += Time.deltaTime * speed;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(time) + 1) / 2);
        sirenLight.intensity = intensity;
    }
}
