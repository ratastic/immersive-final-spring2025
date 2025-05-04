using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnlocked : MonoBehaviour
{
    public List<string> alreadyBoughtArtIDs; // things that need to be bought before new items can be bought
    public bool purchaseRequirements = true; // if object meets the purchase requirements
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string boughtID in alreadyBoughtArtIDs)
        {
            if (!GameManager.Instance.HasPurchased(boughtID))
            {
                purchaseRequirements = false;
                break;
            }
        }

        gameObject.SetActive(purchaseRequirements);
    }
}
