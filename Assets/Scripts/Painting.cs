using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public Transform player;
    public float maxDistance;

    public float maxRotation;
    public float minRotation;

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject door1;
    [SerializeField]
    private GameObject door2;
    private Transform tf;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Mathf.Sqrt(Mathf.Pow(player.position.x - tf.position.x, 2) + Mathf.Pow(player.position.z - tf.position.z, 2)) < maxDistance && player.rotation.z < maxRotation && player.rotation.z > minRotation)
        {
            canvas.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                canvas.enabled = false;
                door1.SetActive(false);
                door2.SetActive(false);
            }
        } else
        {
            canvas.enabled = false;
        }
    }
}
