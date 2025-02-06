using UnityEngine;

public class TurnMonitorOff : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("Renderer component not found on the object.");
            return;
        }
    }

    public void SetColorToBlack()
    {
        if (objectRenderer != null)
        {
            Material material = objectRenderer.material;

            if (material.HasProperty("_BaseColor"))
            {
                material.shader = Shader.Find("Unlit/Color");
                material.SetColor("_Color", Color.black);

            }
            else
            {
                Debug.LogWarning("Material does not have a '_BaseColor' property.");
            }
        }
        else
        {
            Debug.LogError("Renderer component not found on the object.");
        }
    }

}