using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fog : MonoBehaviour
{

    public static Fog Instance; // Singleton Instance

    public float fogDensityLow = 0.01f;
    public float fogDensityMedium = 0.05f;
    public float fogDensityHigh = 0.1f;
    public Color fogColorLow = Color.gray;
    public Color fogColorMedium = Color.green;
    public Color fogColorHigh = Color.red;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate FogManagers
        }
    }

    void Start()
    {
        LoadFogSettings();
    }

    // Set Fog Level and Save to PlayerPrefs
    public void SetFogLevel(int level)
    {
        RenderSettings.fog = true;

        switch (level)
        {
            case 1:
                RenderSettings.fogDensity = fogDensityLow;
                RenderSettings.fogColor = fogColorLow;
                break;
            case 2:
                RenderSettings.fogDensity = fogDensityMedium;
                RenderSettings.fogColor = fogColorMedium;
                break;
            case 3:
                RenderSettings.fogDensity = fogDensityHigh;
                RenderSettings.fogColor = fogColorHigh;
                break;
            default:
                RenderSettings.fog = false;
                break;
        }

        // Save fog settings
        PlayerPrefs.SetInt("FogLevel", level);
        PlayerPrefs.Save();
        Debug.Log("Fog level set and saved to PlayerPrefs: " + level);
    }

    // Load Fog Settings from PlayerPrefs
    public void LoadFogSettings()
    {
        int savedFogLevel = PlayerPrefs.GetInt("FogLevel", 0);

        if (savedFogLevel > 0)
        {
            SetFogLevel(savedFogLevel);
            Debug.Log("Fog level loaded from PlayerPrefs: " + savedFogLevel);
        }
        else
        {
            RenderSettings.fog = false; // No fog if no saved value
            Debug.Log("No saved fog level found, fog disabled.");
        }
    }
}
