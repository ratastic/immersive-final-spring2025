using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButtonsPopUP : MonoBehaviour
{
    public GameObject[] purchaseButtons;

    private Dictionary<string, int> tagButtonIndex;

    //public GameObject ivoryCarveButton;
    //public GameObject casketButton;
    //public GameObject rhinoHornButton;
    //public GameObject eleTuskButton;
    //public GameObject turtleButton;

    // Start is called before the first frame update
    void Start()
    {
        tagButtonIndex = new Dictionary<string, int> // like a map!!
        {
            { "ivoryCarvingSensor", 0 },
            { "casketSensor", 1 },
            { "rhinoHornSensor", 2 },
            { "eleTuskSensor", 3 },
            { "turtleShellSensor", 4 }
        };
    }

    private void OnTriggerEnter(Collider col)
    {
        if (tagButtonIndex.TryGetValue(col.gameObject.tag, out int index))
        {
            if (index >= 0 && index < purchaseButtons.Length)
            {
                purchaseButtons[index].SetActive(true);
            }
        }

        //if (other.gameObject.CompareTag("ivoryCarvingSensor"))
        //{
        //    ivoryCarveButton.SetActive(true);
        //}

        //if (other.gameObject.CompareTag("casketSensor"))
        //{
        //    ivoryCarveButton.SetActive(true);
        //}

        //if (other.gameObject.CompareTag("rhinoHornSensor"))
        //{
        //    ivoryCarveButton.SetActive(true);
        //}

        //if (other.gameObject.CompareTag("eleTuskSensor"))
        //{
        //    ivoryCarveButton.SetActive(true);
        //}

        //if (other.gameObject.CompareTag("turtleShellSensor"))
        //{
        //    ivoryCarveButton.SetActive(true);
        //}
    }

    private void OnTriggerExit(Collider col)
    {
        if (tagButtonIndex.TryGetValue(col.gameObject.tag, out int index))
        {
            if (index >= 0 && index < purchaseButtons.Length)
            {
                purchaseButtons[index].SetActive(false);
            }
        }

        //if (other.gameObject.CompareTag("ivoryCarvingSensor"))
        //{
        //    ivoryCarveButton.SetActive(false);
        //}

        //if (other.gameObject.CompareTag("casketSensor"))
        //{
        //    ivoryCarveButton.SetActive(false);
        //}

        //if (other.gameObject.CompareTag("rhinoHornSensor"))
        //{
        //    ivoryCarveButton.SetActive(false);
        //}

        //if (other.gameObject.CompareTag("eleTuskSensor"))
        //{
        //    ivoryCarveButton.SetActive(false);
        //}

        //if (other.gameObject.CompareTag("turtleShellSensor"))
        //{
        //    ivoryCarveButton.SetActive(false);
        //}
    }
}
