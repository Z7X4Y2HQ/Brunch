using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSkyBox : MonoBehaviour
{
    public Material[] skyboxes;
    public Light directionalLight;

    private void Update()
    {
        RenderSettings.skybox = skyboxes[Brunch.work];
        if (Brunch.work == 0)
        {
            directionalLight.intensity = 2;
        }
        else if (Brunch.work == 1)
        {
            directionalLight.intensity = 1.3f;
        }
        else if (Brunch.work == 2)
        {
            directionalLight.intensity = 0.7f;
        }
        else if (Brunch.work == 3)
        {
            directionalLight.intensity = 0.01f;
        }
    }
}
