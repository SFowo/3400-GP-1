using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 0.0f;
    public float maxIntensity = 1.0f;
    public float flickerSpeed = 1.0f;

    private Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float intensity = Random.Range(minIntensity, maxIntensity);
            pointLight.intensity = intensity;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f) / flickerSpeed);
        }
    }
}
