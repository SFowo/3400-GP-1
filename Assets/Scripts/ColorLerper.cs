using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerper : MonoBehaviour
{
    public float rate;
    public float finalOpacity;

    private Boolean playerIsDead;
    private Image image;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.clear;
        playerIsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDead)
        {
            timer += Time.deltaTime * rate;
            image.color = Color.Lerp(Color.clear, new Color(1, 0, 0, finalOpacity), timer);
        }
    }

    public void startPOVChange()
    {
        playerIsDead = true; 
    }
}
