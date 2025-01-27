using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.GlobalIllumination;

public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 0.0f;
    public float maxIntensity = 1.0f;
    public float flickerSpeed = 1.0f;
    public bool ON = true;

    private Light pointLight;

    void Start()
    {
        ON = true;
        pointLight = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (ON)
        {
            float intensity = Random.Range(minIntensity, maxIntensity);
            pointLight.intensity = intensity;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f) / flickerSpeed);
        }
        if (!ON)
        {
            pointLight.intensity = 0.0f;
            yield return null;
        }
    }

    public void turnOff()
    {
        ON = false;
    }
}
