using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderController : MonoBehaviour
{
    Color aboveWaterColor = Color.white;
    Color underWaterColor;

    float fogAmount;

    public Transform mainCam;

    public ParticleSystem waterParticles;
    public Transform waterlevel;
    public Light sunLight;

    public Color shallowWaterColor;
    public Color deepWaterColor;

    public float minColorDepth;
    public float maxColorDepth;

    public float minFogDensity;
    public float maxFogDensity;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogMode = FogMode.Exponential;
    }

    // Update is called once per frame
    void Update()
    {
        // Takes the camera height value and converts it into lerp value for color, skybox, and fog
        float camHeight = mainCam.transform.position.y;
        float renderDepth = Mathf.Clamp(camHeight, maxColorDepth, minColorDepth);
        float correctionVal = renderDepth / maxColorDepth;

        if( mainCam.transform.position.y < waterlevel.transform.position.y){
            underWater(correctionVal);
        }else{
            aboveWater();
        }

    }
    void underWater(float correctionVal)
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = Color.Lerp(shallowWaterColor, deepWaterColor, correctionVal);
        RenderSettings.fogDensity = Mathf.Lerp(minFogDensity, maxFogDensity, correctionVal);
        sunLight.intensity = Mathf.Lerp(1f, 0f, correctionVal);
        
        waterParticles.Play();
        waterParticles.Emit(100);
    }
    void aboveWater()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = aboveWaterColor;
        RenderSettings.fogDensity = 0.005f;
        sunLight.intensity = 1f;

        waterParticles.Pause();
        waterParticles.Clear();
    }

}
