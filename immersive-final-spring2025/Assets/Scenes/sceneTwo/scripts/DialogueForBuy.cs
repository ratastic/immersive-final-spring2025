using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueForBuy : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public string[] lines;
    public float textPrintSpeed;
    private int index;

    public bool linesAreDone = false;
    // Start is called before the first frame update
    void Start()
    {
        introText.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (introText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                introText.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            introText.text += c;
            yield return new WaitForSeconds(textPrintSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            introText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            introText.gameObject.SetActive(false);
            linesAreDone = true;
        }
    }
}
