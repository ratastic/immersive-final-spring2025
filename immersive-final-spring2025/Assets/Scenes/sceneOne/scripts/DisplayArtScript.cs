using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayArtScript : MonoBehaviour
{
    public string artID;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.HasPurchased(artID)) // when you purchase the art piece 
        {
            GetComponent<MeshRenderer>().enabled = true; // turn on mesh renderer
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false; // i dont think this else statement is necessary tbh
        }

        //maybe dd chnges here?????
    }
}
