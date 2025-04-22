using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneObjectActivator : MonoBehaviour
{
    public ActivateObjects activateObjects;
    public GameObject ivoryObjectOne;
    // Start is called before the first frame update
    void Start()
    {
        ivoryObjectOne.SetActive(false);

        if (activateObjects.isActive == true)
        {
            ivoryObjectOne.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
