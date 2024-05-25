using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSkybox : MonoBehaviour
{
    public Material newSkybox;
    public Material defaultSkybox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RenderSettings.skybox = newSkybox;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RenderSettings.skybox = defaultSkybox;
        }
    }
}