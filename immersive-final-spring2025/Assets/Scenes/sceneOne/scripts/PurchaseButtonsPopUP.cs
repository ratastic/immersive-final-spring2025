using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class PurchaseButtonsPopUP : MonoBehaviour
{
    // dictionaries
    public GameObject[] purchaseButtons;
    private Dictionary<string, int> tagButtonIndex;
    public Dictionary<string, string[]> theDialogue;

    // print text stuff
    public TextMeshProUGUI introText;
    public float textPrintSpeed;
    public int linesIndex;
    public string[] currLines;

    public string currTag;

    public bool isTouching = false;
    public bool linesAreDone = false;

    public bool canPrintText;

    void Start()
    {
        currLines = null;
        introText.text = string.Empty;

        tagButtonIndex = new Dictionary<string, int> // like a map!!
        {
            { "ivoryCarvingSensor", 0 },
            { "casketSensor", 1 },
            { "rhinoHornSensor", 2 },
            { "eleTuskSensor", 3 },
            { "turtleShellSensor", 4 }
        };

        theDialogue = new Dictionary<string, string[]>
        {
            { "ivoryCarvingSensor", new string[]{ "Hi! I have this decorative piece that you can display at your museum— it’s a hand-carved ivory knife.", "It will be a great addition to your collection, and as I’ve said before, the money truly helps.", "I was able to buy my son medicine thanks to your purchases."} },
            { "casketSensor", new string[]{"Step right in! Oh... Do I recognize you from somewhere?", "That’s our hand-carved ivory chest, and by “our” I mean my family’s.", "It’s not an heirloom or anything, so we don’t have any reason to keep it.", "The money means more to us anyway."} },
            { "rhinoHornSensor", new string[]{"You again! Have you noticed the bad weather?", "Anyways, that’s a white rhino horn in pristine condition.", "Are you interested? It’s quite rare."} },
            { "eleTuskSensor", new string[]{"Hello...", "I see you’re interested in the Asian elephant tusk. Elephants tusks are known to symbolize strength, longevity, wisdom, and power in many cultures.", "Oh? It’s for a museum display.", "Well… not only will it function as a talisman, it will also attract many customers."}  },
            { "turtleShellSensor", new string[]{"Welcome", "Ah yes! A loggerhead turtle shell painted over with a dark ochre by yours truly.", "These are quite hard to come by!", "It’s yours for the right price, and the money really helps."} }
        };
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (introText.text == currLines[linesIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                introText.text = currLines[linesIndex];
            }
        }

        if (linesAreDone == true && isTouching == true)
        {
            Debug.Log("this is being called");
            if (tagButtonIndex.TryGetValue(currTag, out int index))
            {
                if (index >= 0 && index < purchaseButtons.Length)
                {
                    purchaseButtons[index].SetActive(true);
                }
            }
        }
    }

    void StartDialogue()
    {
        linesIndex = 0;
        StartCoroutine(TypeLine());
        introText.gameObject.SetActive(true);
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currLines[linesIndex].ToCharArray())
        {
            introText.text += c;
            yield return new WaitForSeconds(textPrintSpeed);
        }
    }

    void NextLine()
    {
        if (linesIndex < currLines.Length - 1)
        {
            linesIndex++;
            introText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            introText.gameObject.SetActive(false);
            linesAreDone = true;
            Debug.Log("lines are done printing");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        linesAreDone = false;
        canPrintText = true;
        StopAllCoroutines(); // just in caseeeeee
        introText.gameObject.SetActive(true);

        if (theDialogue.TryGetValue(col.gameObject.tag, out currLines))
        {
            StartDialogue();
        }

        currTag = col.gameObject.tag;
        isTouching = true;
    }

    private void OnTriggerExit(Collider col)
    {
        canPrintText = false;
        StopAllCoroutines();
        introText.gameObject.SetActive(false);
        introText.text = string.Empty;

        if (tagButtonIndex.TryGetValue(col.gameObject.tag, out int index))
        {
            if (index >= 0 && index < purchaseButtons.Length)
            {
                purchaseButtons[index].SetActive(false);
            }
        }

        isTouching = false;
    }
}
