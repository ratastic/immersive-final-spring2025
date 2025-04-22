using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectActivate : MonoBehaviour
{
    public ActivateObjects activateObjects;

    public void SetActiveOnLoad()
    {
        activateObjects.isActive = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
