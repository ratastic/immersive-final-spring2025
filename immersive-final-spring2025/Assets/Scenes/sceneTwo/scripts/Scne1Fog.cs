using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scne1Fog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FogEnabled", 0) == 1)
            RenderSettings.fog = true;
        else
            RenderSettings.fog = false;
    }
}
