using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.reddit.com/r/csharp/comments/8rto8t/using_foreachin_statements_with_a_c_dictionary/
public class PurchaseObjButton : MonoBehaviour
{
    [System.Serializable]
    public class ArtButtonPair
    {
        public string artID; // the art names/identifiers ex. ivoryObj01 etc
        public Button purchaseButton; // buy button
    }

    public List<ArtButtonPair> purchaseButtons = new List<ArtButtonPair>(); // pairing art name with the purchase button; we need to make individual purchase button for each object

    void Start()
    {
        foreach (var pair in purchaseButtons)
        {
            string id = pair.artID; // save artID as a new variable -> id 
            pair.purchaseButton.onClick.AddListener(() => PurchaseArt(id)); // when you click, pass the art id into the corresponding button
        }
    }

    public void PurchaseArt(string artID) // this is what happens when you click the button: art is purchased 
    {
        GameManager.Instance.PurchaseArt(artID);
        Debug.Log($"boughhhhhtttt: {artID}"); 
    }
}
