using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CRTLightController : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] Color gameplayColor;
    [SerializeField] Color pauseColor;
    [SerializeField] Color staticColor;

    [SerializeField] List<Light> lights;
    [Space]
    [SerializeField] Image tvStatic;

    [Space]
    [SerializeField] bool flicker = true;
    [SerializeField] float flickersPerSec = 10;
    float flickerCooldown;
    float flickerCooldownElapsed = 0;
    [SerializeField] float flickerIntensityMult = 0.1f;
    List<float> intensities = new List<float>();

    private void Start()
    {
        foreach (Light light in lights)
        {
            intensities.Add(light.intensity);
        }

        flickerCooldown = 1 / flickersPerSec;

        FlickerLights();

    }

    // Update is called once per frame
    void Update()
    {
        Color lightColor = Color.white;

        // colors are white if pause menu or static is onscreen.
        // purple if gameplay is onscreen
        if (tvStatic.color.a != 0) { lightColor = staticColor; }
        else if (pauseMenu.isOpen) { lightColor = pauseColor; }
        else { lightColor = gameplayColor; }


        ChangeLightColor(lightColor);

        flickerCooldownElapsed += Time.unscaledDeltaTime;
        if (flickerCooldownElapsed > flickerCooldown) { FlickerLights(); }

    }

    void FlickerLights()
    {
        // do nothing if flicker is disabled
        if (!flicker) { return; }

        foreach (Light light in lights)
        {
            light.intensity = intensities[lights.IndexOf(light)] * // original intensity
                Random.Range(1, 1 + flickerIntensityMult); // random multiplier;
        }

        flickerCooldownElapsed = 0;

    }

    public void ChangeLightColor(Color color)
    {
        foreach (Light light in lights)
        {
            light.color = color;
        }
    }
}
