using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOn : MonoBehaviour

{
    void Start()
    {

        //PlayerPrefs.DeleteKey("FogEnabled");

        // Turn fog on/off based on saved player preference
        if (PlayerPrefs.GetInt("FogEnabled", 0) == 1)
            RenderSettings.fog = true;
        else
            RenderSettings.fog = false;
    }

    public void EnableFog()
    {
        RenderSettings.fog = true;
        PlayerPrefs.SetInt("FogEnabled", 1);
        PlayerPrefs.Save(); // Always good to call Save to ensure it's written
    }

    public void DisableFog()
    {
        RenderSettings.fog = false;
        PlayerPrefs.SetInt("FogEnabled", 0);
        PlayerPrefs.Save();
    }
}

