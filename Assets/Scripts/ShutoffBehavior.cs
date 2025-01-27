using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ShutoffBehavior : MonoBehaviour
{
    private AudioSource offSFX;
    private Light pointLight;
    private FlickeringLight flickeringLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
        flickeringLight = GetComponent<FlickeringLight>();
        offSFX = GetComponent<AudioSource>();
    }

    public void Shutoff()
    {
        flickeringLight.turnOff();
        offSFX.Play();
    }

}
