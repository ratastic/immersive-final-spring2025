using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOneToTwo : MonoBehaviour
{
    public GameObject openButton;
    public Animator flyerAnim;
    public GameObject flyerObj;

    public GameObject marketButton;
    public GameObject noMarketButton;

    public bool buttonOverlap = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        openButton.SetActive(false);
        flyerObj.SetActive(false);

        marketButton.SetActive(false);
        noMarketButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonOverlap == true)
        {
            openButton.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("openMailbox"))
        {
            openButton.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("openMailbox"))
        {
            openButton.SetActive(false);
        }
    }

    public void OpenMailbox()
    {
        flyerObj.SetActive(true);
        flyerAnim.SetBool("flyerAnimPlay", true);

        openButton.SetActive(false);
        marketButton.SetActive(true);
        noMarketButton.SetActive(true);

        buttonOverlap = true;
    }

    public void GoToMarket()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void NoGoToMarket()
    {
        flyerObj.SetActive(false);
        marketButton.SetActive(false);
        noMarketButton.SetActive(false);

        buttonOverlap = false;
    }
}
