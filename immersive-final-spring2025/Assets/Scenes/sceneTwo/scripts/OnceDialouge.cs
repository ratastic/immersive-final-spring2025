using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnceDialouge : MonoBehaviour
{
    public TextMeshProUGUI textObject; 
    public string dialogueText = "!";

    private bool hasTriggered; 

    void Start()
    {
        textObject.gameObject.SetActive(false); 
        hasTriggered = PlayerPrefs.GetInt("HasTriggered", 0) == 1; // Check if the dialogue has been triggered
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            textObject.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            textObject.gameObject.SetActive(true); 
            textObject.text = dialogueText;
            hasTriggered = true; 
            PlayerPrefs.SetInt("HasTriggered", 1); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textObject.gameObject.SetActive(false); 
        }
    }
}