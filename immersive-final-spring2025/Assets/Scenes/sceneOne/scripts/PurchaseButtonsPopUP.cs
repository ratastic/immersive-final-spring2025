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
            { "ivoryCarvingSensor", new string[]{ } },
            { "casketSensor", new string[]{ } },
            { "rhinoHornSensor", new string[]{ } },
            { "eleTuskSensor", new string[]{ }  },
            { "turtleShellSensor", new string[]{"VEGAAAA", "BENJAMINN", "JAFRI", "SOUFERIAN"} }
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
