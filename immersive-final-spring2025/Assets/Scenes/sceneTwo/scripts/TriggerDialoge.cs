using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerDialoge : MonoBehaviour
{

    public TextMeshProUGUI textObject;
    public string dialogueText = "Hello, Player!";

    void Start()
    {
        textObject.gameObject.SetActive(false);
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
        if (other.CompareTag("Player"))
        {
            textObject.gameObject.SetActive(true);
            textObject.text = dialogueText;
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
