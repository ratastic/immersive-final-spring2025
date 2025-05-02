//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://gamedevbeginner.com/singletons-in-unity-the-right-way/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // singleton syntax i guess ?
    public List<string> purchasedArt = new List<string>();

    // maybe something here?????

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // if there is an instance and the instance is me, don't destroy game object 
        }
        else
        {
            Destroy(gameObject); // i dont think this is necessary but i havent tested it without
        }
    }

    // essentially populates the string with new artworks
    public void PurchaseArt(string artID)
    {
        // purchasedArt keeps track of what is bought; if certain art is bought, add another art id (artwork) to the list  
        if (!purchasedArt.Contains(artID)) 
        {
            purchasedArt.Add(artID);
        }
    }

    // checks if art has been purchased
    public bool HasPurchased(string artID)
    {
        return purchasedArt.Contains(artID);
    }
}
